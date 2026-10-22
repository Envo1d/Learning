
namespace WindowsFormsHW2
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.picDol = new System.Windows.Forms.PictureBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.picOil = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResOil3 = new System.Windows.Forms.Label();
            this.lblResOil2 = new System.Windows.Forms.Label();
            this.lblResOil1 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.boxCost = new System.Windows.Forms.TextBox();
            this.lblL = new System.Windows.Forms.Label();
            this.boxLitr = new System.Windows.Forms.TextBox();
            this.pnlChoice = new System.Windows.Forms.Panel();
            this.chBoxCost = new System.Windows.Forms.CheckBox();
            this.chBoxCount = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmboxOilType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOil = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.picHam = new System.Windows.Forms.PictureBox();
            this.txBoxCCCount = new System.Windows.Forms.TextBox();
            this.txBoxPFCount = new System.Windows.Forms.TextBox();
            this.txBoxGMCount = new System.Windows.Forms.TextBox();
            this.txBoxHDCount = new System.Windows.Forms.TextBox();
            this.txBoxCCPrice = new System.Windows.Forms.TextBox();
            this.txBoxPFPrice = new System.Windows.Forms.TextBox();
            this.txBoxGMPrice = new System.Windows.Forms.TextBox();
            this.txBoxHDPrice = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.chBoxCC = new System.Windows.Forms.CheckBox();
            this.chBoxPF = new System.Windows.Forms.CheckBox();
            this.chBoxG = new System.Windows.Forms.CheckBox();
            this.chBoxHD = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblResC3 = new System.Windows.Forms.Label();
            this.lblResC2 = new System.Windows.Forms.Label();
            this.lblResC1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDol)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOil)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlChoice.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHam)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Silver;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.lblRes);
            this.pnlBottom.Controls.Add(this.picDol);
            this.pnlBottom.Controls.Add(this.btnCalculate);
            this.pnlBottom.Controls.Add(this.label5);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 504);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1008, 225);
            this.pnlBottom.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(678, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "грн";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRes.Location = new System.Drawing.Point(449, 91);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(72, 37);
            this.lblRes.TabIndex = 29;
            this.lblRes.Text = "0.00";
            // 
            // picDol
            // 
            this.picDol.Location = new System.Drawing.Point(33, 66);
            this.picDol.Name = "picDol";
            this.picDol.Size = new System.Drawing.Size(100, 95);
            this.picDol.TabIndex = 28;
            this.picDol.TabStop = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCalculate.Location = new System.Drawing.Point(179, 78);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(154, 72);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Всего к оплате:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.LightBlue;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.picOil);
            this.pnlLeft.Controls.Add(this.panel1);
            this.pnlLeft.Controls.Add(this.lblCost);
            this.pnlLeft.Controls.Add(this.boxCost);
            this.pnlLeft.Controls.Add(this.lblL);
            this.pnlLeft.Controls.Add(this.boxLitr);
            this.pnlLeft.Controls.Add(this.pnlChoice);
            this.pnlLeft.Controls.Add(this.label4);
            this.pnlLeft.Controls.Add(this.boxPrice);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.cmboxOilType);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.lblOil);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(504, 504);
            this.pnlLeft.TabIndex = 1;
            // 
            // picOil
            // 
            this.picOil.Location = new System.Drawing.Point(352, 69);
            this.picOil.Name = "picOil";
            this.picOil.Size = new System.Drawing.Size(100, 95);
            this.picOil.TabIndex = 12;
            this.picOil.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblResOil3);
            this.panel1.Controls.Add(this.lblResOil2);
            this.panel1.Controls.Add(this.lblResOil1);
            this.panel1.Location = new System.Drawing.Point(12, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 126);
            this.panel1.TabIndex = 11;
            // 
            // lblResOil3
            // 
            this.lblResOil3.AutoSize = true;
            this.lblResOil3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResOil3.Location = new System.Drawing.Point(338, 99);
            this.lblResOil3.Name = "lblResOil3";
            this.lblResOil3.Size = new System.Drawing.Size(44, 25);
            this.lblResOil3.TabIndex = 6;
            this.lblResOil3.Text = "грн";
            // 
            // lblResOil2
            // 
            this.lblResOil2.AutoSize = true;
            this.lblResOil2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResOil2.Location = new System.Drawing.Point(165, 52);
            this.lblResOil2.Name = "lblResOil2";
            this.lblResOil2.Size = new System.Drawing.Size(50, 25);
            this.lblResOil2.TabIndex = 5;
            this.lblResOil2.Text = "0.00";
            // 
            // lblResOil1
            // 
            this.lblResOil1.AutoSize = true;
            this.lblResOil1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResOil1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResOil1.Location = new System.Drawing.Point(0, 0);
            this.lblResOil1.Name = "lblResOil1";
            this.lblResOil1.Size = new System.Drawing.Size(98, 25);
            this.lblResOil1.TabIndex = 4;
            this.lblResOil1.Text = "К оплате:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCost.Location = new System.Drawing.Point(369, 304);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(33, 19);
            this.lblCost.TabIndex = 10;
            this.lblCost.Text = "грн";
            // 
            // boxCost
            // 
            this.boxCost.Location = new System.Drawing.Point(270, 298);
            this.boxCost.Name = "boxCost";
            this.boxCost.Size = new System.Drawing.Size(93, 23);
            this.boxCost.TabIndex = 9;
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblL.Location = new System.Drawing.Point(369, 240);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(17, 19);
            this.lblL.TabIndex = 8;
            this.lblL.Text = "л";
            // 
            // boxLitr
            // 
            this.boxLitr.Location = new System.Drawing.Point(270, 236);
            this.boxLitr.Name = "boxLitr";
            this.boxLitr.Size = new System.Drawing.Size(93, 23);
            this.boxLitr.TabIndex = 7;
            // 
            // pnlChoice
            // 
            this.pnlChoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChoice.Controls.Add(this.chBoxCost);
            this.pnlChoice.Controls.Add(this.chBoxCount);
            this.pnlChoice.Location = new System.Drawing.Point(12, 221);
            this.pnlChoice.Name = "pnlChoice";
            this.pnlChoice.Size = new System.Drawing.Size(200, 123);
            this.pnlChoice.TabIndex = 6;
            // 
            // chBoxCost
            // 
            this.chBoxCost.AutoSize = true;
            this.chBoxCost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxCost.Location = new System.Drawing.Point(46, 76);
            this.chBoxCost.Name = "chBoxCost";
            this.chBoxCost.Size = new System.Drawing.Size(73, 23);
            this.chBoxCost.TabIndex = 1;
            this.chBoxCost.Text = "Сумма";
            this.chBoxCost.UseVisualStyleBackColor = true;
            this.chBoxCost.CheckedChanged += new System.EventHandler(this.chBoxCost_CheckedChanged);
            // 
            // chBoxCount
            // 
            this.chBoxCount.AutoSize = true;
            this.chBoxCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxCount.Location = new System.Drawing.Point(46, 14);
            this.chBoxCount.Name = "chBoxCount";
            this.chBoxCount.Size = new System.Drawing.Size(107, 23);
            this.chBoxCount.TabIndex = 0;
            this.chBoxCount.Text = "Количество";
            this.chBoxCount.UseVisualStyleBackColor = true;
            this.chBoxCount.CheckedChanged += new System.EventHandler(this.chBoxCount_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(212, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "грн / л";
            // 
            // boxPrice
            // 
            this.boxPrice.Location = new System.Drawing.Point(113, 155);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.Size = new System.Drawing.Size(93, 23);
            this.boxPrice.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(11, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Цена";
            // 
            // cmboxOilType
            // 
            this.cmboxOilType.FormattingEnabled = true;
            this.cmboxOilType.Location = new System.Drawing.Point(113, 73);
            this.cmboxOilType.Name = "cmboxOilType";
            this.cmboxOilType.Size = new System.Drawing.Size(186, 23);
            this.cmboxOilType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Бензин";
            // 
            // lblOil
            // 
            this.lblOil.AutoSize = true;
            this.lblOil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOil.Location = new System.Drawing.Point(179, 9);
            this.lblOil.Name = "lblOil";
            this.lblOil.Size = new System.Drawing.Size(120, 21);
            this.lblOil.TabIndex = 0;
            this.lblOil.Text = "Автозаправка";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Salmon;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.picHam);
            this.pnlRight.Controls.Add(this.txBoxCCCount);
            this.pnlRight.Controls.Add(this.txBoxPFCount);
            this.pnlRight.Controls.Add(this.txBoxGMCount);
            this.pnlRight.Controls.Add(this.txBoxHDCount);
            this.pnlRight.Controls.Add(this.txBoxCCPrice);
            this.pnlRight.Controls.Add(this.txBoxPFPrice);
            this.pnlRight.Controls.Add(this.txBoxGMPrice);
            this.pnlRight.Controls.Add(this.txBoxHDPrice);
            this.pnlRight.Controls.Add(this.lblCount);
            this.pnlRight.Controls.Add(this.lblPrice);
            this.pnlRight.Controls.Add(this.chBoxCC);
            this.pnlRight.Controls.Add(this.chBoxPF);
            this.pnlRight.Controls.Add(this.chBoxG);
            this.pnlRight.Controls.Add(this.chBoxHD);
            this.pnlRight.Controls.Add(this.panel2);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(504, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(504, 504);
            this.pnlRight.TabIndex = 2;
            // 
            // picHam
            // 
            this.picHam.Location = new System.Drawing.Point(346, 374);
            this.picHam.Name = "picHam";
            this.picHam.Size = new System.Drawing.Size(100, 95);
            this.picHam.TabIndex = 27;
            this.picHam.TabStop = false;
            // 
            // txBoxCCCount
            // 
            this.txBoxCCCount.Location = new System.Drawing.Point(385, 296);
            this.txBoxCCCount.Name = "txBoxCCCount";
            this.txBoxCCCount.Size = new System.Drawing.Size(93, 23);
            this.txBoxCCCount.TabIndex = 26;
            // 
            // txBoxPFCount
            // 
            this.txBoxPFCount.Location = new System.Drawing.Point(385, 221);
            this.txBoxPFCount.Name = "txBoxPFCount";
            this.txBoxPFCount.Size = new System.Drawing.Size(93, 23);
            this.txBoxPFCount.TabIndex = 25;
            // 
            // txBoxGMCount
            // 
            this.txBoxGMCount.Location = new System.Drawing.Point(385, 141);
            this.txBoxGMCount.Name = "txBoxGMCount";
            this.txBoxGMCount.Size = new System.Drawing.Size(93, 23);
            this.txBoxGMCount.TabIndex = 24;
            // 
            // txBoxHDCount
            // 
            this.txBoxHDCount.Location = new System.Drawing.Point(385, 69);
            this.txBoxHDCount.Name = "txBoxHDCount";
            this.txBoxHDCount.Size = new System.Drawing.Size(93, 23);
            this.txBoxHDCount.TabIndex = 23;
            // 
            // txBoxCCPrice
            // 
            this.txBoxCCPrice.Location = new System.Drawing.Point(271, 296);
            this.txBoxCCPrice.Name = "txBoxCCPrice";
            this.txBoxCCPrice.Size = new System.Drawing.Size(93, 23);
            this.txBoxCCPrice.TabIndex = 22;
            // 
            // txBoxPFPrice
            // 
            this.txBoxPFPrice.Location = new System.Drawing.Point(271, 221);
            this.txBoxPFPrice.Name = "txBoxPFPrice";
            this.txBoxPFPrice.Size = new System.Drawing.Size(93, 23);
            this.txBoxPFPrice.TabIndex = 21;
            // 
            // txBoxGMPrice
            // 
            this.txBoxGMPrice.Location = new System.Drawing.Point(271, 141);
            this.txBoxGMPrice.Name = "txBoxGMPrice";
            this.txBoxGMPrice.Size = new System.Drawing.Size(93, 23);
            this.txBoxGMPrice.TabIndex = 20;
            // 
            // txBoxHDPrice
            // 
            this.txBoxHDPrice.Location = new System.Drawing.Point(271, 69);
            this.txBoxHDPrice.Name = "txBoxHDPrice";
            this.txBoxHDPrice.Size = new System.Drawing.Size(93, 23);
            this.txBoxHDPrice.TabIndex = 19;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCount.Location = new System.Drawing.Point(403, 41);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(58, 19);
            this.lblCount.TabIndex = 18;
            this.lblCount.Text = "Кол-во";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Location = new System.Drawing.Point(295, 41);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(46, 19);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Цена";
            // 
            // chBoxCC
            // 
            this.chBoxCC.AutoSize = true;
            this.chBoxCC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxCC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxCC.Location = new System.Drawing.Point(47, 296);
            this.chBoxCC.Name = "chBoxCC";
            this.chBoxCC.Size = new System.Drawing.Size(99, 23);
            this.chBoxCC.TabIndex = 16;
            this.chBoxCC.Text = "Кока-кола";
            this.chBoxCC.UseVisualStyleBackColor = true;
            // 
            // chBoxPF
            // 
            this.chBoxPF.AutoSize = true;
            this.chBoxPF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxPF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxPF.Location = new System.Drawing.Point(47, 221);
            this.chBoxPF.Name = "chBoxPF";
            this.chBoxPF.Size = new System.Drawing.Size(130, 23);
            this.chBoxPF.TabIndex = 15;
            this.chBoxPF.Text = "Картошка-фри";
            this.chBoxPF.UseVisualStyleBackColor = true;
            // 
            // chBoxG
            // 
            this.chBoxG.AutoSize = true;
            this.chBoxG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxG.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxG.Location = new System.Drawing.Point(47, 141);
            this.chBoxG.Name = "chBoxG";
            this.chBoxG.Size = new System.Drawing.Size(100, 23);
            this.chBoxG.TabIndex = 14;
            this.chBoxG.Text = "Гамбургер";
            this.chBoxG.UseVisualStyleBackColor = true;
            // 
            // chBoxHD
            // 
            this.chBoxHD.AutoSize = true;
            this.chBoxHD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chBoxHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBoxHD.Location = new System.Drawing.Point(47, 69);
            this.chBoxHD.Name = "chBoxHD";
            this.chBoxHD.Size = new System.Drawing.Size(80, 23);
            this.chBoxHD.TabIndex = 13;
            this.chBoxHD.Text = "Хот-дог";
            this.chBoxHD.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblResC3);
            this.panel2.Controls.Add(this.lblResC2);
            this.panel2.Controls.Add(this.lblResC1);
            this.panel2.Location = new System.Drawing.Point(14, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 126);
            this.panel2.TabIndex = 12;
            // 
            // lblResC3
            // 
            this.lblResC3.AutoSize = true;
            this.lblResC3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResC3.Location = new System.Drawing.Point(182, 97);
            this.lblResC3.Name = "lblResC3";
            this.lblResC3.Size = new System.Drawing.Size(44, 25);
            this.lblResC3.TabIndex = 6;
            this.lblResC3.Text = "грн";
            // 
            // lblResC2
            // 
            this.lblResC2.AutoSize = true;
            this.lblResC2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResC2.Location = new System.Drawing.Point(111, 50);
            this.lblResC2.Name = "lblResC2";
            this.lblResC2.Size = new System.Drawing.Size(50, 25);
            this.lblResC2.TabIndex = 5;
            this.lblResC2.Text = "0.00";
            // 
            // lblResC1
            // 
            this.lblResC1.AutoSize = true;
            this.lblResC1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResC1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResC1.Location = new System.Drawing.Point(0, 0);
            this.lblResC1.Name = "lblResC1";
            this.lblResC1.Size = new System.Drawing.Size(98, 25);
            this.lblResC1.TabIndex = 4;
            this.lblResC1.Text = "К оплате:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(207, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Миникафе";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDol)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlChoice.ResumeLayout(false);
            this.pnlChoice.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHam)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblOil;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxOilType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlChoice;
        private System.Windows.Forms.CheckBox chBoxCount;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox boxCost;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.TextBox boxLitr;
        private System.Windows.Forms.CheckBox chBoxCost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblResOil2;
        private System.Windows.Forms.Label lblResOil1;
        private System.Windows.Forms.Label lblResOil3;
        private System.Windows.Forms.CheckBox chBoxCC;
        private System.Windows.Forms.CheckBox chBoxPF;
        private System.Windows.Forms.CheckBox chBoxG;
        private System.Windows.Forms.CheckBox chBoxHD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblResC3;
        private System.Windows.Forms.Label lblResC2;
        private System.Windows.Forms.Label lblResC1;
        private System.Windows.Forms.TextBox txBoxCCCount;
        private System.Windows.Forms.TextBox txBoxPFCount;
        private System.Windows.Forms.TextBox txBoxGMCount;
        private System.Windows.Forms.TextBox txBoxHDCount;
        private System.Windows.Forms.TextBox txBoxCCPrice;
        private System.Windows.Forms.TextBox txBoxPFPrice;
        private System.Windows.Forms.TextBox txBoxGMPrice;
        private System.Windows.Forms.TextBox txBoxHDPrice;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picOil;
        private System.Windows.Forms.PictureBox picHam;
        private System.Windows.Forms.PictureBox picDol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRes;
    }
}

