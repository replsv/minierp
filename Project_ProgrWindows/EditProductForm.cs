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
    public partial class EditProductForm : Form
    {
        /// <summary>
        /// Parent.
        /// </summary>
        private MainForm parent;

        /// <summary>
        /// List view item.
        /// </summary>
        private ListViewItem item;

        /// <summary>
        /// Constructor.
        /// Populate the current textboxes with the product's data.
        /// Append the categories in a selectbox.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="item"></param>
        public EditProductForm(MainForm parent, ListViewItem item)
        {
            this.parent = parent;
            this.item = item;
            InitializeComponent();
            comboBoxCategory.SelectedIndex = 0;
            populateCategoriesCombobox();
            populateForm();
        }

        /// <summary>
        /// Constructor.
        /// Used when adding a new product.
        /// Few elements are altered. (ie. the title of the form + hide the duplicate button) 
        /// </summary>
        /// <param name="parent"></param>
        public EditProductForm(MainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            comboBoxCategory.SelectedIndex = 0;
            populateCategoriesCombobox();
            this.label1.Text = "Adaugare produs";
            this.Text = "Adaugare produs";
            this.btnDuplicate.Visible = false;
            this.btnExport.Visible = false;
        }

        /// <summary>
        /// Populate form with the current product's values.
        /// </summary>
        private void populateForm()
        {
            textBoxId.Text = item.SubItems[0].Text;
            textBoxNume.Text = item.SubItems[1].Text;
            textBoxSku.Text = item.SubItems[3].Text;
            textBoxPrice.Text = item.SubItems[2].Text;
            textBoxStock.Text = item.SubItems[6].Text;
            comboBoxCategory.Text = item.SubItems[4].Text;
        }

        /// <summary>
        /// Populate category combobox by loading the values from the database.
        /// Also append the current selection in this way.
        /// </summary>
        private void populateCategoriesCombobox()
        {
            Category categories = new Category();
            DataTable results = categories.collection();
            if (results != null)
            {
                foreach (DataRow row in results.Rows)
                {
                    comboBoxCategory.Items.Add(new { category_id = row["category_id"].ToString(), name = row["name"].ToString()});
                }
                comboBoxCategory.ValueMember = "category_id";
                comboBoxCategory.DisplayMember = "name";
            }

        }

        /// <summary>
        /// Close window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        /// <summary>
        /// Duplicate product.
        /// Implement iCloneable interface functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            string productId = textBoxId.Text;
            Product oldProduct = new Product();
            oldProduct.load(productId);
            Product cloned = (Product) oldProduct.Clone();
            var sku = cloned.getData().First(item => item.Key == "sku");
            cloned.setData(cloned.getData());
            if (cloned.save())
            {
                MessageBox.Show(@"Produsul a fost duplicat cu codul SKU " + sku.Value.ToString(), "Succes!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("A intervenit o eroare!", "Eroare");
            }
        }

        /// <summary>
        /// Export product data into a txt file. Usage of streamWriter from System.IO.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = textBoxId.Text;
                Product product = new Product();
                product.load(productId);
                string exportPath = @parent.exportPath + "export-produs-" + product.getData().Single(item => item.Key == "sku").Value.ToString() + ".txt";
                System.IO.StreamWriter write = new System.IO.StreamWriter(exportPath);
                write.WriteLine(product.ToString());
                write.Close();
                MessageBox.Show(@"Fisier export: " + exportPath);
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare!", "Eroare");
            }            
        }

        /// <summary>
        /// Trigger save product.
        /// We're using a custom UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserControlCheckbox1_tryToSave(object sender, EventArgs e)
        {
            dynamic selectedCategory = comboBoxCategory.SelectedItem;
            List<KeyValuePair<String, String>> formData = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>("product_id", textBoxId.Text),
                new KeyValuePair<String, String>("name", textBoxNume.Text),
                new KeyValuePair<String, String>("price", textBoxPrice.Text),
                new KeyValuePair<String, String>("sku", textBoxSku.Text),
                new KeyValuePair<String, String>("stock_qty", textBoxStock.Text),
                new KeyValuePair<String, String>("category_id", selectedCategory.category_id.ToString()),
            };

            Product product = new Product();
            product.setData(formData);

            if (textBoxId.Text != "")
            {
                Product compare = new Product();
                compare.load(textBoxId.Text);
                if (product.CompareTo(compare) == 1)
                {
                    MessageBox.Show("Trebuie sa faceti cel putin o modificare!", "Atentie");
                    return;
                }
            }

            if (product.save())
            {
                MessageBox.Show("Produsul a fost salvat!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("A intervenit o eroare!");
            }
        }
    }
}
