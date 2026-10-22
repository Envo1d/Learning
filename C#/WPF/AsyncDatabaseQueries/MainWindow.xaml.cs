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
using System.Data.SqlClient;
using System.Threading;

namespace WpfADOAsync
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            ConnectionString.Text = @"Data Source=localhost;User ID=db_user;Password=CHANGE_ME;Initial Catalog=AsyncHM;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;";
        }

        private void ConnectionString_TextChanged(object sender, TextChangedEventArgs e)
        {
            connectionString = ConnectionString.Text;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                try { cn.Open(); }
                catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); }
                finally
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        ConnectionString.IsEnabled = !ConnectionString.IsEnabled;
                        Connect.IsEnabled = !Connect.IsEnabled;
                        Start.IsEnabled = !Start.IsEnabled;
                        txtF.IsEnabled = !txtF.IsEnabled;
                        txtS.IsEnabled = !txtS.IsEnabled;
                        Disconnect.IsEnabled = !Disconnect.IsEnabled;
                    }
                    cn.Close();
                }
            }
            catch (Exception ms) { MessageBox.Show(ms.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectionString.IsEnabled = !ConnectionString.IsEnabled;
            Connect.IsEnabled = !Connect.IsEnabled;
            Start.IsEnabled = !Start.IsEnabled;
            txtF.IsEnabled = !txtF.IsEnabled;
            txtS.IsEnabled = !txtS.IsEnabled;
            Disconnect.IsEnabled = !Disconnect.IsEnabled;
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmdS = new SqlCommand("select * from Books", conn);
            SqlCommand cmdF = new SqlCommand("select * from Authors", conn);

            int countF = 0;
            int countS = 0;

            cmdF.BeginExecuteReader(ar =>
            {
                cmdS.BeginExecuteReader(ar2 =>
                {
                    SqlDataReader rdr2 = cmdS.EndExecuteReader(ar2);
                    while (rdr2.Read())
                    {
                        Thread.Sleep(500);
                        countS += rdr2.GetString(1).Length;
                    }
                }, null);
                SqlDataReader rdr = cmdF.EndExecuteReader(ar);
                while (rdr.Read())
                {
                    Thread.Sleep(1000);
                    countF += rdr.GetString(1).Length + rdr.GetString(2).Length;
                }
                Dispatcher.Invoke(() => { txtF.Text = $"{countF}"; txtS.Text = $"{countS}"; });
                conn.Close();
            }, null);
        }
    }
}
