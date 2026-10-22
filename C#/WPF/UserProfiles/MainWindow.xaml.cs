using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Persone> persones = new ObservableCollection<Persone>();
        public MainWindow()
        {
            InitializeComponent();
            ListUsers.ItemsSource = persones;
            cmbDepart.ItemsSource = Enum.GetNames(typeof(Departments));
            cmbRoles.Items.Add("--None Selected--");
            cmbRoles.Items.Add("Accounts Rayable");
            cmbRoles.Items.Add("Accounts Receivable");
            cmbRoles.Items.Add("General Ledger");
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            gridInfo.IsEnabled = true;
            gridRoles.IsEnabled = true;
            btnProfileAdd.IsEnabled = true;
            btnCancel.IsEnabled = true;
            btnRolesDel.IsEnabled = true;
            cmbDepart.IsEnabled = true;
            cmbRoles.IsEnabled = true;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ListUsers.Items.Count != 0)
                ListUsers.Items.Remove(ListUsers.SelectedItem);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUsers.SelectedIndex != -1 && (ListUsers.SelectedValue as Persone).FirstName != "")
            {
                btnProfileAdd.Content = "Update";
            }
            else btnProfileAdd.Content = "Add";
        }

        private void btnProfileAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDepart.SelectedIndex != -1)
            {
                if (ListUsers.Items.Count == 0)
                    try
                    {
                        persones.Add(new Persone { Username = txtUserName.Text, FirstName = txtFName.Text, LastName = txtLName.Text, Email = txtEmail.Text, Password = txtPassword.Text, Department = cmbDepart.SelectedItem.ToString() });
                    }
                    catch (Exception msg) { return; }
                else
                {
                    if (btnProfileAdd.Content == "Update")
                    {
                        ListUsers.SelectedIndex = -1;
                        btnProfileAdd.Content = "Add";
                    }
                    else
                    {
                        try
                        {
                            persones.Add(new Persone { UserName = txtUserName.Text, FirstName = txtFName.Text, LastName = txtLName.Text, Email = txtEmail.Text, Password = txtPassword.Text, Department = cmbDepart.SelectedItem.ToString() });
                        }
                        catch (Exception msg) { return; }
                    }
                }
                if (txtUserName.Text != "" || txtFName.Text != "" || txtLName.Text != "" || txtEmail.Text != "" || txtPassword.Text != "" || cmbDepart.SelectedIndex != -1)
                {
                    txtUserName.Text = txtFName.Text = txtLName.Text = txtEmail.Text = txtPassword.Text = "";
                    cmbDepart.SelectedIndex = -1;
                }
            }
        }
    }
    public class Persone
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
    public enum Departments
    {
        Sales,
        Plant,
        Accounting,
        Administration
    }
}
