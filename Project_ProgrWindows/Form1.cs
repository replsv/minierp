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
        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * Show products.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.hideAllData();
            this.listView2_showData();
            listViewProducts.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();                
                openFile.InitialDirectory = "C:\\";
                openFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Fisier: " + openFile.FileName);
                }
            }
            catch(Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fisierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        /**
         * Show the 'About' window.
         */
        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mini ERP - Aplicatie management produse\nAutor: Cioropina Gabriel\nProiect C#\nASE, CSIE, Bucuresti\nVersiune: " + Constants.APP_VERSION.ToString() + "\n2014", "Despre");
        }

        /**
         * Prompt a confirmation upon exiting.
         */
        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sunteti sigur ca vreti sa iesiti?", "Iesire", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        /**
         * ShowData event.
         */
        private void listView2_showData()
        {
            this.refreshProductsListView();
        }

        /**
         * Hide all data. Needed when changing views.
         */
        private void hideAllData()
        {
            listViewProducts.Visible = false;
        }

        /**
         * Disable resize of columns in listview products.
         */
        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewProducts.Columns[e.ColumnIndex].Width;
        }

        /**
         * Install db.
         */
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

        /**
         * Export products into xml file.
         */
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
                String output = @"C:\\export-produse-minierp-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xml";
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

        /**
         * Trigger edit form on doubleclick event.
         */
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

        /**
         * Click event for edit product from contextual toolstrip menu.
         */
        private void editazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewProducts_DoubleClick(sender, e);
        }

        /**
         * Click event for delete product from contextual toolstrip menu.
         */
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        /**
         * Refresh product list view
         */
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
    }
}
