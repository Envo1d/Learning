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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Window
    {
        private string login;
        private string correctPassword;
        private string password = "";
        public Entrance(UserInfo user)
        {
            InitializeComponent();
            login = user.Login;
            correctPassword = user.Password;
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            lLogin.Foreground = Brushes.Black;
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            lPassword.Foreground = Brushes.Black;
            if (Password.Text.Length != 0)
            {
                if (Password.Text[Password.Text.Length - 1] != '•')
                    password += Password.Text[Password.Text.Length - 1];
                Password.Text = Password.Text.Replace(Password.Text[Password.Text.Length - 1], '•');
            }
            else
                password = "";
            Password.CaretIndex = Password.Text.Length;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == login)
            {
                if(Password.Text != "" && password == correctPassword)
                {
                    (this.Owner as MainWindow).isLogged = true;
                    this.Close();
                }
                else
                {
                    lPassword.Foreground = Brushes.Red;
                    Password.Text = "";
                    password = "";
                }
            }
            else
            {
                lLogin.Foreground = Brushes.Red;
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Ok_Click(null, null);
            }
        }
    }
}
