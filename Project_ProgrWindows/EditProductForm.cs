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

        private MainForm parent;
        private ListViewItem item;

        public EditProductForm(MainForm parent, ListViewItem item)
        {
            this.parent = parent;
            this.item = item;
            InitializeComponent();
            comboBoxCategory.SelectedIndex = 0;
            populateCategoriesCombobox();
            populateForm();
        }

        public EditProductForm(MainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            comboBoxCategory.SelectedIndex = 0;
            populateCategoriesCombobox();
            this.label1.Text = "Adauga produs";
        }

        private void populateForm()
        {
            textBoxId.Text = item.SubItems[0].Text;
            textBoxNume.Text = item.SubItems[1].Text;
            textBoxSku.Text = item.SubItems[3].Text;
            textBoxPrice.Text = item.SubItems[2].Text;
            textBoxStock.Text = item.SubItems[6].Text;
            comboBoxCategory.Text = item.SubItems[4].Text;
        }

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
            if (product.save(formData))
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
