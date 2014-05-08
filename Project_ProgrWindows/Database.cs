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
    /// <summary>
    /// Database class
    /// </summary>
    class Database
    {
        /// <summary>
        /// Mysql connection instance. Acts like a singleton.
        /// </summary>
        private static MySqlConnection instance;

        /// <summary>
        /// Connect to database and save connection details in the instance static var.
        /// </summary>
        /// <returns></returns>
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
            catch (MySqlException)
            {
                //MessageBox.Show(e.ToString(), "Eroare");
                MessageBox.Show("Conectarea la baza de date a esuat.", "Eroare");
            }

            return instance;
        }

        /// <summary>
        /// Get instance singleton.
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getInstance()
        {
            if (instance == null)
            {
                instance = connect();
            }
            return instance;
        }

        /// <summary>
        /// Close connection if needed.
        /// </summary>
        public static void closeConnection()
        {
            if (instance != null)
            {
                instance.Close();
                instance = null;
            }
        }

    }

    /// <summary>
    /// Implement utils over database.
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Import database schema.
        /// </summary>
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

        /// <summary>
        /// Uninstall current database i.e delete all tables.
        /// </summary>
        public static void uninstall()
        {

        }

        /// <summary>
        /// Check if the database is installed.
        /// </summary>
        /// <returns></returns>
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

    abstract class Entity : IComparable<Entity>
    {
        /// <summary>
        /// Entity's table.
        /// </summary>
        protected String main_table = null;

        /// <summary>
        /// Entity's primary key field.
        /// </summary>
        protected String main_field = null;

        /// <summary>
        /// Database current instance.
        /// </summary>
        protected MySqlConnection connection { get; set; }

        /// <summary>
        /// Entity's mapped database fields.
        /// </summary>
        protected List<String> fields = new List<String>();

        /// <summary>
        /// Current data.
        /// </summary>
        protected List<KeyValuePair<String, String>> currentData = new List<KeyValuePair<String, String>>();

        /// <summary>
        /// Constructor. Set connection instance.
        /// </summary>
        protected Entity()
        {
            this.connection = Database.getInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection getConnection()
        {
            return this.connection;
        }

        /// <summary>
        /// Implement iComparable interface.
        /// Compare each field to the other one's value.
        /// Usually gets used before saving an existent object.
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public int CompareTo(Entity compare)
        {
            foreach (string f in fields)
            {
                if (f == this.main_field)
                {
                    continue;
                }
                var current = this.currentData.First(item => item.Key.Equals(f)).Value;
                var compared = compare.getData().First(item => item.Key.Equals(f)).Value;

                if (current != compared)
                {
                    return 0;
                }
            }

            return 1;
        }

        /// <summary>
        /// Load object in currentData key-value list.
        /// </summary>
        /// <param name="value">value to be matched</param>
        /// <param name="field">field to be matched</param>
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

        /// <summary>
        /// Get current instance data.
        /// </summary>
        /// <returns>List<KeyValuePair<String, String>></returns>
        public List<KeyValuePair<String, String>> getData()
        {
            return this.currentData;
        }

        /// <summary>
        /// Check if object is new. We check both the currentData and the value of the
        /// primary field in currentData if the list is not null.
        /// </summary>
        /// <returns>bool</returns>
        public bool isNew()
        {
            if (this.currentData == null)
            {
                return true;
            }

            foreach (KeyValuePair<string, string> k in this.currentData)
            {
                if (k.Key == this.main_field && k.Value.ToString() != "")
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Set data.
        /// </summary>
        /// <param name="data"></param>
        public virtual void setData(List<KeyValuePair<String,String>> data)
        {
            this.currentData = data;
        }

        /// <summary>
        /// Persist data in the object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool save()
        {
            string statement = "INSERT INTO ";
            string where = "";
            List<string> update = new List<string>();
            foreach (KeyValuePair<string, string> k in this.currentData)
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
            statement += @String.Join(", ", update.ToArray()).ToString();

            if (where != "")
            {
                statement += @" WHERE " + where;
            }
            MessageBox.Show(statement);
            try
            {
                MySqlCommand stmt = new MySqlCommand();
                stmt.Connection = this.getConnection();
                stmt.CommandText = statement;
                stmt.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete current entity from the database.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get a collection of elements with the current type.
        /// </summary>
        /// <param name="fields">fields to select</param>
        /// <param name="joinClause">join clause</param>
        /// <param name="whereClause">where clause</param>
        /// <param name="limit">no of entries to return</param>
        /// <param name="offset">offset</param>
        /// <param name="orderbyClause">order by clause</param>
        /// <returns>DataTable</returns>
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

    /// <summary>
    /// Category entity object.
    /// </summary>
    class Category : Entity
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public Category()
        {
            this.main_table = "categories";
            this.main_field = "category_id";

            /** Add fields */
            this.fields.Add("category_id");
            this.fields.Add("name");
        }
    }

    /// <summary>
    /// Product entity object.
    /// </summary>
    class Product : Entity, ICloneable
    {

        const int STOCK_STATUS_OOS = 4;
        const int STOCK_STATUS_SUPPLIER = 3;
        const int STOCK_STATUS_REDUCED = 2;
        const int STOCK_STATUS_AVAILABLE = 1;

        /// <summary>
        /// Public constructor.
        /// </summary>
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

        /// <summary>
        /// Implement ICloneable functionality.
        /// Use of member wise clone to clone the current object.
        /// Reset few fields such as the id and the sku.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Product duplicate = (Product) this.MemberwiseClone();

            /** Remove product_id */
            duplicate.currentData.Remove(duplicate.currentData.First(item => item.Key.Equals(this.main_field)));
            duplicate.currentData.Add(new KeyValuePair<string, string>(this.main_field, ""));

            /** Remove stock status */
            duplicate.currentData.Remove(duplicate.currentData.First(item => item.Key.Equals("status")));

            /** Change SKU */
            var sku = duplicate.currentData.First(item => item.Key.Equals("sku"));
            duplicate.currentData.Remove(sku);
            duplicate.currentData.Add(new KeyValuePair<string, string>("sku", sku.Value + "-duplicat"));

            return duplicate;
        }

        /// <summary>
        /// Override.
        /// Join the category entity for this collection.
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="orderbyClause"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override.
        /// Add the product's status depending on the stock_qty available.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        override public void setData(List<KeyValuePair<String, String>> data)
        {
            int i_stock_qty;
            var stock_qty = data.Single(item => item.Key == "stock_qty").Value.ToString();
            try
            {
                i_stock_qty = Convert.ToInt32(stock_qty);
            } catch(Exception)
            {
                i_stock_qty = 0;
            }

            data.Add(new KeyValuePair<String, String>("status", this._getStockStatus(i_stock_qty).ToString()));

            base.setData(data);
        }

        /// <summary>
        /// Get stock status.
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private int _getStockStatus(int stock)
        {
            int status = 0;

            if (stock == 0)
            {
                status = STOCK_STATUS_OOS;
            }
            else if (stock < 5)
            {
                status = STOCK_STATUS_SUPPLIER;
            }
            else if (stock < 10)
            {
                status = STOCK_STATUS_REDUCED;
            }
            else
            {
                status = STOCK_STATUS_AVAILABLE;
            }

            return status;
        }
    }
}
