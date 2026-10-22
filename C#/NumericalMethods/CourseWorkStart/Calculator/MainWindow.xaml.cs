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
using CourseWorkStart;
using NCalc;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImprovedEilerMethod eiler;
        private RungeKuttaMethod runge;
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Formatter { get; set; }
        public double Base { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Base = 10;

            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
                .Y(point => point.Y);

            SeriesCollection = new SeriesCollection(mapper)
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(1, 0),
                        new ObservablePoint(10, 3),
                        new ObservablePoint(100, 4),
                        new ObservablePoint(1000, 2),
                        new ObservablePoint(10000, 8),
                        new ObservablePoint(100000, 2),
                        new ObservablePoint(1000000, 9),
                        new ObservablePoint(10000000, 8)
                    }
                }
            };

            Formatter = value => string.Format("{0:0.000000}", Math.Pow(Base, value));
            DataContext = this;

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double start;
                double end;
                double step;
                double startY;
                doc.Blocks.Clear();
                if (SeriesCollection != null)
                    SeriesCollection[0].Values.Clear();
                var table = new Table();
                doc.Blocks.Add(table);
                if (!Double.TryParse(StartbBox.Text, out start))
                {
                    NCalc.Expression exp = new NCalc.Expression(StartbBox.Text.ToLower());
                    if (StartbBox.Text.ToLower().Contains("pi"))
                        exp.Parameters["pi"] = Math.PI;
                    if (StartbBox.Text.ToLower().Contains("e"))
                        exp.Parameters["e"] = Math.E;
                    start = Convert.ToDouble(exp.Evaluate());
                }
                if (!Double.TryParse(EndbBox.Text, out end))
                {
                    NCalc.Expression exp = new NCalc.Expression(EndbBox.Text.ToLower());
                    if (EndbBox.Text.ToLower().Contains("pi"))
                        exp.Parameters["pi"] = Math.PI;
                    if (EndbBox.Text.ToLower().Contains("e"))
                        exp.Parameters["e"] = Math.E;
                    end = Convert.ToDouble(exp.Evaluate());
                }
                if (!Double.TryParse(StepBox.Text, out step))
                {
                    NCalc.Expression exp = new NCalc.Expression(StepBox.Text.ToLower());
                    if (StepBox.Text.ToLower().Contains("pi"))
                        exp.Parameters["pi"] = Math.PI;
                    if (StepBox.Text.ToLower().Contains("e"))
                        exp.Parameters["e"] = Math.E;
                    end = Convert.ToDouble(exp.Evaluate());
                }
                if (!Double.TryParse(StartYBox.Text, out startY))
                {
                    NCalc.Expression exp = new NCalc.Expression(StartYBox.Text.ToLower());
                    if (StartYBox.Text.ToLower().Contains("pi"))
                        exp.Parameters["pi"] = Math.PI;
                    if (StartYBox.Text.ToLower().Contains("e"))
                        exp.Parameters["e"] = Math.E;
                    end = Convert.ToDouble(exp.Evaluate());
                }
                if (MethodCombo.SelectedIndex == 0)
                {
                    eiler = new ImprovedEilerMethod(step, start, end, startY, FunctionBox.Text);
                    for (int i = 0; i < eiler.Params; i++)
                    {
                        table.Columns.Add(new TableColumn());
                    }
                    table.RowGroups.Add(new TableRowGroup());
                    table.RowGroups[0].Rows.Add(new TableRow());
                    var currentRow = table.RowGroups[0].Rows[0];
                    currentRow.FontSize = 14;
                    currentRow.Foreground = Brushes.White;
                    currentRow.FontWeight = FontWeights.Bold;
                    currentRow.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Dosis");
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("i"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("x"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("y"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("f(x;y)"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("f(x+h;y+hf(x;y))"))));
                    TableCell cell1 = new TableCell(new Paragraph(new Run("SUMM")));
                    cell1.ToolTip = new ToolTip { Content = "f(x;y)+f(x+h;y+hf(x;y)" };
                    currentRow.Cells.Add(cell1);
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("∆yi"))));
                    eiler.Calculate();
                    for (int i = 0; i < eiler.Iterations; i++)
                    {
                        table.RowGroups[0].Rows.Add(new TableRow());
                        var currentRow2 = table.RowGroups[0].Rows.Last();
                        currentRow2.FontSize = 14;
                        currentRow2.Foreground = Brushes.White;
                        currentRow2.FontWeight = FontWeights.Medium;
                        currentRow2.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Dosis");
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.IterX[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.IterY[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.TablFunc[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.HarTabFunc[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.FuncSum[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(eiler.LIterY[i], 6)}"))));
                    }
                    for (int i = 0; i < eiler.Iterations; i++)
                    {
                        SeriesCollection[0].Values.Add(new ObservablePoint(eiler.IterX[i], Math.Round(eiler.IterY[i],6)));
                    }
                    eiler = null;
                }
                else
                {
                    runge = new RungeKuttaMethod(step, start, end, startY, FunctionBox.Text);
                    for (int i = 0; i < runge.Params; i++)
                    {
                        table.Columns.Add(new TableColumn());
                    }
                    table.RowGroups.Add(new TableRowGroup());
                    table.RowGroups[0].Rows.Add(new TableRow());
                    var currentRow = table.RowGroups[0].Rows[0];
                    currentRow.FontSize = 14;
                    currentRow.Foreground = Brushes.White;
                    currentRow.FontWeight = FontWeights.Bold;
                    currentRow.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Dosis");
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("i"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("xi"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("yi"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("k1"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("k2"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("k3"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("k4"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("∆yi"))));
                    runge.Calculate();
                    for (int i = 0; i < runge.Iterations; i++)
                    {
                        table.RowGroups[0].Rows.Add(new TableRow());
                        var currentRow2 = table.RowGroups[0].Rows.Last();
                        currentRow2.FontSize = 14;
                        currentRow2.Foreground = Brushes.White;
                        currentRow2.FontWeight = FontWeights.Medium;
                        currentRow2.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Dosis");
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.IterX[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.IterY[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.K1[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.K2[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.K3[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.K4[i], 6)}"))));
                        currentRow2.Cells.Add(new TableCell(new Paragraph(new Run($"{Math.Round(runge.LIterY[i], 6)}"))));
                    }
                    for (int i = 0; i < runge.Iterations; i++)
                    {
                        SeriesCollection[0].Values.Add(new ObservablePoint(runge.IterX[i], Math.Round(runge.IterY[i],6)));
                    }
                    runge = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check conditions", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Tables_Click(object sender, RoutedEventArgs e)
        {
            if (Graphic.Visibility == Visibility.Visible)
                Graphic.Visibility = Visibility.Collapsed;
            if (docL.Visibility == Visibility.Collapsed)
                docL.Visibility = Visibility.Visible;
            else
                docL.Visibility = Visibility.Collapsed;
        }

        private void Graphics_Click(object sender, RoutedEventArgs e)
        {
            if (docL.Visibility == Visibility.Visible)
                docL.Visibility = Visibility.Collapsed;
            if (Graphic.Visibility == Visibility.Collapsed)
                Graphic.Visibility = Visibility.Visible;
            else
                Graphic.Visibility = Visibility.Collapsed;
        }

        private void FunctionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(FunctionBox.Text.Contains("cos"))
            {
                FunctionBox.Text = FunctionBox.Text.Replace("cos", "Cos");
                FunctionBox.Focus();
                FunctionBox.SelectionStart = FunctionBox.Text.Length;
            }
            if(FunctionBox.Text.Contains("sin"))
            {
                FunctionBox.Text = FunctionBox.Text.Replace("sin", "Sin");
                FunctionBox.Focus();
                FunctionBox.SelectionStart = FunctionBox.Text.Length;
            }
            if (FunctionBox.Text.Contains("tan"))
            {
                FunctionBox.Text = FunctionBox.Text.Replace("tan", "Tan");
                FunctionBox.Focus();
                FunctionBox.SelectionStart = FunctionBox.Text.Length;
            }
            if (FunctionBox.Text.Contains("cot"))
            {
                FunctionBox.Text = FunctionBox.Text.Replace("cot", "Cot");
                FunctionBox.Focus();
                FunctionBox.SelectionStart = FunctionBox.Text.Length;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            FunctionBox.Text = EndbBox.Text = StartbBox.Text = StepBox.Text = StartYBox.Text = "";
            doc.Blocks.Clear();
            if (SeriesCollection != null)
                SeriesCollection[0].Values.Clear();
        }
    }
}
