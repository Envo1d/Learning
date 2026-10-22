using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class Reports : Form
    {
        class Seller
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}";
            }
        }
        string connString;
        public Reports(string conn)
        {
            InitializeComponent();
            connString = conn;
            lblF.Visible = false;
            lblT.Visible = false;
            dateF.Visible = false;
            dateT.Visible = false;
            cmbSellers.Visible = false;
            lblName.Visible = false;
            int num = 0;
            using(SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select count(*) from Seller";
                var reader = cmd.ExecuteReader();
                reader.Read();
                num = reader.GetInt32(0);
            }
            if(num!=0)
            {
                using(SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select SellerId, Name from Seller", con);
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        cmbSellers.Items.Add(new Seller { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                    }
                }
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string path = sf.FileName;
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlDataAdapter adap = new SqlDataAdapter("select Product.ProductId, Product.Name, Producer.Name, Product.Model, Product.Price, Amount, Units.UnitName from SuppliedProducts " +
                    "join Product on Product.ProductId = SuppliedProducts.ProductId " +
                    "join Units on Units.UnitId = Product.Unit " +
                    "join Producer on Producer.ProducerId = Product.ProducerId", con);
                    adap.Fill(table);
                }

                xlWorkSheet.Cells[1, 2] = "Product specifications";
                xlWorkSheet.Cells[3, 1] = "Product ID";
                xlWorkSheet.Cells[3, 2] = "Product Name";
                xlWorkSheet.Cells[3, 3] = "Producer";
                xlWorkSheet.Cells[3, 4] = "Model";
                xlWorkSheet.Cells[3, 5] = "Purchase Price";
                xlWorkSheet.Cells[3, 6] = "Amount";
                xlWorkSheet.Cells[3, 7] = "Unit";

                int i = 4;
                foreach (DataRow row in table.Rows)
                {
                    object[] k = row.ItemArray.ToArray();
                    for (int j = 0; j < k.Length; j++)
                    {
                        xlWorkSheet.Cells[i, j + 1] = k[j];
                    }
                    i++;
                }

                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string path = sf.FileName;
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlDataAdapter adap = new SqlDataAdapter("select Seller.Name, Product.Name, SaledProductCount, Sale.Price, SaleDate from Sale " +
                    "join Product on Product.ProductId = Sale.ProductId " +
                    "join Seller on Seller.SellerId = Sale.SellerId ", con);
                    adap.Fill(table);
                }

                xlWorkSheet.Cells[1, 2] = "Product Accounting for the sale of goods";
                xlWorkSheet.Cells[3, 1] = "Realizator";
                xlWorkSheet.Cells[3, 2] = "Product Name";
                xlWorkSheet.Cells[3, 3] = "Number of goods sold";
                xlWorkSheet.Cells[3, 4] = "Selling price";
                xlWorkSheet.Cells[3, 5] = "Implementation date";

                int i = 4;
                foreach (DataRow row in table.Rows)
                {
                    object[] k = row.ItemArray.ToArray();
                    for (int j = 0; j < k.Length; j++)
                    {
                        xlWorkSheet.Cells[i, j + 1] = k[j];
                    }
                    i++;
                }

                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        bool isFSPL = true;
        bool isFP = true;

        private void btnProfit_Click(object sender, EventArgs e)
        {
            if(isFP)
            {
                btnProduct.Enabled = false;
                btnSale.Enabled = false;
                btnSellerProdList.Enabled = false;
                btnDifference.Enabled = false;
                lblF.Visible = true;
                lblT.Visible = true;
                dateF.Visible = true;
                dateT.Visible = true;
                isFP = false;
                btnProfit.IconColor = Color.Red;
            }
            else
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel |*.xlsx";
                sf.InitialDirectory = "C:\\";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string path = sf.FileName;
                    Excel.Application xlApp = new Excel.Application();
                    if (xlApp == null)
                    {
                        ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                        msg.ShowDialog();
                        return;
                    }
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    decimal supPrice = 0;
                    decimal salePrice = 0;

                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DATE1", dateF.Value.Date);
                        cmd.Parameters.AddWithValue("@DATE2", dateT.Value.Date);
                        cmd.CommandText = $"select SupDate, Product.Price from SuppliedProducts " +
                            $"join Product on Product.ProductId = SuppliedProducts.ProductId where SupDate >= @DATE1 and SupDate <= @DATE2 ";
                        var reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            supPrice += reader.GetDecimal(1);
                        }
                    }
                    using(SqlConnection con =  new SqlConnection(connString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DATE1", dateF.Value.Date);
                        cmd.Parameters.AddWithValue("@DATE2", dateT.Value.Date);
                        cmd.CommandText = $"select SaleDate, Price from Sale  where SaleDate >= @DATE1 and SaleDate <= @DATE2";
                        var reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            salePrice += reader.GetDecimal(1);
                        }
                    }
                    
                    xlWorkSheet.Cells[1, 2] = $"Enterprise profit from {dateF.Value.Date.ToShortDateString()} to {dateT.Value.Date.ToShortDateString()}";
                    xlWorkSheet.Cells[3, 1] = "Spent on purchase";
                    xlWorkSheet.Cells[3, 2] = "Total sales";
                    xlWorkSheet.Cells[3, 3] = "Profit";
                    xlWorkSheet.Cells[4, 1] = supPrice;
                    xlWorkSheet.Cells[4, 2] = salePrice;
                    xlWorkSheet.Cells[4, 3] = salePrice - supPrice;

                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                    misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
                btnProduct.Enabled = true;
                btnSale.Enabled = true;
                btnSellerProdList.Enabled = true;
                btnDifference.Enabled = true;
                lblF.Visible = false;
                lblT.Visible = false;
                dateF.Visible = false;
                dateT.Visible = false;
                isFP = true;
                btnProfit.IconColor = Color.Gainsboro;
            }
        }

        private void btnDifference_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string path = sf.FileName;
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                DataTable table = new DataTable();

                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlDataAdapter adap = new SqlDataAdapter($"select Sale.ProductId, Product.Name, Product.Price/SuppliedProducts.Amount as [Product price],Sale.Price/SaledProductCount as [SalePrice] , SuppliedProducts.Amount from Sale " +
                        $"join Product on Product.ProductId = Sale.ProductId " +
                        $"join SuppliedProducts on SuppliedProducts.ProductId =  Product.ProductId " +
                        $"where ((Sale.Price/SaledProductCount)/(Product.Price/SuppliedProducts.Amount))*100-100 >= 10", con);
                    adap.Fill(table);
                }

                xlWorkSheet.Cells[1, 2] = $"A list of goods, the selling price of which exceeds the delivery price by 10%";
                xlWorkSheet.Cells[3, 1] = "Product ID";
                xlWorkSheet.Cells[3, 2] = "Product Name";
                xlWorkSheet.Cells[3, 3] = "Purchase price";
                xlWorkSheet.Cells[3, 4] = "Selling price";

                int i = 4;
                foreach (DataRow row in table.Rows)
                {
                    object[] k = row.ItemArray.ToArray();
                    for (int j = 0; j < k.Length - 1; j++)
                    {
                        xlWorkSheet.Cells[i, j + 1] = k[j];
                    }
                    i++;
                }

                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private void btnSellerProdList_Click(object sender, EventArgs e)
        {
            if (cmbSellers.Items.Count == 0)
            {
                ErrorMessage msg = new ErrorMessage("No one's sellers");
                msg.ShowDialog();
            }
            else
            {
                if (isFSPL)
                {
                    lblName.Visible = true;
                    cmbSellers.Visible = true;
                    btnProduct.Enabled = false;
                    btnSale.Enabled = false;
                    btnProfit.Enabled = false;
                    btnDifference.Enabled = false;
                    isFSPL = false;
                    btnSellerProdList.IconColor = Color.Red;
                }
                else
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.Filter = "Excel |*.xlsx";
                    sf.InitialDirectory = "C:\\";
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        string path = sf.FileName;
                        Excel.Application xlApp = new Excel.Application();
                        if (xlApp == null)
                        {
                            ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                            msg.ShowDialog();
                            return;
                        }
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        DataTable table = new DataTable();

                        using (SqlConnection con = new SqlConnection(connString))
                        {
                            SqlDataAdapter adap = new SqlDataAdapter($"select Sale.ProductId, Product.Name, Seller.Name from Sale " +
                                $"join Product on Product.ProductId = Sale.ProductId join Seller on Seller.SellerId = Sale.SellerId where Seller.Name = N'{(cmbSellers.SelectedItem as Seller).Name}' and Seller.SellerId = N'{(cmbSellers.SelectedItem as Seller).Id}'", con);
                            adap.Fill(table);
                        }

                        xlWorkSheet.Cells[1, 2] = $"List of products that {(cmbSellers.SelectedItem as Seller).Name} sells";
                        xlWorkSheet.Cells[3, 1] = "Product ID";
                        xlWorkSheet.Cells[3, 2] = "Product Name";

                        int i = 4;
                        foreach (DataRow row in table.Rows)
                        {
                            object[] k = row.ItemArray.ToArray();
                            for (int j = 0; j < k.Length - 1; j++)
                            {
                                xlWorkSheet.Cells[i, j + 1] = k[j];
                            }
                            i++;
                        }

                        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                        misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);
                        Marshal.ReleaseComObject(xlApp);
                    }
                    lblName.Visible = false;
                    cmbSellers.Visible = false;
                    btnProduct.Enabled = true;
                    btnSale.Enabled = true;
                    btnProfit.Enabled = true;
                    btnDifference.Enabled = true;
                    isFSPL = true;
                    btnSellerProdList.IconColor = Color.Gainsboro;
                }
            } 
        }
    }
}