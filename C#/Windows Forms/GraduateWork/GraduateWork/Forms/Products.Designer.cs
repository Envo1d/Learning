
namespace GraduateWork
{
    partial class Products
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
            this.lstView = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.productName = new System.Windows.Forms.ColumnHeader();
            this.model = new System.Windows.Forms.ColumnHeader();
            this.price = new System.Windows.Forms.ColumnHeader();
            this.amount = new System.Windows.Forms.ColumnHeader();
            this.unit = new System.Windows.Forms.ColumnHeader();
            this.btnReduce = new FontAwesome.Sharp.IconButton();
            this.btnDel = new FontAwesome.Sharp.IconButton();
            this.btnRealize = new FontAwesome.Sharp.IconButton();
            this.producer = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstView
            // 
            this.lstView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.productName,
            this.model,
            this.price,
            this.amount,
            this.unit,
            this.producer});
            this.lstView.ForeColor = System.Drawing.SystemColors.Window;
            this.lstView.Location = new System.Drawing.Point(14, 14);
            this.lstView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(905, 411);
            this.lstView.TabIndex = 0;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 30;
            // 
            // productName
            // 
            this.productName.Text = "Product Name";
            this.productName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productName.Width = 230;
            // 
            // model
            // 
            this.model.Text = "Model";
            this.model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.model.Width = 140;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 90;
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amount.Width = 90;
            // 
            // unit
            // 
            this.unit.Text = "Unit";
            this.unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReduce
            // 
            this.btnReduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReduce.FlatAppearance.BorderSize = 0;
            this.btnReduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduce.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReduce.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReduce.IconChar = FontAwesome.Sharp.IconChar.Percentage;
            this.btnReduce.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReduce.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReduce.IconSize = 32;
            this.btnReduce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReduce.Location = new System.Drawing.Point(14, 436);
            this.btnReduce.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReduce.Name = "btnReduce";
            this.btnReduce.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnReduce.Size = new System.Drawing.Size(164, 69);
            this.btnReduce.TabIndex = 2;
            this.btnReduce.Text = "Reduce the price";
            this.btnReduce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReduce.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReduce.UseVisualStyleBackColor = true;
            this.btnReduce.Click += new System.EventHandler(this.btnReduce_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDel.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDel.IconSize = 32;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(186, 436);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnDel.Size = new System.Drawing.Size(164, 69);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Delete requisites";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRealize
            // 
            this.btnRealize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealize.FlatAppearance.BorderSize = 0;
            this.btnRealize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealize.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRealize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRealize.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.btnRealize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnRealize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRealize.IconSize = 32;
            this.btnRealize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealize.Location = new System.Drawing.Point(755, 436);
            this.btnRealize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRealize.Name = "btnRealize";
            this.btnRealize.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnRealize.Size = new System.Drawing.Size(164, 69);
            this.btnRealize.TabIndex = 4;
            this.btnRealize.Text = "Realize";
            this.btnRealize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRealize.UseVisualStyleBackColor = true;
            this.btnRealize.Click += new System.EventHandler(this.btnRealize_Click);
            // 
            // producer
            // 
            this.producer.Text = "Producer";
            this.producer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.producer.Width = 200;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.btnRealize);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnReduce);
            this.Controls.Add(this.lstView);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Products";
            this.Text = "Products";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstView;
        private FontAwesome.Sharp.IconButton btnReduce;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnRealize;
        private ColumnHeader id;
        private ColumnHeader productName;
        private ColumnHeader model;
        private ColumnHeader price;
        private ColumnHeader amount;
        private ColumnHeader unit;
        private ColumnHeader producer;
    }
}