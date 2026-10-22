namespace tic_toc_toe
{
    partial class Game
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
            btnStart = new Button();
            panel1 = new Panel();
            btnPlay = new Button();
            infLbl = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            box5 = new PictureBox();
            box6 = new PictureBox();
            box4 = new PictureBox();
            panel4 = new Panel();
            box8 = new PictureBox();
            box9 = new PictureBox();
            box7 = new PictureBox();
            panel3 = new Panel();
            box2 = new PictureBox();
            box3 = new PictureBox();
            box1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)box5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box4).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)box8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box7).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)box2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)box1).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 55);
            btnStart.TabIndex = 0;
            btnStart.Text = "Find Player";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPlay);
            panel1.Controls.Add(infLbl);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(585, 75);
            panel1.TabIndex = 1;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(433, 28);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(109, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Start Game";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += button1_Click;
            // 
            // infLbl
            // 
            infLbl.AutoSize = true;
            infLbl.Location = new Point(128, 32);
            infLbl.Name = "infLbl";
            infLbl.Size = new Size(51, 15);
            infLbl.TabIndex = 1;
            infLbl.Text = "Pending";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(585, 576);
            panel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDarkDark;
            panel5.Controls.Add(box5);
            panel5.Controls.Add(box6);
            panel5.Controls.Add(box4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 192);
            panel5.Name = "panel5";
            panel5.Size = new Size(585, 192);
            panel5.TabIndex = 2;
            // 
            // box5
            // 
            box5.BackColor = Color.DimGray;
            box5.BorderStyle = BorderStyle.FixedSingle;
            box5.Dock = DockStyle.Fill;
            box5.Location = new Point(195, 0);
            box5.Name = "box5";
            box5.Size = new Size(195, 192);
            box5.SizeMode = PictureBoxSizeMode.StretchImage;
            box5.TabIndex = 5;
            box5.TabStop = false;
            // 
            // box6
            // 
            box6.BackColor = Color.DimGray;
            box6.BorderStyle = BorderStyle.FixedSingle;
            box6.Dock = DockStyle.Right;
            box6.Location = new Point(390, 0);
            box6.Name = "box6";
            box6.Size = new Size(195, 192);
            box6.SizeMode = PictureBoxSizeMode.StretchImage;
            box6.TabIndex = 4;
            box6.TabStop = false;
            // 
            // box4
            // 
            box4.BackColor = Color.DimGray;
            box4.BorderStyle = BorderStyle.FixedSingle;
            box4.Dock = DockStyle.Left;
            box4.Location = new Point(0, 0);
            box4.Name = "box4";
            box4.Size = new Size(195, 192);
            box4.SizeMode = PictureBoxSizeMode.StretchImage;
            box4.TabIndex = 3;
            box4.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Controls.Add(box8);
            panel4.Controls.Add(box9);
            panel4.Controls.Add(box7);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 384);
            panel4.Name = "panel4";
            panel4.Size = new Size(585, 192);
            panel4.TabIndex = 1;
            // 
            // box8
            // 
            box8.BackColor = Color.DimGray;
            box8.BorderStyle = BorderStyle.FixedSingle;
            box8.Dock = DockStyle.Fill;
            box8.Location = new Point(195, 0);
            box8.Name = "box8";
            box8.Size = new Size(195, 192);
            box8.SizeMode = PictureBoxSizeMode.StretchImage;
            box8.TabIndex = 5;
            box8.TabStop = false;
            // 
            // box9
            // 
            box9.BackColor = Color.DimGray;
            box9.BorderStyle = BorderStyle.FixedSingle;
            box9.Dock = DockStyle.Right;
            box9.Location = new Point(390, 0);
            box9.Name = "box9";
            box9.Size = new Size(195, 192);
            box9.SizeMode = PictureBoxSizeMode.StretchImage;
            box9.TabIndex = 4;
            box9.TabStop = false;
            // 
            // box7
            // 
            box7.BackColor = Color.DimGray;
            box7.BorderStyle = BorderStyle.FixedSingle;
            box7.Dock = DockStyle.Left;
            box7.Location = new Point(0, 0);
            box7.Name = "box7";
            box7.Size = new Size(195, 192);
            box7.SizeMode = PictureBoxSizeMode.StretchImage;
            box7.TabIndex = 3;
            box7.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(box2);
            panel3.Controls.Add(box3);
            panel3.Controls.Add(box1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(585, 192);
            panel3.TabIndex = 0;
            // 
            // box2
            // 
            box2.BackColor = Color.DimGray;
            box2.BorderStyle = BorderStyle.FixedSingle;
            box2.Dock = DockStyle.Fill;
            box2.Location = new Point(195, 0);
            box2.Name = "box2";
            box2.Size = new Size(195, 192);
            box2.SizeMode = PictureBoxSizeMode.StretchImage;
            box2.TabIndex = 8;
            box2.TabStop = false;
            // 
            // box3
            // 
            box3.BackColor = Color.DimGray;
            box3.BorderStyle = BorderStyle.FixedSingle;
            box3.Dock = DockStyle.Right;
            box3.Location = new Point(390, 0);
            box3.Name = "box3";
            box3.Size = new Size(195, 192);
            box3.SizeMode = PictureBoxSizeMode.StretchImage;
            box3.TabIndex = 7;
            box3.TabStop = false;
            // 
            // box1
            // 
            box1.BackColor = Color.DimGray;
            box1.BorderStyle = BorderStyle.FixedSingle;
            box1.Dock = DockStyle.Left;
            box1.Location = new Point(0, 0);
            box1.Name = "box1";
            box1.Size = new Size(195, 192);
            box1.SizeMode = PictureBoxSizeMode.StretchImage;
            box1.TabIndex = 6;
            box1.TabStop = false;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 651);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximumSize = new Size(601, 690);
            MinimumSize = new Size(601, 690);
            Name = "Game";
            Text = "Tic Tac Toe";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)box5).EndInit();
            ((System.ComponentModel.ISupportInitialize)box6).EndInit();
            ((System.ComponentModel.ISupportInitialize)box4).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)box8).EndInit();
            ((System.ComponentModel.ISupportInitialize)box9).EndInit();
            ((System.ComponentModel.ISupportInitialize)box7).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)box2).EndInit();
            ((System.ComponentModel.ISupportInitialize)box3).EndInit();
            ((System.ComponentModel.ISupportInitialize)box1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Panel panel1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private PictureBox box1;
        private PictureBox box3;
        private PictureBox box2;
        private PictureBox box5;
        private PictureBox box6;
        private PictureBox box4;
        private PictureBox box8;
        private PictureBox box9;
        private PictureBox box7;
        private Label infLbl;
        private Button btnPlay;
    }
}