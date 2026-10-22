using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHW2
{
    public partial class Form1 : Form
    {
        private string[] petrlType = new string[]{ "АИ-92", "АИ-95", "АИ-95+", "Дизель", "Газ" };
        private double[] petrlCost = new double[] { 24.1, 25.14, 26.77, 24.48, 12.42 };
        private double[] foodCost = new double[] { 4.00 /*Хот-дог*/, 5.40 /*Гамбургер*/, 7.20 /*Картошка-фри*/, 4.40 /*Кока-кола*/ };
        private double oilResPrice;
        private double HDResPrice = 0;
        private double GMResPrice = 0;
        private double PFResPrice = 0;
        private double CCResPrice = 0;
        private double totalDaySum = 0;
        private Timer timer = new Timer();
        public Form1()
        { 
            InitializeComponent();
            Text = "BestOil";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            cmboxOilType.Items.AddRange(petrlType);
            cmboxOilType.SelectedIndex = 0;
            cmboxOilType.SelectedIndexChanged += boxOilIndexChange;
            boxPrice.Text = $"{petrlCost[0]}";
            boxLitr.TextChanged += boxLTextChange;
            boxCost.TextChanged += boxCostTextChange;
            boxPrice.Enabled = false;
            txBoxHDPrice.Text = $"{foodCost[0]},00"; txBoxHDPrice.Enabled = false; txBoxHDCount.Text = "0"; txBoxHDCount.Enabled = false;
            txBoxGMPrice.Text = $"{foodCost[1]}0"; txBoxGMPrice.Enabled = false; txBoxGMCount.Text = "0"; txBoxGMCount.Enabled = false;
            txBoxPFPrice.Text = $"{foodCost[2]}0"; txBoxPFPrice.Enabled = false; txBoxPFCount.Text = "0"; txBoxPFCount.Enabled = false;
            txBoxCCPrice.Text = $"{foodCost[3]}0";txBoxCCPrice.Enabled = false; txBoxCCCount.Text = "0"; txBoxCCCount.Enabled = false;
            chBoxHD.CheckedChanged += chBoxHDChange;
            chBoxG.CheckedChanged += chBoxGChange;
            chBoxPF.CheckedChanged += chBoxPFChange;
            chBoxCC.CheckedChanged += chBoxCCChange;
            txBoxHDCount.TextChanged += txBoxHDTextChange;
            txBoxGMCount.TextChanged += txBoxGMTextChange;
            txBoxPFCount.TextChanged += txBoxPFTextChange;
            txBoxCCCount.TextChanged += txBoxCCTextChange;
            picOil.Image = Image.FromFile("oil.png");
            picOil.SizeMode = PictureBoxSizeMode.StretchImage;
            picOil.Width = 100;
            picOil.Height = 100;
            picHam.Image = Image.FromFile("hamburger.png");
            picHam.SizeMode = PictureBoxSizeMode.StretchImage;
            picHam.Height = 100;
            picHam.Width = 100;
            picDol.Image = Image.FromFile("dollar.png");
            picDol.SizeMode = PictureBoxSizeMode.StretchImage;
            picDol.Height = 100;
            picDol.Width = 100;
            timer.Interval = 10000;
            timer.Tick += timerTick;
        }
        #region Oil
        private void boxOilIndexChange(object sender, EventArgs e)
        {
            boxPrice.Text = $"{petrlCost[cmboxOilType.SelectedIndex]}";
            if (chBoxCost.Checked && boxCost.Text != "")
                boxCostTextChange(null, null);
            if (chBoxCount.Checked && boxLitr.Text != "")
                boxLTextChange(null, null);
        }

        private void boxLTextChange(object sender, EventArgs e)
        {
            chBoxCount.Checked = true;
            if (chBoxCost.Checked) chBoxCost.Checked = false;
            chBoxCost.Enabled = false;
            boxCost.Enabled = false;
            lblCost.Enabled = false;
            double res = 0;
            try { res = Convert.ToDouble(boxLitr.Text); }catch(Exception exc) { boxLitr.Text = ""; };
            oilResPrice = res * petrlCost[cmboxOilType.SelectedIndex];
            oilResPrice = Math.Round(oilResPrice,2);
            lblResOil2.Text = $"{oilResPrice}";
        }

        private void boxCostTextChange(object sender, EventArgs e)
        {
            chBoxCost.Checked = true;
            if (chBoxCount.Checked) chBoxCount.Checked = false;
            chBoxCount.Enabled = false;
            boxLitr.Enabled = false;
            lblL.Enabled = false;
            double res = 0;
            try { res = Convert.ToDouble(boxCost.Text); } catch (Exception exc) { boxCost.Text = ""; };
            oilResPrice = res;
            lblResOil2.Text = $"{Math.Round(res / petrlCost[cmboxOilType.SelectedIndex], 1)}";
        }

        private void chBoxCost_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxCost.Checked)
            {
                chBoxCount.Checked = false;
                lblResOil1.Text = "К выдаче:";
                lblResOil3.Text = "л";
            }
        }

        private void chBoxCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxCount.Checked)
            {
                chBoxCost.Checked = false;
                lblResOil1.Text = "К оплате:";
                lblResOil3.Text = "грн";
            }
        }
        #endregion
        #region Cafe
        private void chBoxHDChange(object sender, EventArgs e)
        {
            if (chBoxHD.Checked)
                txBoxHDCount.Enabled = true;
            else { txBoxHDCount.Enabled = false; txBoxHDCount.Text = "0"; txBoxHDTextChange(null, null); }
        }
        private void chBoxGChange(object sender, EventArgs e)
        {
            if (chBoxG.Checked)
                txBoxGMCount.Enabled = true;
            else { txBoxGMCount.Enabled = false; txBoxGMCount.Text = "0"; txBoxGMTextChange(null, null); }
        }
        private void chBoxPFChange(object sender, EventArgs e)
        {
            if (chBoxPF.Checked)
                txBoxPFCount.Enabled = true;
            else { txBoxPFCount.Enabled = false; txBoxPFCount.Text = "0"; txBoxPFTextChange(null, null); }
        }
        private void chBoxCCChange(object sender, EventArgs e)
        {
            if (chBoxCC.Checked)
                txBoxCCCount.Enabled = true;
            else { txBoxCCCount.Enabled = false; txBoxCCCount.Text = "0"; txBoxCCTextChange(null, null); }
        }
        private void txBoxHDTextChange(object sender, EventArgs e)
        {
            int count = 0;
            try { count = Convert.ToInt32(txBoxHDCount.Text); } catch (Exception ex) { txBoxHDCount.Text = "0"; }
            double res = foodCost[0] * count;
            HDResPrice = Math.Round(res, 2);
            lblResC2.Text = $"{HDResPrice + GMResPrice + PFResPrice + CCResPrice}";
        }
        private void txBoxGMTextChange(object sender, EventArgs e)
        {
            int count = 0;
            try { count = Convert.ToInt32(txBoxGMCount.Text); } catch (Exception ex) { txBoxGMCount.Text = "0"; }
            double res = foodCost[1] * count;
            GMResPrice = Math.Round(res, 2);
            lblResC2.Text = $"{HDResPrice + GMResPrice + PFResPrice + CCResPrice}";
        }
        private void txBoxPFTextChange(object sender, EventArgs e)
        {
            int count = 0;
            try { count = Convert.ToInt32(txBoxPFCount.Text); } catch (Exception ex) { txBoxPFCount.Text = "0"; }
            double res = foodCost[2] * count;
            PFResPrice = Math.Round(res, 2);
            lblResC2.Text = $"{HDResPrice + GMResPrice + PFResPrice + CCResPrice}";
        }
        private void txBoxCCTextChange(object sender, EventArgs e)
        {
            int count = 0;
            try { count = Convert.ToInt32(txBoxCCCount.Text); } catch (Exception ex) { txBoxCCCount.Text = "0"; }
            double res = foodCost[3] * count;
            CCResPrice = Math.Round(res, 2);
            lblResC2.Text = $"{HDResPrice + GMResPrice + PFResPrice + CCResPrice}";
        }
        #endregion
        #region ToPay
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double tmpres = Math.Round(oilResPrice + HDResPrice + GMResPrice + PFResPrice + CCResPrice, 2);
            if (tmpres != 0)
            {
                lblRes.Text = $"{tmpres}";
                timer.Start();
            }
            else
                MessageBox.Show("Не введена информация", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void timerTick(object sender,EventArgs e)
        {
            timer.Stop();
            DialogResult res = MessageBox.Show("Очистить форму?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (cmboxOilType.SelectedIndex != 0) { cmboxOilType.SelectedIndex = 0; boxPrice.Text = $"{petrlCost[0]}"; }
                txBoxHDPrice.Text = $"{foodCost[0]},00"; txBoxHDPrice.Enabled = false; txBoxHDCount.Text = "0"; txBoxHDCount.Enabled = false;
                txBoxGMPrice.Text = $"{foodCost[1]}0"; txBoxGMPrice.Enabled = false; txBoxGMCount.Text = "0"; txBoxGMCount.Enabled = false;
                txBoxPFPrice.Text = $"{foodCost[2]}0"; txBoxPFPrice.Enabled = false; txBoxPFCount.Text = "0"; txBoxPFCount.Enabled = false;
                txBoxCCPrice.Text = $"{foodCost[3]}0"; txBoxCCPrice.Enabled = false; txBoxCCCount.Text = "0"; txBoxCCCount.Enabled = false;
                boxLitr.Text = "";
                boxCost.Text = "";
                if (chBoxCount.Checked) chBoxCount.Checked = false; chBoxCount_CheckedChanged(null, null);
                if (chBoxCost.Checked) chBoxCost.Checked = false; chBoxCost_CheckedChanged(null, null);
                if (!chBoxCount.Enabled) chBoxCount.Enabled = true;
                if (!chBoxCost.Enabled) chBoxCost.Enabled = true;
                if (!boxCost.Enabled) boxCost.Enabled = true;
                if (!boxLitr.Enabled) boxLitr.Enabled = true;
                if (chBoxCC.Checked) chBoxCC.Checked = false; chBoxCCChange(null, null);
                if (chBoxPF.Checked) chBoxPF.Checked = false; chBoxPFChange(null, null);
                if (chBoxHD.Checked) chBoxHD.Checked = false; chBoxHDChange(null, null);
                if (chBoxG.Checked) chBoxG.Checked = false; chBoxGChange(null, null);
                totalDaySum += Convert.ToDouble(lblRes.Text);
                lblResC2.Text = "0,00";
                lblResOil2.Text = "0,00";
                lblRes.Text = "0,00";
                oilResPrice = 0;
                HDResPrice = 0;
                PFResPrice = 0;
                CCResPrice = 0;
                GMResPrice = 0;
            }
            else timer.Start();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"Выручка за день: {totalDaySum} грн", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
