using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project_ProgrWindows;
using System.IO;
using System.Data;

namespace Project_ProgrWindows
{
    class Database
    {
        private static MySqlConnection instance;

        private static MySqlConnection connect()
        {
            MySqlConnection instance = null;
            string connection_string = @"server=" + Constants.DATABASE_HOST +
                    ";userid=" + Constants.DATABASE_USER +
                    ";password=" + Constants.DATABASE_PASSWORD +
                    ";database=" + Constants.DATABASE_NAME;
            instance = null;
            try
            {
                instance = new MySqlConnection(connection_string);
                instance.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString(), "Eroare");
            }

            return instance;
        }

        public static MySqlConnection getInstance()
        {
            if (instance == null)
            {
                instance = connect();
            }
            return instance;
        }

        public static void closeConnection()
        {
            if (instance != null)
            {
                instance.Close();
                instance = null;
            }
        }

    }

    class Utils
    {

        public static void install()
        {
            try
            {
                MySqlCommand stmt = new MySqlCommand();
                stmt.Connection = Database.getInstance();
                stmt.CommandText = File.ReadAllText("schema.sql");
                stmt.ExecuteNonQuery();
                MessageBox.Show("Baza de date a fost populata!");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString(), "Eroare la instalare");
            }
        }

        public static void uninstall()
        {

        }

        public static bool isInstalled()
        {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand stmt = new MySqlCommand();

                stmt.Connection = Database.getInstance();
                stmt.CommandText = @"SELECT * FROM information_schema.tables
                    WHERE table_schema = '" + Constants.DATABASE_NAME + @"' 
                    AND table_name = 'products'
                    LIMIT 1;";
                reader = stmt.ExecuteReader();
                while (reader.Read())
                {
                    return false;
                }
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }

    abstract class Entity
    {
        protected String main_table = null;

        protected String main_field = null;

        protected MySqlConnection connection = null;

        protected List<String> fields = new List<String>();

        protected List<KeyValuePair<String, String>> currentData = new List<KeyValuePair<String, String>>();

        protected Entity()
        {
            this.connection = Database.getInstance();
        }

        protected MySqlConnection getConnection()
        {
            return this.connection;
        }

        public void load(string value, string field = null)
        {
            if (field == null)
            {
                field = this.main_field;
            }

            if (field == null)
            {
                throw new Exception("No field clause...");
            }

            DataSet result = new DataSet("result");

            try
            {
                String entity_fields = string.Join(", ", this.fields);
                String stmt = @"SELECT " + entity_fields + " FROM " + this.main_table + " WHERE `" + field + "` = '" + 
                    MySql.Data.MySqlClient.MySqlHelper.EscapeString(value) + "' LIMIT 1";
                Console.WriteLine(stmt);
                MySqlCommand command = new MySqlCommand(stmt, this.getConnection());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int i = 0;
                    foreach (string f in fields)
                    {
                        this.currentData.Add(new KeyValuePair<String, String>(f, reader.GetValue(i).ToString()));
                        i++;
                    }
                }
                reader.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("A intervenit o eroare!");
            }
        }

        public List<KeyValuePair<String, String>> getData()
        {
            return this.currentData;
        }

        public bool isNew()
        {
            foreach (KeyValuePair<string, string> k in this.currentData)
            {
                if (k.Key == this.main_field && k.Value.ToString() != "")
                {
                    return false;
                }
            }

            return true;
        }

        public bool save(List<KeyValuePair<String,String>> data)
        {
            string statement = "INSERT INTO ";
            string where = "1";
            List<string> update = new List<string>();
            foreach (KeyValuePair<string, string> k in data)
            {
                if(k.Key == this.main_field && k.Value.ToString() != "")
                {
                    statement = "UPDATE ";
                    where = @main_field + " = '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(k.Value) + "'";
                    continue;
                }
                update.Add(@k.Key + " = '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(k.Value) + "'");
            }

            statement += this.main_table + " SET ";
            statement += @String.Join(", ", update.ToArray()).ToString() + " WHERE " + where;

            try
            {
                MySqlCommand stmt = new MySqlCommand();
                stmt.Connection = this.getConnection();
                stmt.CommandText = statement;
                stmt.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }

        public bool delete()
        {
            if (this.isNew())
            {
                throw new Exception("Nu exista o instanta a produsului!");
            }

            int id = 0;

            foreach (KeyValuePair<string, string> k in this.currentData)
            {
                if (k.Key == this.main_field && k.Value.ToString() != "")
                {
                    id = int.Parse(k.Value);
                }
            }

            if (id == 0)
            {
                return false;
            }

            string statement = @"DELETE FROM " + this.main_table + " WHERE " + this.main_field + " = " + id;

            try
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = statement;
                command.Connection = this.getConnection();
                command.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
            }

            return true;
        }

        public DataTable collection(string fields = "*", string joinClause = null, string whereClause = null, int limit = 100, int offset = 0, string orderbyClause = null)
        {
            string select = @"SELECT " + fields + " FROM " + this.main_table;
            DataTable dataTable = null; 
            try
            {                
                // Join
                if (joinClause != null)
                {
                    select += joinClause;
                }
                // Where
                if(whereClause != null)
                {
                    select += whereClause;
                }

                // Order by
                if (orderbyClause != null)
                {
                    select += " ORDER BY " + orderbyClause;
                }
                else
                {
                    select += " ORDER BY " + this.main_field;
                }

                // Limit + limit's offset
                if (limit > 0)
                {
                    select += " LIMIT " + limit.ToString();
                    if (offset > 0)
                    {
                        select += ", " + offset.ToString();
                    }
                }

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(select, this.getConnection());
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "results");
                dataTable = dataSet.Tables["results"];                
            } catch(MySqlException e)
            {
                MessageBox.Show(e.ToString(), "Eroare");                
            }

            return dataTable;
        }
    }

    class Category : Entity
    {
        public Category()
        {
            this.main_table = "categories";
            this.main_field = "category_id";
        }
    }

    class Product : Entity 
    {
        public Product()
        {
            this.main_table = "products";
            this.main_field = "product_id";

            /** Add fields */
            this.fields.Add("product_id");
            this.fields.Add("name");
            this.fields.Add("sku");
            this.fields.Add("price");
            this.fields.Add("category_id");
            this.fields.Add("status");
            this.fields.Add("stock_qty");
        }

        public DataTable collection(string whereClause = null, int limit = 100, int offset = 0, string orderbyClause = null)
        {
            String fields = "products.*, categories.name as category_name," +
                "case products.status " +
                    "WHEN 1 then 'Stoc suficient' " +
                    "WHEN 2 then 'Stoc redus' " +
                    "WHEN 3 then 'Stoc furnizor' " +
                    "WHEN 4 then 'Fara stoc' " +
                " end " +
                " AS `status_label` ";
            String joinTable = " INNER JOIN `categories` ON categories.category_id = products.category_id";

            return base.collection(fields, joinTable, whereClause, limit, offset, orderbyClause);
        }
    }
}
