
namespace GraduateWork
{
    partial class Reports
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
            this.btnProduct = new FontAwesome.Sharp.IconButton();
            this.btnSale = new FontAwesome.Sharp.IconButton();
            this.btnProfit = new FontAwesome.Sharp.IconButton();
            this.dateF = new System.Windows.Forms.DateTimePicker();
            this.lblF = new System.Windows.Forms.Label();
            this.dateT = new System.Windows.Forms.DateTimePicker();
            this.lblT = new System.Windows.Forms.Label();
            this.btnDifference = new FontAwesome.Sharp.IconButton();
            this.btnSellerProdList = new FontAwesome.Sharp.IconButton();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbSellers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProduct.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProduct.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnProduct.IconColor = System.Drawing.Color.Gainsboro;
            this.btnProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProduct.IconSize = 32;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(56, 38);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnProduct.Size = new System.Drawing.Size(202, 69);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "Product specification";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSale
            // 
            this.btnSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSale.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.btnSale.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSale.IconSize = 32;
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.Location = new System.Drawing.Point(56, 128);
            this.btnSale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSale.Name = "btnSale";
            this.btnSale.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnSale.Size = new System.Drawing.Size(234, 69);
            this.btnSale.TabIndex = 5;
            this.btnSale.Text = "Accounting for the sale of goods";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnProfit
            // 
            this.btnProfit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProfit.FlatAppearance.BorderSize = 0;
            this.btnProfit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProfit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProfit.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnProfit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnProfit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfit.IconSize = 32;
            this.btnProfit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfit.Location = new System.Drawing.Point(56, 222);
            this.btnProfit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnProfit.Name = "btnProfit";
            this.btnProfit.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnProfit.Size = new System.Drawing.Size(202, 69);
            this.btnProfit.TabIndex = 6;
            this.btnProfit.Text = "Profit for the period";
            this.btnProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfit.UseVisualStyleBackColor = true;
            this.btnProfit.Click += new System.EventHandler(this.btnProfit_Click);
            // 
            // dateF
            // 
            this.dateF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateF.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateF.Location = new System.Drawing.Point(426, 245);
            this.dateF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateF.Name = "dateF";
            this.dateF.Size = new System.Drawing.Size(102, 23);
            this.dateF.TabIndex = 7;
            // 
            // lblF
            // 
            this.lblF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblF.AutoSize = true;
            this.lblF.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblF.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblF.Location = new System.Drawing.Point(336, 242);
            this.lblF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(48, 21);
            this.lblF.TabIndex = 9;
            this.lblF.Text = "From";
            // 
            // dateT
            // 
            this.dateT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateT.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateT.Location = new System.Drawing.Point(632, 245);
            this.dateT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateT.Name = "dateT";
            this.dateT.Size = new System.Drawing.Size(102, 23);
            this.dateT.TabIndex = 10;
            // 
            // lblT
            // 
            this.lblT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblT.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblT.Location = new System.Drawing.Point(569, 243);
            this.lblT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(28, 21);
            this.lblT.TabIndex = 11;
            this.lblT.Text = "To";
            // 
            // btnDifference
            // 
            this.btnDifference.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDifference.FlatAppearance.BorderSize = 0;
            this.btnDifference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDifference.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDifference.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDifference.IconChar = FontAwesome.Sharp.IconChar.ScaleUnbalanced;
            this.btnDifference.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDifference.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDifference.IconSize = 32;
            this.btnDifference.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDifference.Location = new System.Drawing.Point(56, 310);
            this.btnDifference.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDifference.Name = "btnDifference";
            this.btnDifference.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnDifference.Size = new System.Drawing.Size(219, 69);
            this.btnDifference.TabIndex = 12;
            this.btnDifference.Text = "Price difference";
            this.btnDifference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDifference.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDifference.UseVisualStyleBackColor = true;
            this.btnDifference.Click += new System.EventHandler(this.btnDifference_Click);
            // 
            // btnSellerProdList
            // 
            this.btnSellerProdList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSellerProdList.FlatAppearance.BorderSize = 0;
            this.btnSellerProdList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellerProdList.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSellerProdList.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSellerProdList.IconChar = FontAwesome.Sharp.IconChar.DriversLicense;
            this.btnSellerProdList.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSellerProdList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSellerProdList.IconSize = 32;
            this.btnSellerProdList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSellerProdList.Location = new System.Drawing.Point(56, 399);
            this.btnSellerProdList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSellerProdList.Name = "btnSellerProdList";
            this.btnSellerProdList.Padding = new System.Windows.Forms.Padding(12, 0, 23, 0);
            this.btnSellerProdList.Size = new System.Drawing.Size(202, 69);
            this.btnSellerProdList.TabIndex = 13;
            this.btnSellerProdList.Text = "Seller\'s product list";
            this.btnSellerProdList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSellerProdList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSellerProdList.UseVisualStyleBackColor = true;
            this.btnSellerProdList.Click += new System.EventHandler(this.btnSellerProdList_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblName.Location = new System.Drawing.Point(336, 420);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 21);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Seller";
            // 
            // cmbSellers
            // 
            this.cmbSellers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSellers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSellers.FormattingEnabled = true;
            this.cmbSellers.Location = new System.Drawing.Point(485, 417);
            this.cmbSellers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSellers.Name = "cmbSellers";
            this.cmbSellers.Size = new System.Drawing.Size(249, 29);
            this.cmbSellers.TabIndex = 16;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.cmbSellers);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSellerProdList);
            this.Controls.Add(this.btnDifference);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.dateT);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.dateF);
            this.Controls.Add(this.btnProfit);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnProduct);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnProduct;
        private FontAwesome.Sharp.IconButton btnSale;
        private FontAwesome.Sharp.IconButton btnProfit;
        private System.Windows.Forms.DateTimePicker dateF;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.DateTimePicker dateT;
        private System.Windows.Forms.Label lblT;
        private FontAwesome.Sharp.IconButton btnDifference;
        private FontAwesome.Sharp.IconButton btnSellerProdList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbSellers;
    }
}