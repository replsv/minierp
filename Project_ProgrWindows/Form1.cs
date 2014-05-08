using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_ProgrWindows;

namespace Project_ProgrWindows
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Define the export path.
        /// </summary>
        private static string _exportPath = System.Configuration.ConfigurationManager.AppSettings["export_path"];

        /// <summary>
        /// Public getter.
        /// </summary>
        public string exportPath { get { return _exportPath; } }

        /// <summary>
        /// Constructor.
        /// Initialize component.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show products.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.hideAllData();
            this.listView2_showData();
            listViewProducts.Visible = true;
        }

        /// <summary>
        /// Import products.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();                
                openFile.InitialDirectory = "C:\\";
                openFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
            catch(Exception)
            {

            }
        }

        /// <summary>
        /// Show the "About" info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Mini ERP - Aplicatie management produse\n" +
                "Autor: Cioropina Gabriel\n" + 
                "Proiect C#\n" +
                "ASE, CSIE, Bucuresti\n" +
                "Versiune: " + Constants.APP_VERSION.ToString() + "\n" +
                "2014", "Despre");
        }

        /// <summary>
        /// Prompt a confirmation upon exiting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sunteti sigur ca vreti sa iesiti?", "Iesire", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        /// ShowData event.
        /// </summary>
        private void listView2_showData()
        {
            this.labelListProducts.Visible = true;
            this.refreshProductsListView();
        }

        /// <summary>
        /// Hide all data. Needed when changing views between products and categories.
        /// </summary>
        private void hideAllData()
        {
            this.labelListProducts.Visible = false;
            this.labelListCategories.Visible = false;
            this.listViewProducts.Visible = false;
            this.listViewCategories.Visible = false;
        }

        /// <summary>
        /// Disable resize of columns in listview products.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewProducts.Columns[e.ColumnIndex].Width;
        }

        /// <summary>
        /// Install db.
        /// Import the sql file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instaleazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utils.isInstalled() == false)
            {
                if (MessageBox.Show("Baza de date este deja instalata. Vreti sa reinstalati?", "Atentie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Utils.install();
                }
            }
            else
            {
                Utils.install();
            }
        }

        /// <summary>
        /// Export products into xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Product products = new Product();
            DataTable results = products.collection();
            if (results == null || results.Rows.Count == 0)
            {
                MessageBox.Show("Nu exista rezultate ce pot fi exportate!", "Eroare");
            }
            else
            {
                DataSet dataSet = results.DataSet;
                String output = @exportPath + "export-produse-minierp-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xml";
                try
                {
                    dataSet.WriteXml(output);
                    MessageBox.Show(@"Fisier export: " + output, "Succes!");
                }
                catch (Exception)
                {
                    MessageBox.Show("A intervenit o eroare!", "Eroare");
                }
            }
            
        }

        /// <summary>
        /// Trigger product edit form on doubleclick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewProducts_DoubleClick(object sender, EventArgs e)
        {
            if (listViewProducts.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listViewProducts.SelectedItems;
                ListViewItem lvItem = items[0];
                EditProductForm editForm = new EditProductForm(this, lvItem);
                editForm.ShowDialog();
                this.refreshProductsListView();
            }
        }

        /// <summary>
        /// Click event for edit product from contextual toolstrip menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewProducts_DoubleClick(sender, e);
        }

        /// <summary>
        /// Click event for delete product from contextual toolstrip menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected = listViewProducts.SelectedItems.Count;
            if (selected == 0)
            {
                return;
            }
            if (MessageBox.Show("Sunteti sigur ca vreti sa stergeti acest produs?", "Atentie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = listViewProducts.SelectedItems[0].Text;
                Product product = new Product();
                product.load(id);

                if (product.isNew())
                {
                    MessageBox.Show("Nu exista produsul cu id-ul " + id);
                }
                else
                {
                    if (product.delete())
                    {
                        MessageBox.Show("Produsul cu id-ul " + id + " a fost sters");
                        this.refreshProductsListView();
                    }
                    else
                    {
                        MessageBox.Show("A intervenit o eroare.", "Eroare!");
                    }
                }
            }
        }

        /// <summary>
        /// Refresh product list view
        /// Reload all data from database.
        /// </summary>
        private void refreshProductsListView()
        {
            listViewProducts.Items.Clear();
            Product products = new Product();
            DataTable results = products.collection();
            String[] fields = new[] { "name", "price", "sku", "category_name", "status_label", "stock_qty" };
            if (results != null)
            {
                foreach (DataRow row in results.Rows)
                {
                    ListViewItem item = new ListViewItem(new[] { row["product_id"].ToString() });

                    foreach (String rowName in fields)
                    {
                        item.SubItems.Add(row[rowName].ToString());
                    }

                    listViewProducts.Items.Add(item);
                }
            }
            else
            {
                listViewProducts.Items.Add(new ListViewItem(new[] { "Nu exista rezultate" }));
            }

            listViewProducts.View = View.Details;
        }

        /// <summary>
        /// Add new product.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adaugaProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProductForm editForm = new EditProductForm(this);
            editForm.ShowDialog();
            this.refreshProductsListView();
        }

        /// <summary>
        /// List categories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonListCategories_Click(object sender, EventArgs e)
        {
            this.hideAllData();
            this.labelListCategories.Visible = true;
            this.listViewCategories.Visible = true;
            this.refreshCategoriesListView();
        }

        /// <summary>
        /// Refresh category list view.
        /// </summary>
        private void refreshCategoriesListView()
        {
            listViewCategories.Items.Clear();
            Category products = new Category();
            DataTable results = products.collection();
            String[] fields = new[] { "name" };
            if (results != null)
            {
                foreach (DataRow row in results.Rows)
                {
                    ListViewItem item = new ListViewItem(new[] { row["category_id"].ToString() });

                    foreach (String rowName in fields)
                    {
                        item.SubItems.Add(row[rowName].ToString());
                    }

                    listViewCategories.Items.Add(item);
                }
            }
            else
            {
                listViewCategories.Items.Add(new ListViewItem(new[] { "Nu exista rezultate" }));
            }

            listViewCategories.View = View.Details;
        }

        /// <summary>
        /// Trigger edit form for categories on doubleclick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewCategories_DoubleClick(object sender, EventArgs e)
        {
            if (listViewCategories.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listViewCategories.SelectedItems;
                ListViewItem lvItem = items[0];
                EditCategoryForm editForm = new EditCategoryForm(this, lvItem);
                editForm.ShowDialog();
                this.refreshCategoriesListView();
            }
        }

        /// <summary>
        /// Add category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adaugaCategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategoryForm editForm = new EditCategoryForm(this);
            editForm.ShowDialog();
            this.refreshProductsListView();
        }

        /// <summary>
        /// Show statistics chart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statisticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatsChart form = new StatsChart();
            form.Show();
        }
    }
}
