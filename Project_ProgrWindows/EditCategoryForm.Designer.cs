namespace Project_ProgrWindows
{
    partial class EditCategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.labelNume = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Modificare categorie";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(121, 99);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(188, 20);
            this.textBoxNume.TabIndex = 13;
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(13, 106);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(35, 13);
            this.labelNume.TabIndex = 12;
            this.labelNume.Text = "Nume";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(121, 69);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(188, 20);
            this.textBoxId.TabIndex = 11;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(13, 76);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 10;
            this.labelId.Text = "ID";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(14, 149);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Salvare";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(234, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Anulare";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // EditCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 194);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Name = "EditCategoryForm";
            this.Text = "Modificare categorie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}