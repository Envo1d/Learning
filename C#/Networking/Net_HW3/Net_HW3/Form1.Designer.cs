namespace Net_HW3
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
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.infLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.box5 = new System.Windows.Forms.PictureBox();
            this.box6 = new System.Windows.Forms.PictureBox();
            this.box4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.box8 = new System.Windows.Forms.PictureBox();
            this.box9 = new System.Windows.Forms.PictureBox();
            this.box7 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.box2 = new System.Windows.Forms.PictureBox();
            this.box3 = new System.Windows.Forms.PictureBox();
            this.box1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box7)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 55);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Найти пару";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.infLbl);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 75);
            this.panel1.TabIndex = 1;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(433, 28);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(109, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Начать игру";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.button1_Click);
            // 
            // infLbl
            // 
            this.infLbl.AutoSize = true;
            this.infLbl.Location = new System.Drawing.Point(128, 32);
            this.infLbl.Name = "infLbl";
            this.infLbl.Size = new System.Drawing.Size(51, 15);
            this.infLbl.TabIndex = 1;
            this.infLbl.Text = "Pending";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 576);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Controls.Add(this.box5);
            this.panel5.Controls.Add(this.box6);
            this.panel5.Controls.Add(this.box4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(585, 192);
            this.panel5.TabIndex = 2;
            // 
            // box5
            // 
            this.box5.BackColor = System.Drawing.Color.DimGray;
            this.box5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.box5.Location = new System.Drawing.Point(195, 0);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(195, 192);
            this.box5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box5.TabIndex = 5;
            this.box5.TabStop = false;
            // 
            // box6
            // 
            this.box6.BackColor = System.Drawing.Color.DimGray;
            this.box6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box6.Dock = System.Windows.Forms.DockStyle.Right;
            this.box6.Location = new System.Drawing.Point(390, 0);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(195, 192);
            this.box6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box6.TabIndex = 4;
            this.box6.TabStop = false;
            // 
            // box4
            // 
            this.box4.BackColor = System.Drawing.Color.DimGray;
            this.box4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box4.Dock = System.Windows.Forms.DockStyle.Left;
            this.box4.Location = new System.Drawing.Point(0, 0);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(195, 192);
            this.box4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box4.TabIndex = 3;
            this.box4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Controls.Add(this.box8);
            this.panel4.Controls.Add(this.box9);
            this.panel4.Controls.Add(this.box7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 384);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(585, 192);
            this.panel4.TabIndex = 1;
            // 
            // box8
            // 
            this.box8.BackColor = System.Drawing.Color.DimGray;
            this.box8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.box8.Location = new System.Drawing.Point(195, 0);
            this.box8.Name = "box8";
            this.box8.Size = new System.Drawing.Size(195, 192);
            this.box8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box8.TabIndex = 5;
            this.box8.TabStop = false;
            // 
            // box9
            // 
            this.box9.BackColor = System.Drawing.Color.DimGray;
            this.box9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box9.Dock = System.Windows.Forms.DockStyle.Right;
            this.box9.Location = new System.Drawing.Point(390, 0);
            this.box9.Name = "box9";
            this.box9.Size = new System.Drawing.Size(195, 192);
            this.box9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box9.TabIndex = 4;
            this.box9.TabStop = false;
            // 
            // box7
            // 
            this.box7.BackColor = System.Drawing.Color.DimGray;
            this.box7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box7.Dock = System.Windows.Forms.DockStyle.Left;
            this.box7.Location = new System.Drawing.Point(0, 0);
            this.box7.Name = "box7";
            this.box7.Size = new System.Drawing.Size(195, 192);
            this.box7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box7.TabIndex = 3;
            this.box7.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.box2);
            this.panel3.Controls.Add(this.box3);
            this.panel3.Controls.Add(this.box1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 192);
            this.panel3.TabIndex = 0;
            // 
            // box2
            // 
            this.box2.BackColor = System.Drawing.Color.DimGray;
            this.box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.box2.Location = new System.Drawing.Point(195, 0);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(195, 192);
            this.box2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box2.TabIndex = 8;
            this.box2.TabStop = false;
            // 
            // box3
            // 
            this.box3.BackColor = System.Drawing.Color.DimGray;
            this.box3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box3.Dock = System.Windows.Forms.DockStyle.Right;
            this.box3.Location = new System.Drawing.Point(390, 0);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(195, 192);
            this.box3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box3.TabIndex = 7;
            this.box3.TabStop = false;
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.Color.DimGray;
            this.box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box1.Dock = System.Windows.Forms.DockStyle.Left;
            this.box1.Location = new System.Drawing.Point(0, 0);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(195, 192);
            this.box1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box1.TabIndex = 6;
            this.box1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 651);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(601, 690);
            this.MinimumSize = new System.Drawing.Size(601, 690);
            this.Name = "Form1";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.box5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box4)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.box8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box7)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox box1;
        private System.Windows.Forms.PictureBox box3;
        private System.Windows.Forms.PictureBox box2;
        private System.Windows.Forms.PictureBox box5;
        private System.Windows.Forms.PictureBox box6;
        private System.Windows.Forms.PictureBox box4;
        private System.Windows.Forms.PictureBox box8;
        private System.Windows.Forms.PictureBox box9;
        private System.Windows.Forms.PictureBox box7;
        private System.Windows.Forms.Label infLbl;
        private System.Windows.Forms.Button btnPlay;
    }
}
