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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class UserInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public partial class MainWindow : Window
    {
        private bool isFirstStart = false;
        private bool isPathSet = false;
        public UserInfo user { get; set; } = null;
        public bool isLogged = false;
        private string path = "";
        private List<string> files;
        private int imageCount;
        public MainWindow()
        {
            InitializeComponent();
            using (FileStream stream = new FileStream("usrinfo", FileMode.OpenOrCreate))
            {
                if(stream.Length==0)
                {
                    isFirstStart = true;
                }
            }
            using (FileStream stream = new FileStream("path", FileMode.OpenOrCreate))
            {
                if (stream.Length != 0)
                {
                    isPathSet = true;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isFirstStart)
            {
                RegistrationWindow reg = new RegistrationWindow();
                reg.Owner = this;
                this.Visibility = Visibility.Hidden;
                reg.ShowDialog();
                if (user != null)
                {
                    using (StreamWriter sw = new StreamWriter("usrinfo", false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(user.Login);
                        sw.WriteLine(user.Password);
                        sw.WriteLine(user.Name);
                        sw.WriteLine(user.Surname);
                    }
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                user = new UserInfo();
                using(StreamReader sr = new StreamReader(("usrinfo"), System.Text.Encoding.Default))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 0)
                            user.Login = sr.ReadLine();
                        else if (i == 1)
                            user.Password = sr.ReadLine();
                        else if (i == 2)
                            user.Name = sr.ReadLine();
                        else if (i == 3)
                            user.Surname = sr.ReadLine();
                    }
                }
                Entrance entrance = new Entrance(user);
                entrance.Owner = this;
                this.Visibility = Visibility.Hidden;
                entrance.ShowDialog();
                if (isLogged)
                {
                    this.Visibility = Visibility.Visible;
                    if (isPathSet)
                    {
                        using (StreamReader sw = new StreamReader("path"))
                        {
                            path = sw.ReadLine();
                        }
                        if (CheckAll())
                        {
                            SliderNum.Maximum = imageCount - 1;
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) && result == System.Windows.Forms.DialogResult.OK)
            {
                path = folderBrowser.SelectedPath;
                if (CheckAll())
                {
                    using (StreamWriter sw = new StreamWriter("path", false, System.Text.Encoding.Default))
                    {
                        sw.Write(path);
                        isPathSet = true;
                    }
                    SliderNum.Maximum = imageCount - 1;
                }
            }
        }
        private bool CheckAll()
        {
            files = new List<string>();
            files.AddRange(Directory.GetFiles(path));
            files = (from f in files where f.Contains(".jpg") || f.Contains(".png") || f.Contains(".bmp") select f).ToList();
            if (files.Count != 0)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(files[0]);
                image.EndInit();
                Images.Source = image;
                imageCount = files.Count;
                GetInfo(0);
                return true;
            }
            return false;
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (files != null)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(files[(int)SliderNum.Value]);
                image.EndInit();
                Images.Source = image;
                GetInfo((int)SliderNum.Value);
                GC.Collect();
            }
        }
        private void GetInfo(int id)
        {
            One.IsChecked = false;

            Two.IsChecked = false;

            Three.IsChecked = false;

            Four.IsChecked = false;

            Five.IsChecked = false;

            var file = ShellFile.FromFilePath(files[id]);

            string author = "unknown";
            if (file.Properties.System.Author.Value != null)
            {
                author = file.Properties.System.Author.Value[0];
            }
            string name = file.Properties.System.FileName.Value;
            string date = file.Properties.System.DateCreated.Value.Value.Date.ToShortDateString();
            uint rate = 0;
            if (file.Properties.System.Rating.Value.HasValue)
            {
                rate = file.Properties.System.Rating.Value.Value;
            }
            Info.Text = $"Name: {name}\nAuthor: {author}\nDate: {date}";
            if (rate != 0)
            {
                if (rate >= 1 && rate <= 12)
                    One.IsChecked = true;
                else if (rate >= 13 && rate <= 37)
                    Two.IsChecked = true;
                else if (rate >= 38 && rate <= 62)
                    Three.IsChecked = true;
                else if (rate >= 63 && rate <= 87)
                    Four.IsChecked = true;
                else if (rate >= 88 && rate <= 99)
                    Five.IsChecked = true;
            }
            file.Dispose();
        }
        private void RadioClicked(object sender , RoutedEventArgs e)
        {
            uint rating = 0;
            if((sender as System.Windows.Controls.RadioButton).Name == "One")
            {
                (sender as System.Windows.Controls.RadioButton).IsChecked = true;
                rating = 12;
            }
            else if ((sender as System.Windows.Controls.RadioButton).Name == "Two")
            {
                (sender as System.Windows.Controls.RadioButton).IsChecked = true;
                rating = 37;
            }
            else if ((sender as System.Windows.Controls.RadioButton).Name == "Three")
            {
                (sender as System.Windows.Controls.RadioButton).IsChecked = true;
                rating = 62;
            }
            else if ((sender as System.Windows.Controls.RadioButton).Name == "Four")
            {
                (sender as System.Windows.Controls.RadioButton).IsChecked = true;
                rating = 87;
            }
            else if ((sender as System.Windows.Controls.RadioButton).Name == "Five")
            {
                (sender as System.Windows.Controls.RadioButton).IsChecked = true;
                rating = 99;
            }
            int id = (int)SliderNum.Value;
            Images.Source = null;
            GC.Collect();
            var file = ShellFile.FromFilePath(files[id]);
            file.Properties.System.Rating.Value = rating;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(files[id]);
            image.EndInit();
            Images.Source = image;
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            SliderNum.Value = SliderNum.Minimum;
        }
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (SliderNum.Value - 1 >= SliderNum.Minimum)
                SliderNum.Value--;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (SliderNum.Value + 1 <= SliderNum.Maximum)
                SliderNum.Value++;
        }
        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SliderNum.Value = SliderNum.Maximum;
        }
    }
}
