using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
using Wpf4.Data;

namespace Wpf4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookDbContext bookDb;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            bookDb = new BookDbContext();
            LoadData();
        }

        public void LoadData()
        {
            listbox.Items.Clear();
            List<Book> books;
            books = bookDb.Books.ToList();
            if (books.Count != 0)
                foreach (var b in books)
                {
                    ListBoxItem itm = new ListBoxItem();
                    StackPanel pnl = new StackPanel();
                    pnl.Orientation = Orientation.Horizontal;
                    TextBlock b1 = new TextBlock();
                    b1.FontFamily = new FontFamily("Helvetica");
                    b1.Text = b.Name;
                    b1.FontSize = 15;
                    TextBlock b2 = new TextBlock();
                    b2.FontFamily = new FontFamily("Helvetica");
                    b2.Text = b.Price;
                    b2.FontSize = 15;
                    Image img = new Image();
                    BitmapImage bitmap;
                    try
                    {
                        bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(b.ImageUrl, UriKind.Absolute);
                        bitmap.EndInit();
                    }
                    catch(Exception m) 
                    {
                        bitmap = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/error.png", UriKind.Absolute));
                    }
                    img.Source = bitmap;
                    img.Width = 40;
                    b1.Margin = new Thickness(10, 0, 0, 0);
                    b2.Margin = new Thickness(10, 0, 0, 0);
                    pnl.Children.Add(img);
                    pnl.Children.Add(b1);
                    pnl.Children.Add(b2);
                    itm.Content = pnl;
                    itm.DataContext = b;
                    listbox.Items.Add(itm);
                }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if(listbox.SelectedIndex != -1)
            {
                bookDb.Books.Remove((listbox.SelectedItem as ListBoxItem).DataContext as Book);
                bookDb.SaveChanges();
                listbox.Items.Remove(listbox.SelectedItem);
                GC.Collect();
                Message msg = new Message();
                msg.ShowDialog();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Log login = new Log();
            if (login.ShowDialog() == true)
            {
                Admin admin = new Admin();
                admin.Owner = this;
                admin.Show();
            }
        }
    }
}
