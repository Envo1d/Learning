using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для OnlyNum.xaml
    /// </summary>
    public partial class OnlyNum : Window
    {
        public OnlyNum()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string keyInput = e.Key.ToString();
            char ch = keyInput[0];
            if (keyInput.Length == 2)
                ch = keyInput[1];
            else if (keyInput.Length == 7)
                ch = keyInput[6];
                e.Handled = !(Char.IsDigit(ch));
        }
    }
}
