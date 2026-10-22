
namespace Exam
{
    partial class NewTask
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCncl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chDateTime = new System.Windows.Forms.CheckBox();
            this.chPrior = new System.Windows.Forms.CheckBox();
            this.chTags = new System.Windows.Forms.CheckBox();
            this.chCmmnt = new System.Windows.Forms.CheckBox();
            this.chFile = new System.Windows.Forms.CheckBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(206, 20);
            this.txtName.TabIndex = 0;
            // 
            // dateTime
            // 
            this.dateTime.CustomFormat = "d.MM.yyyy HH:mm";
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(129, 74);
            this.dateTime.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTime.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(134, 20);
            this.dateTime.TabIndex = 4;
            // 
            // cmbPriority
            // 
            this.cmbPriority.AutoCompleteCustomSource.AddRange(new string[] {
            "Low",
            "Middle",
            "High"});
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Low",
            "Middle",
            "High"});
            this.cmbPriority.Location = new System.Drawing.Point(129, 114);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(178, 21);
            this.cmbPriority.TabIndex = 6;
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(129, 155);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(206, 20);
            this.txtTags.TabIndex = 7;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(129, 197);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(407, 71);
            this.txtComment.TabIndex = 9;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(129, 317);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(206, 20);
            this.txtFile.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(476, 386);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCncl
            // 
            this.btnCncl.Location = new System.Drawing.Point(12, 386);
            this.btnCncl.Name = "btnCncl";
            this.btnCncl.Size = new System.Drawing.Size(75, 23);
            this.btnCncl.TabIndex = 14;
            this.btnCncl.Text = "Cancel";
            this.btnCncl.UseVisualStyleBackColor = true;
            this.btnCncl.Click += new System.EventHandler(this.btnCncl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // chDateTime
            // 
            this.chDateTime.AutoSize = true;
            this.chDateTime.Location = new System.Drawing.Point(12, 74);
            this.chDateTime.Name = "chDateTime";
            this.chDateTime.Size = new System.Drawing.Size(96, 17);
            this.chDateTime.TabIndex = 20;
            this.chDateTime.Text = "Date and Time";
            this.chDateTime.UseVisualStyleBackColor = true;
            this.chDateTime.CheckedChanged += new System.EventHandler(this.btnDateTime_CheckedChanged);
            // 
            // chPrior
            // 
            this.chPrior.AutoSize = true;
            this.chPrior.Location = new System.Drawing.Point(12, 116);
            this.chPrior.Name = "chPrior";
            this.chPrior.Size = new System.Drawing.Size(57, 17);
            this.chPrior.TabIndex = 21;
            this.chPrior.Text = "Priority";
            this.chPrior.UseVisualStyleBackColor = true;
            this.chPrior.CheckedChanged += new System.EventHandler(this.chPrior_CheckedChanged);
            // 
            // chTags
            // 
            this.chTags.AutoSize = true;
            this.chTags.Location = new System.Drawing.Point(12, 157);
            this.chTags.Name = "chTags";
            this.chTags.Size = new System.Drawing.Size(50, 17);
            this.chTags.TabIndex = 22;
            this.chTags.Text = "Tags";
            this.chTags.UseVisualStyleBackColor = true;
            this.chTags.CheckedChanged += new System.EventHandler(this.chTags_CheckedChanged);
            // 
            // chCmmnt
            // 
            this.chCmmnt.AutoSize = true;
            this.chCmmnt.Location = new System.Drawing.Point(12, 224);
            this.chCmmnt.Name = "chCmmnt";
            this.chCmmnt.Size = new System.Drawing.Size(70, 17);
            this.chCmmnt.TabIndex = 23;
            this.chCmmnt.Text = "Comment";
            this.chCmmnt.UseVisualStyleBackColor = true;
            this.chCmmnt.CheckedChanged += new System.EventHandler(this.chCmmnt_CheckedChanged);
            // 
            // chFile
            // 
            this.chFile.AutoSize = true;
            this.chFile.Location = new System.Drawing.Point(12, 319);
            this.chFile.Name = "chFile";
            this.chFile.Size = new System.Drawing.Size(42, 17);
            this.chFile.TabIndex = 24;
            this.chFile.Text = "File";
            this.chFile.UseVisualStyleBackColor = true;
            this.chFile.CheckedChanged += new System.EventHandler(this.chFile_CheckedChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(359, 315);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 25;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 419);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.chFile);
            this.Controls.Add(this.chCmmnt);
            this.Controls.Add(this.chTags);
            this.Controls.Add(this.chPrior);
            this.Controls.Add(this.chDateTime);
            this.Controls.Add(this.btnCncl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewTask";
            this.Text = "New Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCncl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chDateTime;
        private System.Windows.Forms.CheckBox chPrior;
        private System.Windows.Forms.CheckBox chTags;
        private System.Windows.Forms.CheckBox chCmmnt;
        private System.Windows.Forms.CheckBox chFile;
        private System.Windows.Forms.Button btnOpenFile;
    }
}