
namespace WindowsFormsHW4
{
    partial class AddCarDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCarDialog));
            this.pnlUp = new System.Windows.Forms.Panel();
            this.DialogName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pnlCarId = new System.Windows.Forms.Panel();
            this.lblCarId = new System.Windows.Forms.Label();
            this.pnlMod = new System.Windows.Forms.Panel();
            this.txtBoxModel = new System.Windows.Forms.TextBox();
            this.lblCarMod = new System.Windows.Forms.Label();
            this.pnlPrice = new System.Windows.Forms.Panel();
            this.lblCarPrice = new System.Windows.Forms.Label();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.pnlSold = new System.Windows.Forms.Panel();
            this.lblSold = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.RadioButton();
            this.btnNo = new System.Windows.Forms.RadioButton();
            this.btnAddRec = new System.Windows.Forms.PictureBox();
            this.btnDeleteRec = new System.Windows.Forms.PictureBox();
            this.btnUpdateRec = new System.Windows.Forms.PictureBox();
            this.pnlUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.pnlCarId.SuspendLayout();
            this.pnlMod.SuspendLayout();
            this.pnlPrice.SuspendLayout();
            this.pnlSold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateRec)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUp
            // 
            this.pnlUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.pnlUp.Controls.Add(this.DialogName);
            this.pnlUp.Controls.Add(this.btnClose);
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(900, 42);
            this.pnlUp.TabIndex = 0;
            this.pnlUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUp_MouseDown);
            // 
            // DialogName
            // 
            this.DialogName.AutoSize = true;
            this.DialogName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DialogName.ForeColor = System.Drawing.SystemColors.Control;
            this.DialogName.Location = new System.Drawing.Point(412, 6);
            this.DialogName.Name = "DialogName";
            this.DialogName.Size = new System.Drawing.Size(70, 21);
            this.DialogName.TabIndex = 5;
            this.DialogName.Text = "Add Car";
            this.DialogName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DialogName_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(856, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCarId
            // 
            this.pnlCarId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(80)))));
            this.pnlCarId.Controls.Add(this.txtBoxId);
            this.pnlCarId.Controls.Add(this.lblCarId);
            this.pnlCarId.Location = new System.Drawing.Point(33, 69);
            this.pnlCarId.Name = "pnlCarId";
            this.pnlCarId.Size = new System.Drawing.Size(830, 51);
            this.pnlCarId.TabIndex = 1;
            // 
            // lblCarId
            // 
            this.lblCarId.AutoSize = true;
            this.lblCarId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCarId.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCarId.Location = new System.Drawing.Point(15, 14);
            this.lblCarId.Name = "lblCarId";
            this.lblCarId.Size = new System.Drawing.Size(56, 21);
            this.lblCarId.TabIndex = 6;
            this.lblCarId.Text = "Car ID";
            // 
            // pnlMod
            // 
            this.pnlMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(80)))));
            this.pnlMod.Controls.Add(this.txtBoxModel);
            this.pnlMod.Controls.Add(this.lblCarMod);
            this.pnlMod.Location = new System.Drawing.Point(33, 155);
            this.pnlMod.Name = "pnlMod";
            this.pnlMod.Size = new System.Drawing.Size(830, 51);
            this.pnlMod.TabIndex = 2;
            // 
            // txtBoxModel
            // 
            this.txtBoxModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxModel.Location = new System.Drawing.Point(119, 11);
            this.txtBoxModel.Name = "txtBoxModel";
            this.txtBoxModel.Size = new System.Drawing.Size(264, 29);
            this.txtBoxModel.TabIndex = 7;
            // 
            // lblCarMod
            // 
            this.lblCarMod.AutoSize = true;
            this.lblCarMod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCarMod.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCarMod.Location = new System.Drawing.Point(15, 14);
            this.lblCarMod.Name = "lblCarMod";
            this.lblCarMod.Size = new System.Drawing.Size(88, 21);
            this.lblCarMod.TabIndex = 6;
            this.lblCarMod.Text = "Car Model";
            // 
            // pnlPrice
            // 
            this.pnlPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(80)))));
            this.pnlPrice.Controls.Add(this.txtBoxPrice);
            this.pnlPrice.Controls.Add(this.lblCarPrice);
            this.pnlPrice.Location = new System.Drawing.Point(33, 243);
            this.pnlPrice.Name = "pnlPrice";
            this.pnlPrice.Size = new System.Drawing.Size(830, 51);
            this.pnlPrice.TabIndex = 3;
            // 
            // lblCarPrice
            // 
            this.lblCarPrice.AutoSize = true;
            this.lblCarPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCarPrice.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCarPrice.Location = new System.Drawing.Point(15, 14);
            this.lblCarPrice.Name = "lblCarPrice";
            this.lblCarPrice.Size = new System.Drawing.Size(77, 21);
            this.lblCarPrice.TabIndex = 6;
            this.lblCarPrice.Text = "Car Price";
            // 
            // txtBoxId
            // 
            this.txtBoxId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxId.Location = new System.Drawing.Point(119, 11);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(264, 29);
            this.txtBoxId.TabIndex = 8;
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBoxPrice.Location = new System.Drawing.Point(119, 11);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(264, 29);
            this.txtBoxPrice.TabIndex = 8;
            // 
            // pnlSold
            // 
            this.pnlSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(80)))));
            this.pnlSold.Controls.Add(this.btnNo);
            this.pnlSold.Controls.Add(this.btnYes);
            this.pnlSold.Controls.Add(this.lblSold);
            this.pnlSold.Location = new System.Drawing.Point(33, 331);
            this.pnlSold.Name = "pnlSold";
            this.pnlSold.Size = new System.Drawing.Size(830, 51);
            this.pnlSold.TabIndex = 4;
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSold.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSold.Location = new System.Drawing.Point(15, 14);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(44, 21);
            this.lblSold.TabIndex = 6;
            this.lblSold.Text = "Sold";
            // 
            // btnYes
            // 
            this.btnYes.AutoSize = true;
            this.btnYes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnYes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnYes.Location = new System.Drawing.Point(119, 12);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(51, 25);
            this.btnYes.TabIndex = 7;
            this.btnYes.TabStop = true;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.AutoSize = true;
            this.btnNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNo.Location = new System.Drawing.Point(192, 12);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(49, 25);
            this.btnNo.TabIndex = 8;
            this.btnNo.TabStop = true;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // btnAddRec
            // 
            this.btnAddRec.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRec.Image")));
            this.btnAddRec.Location = new System.Drawing.Point(823, 487);
            this.btnAddRec.Name = "btnAddRec";
            this.btnAddRec.Size = new System.Drawing.Size(40, 40);
            this.btnAddRec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddRec.TabIndex = 5;
            this.btnAddRec.TabStop = false;
            // 
            // btnDeleteRec
            // 
            this.btnDeleteRec.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRec.Image")));
            this.btnDeleteRec.Location = new System.Drawing.Point(33, 487);
            this.btnDeleteRec.Name = "btnDeleteRec";
            this.btnDeleteRec.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteRec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteRec.TabIndex = 6;
            this.btnDeleteRec.TabStop = false;
            // 
            // btnUpdateRec
            // 
            this.btnUpdateRec.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateRec.Image")));
            this.btnUpdateRec.Location = new System.Drawing.Point(423, 487);
            this.btnUpdateRec.Name = "btnUpdateRec";
            this.btnUpdateRec.Size = new System.Drawing.Size(40, 40);
            this.btnUpdateRec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUpdateRec.TabIndex = 7;
            this.btnUpdateRec.TabStop = false;
            // 
            // AddCarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.btnUpdateRec);
            this.Controls.Add(this.btnDeleteRec);
            this.Controls.Add(this.btnAddRec);
            this.Controls.Add(this.pnlSold);
            this.Controls.Add(this.pnlPrice);
            this.Controls.Add(this.pnlMod);
            this.Controls.Add(this.pnlCarId);
            this.Controls.Add(this.pnlUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCarDialog";
            this.Text = "AddCarDialog";
            this.pnlUp.ResumeLayout(false);
            this.pnlUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.pnlCarId.ResumeLayout(false);
            this.pnlCarId.PerformLayout();
            this.pnlMod.ResumeLayout(false);
            this.pnlMod.PerformLayout();
            this.pnlPrice.ResumeLayout(false);
            this.pnlPrice.PerformLayout();
            this.pnlSold.ResumeLayout(false);
            this.pnlSold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateRec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUp;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label DialogName;
        private System.Windows.Forms.Panel pnlCarId;
        private System.Windows.Forms.Label lblCarId;
        private System.Windows.Forms.Panel pnlMod;
        private System.Windows.Forms.Label lblCarMod;
        private System.Windows.Forms.TextBox txtBoxModel;
        private System.Windows.Forms.Panel pnlPrice;
        private System.Windows.Forms.Label lblCarPrice;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Panel pnlSold;
        private System.Windows.Forms.RadioButton btnNo;
        private System.Windows.Forms.RadioButton btnYes;
        private System.Windows.Forms.Label lblSold;
        private System.Windows.Forms.PictureBox btnAddRec;
        private System.Windows.Forms.PictureBox btnDeleteRec;
        private System.Windows.Forms.PictureBox btnUpdateRec;
    }
}