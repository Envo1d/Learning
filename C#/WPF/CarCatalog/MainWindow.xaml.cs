using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Car> cars = new ObservableCollection<Car>();
        private ListSortDirection sortDirection;
        private readonly CarDb carDb;
        private Car carMod;
        public MainWindow()
        {
            InitializeComponent();
            carDb = new CarDb();

            if (carDb.cars != null)
                foreach (var car in carDb.cars)
                    cars.Add(car);

            Cars.ItemsSource = cars;
            sortDirection = ListSortDirection.Ascending;
        }

        private bool FilterByModel(object obj)
        {
            string model = filterTxt.Text;
            if (string.IsNullOrWhiteSpace(model)) return true;
            Car car = obj as Car;
            if (car == null) return false;
            return car.Model.ToLower().StartsWith(model.ToLower());
        }
        private bool FilterByColor(object obj)
        {
            string color = filterTxt.Text;
            if (string.IsNullOrWhiteSpace(color)) return true;
            Car car = obj as Car;
            if (car == null) return false;
            return car.Color.ToLower().StartsWith(color.ToLower());
        }
        private bool FilterByPrice(object obj)
        {
            int price;
            try { price = Convert.ToInt32(filterTxt.Text); }catch(Exception msg) { return true; }
            Car car = obj as Car;
            if (car == null) return false;
            return car.Price == price;
        }
        private bool FilterByType(object obj)
        {
            Types type;
            try { type = (Types)Enum.Parse(typeof(Types), filterTxt.Text); } catch (Exception msg) { return true; }
            Car car = obj as Car;
            if (car == null) return false;
            return car.Type == type;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ModelTxt.Text != "" && ColorTxt.Text != "" && PriceTxt.Text != "" && TypesCmb.SelectedIndex != -1 && ImageTxt.Text != "")
            {
                if (Cars.Items.Count == 0)
                    try
                    {
                        cars.Add(new Car { Model = ModelTxt.Text, Color = ColorTxt.Text, Type = (Types)Enum.Parse(typeof(Types), TypesCmb.Text), Price = Convert.ToInt32(PriceTxt.Text), ImageUrl = ImageTxt.Text });
                        carDb.cars.Add(new Car { Model = ModelTxt.Text, Color = ColorTxt.Text, Type = (Types)Enum.Parse(typeof(Types), TypesCmb.Text), Price = Convert.ToInt32(PriceTxt.Text), ImageUrl = ImageTxt.Text });
                        carDb.SaveChanges();
                    }
                    catch (Exception msg) { return; }
                else
                {
                    if (Add.Content == "Update")
                    {
                        if (carMod != null)
                        {
                            carMod = Cars.SelectedItem as Car;
                            carDb.Entry(carMod).State = EntityState.Modified;
                            carDb.SaveChanges();
                            Cars.SelectedIndex = -1;
                            Add.Content = "Add";
                        }
                        else return;
                    }
                    else
                    {
                        try
                        {
                            cars.Add(new Car { Model = ModelTxt.Text, Color = ColorTxt.Text, Type = (Types)Enum.Parse(typeof(Types), TypesCmb.Text), Price = Convert.ToInt32(PriceTxt.Text), ImageUrl = ImageTxt.Text });
                            carDb.cars.Add(new Car { Model = ModelTxt.Text, Color = ColorTxt.Text, Type = (Types)Enum.Parse(typeof(Types), TypesCmb.Text), Price = Convert.ToInt32(PriceTxt.Text), ImageUrl = ImageTxt.Text });
                            carDb.SaveChanges();
                        }
                        catch (Exception msg) { return; }
                    }
                }
                if (ModelTxt.Text != "" || ColorTxt.Text != "" || TypesCmb.Text != "" || PriceTxt.Text != "" || ImageTxt.Text != "")
                {
                    ModelTxt.Text = ColorTxt.Text = PriceTxt.Text = ImageTxt.Text = "";
                    TypesCmb.SelectedIndex = -1;
                }
            }
            else return;
        }

        private void Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cars.SelectedIndex != -1 && (Cars.SelectedValue as Car).Model != "")
            {
                Add.Content = "Update";
                carMod = carDb.cars.Find((Cars.SelectedItem as Car).Id);
            }
            else Add.Content = "Add";
        }

        private void Cars_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                if (Cars.SelectedIndex != -1 && (Cars.SelectedValue as Car).Model != "")
                {
                    carDb.cars.Remove(Cars.SelectedItem as Car);
                    carDb.SaveChanges();
                    cars.RemoveAt(Cars.SelectedIndex);
                }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbFilter.SelectedIndex == 0)
                Cars.Items.Filter = FilterByModel;
            else if (CmbFilter.SelectedIndex == 1)
                Cars.Items.Filter = FilterByColor;
            else if (CmbFilter.SelectedIndex == 2)
                Cars.Items.Filter = FilterByPrice;
            else
                Cars.Items.Filter = FilterByType;
            CollectionViewSource.GetDefaultView(Cars.ItemsSource).Refresh();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            Cars.Items.SortDescriptions.Clear();
            Cars.Items.SortDescriptions.Add(new SortDescription("Model", sortDirection));
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        private void GridViewColumnHeader_Click_1(object sender, RoutedEventArgs e)
        {
            Cars.Items.SortDescriptions.Clear();
            Cars.Items.SortDescriptions.Add(new SortDescription("Color", sortDirection));
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        private void GridViewColumnHeader_Click_2(object sender, RoutedEventArgs e)
        {
            Cars.Items.SortDescriptions.Clear();
            Cars.Items.SortDescriptions.Add(new SortDescription("Type", sortDirection));
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        private void GridViewColumnHeader_Click_3(object sender, RoutedEventArgs e)
        {
            Cars.Items.SortDescriptions.Clear();
            Cars.Items.SortDescriptions.Add(new SortDescription("Price", sortDirection));
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (carDb != null)
                carDb.Dispose();
        }

        private void filterTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(filterTxt.Text))
            {
                Cars.Items.Filter = null;
                CmbFilter.SelectedIndex = -1;
            }
        }
    }
}
