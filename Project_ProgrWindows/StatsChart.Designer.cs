namespace Project_ProgrWindows
{
    partial class StatsChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(205, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Inchide";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.labelTitle.Location = new System.Drawing.Point(71, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(336, 29);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Statistici categorii si produse";
            // 
            // chartStatistics
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatistics.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStatistics.Legends.Add(legend1);
            this.chartStatistics.Location = new System.Drawing.Point(29, 79);
            this.chartStatistics.Name = "chartStatistics";
            this.chartStatistics.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartStatistics.Size = new System.Drawing.Size(436, 268);
            this.chartStatistics.TabIndex = 2;
            this.chartStatistics.Text = "Statistici";
            // 
            // StatsChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 407);
            this.Controls.Add(this.chartStatistics);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnClose);
            this.Name = "StatsChart";
            this.Text = "Statistici";
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
    }
}