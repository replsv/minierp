namespace Project_ProgrWindows
{
    partial class btnUserControlCheckbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.checkboxVerify = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salveaza";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkboxVerify
            // 
            this.checkboxVerify.AutoSize = true;
            this.checkboxVerify.Location = new System.Drawing.Point(5, 1);
            this.checkboxVerify.Name = "checkboxVerify";
            this.checkboxVerify.Size = new System.Drawing.Size(113, 17);
            this.checkboxVerify.TabIndex = 1;
            this.checkboxVerify.Text = "Am verificat datele";
            this.checkboxVerify.UseVisualStyleBackColor = true;
            // 
            // btnUserControlCheckbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkboxVerify);
            this.Controls.Add(this.btnSave);
            this.Name = "btnUserControlCheckbox";
            this.Size = new System.Drawing.Size(113, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkboxVerify;
    }
}
