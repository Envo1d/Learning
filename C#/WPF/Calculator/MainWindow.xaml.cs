using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPMClicked = false;
        private bool isComaClicked = false;
        private bool isAfterOp = false;
        private byte fontBgResizeCount = 0;
        private byte fontSmResizeCount = 0;
        private bool isAfterEquals = false;
        private decimal prevNum = 0;
        public MainWindow()
        {
            InitializeComponent();
            #region Btns
            btnPercent.MouseEnter += BtnEnter;
            btnPercent.MouseLeave += BtnLeave;
            btnCE.Click += CEClick;
            btnCE.MouseEnter += BtnEnter;
            btnCE.MouseLeave += BtnLeave;
            btnC.Click += CClick;
            btnC.MouseEnter += BtnEnter;
            btnC.MouseLeave += BtnLeave;
            btnBackspace.Click += BtnBackspaceClick;
            btnBackspace.MouseEnter += BtnEnter;
            btnBackspace.MouseLeave += BtnLeave;
            btnFract.MouseEnter += BtnEnter;
            btnFract.MouseLeave += BtnLeave;
            btnPow.MouseEnter += BtnEnter;
            btnPow.MouseLeave += BtnLeave;
            btnSqrt.MouseEnter += BtnEnter;
            btnSqrt.MouseLeave += BtnLeave;
            btnDivide.Click += BtnDivideClick;
            btnDivide.MouseEnter += BtnEnter;
            btnDivide.MouseLeave += BtnLeave;
            btnNumSeven.Click += BtnNumClick;
            btnNumSeven.MouseEnter += BtnEnter;
            btnNumSeven.MouseLeave += BtnLeave;
            btnNumEight.Click += BtnNumClick;
            btnNumEight.MouseEnter += BtnEnter;
            btnNumEight.MouseLeave += BtnLeave;
            btnNumNine.Click += BtnNumClick;
            btnNumNine.MouseEnter += BtnEnter;
            btnNumNine.MouseLeave += BtnLeave;
            btnMultiply.Click += BtnMultiplyClick;
            btnMultiply.MouseEnter += BtnEnter;
            btnMultiply.MouseLeave += BtnLeave;
            btnNumFour.Click += BtnNumClick;
            btnNumFour.MouseEnter += BtnEnter;
            btnNumFour.MouseLeave += BtnLeave;
            btnNumFive.Click += BtnNumClick;
            btnNumFive.MouseEnter += BtnEnter;
            btnNumFive.MouseLeave += BtnLeave;
            btnNumSix.Click += BtnNumClick;
            btnNumSix.MouseEnter += BtnEnter;
            btnNumSix.MouseLeave += BtnLeave;
            btnSbtr.Click += BtnSbtrClick;
            btnSbtr.MouseEnter += BtnEnter;
            btnSbtr.MouseLeave += BtnLeave;
            btnNumOne.Click += BtnNumClick;
            btnNumOne.MouseEnter += BtnEnter;
            btnNumOne.MouseLeave += BtnLeave;
            btnNumTwo.Click += BtnNumClick;
            btnNumTwo.MouseEnter += BtnEnter;
            btnNumTwo.MouseLeave += BtnLeave;
            btnNumThree.Click += BtnNumClick;
            btnNumThree.MouseEnter += BtnEnter;
            btnNumThree.MouseLeave += BtnLeave;
            btnPlus.Click += BtnPlusClick;
            btnPlus.MouseEnter += BtnEnter;
            btnPlus.MouseLeave += BtnLeave;
            btnNumPM.Click += BtnNumClick;
            btnNumPM.MouseEnter += BtnEnter;
            btnNumPM.MouseLeave += BtnLeave;
            btnNumZero.Click += BtnNumClick;
            btnNumZero.MouseEnter += BtnEnter;
            btnNumZero.MouseLeave += BtnLeave;
            btnNumComa.Click += BtnNumClick;
            btnNumComa.MouseEnter += BtnEnter;
            btnNumComa.MouseLeave += BtnLeave;
            btnEquals.Click += BtnEqualsClick;
            btnEquals.MouseEnter += BtnEnter;
            btnEquals.MouseLeave += BtnLeave;
            #endregion
        }
        private void CheckSize()
        {
            FormattedText strBg = new FormattedText(txtBlBg.Text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Cambria Math"), 55, Brushes.White);
            if (strBg.Width >= txtBlBg.Width && fontBgResizeCount < 5)
            {
                txtBlBg.FontSize -= 5;
                fontBgResizeCount++;
            }
            FormattedText strSm = new FormattedText(txtBlBg.Text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Cambria Math"), 20, Brushes.White);
            if (strSm.Width >= txtBlSm.Width && fontSmResizeCount < 5)
            {
                txtBlBg.FontSize -= 5;
                fontSmResizeCount++;
            }
        }
        private void NoEqualsOperation()
        {
            StringBuilder num = new StringBuilder();
            StringBuilder op = new StringBuilder();

            for (int i = 0; i < txtBlSm.Text.Length; i++)
            {
                if (txtBlSm.Text[i] == '+' || txtBlSm.Text[i] == '-' || txtBlSm.Text[i] == '÷' || txtBlSm.Text[i] == '×')
                {
                    if (i != 0)
                        if (txtBlSm.Text[i - 1] != '+' || txtBlSm.Text[i - 1] != '-' || txtBlSm.Text[i - 1] != '÷' || txtBlSm.Text[i - 1] != '×')
                            op.Append(txtBlSm.Text[i]);
                        else continue;
                    else num.Append(txtBlSm.Text[i]);
                }
                else num.Append(txtBlSm.Text[i]);
            }

            string number = num.ToString();
            string operation = op.ToString();

            decimal result = Convert.ToDecimal(number);
            if (operation == "+")
                result = result + Convert.ToDecimal(txtBlBg.Text);
            else if (operation == "-")
                result = result - Convert.ToDecimal(txtBlBg.Text);
            else if (operation == "÷")
                if (Convert.ToDecimal(txtBlBg.Text) != 0)
                    result = result / Convert.ToDecimal(txtBlBg.Text);
                else return;
            else if (operation == "×")
                result = result * Convert.ToDecimal(txtBlBg.Text);
            decimal tmp = (int)result;
            if (tmp == result)
                result = tmp;
            txtBlSm.Text = $"{result}";
            txtBlBg.Text = $"{result}";
            CheckSize();

        }
        private void BtnEqualsClick(object sender, RoutedEventArgs e)
        {
            if (txtBlSm.Text == "")
                return;
            if (prevNum != 0)
            {
                txtBlSm.Text = txtBlSm.Text.Replace($"{prevNum}", txtBlBg.Text);
            }
            StringBuilder num = new StringBuilder();
            StringBuilder op = new StringBuilder();
            string prev = "";
            if (prevNum == 0)
                for (int i = 0; i < txtBlSm.Text.Length; i++)
                {
                    if (txtBlSm.Text[i] == '+' || txtBlSm.Text[i] == '-' || txtBlSm.Text[i] == '÷' || txtBlSm.Text[i] == '×')
                    {
                        if (i != 0)
                            if (txtBlSm.Text[i - 1] != '+' || txtBlSm.Text[i - 1] != '-' || txtBlSm.Text[i - 1] != '÷' || txtBlSm.Text[i - 1] != '×')
                            { op.Append(txtBlSm.Text[i]); prev = num.ToString(); }
                            else continue;
                        else num.Append(txtBlSm.Text[i]);
                    }
                    else num.Append(txtBlSm.Text[i]);
                }
            else
                for (int i = 0; i < txtBlSm.Text.Length; i++)
                {
                    if (txtBlSm.Text[i] == '+' || txtBlSm.Text[i] == '-' || txtBlSm.Text[i] == '÷' || txtBlSm.Text[i] == '×')
                    {
                        if (i != 0)
                            if (txtBlSm.Text[i - 1] != '+' || txtBlSm.Text[i - 1] != '-' || txtBlSm.Text[i - 1] != '÷' || txtBlSm.Text[i - 1] != '×')
                            { op.Append(txtBlSm.Text[i]); prev=num.ToString(); num.Clear(); }
                            else continue;
                        else
                        {
                            num.Append(txtBlSm.Text[i]);
                        }
                    }
                    else num.Append(txtBlSm.Text[i]);
                }

            string number = num.ToString();
            number = number.Replace("=", "");
            string operation = op.ToString();
            decimal result = Convert.ToDecimal(number);
            if (prevNum == 0)
            {
                if (operation == "+")
                    result = result + Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "-")
                    result = result - Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "÷")
                    result = result / Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "×")
                    result = result * Convert.ToDecimal(txtBlBg.Text);
            }
            else
            {
                if (operation == "+")
                    result = result + Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "-")
                    result = result - Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "÷")
                    result = result / Convert.ToDecimal(txtBlBg.Text);
                else if (operation == "×")
                    result = result * Convert.ToDecimal(txtBlBg.Text);
            }
            if (prevNum == 0)
                txtBlSm.Text += txtBlBg.Text + "=";
            prevNum = Convert.ToDecimal(prev);
            txtBlBg.Text = $"{result}";
            isAfterEquals = true;
            CheckSize();
        }
        private void BtnPlusClick(object sender, RoutedEventArgs e)
        {
            if (isAfterEquals)
            {
                txtBlBg.Text = "0";
                txtBlSm.Text = "";
                isAfterEquals = false;
                prevNum = 0;
                return;
            }
            //if (isAfterFract || isAfterPow || isAfterSqrt || isAfterPercent)
            //{
            //    txtBlSm.Text += "+";
            //    isAfterFract = false;
            //    isAfterPow = false;
            //    isAfterPercent = false;
            //    isAfterSqrt = false;
            //    txtBlBg.Text = "0";
            //}
            if (txtBlSm.Text.Length == 0)
            {
                txtBlSm.Text = txtBlBg.Text + "+";
                txtBlBg.Text = "0";
            }
            else
            {
                NoEqualsOperation();
                isAfterOp = true;
                txtBlSm.Text += "+";
            }
            isComaClicked = false;
            CheckSize();
        }
        private void BtnSbtrClick(object sender, RoutedEventArgs e)
        {
            if (isAfterEquals)
            {
                txtBlBg.Text = "0";
                txtBlSm.Text = "";
                isAfterEquals = false;
                prevNum = 0;
                return;
            }
            if (txtBlSm.Text.Length == 0)
            {
                txtBlSm.Text = txtBlBg.Text + "-";
                txtBlBg.Text = "0";
            }
            //else if (isAfterFract || isAfterPow || isAfterSqrt || isAfterPercent)
            //{
            //    txtBlSm.Text += "-";
            //    isAfterFract = false;
            //    isAfterPow = false;
            //    isAfterPercent = false;
            //    isAfterSqrt = false;
            //    txtBlBg.Text = "0";
            //}
            else
            {
                NoEqualsOperation();
                isAfterOp = true;
                txtBlSm.Text += "-";
            }
            isComaClicked = false;
            CheckSize();
        }
        private void BtnMultiplyClick(object sender, RoutedEventArgs e)
        {
            if (isAfterEquals)
            {
                txtBlBg.Text = "0";
                txtBlSm.Text = "";
                isAfterEquals = false;
                prevNum = 0;
                return;
            }
            if (txtBlSm.Text.Length == 0)
            {
                txtBlSm.Text = txtBlBg.Text + "×";
                txtBlBg.Text = "0";
            }
            //else if (isAfterFract || isAfterPow || isAfterSqrt || isAfterPercent)
            //{
            //    txtBlSm.Text += "×";
            //    isAfterFract = false;
            //    isAfterPow = false;
            //    isAfterPercent = false;
            //    isAfterSqrt = false;
            //    txtBlBg.Text = "0";
            //}
            else
            {
                NoEqualsOperation();
                isAfterOp = true;
                txtBlSm.Text += "×";
            }
            isComaClicked = false;
            CheckSize();
        }
        private void BtnNumClick(object sender, RoutedEventArgs e)
        {
            if(isAfterEquals)
            {
                txtBlBg.Text = "0";
                txtBlSm.Text = "";
                isAfterEquals = false;
                prevNum = 0;
            }
            if (txtBlBg.Text == "0")
            {
                if ((sender as Button).Name.Contains("PM"))
                    return;
                if (!(sender as Button).Name.Contains("Coma"))
                    txtBlBg.Text = (sender as Button).Content.ToString();
                else
                {
                    if (isComaClicked == false)
                    {
                        isComaClicked = true;
                        txtBlBg.Text += ",";
                    }
                }
            }
            else
            {
                if ((sender as Button).Name.Contains("Coma"))
                {
                    if (isComaClicked == false)
                    {
                        if (!isAfterOp)
                        {
                            isComaClicked = true;
                            txtBlBg.Text += ",";
                        }
                        else
                        {
                            isComaClicked = true;
                            txtBlBg.Text = "0,";
                            isAfterOp = false;
                        }
                    }
                }
                else
                {
                    if ((sender as Button).Name.Contains("PM"))
                    {
                        if (!isPMClicked && txtBlBg.Text[0] == '-')
                            txtBlBg.Text = txtBlBg.Text.Remove(0, 1);
                        else
                        {
                            isPMClicked = !isPMClicked;
                            if (isPMClicked)
                                txtBlBg.Text = txtBlBg.Text.Insert(0, "-");
                            else
                                txtBlBg.Text = txtBlBg.Text.Remove(0, 1);
                        }
                    }
                    else
                    {
                        if (!isAfterOp)
                        {
                            txtBlBg.Text += (sender as Button).Content;
                        }
                        else
                        {
                            txtBlBg.Text = (sender as Button).Content.ToString();
                            isAfterOp = false;
                        }
                    }
                }
            }
            prevNum = 0;
            CheckSize();
        }
        private void BtnDivideClick(object sender, RoutedEventArgs e)
        {
            if (isAfterEquals)
            {
                txtBlBg.Text = "0";
                txtBlSm.Text = "";
                isAfterEquals = false;
                prevNum = 0;
                return;
            }
            if (txtBlSm.Text.Length == 0)
            {
                txtBlSm.Text = txtBlBg.Text + "÷";
                txtBlBg.Text = "0";
            }
            else
            {
                NoEqualsOperation();
                isAfterOp = true;
                txtBlSm.Text += "÷";
            }
            isComaClicked = false;
            CheckSize();
        }
        private void CEClick(object sender, EventArgs e)
        {
            txtBlBg.Text = "0";
            isComaClicked = false;
            isPMClicked = false;
            isAfterOp = false;
            isAfterEquals = false;
            prevNum = 0;
        }
        private void CClick(object sender, EventArgs e)
        {
            txtBlBg.Text = "0";
            txtBlSm.Text = "";
            isComaClicked = false;
            isPMClicked = false;
            isAfterOp = false;
            isAfterEquals = false;
            prevNum = 0;
        }
        private void BtnBackspaceClick(object sender, EventArgs e)
        {
            if (txtBlBg.Text.Length != 1)
                txtBlBg.Text = txtBlBg.Text.Remove(txtBlBg.Text.Length - 1, 1);
            else txtBlBg.Text = "0";
        }
        private void BtnEnter(object sender, EventArgs e)
        {
            if (!(sender as Button).Name.Contains("Equals"))
                (sender as Button).Background = Brushes.DarkGray;
            else
                (sender as Button).Background = Brushes.DarkBlue;
        }
        private void BtnLeave(object sender, EventArgs e)
        {
            if (!(sender as Button).Name.Contains("Equals"))
                if ((sender as Button).Name.Contains("Num"))
                    (sender as Button).Background = Brushes.Black;
                else
                    (sender as Button).Background = Brushes.DimGray;
            else
                (sender as Button).Background = Brushes.DarkSlateBlue;
        }
    }
}