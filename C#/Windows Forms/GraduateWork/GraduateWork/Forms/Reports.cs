using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using GraduateWork.DB;
using Microsoft.EntityFrameworkCore;
using GraduateWork.DB.Entity;
using System.Collections.Generic;
using System.ComponentModel;

namespace GraduateWork
{
    public partial class Reports : Form
    {
        private string connString;
        private bool isFSPL = true;
        private bool isFP = true;
        private BackgroundWorker worker;

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
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        private async void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
           using(var db = new AppDbContext(connString))
           {
                var sellers = await db.Sellers.ToListAsync();

                foreach (var seller in sellers)
                {
                    cmbSellers.BeginInvoke(new MethodInvoker(() => cmbSellers.Items.Add(seller)));
                }
           }
        }

        private async void btnProduct_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                object misValue = System.Reflection.Missing.Value;

                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }

                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                try
                {
                    string path = sf.FileName;

                    List<SuppliedProduct> products;
                    using (var db = new AppDbContext(connString))
                    {
                        products = await db.SuppliedProducts.Include(s => s.Product).ThenInclude(p => p.UnitNavigation)
                            .Include(s => s.Product).ThenInclude(p => p.Producer).AsNoTracking().ToListAsync();
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
                    foreach (var product in products)
                    {
                        xlWorkSheet.Cells[i, 1] = product.Product.ProductId;
                        xlWorkSheet.Cells[i, 2] = product.Product.Name;
                        xlWorkSheet.Cells[i, 3] = product.Product.Producer.Name;
                        xlWorkSheet.Cells[i, 4] = product.Product.Model;
                        xlWorkSheet.Cells[i, 5] = product.Product.Price;
                        xlWorkSheet.Cells[i, 6] = product.Amount;
                        xlWorkSheet.Cells[i, 7] = product.Product.UnitNavigation.UnitName;
                        i++;
                    }

                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                    misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    Ok ok = new Ok();
                    ok.ShowDialog();
                }
                catch (Exception ex)
                {
                    ErrorMessage err = new ErrorMessage(ex.Message);
                    err.ShowDialog();
                }

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                object misValue = System.Reflection.Missing.Value;

                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                try
                {
                    string path = sf.FileName;

                    List<Sale> sales;
                    using (var db = new AppDbContext(connString))
                    {
                        sales = await db.Sales.Include(s => s.Seller).Include(s => s.Product).AsNoTracking().ToListAsync();
                    }

                    xlWorkSheet.Cells[1, 2] = "Product Accounting for the sale of goods";
                    xlWorkSheet.Cells[3, 1] = "Realizator";
                    xlWorkSheet.Cells[3, 2] = "Product Name";
                    xlWorkSheet.Cells[3, 3] = "Number of goods sold";
                    xlWorkSheet.Cells[3, 4] = "Selling price";
                    xlWorkSheet.Cells[3, 5] = "Implementation date";

                    int i = 4;
                    foreach (var sale in sales)
                    {
                        xlWorkSheet.Cells[i, 1] = sale.Seller.FullName;
                        xlWorkSheet.Cells[i, 2] = sale.Product.Name;
                        xlWorkSheet.Cells[i, 3] = sale.SaledProductCount;
                        xlWorkSheet.Cells[i, 4] = sale.Price;
                        xlWorkSheet.Cells[i, 5] = sale.SaleDate;
                        i++;
                    }

                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                    misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    Ok ok = new Ok();
                    ok.ShowDialog();
                }
                catch (Exception ex)
                {
                    ErrorMessage err = new ErrorMessage(ex.Message);
                    err.ShowDialog();
                }

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private async void btnProfit_Click(object sender, EventArgs e)
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
                    
                    Excel.Application xlApp = new Excel.Application();
                    if (xlApp == null)
                    {
                        ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                        msg.ShowDialog();
                        return;
                    }
                    object misValue = System.Reflection.Missing.Value;
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                    try
                    {
                        string path = sf.FileName;
                        decimal supPrice = 0;
                        decimal salePrice = 0;

                        using (var db = new AppDbContext(connString))
                        {
                            var suplies = await db.SuppliedProducts.Include(s => s.Product)
                                .Where(s => s.SupDate >= dateF.Value.Date && s.SupDate <= dateT.Value.Date)
                                .AsNoTracking().ToListAsync();

                            foreach (var suply in suplies)
                            {
                                supPrice += suply.Product.Price;
                            }

                            var sales = await db.Sales.
                                Where(s=>s.SaleDate >= dateF.Value.Date && s.SaleDate <= dateT.Value.Date)
                                .AsNoTracking().ToListAsync();
                            foreach (var sale in sales)
                            {
                                salePrice += sale.Price;
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
                        Ok ok = new Ok();
                        ok.ShowDialog();
                    }
                    catch (Exception  ex)
                    {
                        ErrorMessage err = new ErrorMessage(ex.Message);
                        err.ShowDialog();
                    }

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

        private async void btnDifference_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel |*.xlsx";
            sf.InitialDirectory = "C:\\";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                    msg.ShowDialog();
                    return;
                }
                object misValue = System.Reflection.Missing.Value;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                try
                {
                    string path = sf.FileName;

                    xlWorkSheet.Cells[1, 2] = $"A list of goods, the selling price of which exceeds the delivery price by 10%";
                    xlWorkSheet.Cells[3, 1] = "Product ID";
                    xlWorkSheet.Cells[3, 2] = "Product Name";
                    xlWorkSheet.Cells[3, 3] = "Purchase price";
                    xlWorkSheet.Cells[3, 4] = "Selling price";

                    using(var db = new AppDbContext(connString))
                    using(var command = db.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = $"select Sale.ProductId, Product.Name, Product.Price/SuppliedProducts.Amount as " +
                            $"[Product price],Sale.Price/SaledProductCount as [SalePrice] , SuppliedProducts.Amount from Sale " +
                        $"join Product on Product.ProductId = Sale.ProductId " +
                        $"join SuppliedProducts on SuppliedProducts.ProductId =  Product.ProductId " +
                        $"where ((Sale.Price/SaledProductCount)/(Product.Price/SuppliedProducts.Amount))*100-100 >= 10";
                        db.Database.OpenConnection();
                        using(var res = command.ExecuteReader())
                        {
                            int i = 4;
                            while(res.Read())
                            {
                                xlWorkSheet.Cells[i, 1] = res.GetInt32(0);
                                xlWorkSheet.Cells[i, 2] = res.GetString(1);
                                xlWorkSheet.Cells[i, 3] = res.GetDecimal(2);
                                xlWorkSheet.Cells[i, 4] = res.GetDecimal(3);
                                i++;
                            }
                        }
                    }

                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    Ok ok = new Ok();
                    ok.ShowDialog();
                }
                catch (Exception ex)
                {
                    ErrorMessage err = new ErrorMessage(ex.Message);
                    err.ShowDialog();
                }

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private async void btnSellerProdList_Click(object sender, EventArgs e)
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
                        object misValue = System.Reflection.Missing.Value;
                        Excel.Application xlApp = new Excel.Application();
                        if (xlApp == null)
                        {
                            ErrorMessage msg = new ErrorMessage("Excel is not properly installed");
                            msg.ShowDialog();
                            return;
                        }
                        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                        Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        try
                        {
                            string path = sf.FileName;

                            DataTable table = new DataTable();

                            xlWorkSheet.Cells[1, 2] = $"List of products that {(cmbSellers.SelectedItem as Seller).FullName} sells";
                            xlWorkSheet.Cells[3, 1] = "Product ID";
                            xlWorkSheet.Cells[3, 2] = "Product Name";

                            using(var db = new AppDbContext(connString))
                            {
                                var res = await db.Sellers.Where(s => s.SellerId == (cmbSellers.SelectedItem as Seller).SellerId).Include(s => s.Sales).ThenInclude(s => s.Product).SingleOrDefaultAsync();
                                int i = 4;
                                foreach (var sale in res.Sales)
                                {
                                    xlWorkSheet.Cells[i, 1] = sale.Product.ProductId;
                                    xlWorkSheet.Cells[i, 2] = sale.Product.Name;
                                    i++;
                                }
                            }

                            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                            misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                            Ok ok = new Ok();
                            ok.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage err = new ErrorMessage(ex.Message);
                            err.ShowDialog();
                        }

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