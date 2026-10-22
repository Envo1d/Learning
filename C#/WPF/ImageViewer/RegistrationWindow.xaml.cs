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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text != "")
            {
                if(Password.Text != "")
                {

                    if(PasswordAgain.Text != "" && PasswordAgain.Text == Password.Text)
                    {
                        if(Name.Text != "")
                        {
                            if(Surname.Text != "")
                            {
                                UserInfo info = new UserInfo { Name = Name.Text, Surname = Surname.Text, Login = Login.Text, Password = Password.Text };
                                (this.Owner as MainWindow).user = info;
                                this.Close();
                            }
                            else
                            {
                                lSurname.Foreground = Brushes.Red;
                            }
                        }
                        else
                        {
                            lName.Foreground = Brushes.Red;
                        }
                    }
                    else
                    {
                        lPassAgain.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    lPassword.Foreground = Brushes.Red;
                }
            }
            else
            {
                lLogin.Foreground = Brushes.Red;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            lLogin.Foreground = Brushes.Black;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            lPassword.Foreground = Brushes.Black;
        }

        private void PasswordAgain_TextChanged(object sender, TextChangedEventArgs e)
        {
            lPassAgain.Foreground = Brushes.Black;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            lName.Foreground = Brushes.Black;
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            lSurname.Foreground = Brushes.Black;
        }
    }
}
