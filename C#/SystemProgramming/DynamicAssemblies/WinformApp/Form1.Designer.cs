
namespace WinformApp
{
    partial class Form1
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
            this.originText = new System.Windows.Forms.TextBox();
            this.encryptedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.methodCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.startOp = new System.Windows.Forms.Button();
            this.opnFile = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // originText
            // 
            this.originText.Location = new System.Drawing.Point(25, 67);
            this.originText.Multiline = true;
            this.originText.Name = "originText";
            this.originText.Size = new System.Drawing.Size(329, 222);
            this.originText.TabIndex = 0;
            // 
            // encryptedText
            // 
            this.encryptedText.Location = new System.Drawing.Point(460, 67);
            this.encryptedText.Multiline = true;
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(329, 222);
            this.encryptedText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Origin Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted Text";
            // 
            // methodCmb
            // 
            this.methodCmb.FormattingEnabled = true;
            this.methodCmb.Location = new System.Drawing.Point(668, 336);
            this.methodCmb.Name = "methodCmb";
            this.methodCmb.Size = new System.Drawing.Size(121, 23);
            this.methodCmb.TabIndex = 5;
            this.methodCmb.SelectedIndexChanged += new System.EventHandler(this.methodCmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(706, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Method";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(124, 321);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // startOp
            // 
            this.startOp.Location = new System.Drawing.Point(370, 389);
            this.startOp.Name = "startOp";
            this.startOp.Size = new System.Drawing.Size(75, 23);
            this.startOp.TabIndex = 9;
            this.startOp.Text = "Begin";
            this.startOp.UseVisualStyleBackColor = true;
            this.startOp.Click += new System.EventHandler(this.startOp_Click);
            // 
            // opnFile
            // 
            this.opnFile.Location = new System.Drawing.Point(370, 67);
            this.opnFile.Name = "opnFile";
            this.opnFile.Size = new System.Drawing.Size(75, 23);
            this.opnFile.TabIndex = 10;
            this.opnFile.Text = "File";
            this.opnFile.UseVisualStyleBackColor = true;
            this.opnFile.Click += new System.EventHandler(this.opnFile_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(368, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 451);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.opnFile);
            this.Controls.Add(this.startOp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.methodCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encryptedText);
            this.Controls.Add(this.originText);
            this.MaximumSize = new System.Drawing.Size(827, 490);
            this.MinimumSize = new System.Drawing.Size(827, 490);
            this.Name = "Form1";
            this.Text = "CDR";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originText;
        private System.Windows.Forms.TextBox encryptedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox methodCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button startOp;
        private System.Windows.Forms.Button opnFile;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

