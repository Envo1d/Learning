
namespace WindowsFormsHW4
{
    partial class CarCatalogForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarCatalogForm));
            this.UpPnl = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.FormName = new System.Windows.Forms.Label();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblSave = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.PictureBox();
            this.lblRemove = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.PictureBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.UpPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // UpPnl
            // 
            this.UpPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.UpPnl.Controls.Add(this.btnMinimize);
            this.UpPnl.Controls.Add(this.btnClose);
            this.UpPnl.Controls.Add(this.FormName);
            this.UpPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPnl.Location = new System.Drawing.Point(0, 0);
            this.UpPnl.Name = "UpPnl";
            this.UpPnl.Size = new System.Drawing.Size(1100, 42);
            this.UpPnl.TabIndex = 0;
            this.UpPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpPnl_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1018, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 32);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1056, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            // 
            // FormName
            // 
            this.FormName.AutoSize = true;
            this.FormName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormName.ForeColor = System.Drawing.SystemColors.Control;
            this.FormName.Location = new System.Drawing.Point(512, 9);
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(98, 21);
            this.FormName.TabIndex = 0;
            this.FormName.Text = "Car Catalog";
            this.FormName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormName_MouseDown);
            // 
            // lstBox
            // 
            this.lstBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(150)))));
            this.lstBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 21;
            this.lstBox.Location = new System.Drawing.Point(54, 42);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(1034, 697);
            this.lstBox.TabIndex = 2;
            this.lstBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBox_MouseDoubleClick);
            this.lstBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lstBox_PreviewKeyDown);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.pnlMenu.Controls.Add(this.lblSave);
            this.pnlMenu.Controls.Add(this.btnSave);
            this.pnlMenu.Controls.Add(this.lblLoad);
            this.pnlMenu.Controls.Add(this.btnLoad);
            this.pnlMenu.Controls.Add(this.lblRemove);
            this.pnlMenu.Controls.Add(this.btnRemove);
            this.pnlMenu.Controls.Add(this.lblAdd);
            this.pnlMenu.Controls.Add(this.btnAdd);
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 42);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(48, 708);
            this.pnlMenu.TabIndex = 3;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSave.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSave.Location = new System.Drawing.Point(44, 630);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(100, 21);
            this.lblSave.TabIndex = 10;
            this.lblSave.Text = " - Save to file";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(6, 626);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSave.TabIndex = 9;
            this.btnSave.TabStop = false;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLoad.Location = new System.Drawing.Point(44, 583);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(83, 21);
            this.lblLoad.TabIndex = 8;
            this.lblLoad.Text = " - Load file";
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(6, 579);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(32, 32);
            this.btnLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLoad.TabIndex = 7;
            this.btnLoad.TabStop = false;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemove.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRemove.Location = new System.Drawing.Point(44, 145);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(88, 21);
            this.lblRemove.TabIndex = 6;
            this.lblRemove.Text = " - Clear List";
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(6, 142);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 32);
            this.btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRemove.TabIndex = 5;
            this.btnRemove.TabStop = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAdd.Location = new System.Drawing.Point(44, 97);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(85, 21);
            this.lblAdd.TabIndex = 4;
            this.lblAdd.Text = " - Add new";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(6, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(6, 6);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(32, 32);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMenu.TabIndex = 2;
            this.btnMenu.TabStop = false;
            // 
            // CarCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.UpPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CarCatalogForm";
            this.Text = "Car Catalog";
            this.UpPnl.ResumeLayout(false);
            this.UpPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UpPnl;
        private System.Windows.Forms.Label FormName;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.PictureBox btnRemove;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.PictureBox btnLoad;
    }
}

