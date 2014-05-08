namespace Project_ProgrWindows
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonListProducts = new System.Windows.Forms.Button();
            this.buttonImportProductsXml = new System.Windows.Forms.Button();
            this.buttonExportProductsXml = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instaleazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiuniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaProdusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaCategorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonListCategories = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sku = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stock_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelListProducts = new System.Windows.Forms.Label();
            this.labelListCategories = new System.Windows.Forms.Label();
            this.listViewCategories = new System.Windows.Forms.ListView();
            this.categoryId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statisticiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonListProducts
            // 
            this.buttonListProducts.Location = new System.Drawing.Point(174, 41);
            this.buttonListProducts.Name = "buttonListProducts";
            this.buttonListProducts.Size = new System.Drawing.Size(138, 59);
            this.buttonListProducts.TabIndex = 0;
            this.buttonListProducts.Text = "Listare produse";
            this.buttonListProducts.UseVisualStyleBackColor = true;
            this.buttonListProducts.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonImportProductsXml
            // 
            this.buttonImportProductsXml.Location = new System.Drawing.Point(850, 41);
            this.buttonImportProductsXml.Name = "buttonImportProductsXml";
            this.buttonImportProductsXml.Size = new System.Drawing.Size(110, 23);
            this.buttonImportProductsXml.TabIndex = 1;
            this.buttonImportProductsXml.Text = "Import produse";
            this.buttonImportProductsXml.UseVisualStyleBackColor = true;
            this.buttonImportProductsXml.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonExportProductsXml
            // 
            this.buttonExportProductsXml.Location = new System.Drawing.Point(850, 81);
            this.buttonExportProductsXml.Name = "buttonExportProductsXml";
            this.buttonExportProductsXml.Size = new System.Drawing.Size(110, 23);
            this.buttonExportProductsXml.TabIndex = 2;
            this.buttonExportProductsXml.Text = "Export produse";
            this.buttonExportProductsXml.UseVisualStyleBackColor = true;
            this.buttonExportProductsXml.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fisierToolStripMenuItem,
            this.optiuniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fisierToolStripMenuItem
            // 
            this.fisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despreToolStripMenuItem,
            this.instaleazaToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            this.fisierToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fisierToolStripMenuItem.Text = "Fisier";
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "despreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.despreToolStripMenuItem.Text = "Despre";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.despreToolStripMenuItem_Click);
            // 
            // instaleazaToolStripMenuItem
            // 
            this.instaleazaToolStripMenuItem.Name = "instaleazaToolStripMenuItem";
            this.instaleazaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.instaleazaToolStripMenuItem.Text = "Instaleaza";
            this.instaleazaToolStripMenuItem.Click += new System.EventHandler(this.instaleazaToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // optiuniToolStripMenuItem
            // 
            this.optiuniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaProdusToolStripMenuItem,
            this.adaugaCategorieToolStripMenuItem,
            this.statisticiToolStripMenuItem});
            this.optiuniToolStripMenuItem.Name = "optiuniToolStripMenuItem";
            this.optiuniToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.optiuniToolStripMenuItem.Text = "Optiuni";
            // 
            // adaugaProdusToolStripMenuItem
            // 
            this.adaugaProdusToolStripMenuItem.Name = "adaugaProdusToolStripMenuItem";
            this.adaugaProdusToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.adaugaProdusToolStripMenuItem.Text = "Adauga produs";
            this.adaugaProdusToolStripMenuItem.Click += new System.EventHandler(this.adaugaProdusToolStripMenuItem_Click);
            // 
            // adaugaCategorieToolStripMenuItem
            // 
            this.adaugaCategorieToolStripMenuItem.Name = "adaugaCategorieToolStripMenuItem";
            this.adaugaCategorieToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.adaugaCategorieToolStripMenuItem.Text = "Adauga categorie";
            this.adaugaCategorieToolStripMenuItem.Click += new System.EventHandler(this.adaugaCategorieToolStripMenuItem_Click);
            // 
            // buttonListCategories
            // 
            this.buttonListCategories.Location = new System.Drawing.Point(12, 41);
            this.buttonListCategories.Name = "buttonListCategories";
            this.buttonListCategories.Size = new System.Drawing.Size(144, 59);
            this.buttonListCategories.TabIndex = 4;
            this.buttonListCategories.Text = "Listare categorii";
            this.buttonListCategories.UseVisualStyleBackColor = true;
            this.buttonListCategories.Click += new System.EventHandler(this.buttonListCategories_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.label1.Location = new System.Drawing.Point(434, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "MiniERP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aplicatie gestiune produse";
            // 
            // listViewProducts
            // 
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.price,
            this.sku,
            this.category,
            this.status,
            this.stock_qty});
            this.listViewProducts.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewProducts.FullRowSelect = true;
            this.listViewProducts.GridLines = true;
            this.listViewProducts.Location = new System.Drawing.Point(12, 137);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(948, 283);
            this.listViewProducts.TabIndex = 8;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.SmallIcon;
            this.listViewProducts.Visible = false;
            this.listViewProducts.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView2_ColumnWidthChanging);
            this.listViewProducts.DoubleClick += new System.EventHandler(this.listViewProducts_DoubleClick);
            // 
            // id
            // 
            this.id.Tag = "1";
            this.id.Text = "ID Intern";
            // 
            // name
            // 
            this.name.Text = "Nume";
            this.name.Width = 300;
            // 
            // price
            // 
            this.price.Text = "Pret";
            this.price.Width = 150;
            // 
            // sku
            // 
            this.sku.Text = "SKU";
            this.sku.Width = 150;
            // 
            // category
            // 
            this.category.Text = "Categorie";
            this.category.Width = 100;
            // 
            // status
            // 
            this.status.Text = "Statut";
            this.status.Width = 80;
            // 
            // stock_qty
            // 
            this.stock_qty.Text = "Stoc";
            this.stock_qty.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editazaToolStripMenuItem,
            this.stergeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            // 
            // editazaToolStripMenuItem
            // 
            this.editazaToolStripMenuItem.Name = "editazaToolStripMenuItem";
            this.editazaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editazaToolStripMenuItem.Text = "Editeaza";
            this.editazaToolStripMenuItem.Click += new System.EventHandler(this.editazaToolStripMenuItem_Click);
            // 
            // stergeToolStripMenuItem
            // 
            this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
            this.stergeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stergeToolStripMenuItem.Text = "Sterge";
            this.stergeToolStripMenuItem.Click += new System.EventHandler(this.stergeToolStripMenuItem_Click);
            // 
            // labelListProducts
            // 
            this.labelListProducts.AutoSize = true;
            this.labelListProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListProducts.Location = new System.Drawing.Point(13, 118);
            this.labelListProducts.Name = "labelListProducts";
            this.labelListProducts.Size = new System.Drawing.Size(94, 13);
            this.labelListProducts.TabIndex = 9;
            this.labelListProducts.Text = "Listare produse";
            this.labelListProducts.Visible = false;
            // 
            // labelListCategories
            // 
            this.labelListCategories.AutoSize = true;
            this.labelListCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListCategories.Location = new System.Drawing.Point(13, 118);
            this.labelListCategories.Name = "labelListCategories";
            this.labelListCategories.Size = new System.Drawing.Size(98, 13);
            this.labelListCategories.TabIndex = 10;
            this.labelListCategories.Text = "Listare categorii";
            this.labelListCategories.Visible = false;
            // 
            // listViewCategories
            // 
            this.listViewCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categoryId,
            this.categoryName});
            this.listViewCategories.FullRowSelect = true;
            this.listViewCategories.Location = new System.Drawing.Point(12, 137);
            this.listViewCategories.Name = "listViewCategories";
            this.listViewCategories.Size = new System.Drawing.Size(665, 283);
            this.listViewCategories.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewCategories.TabIndex = 11;
            this.listViewCategories.UseCompatibleStateImageBehavior = false;
            this.listViewCategories.Visible = false;
            this.listViewCategories.DoubleClick += new System.EventHandler(this.listViewCategories_DoubleClick);
            // 
            // categoryId
            // 
            this.categoryId.Text = "ID";
            // 
            // categoryName
            // 
            this.categoryName.Text = "Nume";
            this.categoryName.Width = 600;
            // 
            // statisticiToolStripMenuItem
            // 
            this.statisticiToolStripMenuItem.Name = "statisticiToolStripMenuItem";
            this.statisticiToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.statisticiToolStripMenuItem.Text = "Statistici";
            this.statisticiToolStripMenuItem.Click += new System.EventHandler(this.statisticiToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 460);
            this.Controls.Add(this.listViewCategories);
            this.Controls.Add(this.labelListCategories);
            this.Controls.Add(this.labelListProducts);
            this.Controls.Add(this.listViewProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonListCategories);
            this.Controls.Add(this.buttonExportProductsXml);
            this.Controls.Add(this.buttonImportProductsXml);
            this.Controls.Add(this.buttonListProducts);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mini ERP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonListProducts;
        private System.Windows.Forms.Button buttonImportProductsXml;
        private System.Windows.Forms.Button buttonExportProductsXml;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiuniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaProdusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaCategorieToolStripMenuItem;
        private System.Windows.Forms.Button buttonListCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewProducts;
        public System.Windows.Forms.ColumnHeader id;
        public System.Windows.Forms.ColumnHeader sku;
        public System.Windows.Forms.ColumnHeader name;
        public System.Windows.Forms.ColumnHeader category;
        public System.Windows.Forms.ColumnHeader status;
        public System.Windows.Forms.ColumnHeader stock_qty;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ToolStripMenuItem instaleazaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeToolStripMenuItem;
        private System.Windows.Forms.Label labelListProducts;
        private System.Windows.Forms.Label labelListCategories;
        private System.Windows.Forms.ListView listViewCategories;
        private System.Windows.Forms.ColumnHeader categoryId;
        private System.Windows.Forms.ColumnHeader categoryName;
        private System.Windows.Forms.ToolStripMenuItem statisticiToolStripMenuItem;
    }
}

