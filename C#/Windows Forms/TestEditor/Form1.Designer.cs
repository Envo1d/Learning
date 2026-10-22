
namespace WinFormsHW3
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
            this.pnlTests = new System.Windows.Forms.Panel();
            this.txBoxNameHided = new System.Windows.Forms.TextBox();
            this.btnTestAdd = new System.Windows.Forms.Button();
            this.btnTestEdit = new System.Windows.Forms.Button();
            this.btnTestDel = new System.Windows.Forms.Button();
            this.numMark = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmBoxName = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlQQ = new System.Windows.Forms.Panel();
            this.btnQQEd = new System.Windows.Forms.Button();
            this.btnQQDel = new System.Windows.Forms.Button();
            this.lstBoxQQ = new System.Windows.Forms.ListBox();
            this.txBoxQQ = new System.Windows.Forms.RichTextBox();
            this.btnQQAdd = new System.Windows.Forms.Button();
            this.pnlAns = new System.Windows.Forms.Panel();
            this.btnAnsEd = new System.Windows.Forms.Button();
            this.btnAnsDel = new System.Windows.Forms.Button();
            this.lstBoxAns = new System.Windows.Forms.ListBox();
            this.chBoxTrueAns = new System.Windows.Forms.CheckBox();
            this.txBoxAns = new System.Windows.Forms.RichTextBox();
            this.btnAnsAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblQQ = new System.Windows.Forms.Label();
            this.lblAns = new System.Windows.Forms.Label();
            this.lblTests = new System.Windows.Forms.Label();
            this.pnlTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.pnlQQ.SuspendLayout();
            this.pnlAns.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTests
            // 
            this.pnlTests.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTests.Controls.Add(this.txBoxNameHided);
            this.pnlTests.Controls.Add(this.btnTestAdd);
            this.pnlTests.Controls.Add(this.btnTestEdit);
            this.pnlTests.Controls.Add(this.btnTestDel);
            this.pnlTests.Controls.Add(this.numMark);
            this.pnlTests.Controls.Add(this.label2);
            this.pnlTests.Controls.Add(this.label1);
            this.pnlTests.Controls.Add(this.lblTime);
            this.pnlTests.Controls.Add(this.numMinutes);
            this.pnlTests.Controls.Add(this.cmBoxName);
            this.pnlTests.Controls.Add(this.lblName);
            this.pnlTests.Location = new System.Drawing.Point(12, 12);
            this.pnlTests.Name = "pnlTests";
            this.pnlTests.Size = new System.Drawing.Size(969, 149);
            this.pnlTests.TabIndex = 0;
            // 
            // txBoxNameHided
            // 
            this.txBoxNameHided.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txBoxNameHided.Location = new System.Drawing.Point(247, 13);
            this.txBoxNameHided.Name = "txBoxNameHided";
            this.txBoxNameHided.Size = new System.Drawing.Size(465, 27);
            this.txBoxNameHided.TabIndex = 14;
            this.txBoxNameHided.Visible = false;
            // 
            // btnTestAdd
            // 
            this.btnTestAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTestAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestAdd.Location = new System.Drawing.Point(772, 13);
            this.btnTestAdd.Name = "btnTestAdd";
            this.btnTestAdd.Size = new System.Drawing.Size(172, 29);
            this.btnTestAdd.TabIndex = 13;
            this.btnTestAdd.Text = "Добавить новый тест";
            this.btnTestAdd.UseVisualStyleBackColor = false;
            this.btnTestAdd.Click += new System.EventHandler(this.btnTestAdd_Click);
            // 
            // btnTestEdit
            // 
            this.btnTestEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTestEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestEdit.Location = new System.Drawing.Point(826, 54);
            this.btnTestEdit.Name = "btnTestEdit";
            this.btnTestEdit.Size = new System.Drawing.Size(118, 29);
            this.btnTestEdit.TabIndex = 12;
            this.btnTestEdit.Text = "Изменить тест";
            this.btnTestEdit.UseVisualStyleBackColor = false;
            this.btnTestEdit.Click += new System.EventHandler(this.btnTestEdit_Click);
            // 
            // btnTestDel
            // 
            this.btnTestDel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTestDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestDel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestDel.Location = new System.Drawing.Point(837, 96);
            this.btnTestDel.Name = "btnTestDel";
            this.btnTestDel.Size = new System.Drawing.Size(107, 29);
            this.btnTestDel.TabIndex = 11;
            this.btnTestDel.Text = "Удалить тест";
            this.btnTestDel.UseVisualStyleBackColor = false;
            this.btnTestDel.Click += new System.EventHandler(this.btnTestDel_Click);
            // 
            // numMark
            // 
            this.numMark.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMark.Location = new System.Drawing.Point(247, 100);
            this.numMark.Name = "numMark";
            this.numMark.Size = new System.Drawing.Size(186, 27);
            this.numMark.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Проходной балл";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(446, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "мин";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(27, 58);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(154, 20);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Время тестирования";
            // 
            // numMinutes
            // 
            this.numMinutes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMinutes.Location = new System.Drawing.Point(247, 56);
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(186, 27);
            this.numMinutes.TabIndex = 2;
            // 
            // cmBoxName
            // 
            this.cmBoxName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmBoxName.FormattingEnabled = true;
            this.cmBoxName.Location = new System.Drawing.Point(247, 13);
            this.cmBoxName.Name = "cmBoxName";
            this.cmBoxName.Size = new System.Drawing.Size(465, 28);
            this.cmBoxName.TabIndex = 1;
            this.cmBoxName.SelectedIndexChanged += new System.EventHandler(this.cmBoxName_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(27, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название";
            // 
            // pnlQQ
            // 
            this.pnlQQ.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlQQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQQ.Controls.Add(this.btnQQEd);
            this.pnlQQ.Controls.Add(this.btnQQDel);
            this.pnlQQ.Controls.Add(this.lstBoxQQ);
            this.pnlQQ.Controls.Add(this.txBoxQQ);
            this.pnlQQ.Controls.Add(this.btnQQAdd);
            this.pnlQQ.Location = new System.Drawing.Point(12, 184);
            this.pnlQQ.Name = "pnlQQ";
            this.pnlQQ.Size = new System.Drawing.Size(498, 426);
            this.pnlQQ.TabIndex = 1;
            this.pnlQQ.Tag = "";
            // 
            // btnQQEd
            // 
            this.btnQQEd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnQQEd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQQEd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQQEd.Location = new System.Drawing.Point(181, 388);
            this.btnQQEd.Name = "btnQQEd";
            this.btnQQEd.Size = new System.Drawing.Size(112, 29);
            this.btnQQEd.TabIndex = 11;
            this.btnQQEd.Text = "Изменить";
            this.btnQQEd.UseVisualStyleBackColor = false;
            this.btnQQEd.Click += new System.EventHandler(this.btnQQEd_Click);
            // 
            // btnQQDel
            // 
            this.btnQQDel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnQQDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQQDel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQQDel.Location = new System.Drawing.Point(11, 388);
            this.btnQQDel.Name = "btnQQDel";
            this.btnQQDel.Size = new System.Drawing.Size(75, 29);
            this.btnQQDel.TabIndex = 10;
            this.btnQQDel.Text = "Удалить";
            this.btnQQDel.UseVisualStyleBackColor = false;
            this.btnQQDel.Click += new System.EventHandler(this.btnQQDel_Click);
            // 
            // lstBoxQQ
            // 
            this.lstBoxQQ.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstBoxQQ.FormattingEnabled = true;
            this.lstBoxQQ.ItemHeight = 20;
            this.lstBoxQQ.Location = new System.Drawing.Point(11, 14);
            this.lstBoxQQ.Name = "lstBoxQQ";
            this.lstBoxQQ.Size = new System.Drawing.Size(473, 264);
            this.lstBoxQQ.TabIndex = 6;
            this.lstBoxQQ.SelectedIndexChanged += new System.EventHandler(this.lstBoxQQ_SelectedIndexChanged);
            // 
            // txBoxQQ
            // 
            this.txBoxQQ.BackColor = System.Drawing.SystemColors.Control;
            this.txBoxQQ.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txBoxQQ.Location = new System.Drawing.Point(11, 291);
            this.txBoxQQ.Name = "txBoxQQ";
            this.txBoxQQ.Size = new System.Drawing.Size(473, 88);
            this.txBoxQQ.TabIndex = 5;
            this.txBoxQQ.Text = "";
            // 
            // btnQQAdd
            // 
            this.btnQQAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnQQAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQQAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQQAdd.Location = new System.Drawing.Point(391, 388);
            this.btnQQAdd.Name = "btnQQAdd";
            this.btnQQAdd.Size = new System.Drawing.Size(93, 29);
            this.btnQQAdd.TabIndex = 4;
            this.btnQQAdd.Text = "Добавить";
            this.btnQQAdd.UseVisualStyleBackColor = false;
            this.btnQQAdd.Click += new System.EventHandler(this.btnQQAdd_Click);
            // 
            // pnlAns
            // 
            this.pnlAns.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAns.Controls.Add(this.btnAnsEd);
            this.pnlAns.Controls.Add(this.btnAnsDel);
            this.pnlAns.Controls.Add(this.lstBoxAns);
            this.pnlAns.Controls.Add(this.chBoxTrueAns);
            this.pnlAns.Controls.Add(this.txBoxAns);
            this.pnlAns.Controls.Add(this.btnAnsAdd);
            this.pnlAns.Location = new System.Drawing.Point(516, 184);
            this.pnlAns.Name = "pnlAns";
            this.pnlAns.Size = new System.Drawing.Size(466, 426);
            this.pnlAns.TabIndex = 2;
            // 
            // btnAnsEd
            // 
            this.btnAnsEd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAnsEd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnsEd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnsEd.Location = new System.Drawing.Point(227, 388);
            this.btnAnsEd.Name = "btnAnsEd";
            this.btnAnsEd.Size = new System.Drawing.Size(115, 29);
            this.btnAnsEd.TabIndex = 10;
            this.btnAnsEd.Text = "Изменить";
            this.btnAnsEd.UseVisualStyleBackColor = false;
            this.btnAnsEd.Click += new System.EventHandler(this.btnAnsEd_Click);
            // 
            // btnAnsDel
            // 
            this.btnAnsDel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAnsDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnsDel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnsDel.Location = new System.Drawing.Point(135, 388);
            this.btnAnsDel.Name = "btnAnsDel";
            this.btnAnsDel.Size = new System.Drawing.Size(75, 29);
            this.btnAnsDel.TabIndex = 9;
            this.btnAnsDel.Text = "Удалить";
            this.btnAnsDel.UseVisualStyleBackColor = false;
            this.btnAnsDel.Click += new System.EventHandler(this.btnAnsDel_Click);
            // 
            // lstBoxAns
            // 
            this.lstBoxAns.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstBoxAns.FormattingEnabled = true;
            this.lstBoxAns.ItemHeight = 20;
            this.lstBoxAns.Location = new System.Drawing.Point(11, 14);
            this.lstBoxAns.Name = "lstBoxAns";
            this.lstBoxAns.Size = new System.Drawing.Size(439, 264);
            this.lstBoxAns.TabIndex = 8;
            this.lstBoxAns.SelectedIndexChanged += new System.EventHandler(this.lstBoxAns_SelectedIndexChanged);
            // 
            // chBoxTrueAns
            // 
            this.chBoxTrueAns.AutoSize = true;
            this.chBoxTrueAns.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chBoxTrueAns.Location = new System.Drawing.Point(11, 388);
            this.chBoxTrueAns.Name = "chBoxTrueAns";
            this.chBoxTrueAns.Size = new System.Drawing.Size(118, 24);
            this.chBoxTrueAns.TabIndex = 7;
            this.chBoxTrueAns.Text = "Правильный";
            this.chBoxTrueAns.UseVisualStyleBackColor = true;
            // 
            // txBoxAns
            // 
            this.txBoxAns.BackColor = System.Drawing.SystemColors.Control;
            this.txBoxAns.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txBoxAns.Location = new System.Drawing.Point(11, 291);
            this.txBoxAns.Name = "txBoxAns";
            this.txBoxAns.Size = new System.Drawing.Size(439, 88);
            this.txBoxAns.TabIndex = 6;
            this.txBoxAns.Text = "";
            // 
            // btnAnsAdd
            // 
            this.btnAnsAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAnsAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnsAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnsAdd.Location = new System.Drawing.Point(362, 388);
            this.btnAnsAdd.Name = "btnAnsAdd";
            this.btnAnsAdd.Size = new System.Drawing.Size(88, 29);
            this.btnAnsAdd.TabIndex = 5;
            this.btnAnsAdd.Text = "Добавить";
            this.btnAnsAdd.UseVisualStyleBackColor = false;
            this.btnAnsAdd.Click += new System.EventHandler(this.btnAnsAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(850, 636);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQQ.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQQ.Location = new System.Drawing.Point(12, 175);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(67, 21);
            this.lblQQ.TabIndex = 4;
            this.lblQQ.Text = "Вопросы";
            // 
            // lblAns
            // 
            this.lblAns.AutoSize = true;
            this.lblAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAns.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAns.Location = new System.Drawing.Point(516, 175);
            this.lblAns.Name = "lblAns";
            this.lblAns.Size = new System.Drawing.Size(58, 21);
            this.lblAns.TabIndex = 8;
            this.lblAns.Text = "Ответы";
            // 
            // lblTests
            // 
            this.lblTests.AutoSize = true;
            this.lblTests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTests.Location = new System.Drawing.Point(12, 0);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(47, 21);
            this.lblTests.TabIndex = 9;
            this.lblTests.Text = "Тесты";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(994, 681);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.lblAns);
            this.Controls.Add(this.lblQQ);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlAns);
            this.Controls.Add(this.pnlQQ);
            this.Controls.Add(this.pnlTests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Редактор тестов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTests.ResumeLayout(false);
            this.pnlTests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            this.pnlQQ.ResumeLayout(false);
            this.pnlAns.ResumeLayout(false);
            this.pnlAns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTests;
        private System.Windows.Forms.Panel pnlQQ;
        private System.Windows.Forms.Panel pnlAns;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQQAdd;
        private System.Windows.Forms.Button btnAnsAdd;
        private System.Windows.Forms.RichTextBox txBoxQQ;
        private System.Windows.Forms.CheckBox chBoxTrueAns;
        private System.Windows.Forms.RichTextBox txBoxAns;
        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.Label lblAns;
        private System.Windows.Forms.ListBox lstBoxQQ;
        private System.Windows.Forms.ListBox lstBoxAns;
        private System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmBoxName;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestAdd;
        private System.Windows.Forms.Button btnTestEdit;
        private System.Windows.Forms.Button btnTestDel;
        private System.Windows.Forms.Button btnQQEd;
        private System.Windows.Forms.Button btnQQDel;
        private System.Windows.Forms.Button btnAnsEd;
        private System.Windows.Forms.Button btnAnsDel;
        private System.Windows.Forms.TextBox txBoxNameHided;
    }
}

