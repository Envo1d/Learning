using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Wpf3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        private Message message;
        public Message Message => message;
        public MainWindow()
        {
            InitializeComponent();
            message = new Message();
            DataContext = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Regex.IsMatch(emailTxb.Text,emailPattern,RegexOptions.IgnoreCase))
            {
                if(string.IsNullOrEmpty( nameTxb.Text))
                {
                    MessageBox.Show("Name is empty", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(string.IsNullOrEmpty(commTxb.Text))
                    {
                        MessageBox.Show("Comment is empty", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Sent successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        nameTxb.Text = emailTxb.Text = commTxb.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Email", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Message : DependencyObject
    {
        public static readonly DependencyProperty NameProp = DependencyProperty.Register("Name", typeof(string), typeof(Message), new PropertyMetadata(""));
        public static readonly DependencyProperty EmailProp = DependencyProperty.Register("Email", typeof(string), typeof(Message), new PropertyMetadata(""));
        public static readonly DependencyProperty CommentProp = DependencyProperty.Register("Comment", typeof(string), typeof(Message), new PropertyMetadata(""));

        public string Name
        {
            get { return (string)GetValue(NameProp); }
            set { SetValue(NameProp, value); }
        }
        public string Email
        {
            get { return (string)GetValue(EmailProp); }
            set { SetValue(EmailProp, value); }
        }
        public string Comment
        {
            get { return (string)GetValue(CommentProp); }
            set { SetValue(CommentProp, value); }
        }

        //public override string ToString()
        //{
        //    return $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Comment)}: {Comment}";
        //}
    }
}
