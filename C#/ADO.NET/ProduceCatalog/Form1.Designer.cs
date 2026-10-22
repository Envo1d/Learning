
namespace WindowsFormsADO2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClRange = new System.Windows.Forms.Button();
            this.btnClUpper = new System.Windows.Forms.Button();
            this.btnClLower = new System.Windows.Forms.Button();
            this.btnShColor = new System.Windows.Forms.Button();
            this.btnCCount = new System.Windows.Forms.Button();
            this.btnFCount = new System.Windows.Forms.Button();
            this.btnVCount = new System.Windows.Forms.Button();
            this.btnAvg = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnNames = new System.Windows.Forms.Button();
            this.btnDsc = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConn = new System.Windows.Forms.Button();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.btnColors = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnColors);
            this.panel1.Controls.Add(this.btnClRange);
            this.panel1.Controls.Add(this.btnClUpper);
            this.panel1.Controls.Add(this.btnClLower);
            this.panel1.Controls.Add(this.btnShColor);
            this.panel1.Controls.Add(this.btnCCount);
            this.panel1.Controls.Add(this.btnFCount);
            this.panel1.Controls.Add(this.btnVCount);
            this.panel1.Controls.Add(this.btnAvg);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.btnMax);
            this.panel1.Controls.Add(this.btnNames);
            this.panel1.Controls.Add(this.btnDsc);
            this.panel1.Controls.Add(this.btnUpd);
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnConn);
            this.panel1.Controls.Add(this.cmbDB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 90);
            this.panel1.TabIndex = 0;
            // 
            // btnClRange
            // 
            this.btnClRange.Location = new System.Drawing.Point(500, 63);
            this.btnClRange.Name = "btnClRange";
            this.btnClRange.Size = new System.Drawing.Size(106, 23);
            this.btnClRange.TabIndex = 16;
            this.btnClRange.Text = "Calorie in indicated";
            this.btnClRange.UseVisualStyleBackColor = true;
            this.btnClRange.Click += new System.EventHandler(this.btnClRange_Click);
            // 
            // btnClUpper
            // 
            this.btnClUpper.Location = new System.Drawing.Point(388, 63);
            this.btnClUpper.Name = "btnClUpper";
            this.btnClUpper.Size = new System.Drawing.Size(106, 23);
            this.btnClUpper.TabIndex = 15;
            this.btnClUpper.Text = "Calorie > indicated";
            this.btnClUpper.UseVisualStyleBackColor = true;
            this.btnClUpper.Click += new System.EventHandler(this.btnClUpper_Click);
            // 
            // btnClLower
            // 
            this.btnClLower.Location = new System.Drawing.Point(276, 63);
            this.btnClLower.Name = "btnClLower";
            this.btnClLower.Size = new System.Drawing.Size(106, 23);
            this.btnClLower.TabIndex = 14;
            this.btnClLower.Text = "Calorie < indicated";
            this.btnClLower.UseVisualStyleBackColor = true;
            this.btnClLower.Click += new System.EventHandler(this.btnClLower_Click);
            // 
            // btnShColor
            // 
            this.btnShColor.Location = new System.Drawing.Point(766, 34);
            this.btnShColor.Name = "btnShColor";
            this.btnShColor.Size = new System.Drawing.Size(94, 23);
            this.btnShColor.TabIndex = 13;
            this.btnShColor.Text = "Count of Color";
            this.btnShColor.UseVisualStyleBackColor = true;
            this.btnShColor.Click += new System.EventHandler(this.btnShColor_Click);
            // 
            // btnCCount
            // 
            this.btnCCount.Location = new System.Drawing.Point(866, 34);
            this.btnCCount.Name = "btnCCount";
            this.btnCCount.Size = new System.Drawing.Size(79, 23);
            this.btnCCount.TabIndex = 12;
            this.btnCCount.Text = "Colors Count";
            this.btnCCount.UseVisualStyleBackColor = true;
            this.btnCCount.Click += new System.EventHandler(this.btnCCount_Click);
            // 
            // btnFCount
            // 
            this.btnFCount.Location = new System.Drawing.Point(694, 34);
            this.btnFCount.Name = "btnFCount";
            this.btnFCount.Size = new System.Drawing.Size(68, 23);
            this.btnFCount.TabIndex = 11;
            this.btnFCount.Text = "Fruit Count";
            this.btnFCount.UseVisualStyleBackColor = true;
            this.btnFCount.Click += new System.EventHandler(this.btnFCount_Click);
            // 
            // btnVCount
            // 
            this.btnVCount.Location = new System.Drawing.Point(590, 34);
            this.btnVCount.Name = "btnVCount";
            this.btnVCount.Size = new System.Drawing.Size(98, 23);
            this.btnVCount.TabIndex = 10;
            this.btnVCount.Text = "Vegetable Count";
            this.btnVCount.UseVisualStyleBackColor = true;
            this.btnVCount.Click += new System.EventHandler(this.btnVCount_Click);
            // 
            // btnAvg
            // 
            this.btnAvg.Location = new System.Drawing.Point(510, 34);
            this.btnAvg.Name = "btnAvg";
            this.btnAvg.Size = new System.Drawing.Size(74, 23);
            this.btnAvg.TabIndex = 9;
            this.btnAvg.Text = "Avg Calorie";
            this.btnAvg.UseVisualStyleBackColor = true;
            this.btnAvg.Click += new System.EventHandler(this.btnAvg_Click);
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(436, 34);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(68, 23);
            this.btnMin.TabIndex = 8;
            this.btnMin.Text = "Min Calorie";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.Location = new System.Drawing.Point(360, 34);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(70, 23);
            this.btnMax.TabIndex = 7;
            this.btnMax.Text = "Max Calorie";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnNames
            // 
            this.btnNames.Location = new System.Drawing.Point(276, 34);
            this.btnNames.Name = "btnNames";
            this.btnNames.Size = new System.Drawing.Size(78, 23);
            this.btnNames.TabIndex = 6;
            this.btnNames.Text = "Show Names";
            this.btnNames.UseVisualStyleBackColor = true;
            this.btnNames.Click += new System.EventHandler(this.btnNames_Click);
            // 
            // btnDsc
            // 
            this.btnDsc.Location = new System.Drawing.Point(20, 55);
            this.btnDsc.Name = "btnDsc";
            this.btnDsc.Size = new System.Drawing.Size(76, 23);
            this.btnDsc.TabIndex = 5;
            this.btnDsc.Text = "Disconnect";
            this.btnDsc.UseVisualStyleBackColor = true;
            this.btnDsc.Click += new System.EventHandler(this.btnDsc_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(185, 55);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(50, 23);
            this.btnUpd.TabIndex = 4;
            this.btnUpd.Text = "Update";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(177, 34);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(58, 23);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "Show All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(276, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(678, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(20, 34);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(59, 23);
            this.btnConn.TabIndex = 1;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // cmbDB
            // 
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(0, 7);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(235, 21);
            this.cmbDB.TabIndex = 0;
            this.cmbDB.SelectedIndexChanged += new System.EventHandler(this.cmbDB_SelectedIndexChanged);
            // 
            // dtGrid
            // 
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(0, 0);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(957, 426);
            this.dtGrid.TabIndex = 1;
            // 
            // btnColors
            // 
            this.btnColors.Location = new System.Drawing.Point(612, 63);
            this.btnColors.Name = "btnColors";
            this.btnColors.Size = new System.Drawing.Size(129, 23);
            this.btnColors.TabIndex = 17;
            this.btnColors.Text = "With Red/Yellow color";
            this.btnColors.UseVisualStyleBackColor = true;
            this.btnColors.Click += new System.EventHandler(this.btnColors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 516);
            this.Controls.Add(this.dtGrid);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDsc;
        private System.Windows.Forms.Button btnNames;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnAvg;
        private System.Windows.Forms.Button btnVCount;
        private System.Windows.Forms.Button btnFCount;
        private System.Windows.Forms.Button btnCCount;
        private System.Windows.Forms.Button btnShColor;
        private System.Windows.Forms.Button btnClLower;
        private System.Windows.Forms.Button btnClUpper;
        private System.Windows.Forms.Button btnClRange;
        private System.Windows.Forms.Button btnColors;
    }
}

