using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_ProgrWindows
{
    public partial class StatsChart : Form
    {
        /// <summary>
        /// Initialize component and create also the series for the chart.
        /// </summary>
        public StatsChart()
        {
            InitializeComponent();

            List<KeyValuePair<String, int>> data = this.getData();

            if (data.Count == 0)
            {
                MessageBox.Show("Nu exista date!", "Eroare");
                this.Dispose();
            }
            else
            {
                int i = 0;
                foreach (KeyValuePair<String, int> item in data)
                {
                    this.chartStatistics.Series.Add(item.Key.ToString());
                    this.chartStatistics.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                    this.chartStatistics.Series[i].Points.AddY(item.Value);
                }
                chartStatistics.DataBind();
            }
        }

        /// <summary>
        /// Dispose the current form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Get data. (a list with category name and # of products)
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<String, int>> getData()
        {
            List<KeyValuePair<String, int>> data = new List<KeyValuePair<String, int>>();

            try
            {
                MySqlConnection connection = Database.getInstance();
                String stmt = @"SELECT categories.name, COUNT(*) as products_count " +
                    " FROM products INNER JOIN categories ON products.category_id = categories.category_id " +
                    " GROUP BY (products.category_id);";
                MySqlCommand command = new MySqlCommand(stmt, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new KeyValuePair<String, int>(reader.GetValue(0).ToString(), Convert.ToInt32(reader.GetValue(1).ToString())));
                }
                reader.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("A intervenit o eroare!");
            }

            return data;
        }
    }
}
