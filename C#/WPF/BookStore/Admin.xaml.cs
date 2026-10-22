using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Wpf4.Data;

namespace Wpf4
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Book InBook
        {
            get { return (Book)GetValue(InBookProperty); }
            set { SetValue(InBookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InBook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InBookProperty =
            DependencyProperty.Register("InBook", typeof(Book), typeof(Admin), new PropertyMetadata(null));
        private readonly BookDbContext bookDb;
        public Admin()
        {
            InitializeComponent();

            InBook = new Book();
            List<Book> books;
            DataContext = this;
            bookDb = new BookDbContext();

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
                    TextBlock b2 = new TextBlock();
                    b2.FontFamily = new FontFamily("Helvetica");
                    b2.Text = b.Price;
                    TextBlock b3 = new TextBlock();
                    b3.Text = b.ImageUrl;
                    b3.FontFamily = new FontFamily("Helvetica");
                    b1.Margin = new Thickness(Left = 5);
                    b2.Margin = new Thickness(Left = 5);
                    b3.Margin = new Thickness(Left = 5);
                    pnl.Children.Add(b1);
                    pnl.Children.Add(b2);
                    pnl.Children.Add(b3);
                    itm.Content = pnl;
                    itm.DataContext = b;
                    ListBox.Items.Add(itm);
                }
            GC.Collect();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Title.Text) && !string.IsNullOrEmpty(Image.Text) && !string.IsNullOrEmpty(Price.Text))
            {
                bookDb.Books.Add(InBook);
                bookDb.SaveChanges();
                ListBoxItem itm = new ListBoxItem();
                StackPanel pnl = new StackPanel();
                pnl.Orientation = Orientation.Horizontal;
                TextBlock b1 = new TextBlock();
                b1.Text = Title.Text;
                TextBlock b2 = new TextBlock();
                b2.Text = Price.Text;
                TextBlock b3 = new TextBlock();
                b3.Text = Image.Text;
                b1.Margin = new Thickness(Left = 5);
                b2.Margin = new Thickness(Left = 5);
                b3.Margin = new Thickness(Left = 5);
                pnl.Children.Add(b1);
                pnl.Children.Add(b2);
                pnl.Children.Add(b3);
                itm.Content = pnl;
                ListBox.Items.Add(itm);
                GC.Collect();
                Title.Text = Image.Text = Price.Text = "";
                (Owner as MainWindow).LoadData();
            }
        }

        private void ListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                bookDb.Books.Remove((ListBox.SelectedItem as ListBoxItem).DataContext as Book);
                bookDb.SaveChanges();
                ListBox.Items.Remove(ListBox.SelectedItem);
                (Owner as MainWindow).LoadData();
                GC.Collect();
            }
        }
    }
}
