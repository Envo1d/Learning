using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для Rainbow.xaml
    /// </summary>
    public partial class Rainbow : Window
    {
        enum Colors
        {
            Red,
            Orange,
            Yellow,
            Green,
            LightBlue,
            Blue,
            Violet,
            Aqua,
            DeepPink,
            Gray
        }

        Colors state = 0;

        public Rainbow()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));

            if ((int)state > 9 )
                state++;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Enum.GetName(state));
            state++;
            if ((int)state > 9)
                state = 0;
        }
    }
}
