
namespace GraduateWork
{
    partial class Supply
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.pnlChange = new System.Windows.Forms.Panel();
            this.txtCountry = new System.Windows.Forms.MaskedTextBox();
            this.txtCity = new System.Windows.Forms.MaskedTextBox();
            this.txtStreet = new System.Windows.Forms.MaskedTextBox();
            this.txtName = new System.Windows.Forms.MaskedTextBox();
            this.txtCustom5 = new System.Windows.Forms.MaskedTextBox();
            this.txtCustom4 = new System.Windows.Forms.MaskedTextBox();
            this.txtCustom2 = new System.Windows.Forms.MaskedTextBox();
            this.txtCustom1 = new System.Windows.Forms.MaskedTextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCustom5 = new System.Windows.Forms.Label();
            this.lblCustom4 = new System.Windows.Forms.Label();
            this.lblCustom2 = new System.Windows.Forms.Label();
            this.lblCustom1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 57);
            this.panel1.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnNext.IconColor = System.Drawing.Color.Gainsboro;
            this.btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNext.IconSize = 32;
            this.btnNext.Location = new System.Drawing.Point(756, 13);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlChange
            // 
            this.pnlChange.Controls.Add(this.txtCountry);
            this.pnlChange.Controls.Add(this.txtCity);
            this.pnlChange.Controls.Add(this.txtStreet);
            this.pnlChange.Controls.Add(this.txtName);
            this.pnlChange.Controls.Add(this.txtCustom5);
            this.pnlChange.Controls.Add(this.txtCustom4);
            this.pnlChange.Controls.Add(this.txtCustom2);
            this.pnlChange.Controls.Add(this.txtCustom1);
            this.pnlChange.Controls.Add(this.lblCountry);
            this.pnlChange.Controls.Add(this.lblCity);
            this.pnlChange.Controls.Add(this.lblStreet);
            this.pnlChange.Controls.Add(this.lblAddress);
            this.pnlChange.Controls.Add(this.lblType);
            this.pnlChange.Controls.Add(this.lblCustom5);
            this.pnlChange.Controls.Add(this.lblCustom4);
            this.pnlChange.Controls.Add(this.lblCustom2);
            this.pnlChange.Controls.Add(this.lblCustom1);
            this.pnlChange.Controls.Add(this.lblName);
            this.pnlChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChange.Location = new System.Drawing.Point(0, 0);
            this.pnlChange.Name = "pnlChange";
            this.pnlChange.Size = new System.Drawing.Size(800, 393);
            this.pnlChange.TabIndex = 2;
            // 
            // txtCountry
            // 
            this.txtCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCountry.BackColor = System.Drawing.Color.LightGray;
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCountry.Location = new System.Drawing.Point(600, 166);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(142, 16);
            this.txtCountry.TabIndex = 8;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCity.BackColor = System.Drawing.Color.LightGray;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCity.Location = new System.Drawing.Point(600, 125);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(142, 16);
            this.txtCity.TabIndex = 7;
            this.txtCity.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStreet.BackColor = System.Drawing.Color.LightGray;
            this.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtStreet.Location = new System.Drawing.Point(600, 86);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(142, 16);
            this.txtStreet.TabIndex = 6;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.BackColor = System.Drawing.Color.LightGray;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtName.Location = new System.Drawing.Point(178, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 16);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCustom5
            // 
            this.txtCustom5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustom5.BackColor = System.Drawing.Color.LightGray;
            this.txtCustom5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustom5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCustom5.Location = new System.Drawing.Point(178, 249);
            this.txtCustom5.Name = "txtCustom5";
            this.txtCustom5.Size = new System.Drawing.Size(142, 16);
            this.txtCustom5.TabIndex = 5;
            this.txtCustom5.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCustom4
            // 
            this.txtCustom4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustom4.BackColor = System.Drawing.Color.LightGray;
            this.txtCustom4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustom4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCustom4.Location = new System.Drawing.Point(178, 207);
            this.txtCustom4.Name = "txtCustom4";
            this.txtCustom4.Size = new System.Drawing.Size(142, 16);
            this.txtCustom4.TabIndex = 4;
            this.txtCustom4.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCustom2
            // 
            this.txtCustom2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustom2.BackColor = System.Drawing.Color.LightGray;
            this.txtCustom2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustom2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCustom2.Location = new System.Drawing.Point(178, 166);
            this.txtCustom2.Name = "txtCustom2";
            this.txtCustom2.Size = new System.Drawing.Size(142, 16);
            this.txtCustom2.TabIndex = 3;
            this.txtCustom2.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCustom1
            // 
            this.txtCustom1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustom1.BackColor = System.Drawing.Color.LightGray;
            this.txtCustom1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustom1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCustom1.Location = new System.Drawing.Point(178, 124);
            this.txtCustom1.Name = "txtCustom1";
            this.txtCustom1.Size = new System.Drawing.Size(142, 16);
            this.txtCustom1.TabIndex = 2;
            this.txtCustom1.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountry.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCountry.Location = new System.Drawing.Point(476, 165);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(59, 17);
            this.lblCountry.TabIndex = 16;
            this.lblCountry.Text = "Country";
            // 
            // lblCity
            // 
            this.lblCity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCity.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCity.Location = new System.Drawing.Point(476, 124);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(33, 17);
            this.lblCity.TabIndex = 14;
            this.lblCity.Text = "City";
            // 
            // lblStreet
            // 
            this.lblStreet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStreet.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStreet.Location = new System.Drawing.Point(476, 85);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(44, 17);
            this.lblStreet.TabIndex = 12;
            this.lblStreet.Text = "Street";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAddress.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblAddress.Location = new System.Drawing.Point(562, 51);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(72, 21);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Address";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblType.Location = new System.Drawing.Point(54, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(87, 23);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Product";
            // 
            // lblCustom5
            // 
            this.lblCustom5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustom5.AutoSize = true;
            this.lblCustom5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustom5.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCustom5.Location = new System.Drawing.Point(54, 248);
            this.lblCustom5.Name = "lblCustom5";
            this.lblCustom5.Size = new System.Drawing.Size(32, 17);
            this.lblCustom5.TabIndex = 8;
            this.lblCustom5.Text = "Unit";
            // 
            // lblCustom4
            // 
            this.lblCustom4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustom4.AutoSize = true;
            this.lblCustom4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustom4.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCustom4.Location = new System.Drawing.Point(54, 207);
            this.lblCustom4.Name = "lblCustom4";
            this.lblCustom4.Size = new System.Drawing.Size(60, 17);
            this.lblCustom4.TabIndex = 6;
            this.lblCustom4.Text = "Amount";
            // 
            // lblCustom2
            // 
            this.lblCustom2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustom2.AutoSize = true;
            this.lblCustom2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustom2.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCustom2.Location = new System.Drawing.Point(54, 165);
            this.lblCustom2.Name = "lblCustom2";
            this.lblCustom2.Size = new System.Drawing.Size(39, 17);
            this.lblCustom2.TabIndex = 4;
            this.lblCustom2.Text = "Price";
            // 
            // lblCustom1
            // 
            this.lblCustom1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustom1.AutoSize = true;
            this.lblCustom1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustom1.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCustom1.Location = new System.Drawing.Point(54, 124);
            this.lblCustom1.Name = "lblCustom1";
            this.lblCustom1.Size = new System.Drawing.Size(48, 17);
            this.lblCustom1.TabIndex = 2;
            this.lblCustom1.Text = "Model";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblName.Location = new System.Drawing.Point(54, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name";
            // 
            // Supply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(37)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlChange);
            this.Controls.Add(this.panel1);
            this.Name = "Supply";
            this.Text = "Supply";
            this.panel1.ResumeLayout(false);
            this.pnlChange.ResumeLayout(false);
            this.pnlChange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnNext;
        private System.Windows.Forms.Panel pnlChange;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCustom2;
        private System.Windows.Forms.Label lblCustom1;
        private System.Windows.Forms.Label lblCustom4;
        private System.Windows.Forms.Label lblCustom5;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.MaskedTextBox txtCustom1;
        private System.Windows.Forms.MaskedTextBox txtCustom5;
        private System.Windows.Forms.MaskedTextBox txtCustom4;
        private System.Windows.Forms.MaskedTextBox txtCustom2;
        private System.Windows.Forms.MaskedTextBox txtCountry;
        private System.Windows.Forms.MaskedTextBox txtCity;
        private System.Windows.Forms.MaskedTextBox txtStreet;
        private System.Windows.Forms.MaskedTextBox txtName;
    }
}