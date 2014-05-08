using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ProgrWindows
{
    public partial class btnUserControlCheckbox : UserControl
    {
        /// <summary>
        /// Declare delegate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void click(object sender, EventArgs e);

        /// <summary>
        /// Declare event.
        /// </summary>
        public event click tryToSave;

        /// <summary>
        /// Constructor.
        /// </summary>
        public btnUserControlCheckbox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check if the condition is met. (ie. the checkbox is checked)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkboxVerify.Checked)
            {
                if (tryToSave != null)
                {
                    tryToSave(sender, e);
                }

            }
            else
            {
                MessageBox.Show("Bifati ca ati verificat datele!", "Atentie");
            }
        }
    }
}
