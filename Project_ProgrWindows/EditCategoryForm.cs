using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ProgrWindows
{
    public partial class EditCategoryForm : Form
    {
        private MainForm parent;
        private ListViewItem item;

        public EditCategoryForm()
        {
            InitializeComponent();
        }

        public EditCategoryForm(MainForm parent, ListViewItem item)
        {
            this.parent = parent;
            this.item = item;
            InitializeComponent();
            populateForm();
        }

        public EditCategoryForm(MainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.label1.Text = "Adauga categorie";
        }

        private void populateForm()
        {
            this.textBoxId.Text = item.SubItems[0].Text;
            this.textBoxNume.Text = item.SubItems[1].Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<String, String>> formData = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>("category_id", textBoxId.Text),
                new KeyValuePair<String, String>("name", textBoxNume.Text),
            };

            Category category = new Category();

            if (textBoxId.Text != "")
            {
                Category compare = new Category();
                compare.load(textBoxId.Text);
                if (category.CompareTo(compare) == 1)
                {
                    MessageBox.Show("Trebuie sa faceti cel putin o modificare!", "Atentie");
                    return;
                }
            }

            if (category.save())
            {
                MessageBox.Show("Categoria a fost salvata!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("A intervenit o eroare!");
            }

        }
    }
}
