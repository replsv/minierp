namespace Project_ProgrWindows
{
    partial class EditProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelNume = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.labelSku = new System.Windows.Forms.Label();
            this.textBoxSku = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUserControlCheckbox1 = new Project_ProgrWindows.btnUserControlCheckbox();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 77);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(120, 70);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(188, 20);
            this.textBoxId.TabIndex = 1;
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(12, 107);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(35, 13);
            this.labelNume.TabIndex = 2;
            this.labelNume.Text = "Nume";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(120, 100);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(188, 20);
            this.textBoxNume.TabIndex = 3;
            // 
            // labelSku
            // 
            this.labelSku.AutoSize = true;
            this.labelSku.Location = new System.Drawing.Point(12, 136);
            this.labelSku.Name = "labelSku";
            this.labelSku.Size = new System.Drawing.Size(91, 13);
            this.labelSku.TabIndex = 4;
            this.labelSku.Text = "SKU (cod produs)";
            // 
            // textBoxSku
            // 
            this.textBoxSku.Location = new System.Drawing.Point(120, 129);
            this.textBoxSku.Name = "textBoxSku";
            this.textBoxSku.Size = new System.Drawing.Size(188, 20);
            this.textBoxSku.TabIndex = 5;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(120, 155);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(188, 20);
            this.textBoxPrice.TabIndex = 7;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(12, 162);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(26, 13);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Pret";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modificare produs";
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(120, 181);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(188, 20);
            this.textBoxStock.TabIndex = 10;
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(12, 184);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(29, 13);
            this.labelStock.TabIndex = 9;
            this.labelStock.Text = "Stoc";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(12, 214);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(52, 13);
            this.labelCategory.TabIndex = 11;
            this.labelCategory.Text = "Categorie";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Cursor = System.Windows.Forms.Cursors.Cross;
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "- Alegeti o categorie -"});
            this.comboBoxCategory.Location = new System.Drawing.Point(120, 206);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(188, 21);
            this.comboBoxCategory.TabIndex = 12;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(233, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Anulare";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Location = new System.Drawing.Point(123, 357);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(75, 23);
            this.btnDuplicate.TabIndex = 15;
            this.btnDuplicate.Text = "Duplicare";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(123, 387);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnUserControlCheckbox1
            // 
            this.btnUserControlCheckbox1.Location = new System.Drawing.Point(4, 333);
            this.btnUserControlCheckbox1.Name = "btnUserControlCheckbox1";
            this.btnUserControlCheckbox1.Size = new System.Drawing.Size(113, 51);
            this.btnUserControlCheckbox1.TabIndex = 17;
            this.btnUserControlCheckbox1.tryToSave += new Project_ProgrWindows.btnUserControlCheckbox.click(this.btnUserControlCheckbox1_tryToSave);
            // 
            // EditProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 426);
            this.Controls.Add(this.btnUserControlCheckbox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxSku);
            this.Controls.Add(this.labelSku);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProductForm";
            this.ShowInTaskbar = false;
            this.Text = "Modificare produs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Label labelSku;
        private System.Windows.Forms.TextBox textBoxSku;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Button btnExport;
        private btnUserControlCheckbox btnUserControlCheckbox1;
    }
}