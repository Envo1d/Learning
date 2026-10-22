using GraduateWork.DB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GraduateWork
{
    public partial class Products : Form
    {
        private string connString;
        private BackgroundWorker worker;

        public Products(string conn)
        {
            InitializeComponent();
            connString = conn;
            lstView.FullRowSelect = true;
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        private async void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            await UpdateList();
        }

        private async Task UpdateList()
        {
            if (lstView.InvokeRequired)
                lstView.BeginInvoke(new MethodInvoker(() => lstView.Items.Clear()));
            else
                lstView.Items.Clear();
            using (var db = new AppDbContext(connString))
            {
                var products = await db.SuppliedProducts.Include(p => p.Product)
                    .ThenInclude(u => u.UnitNavigation).Include(p => p.Product).ThenInclude(p => p.Producer).AsNoTracking().ToListAsync();
                foreach (var product in products)
                {
                    if (lstView.InvokeRequired)
                        lstView.BeginInvoke(new MethodInvoker(() =>
                        {
                            var item = lstView.Items.Add(product.ProductId.ToString());
                            item.SubItems.Add(product.Product.Name);
                            item.SubItems.Add(product.Product.Model);
                            item.SubItems.Add(product.Product.Price.ToString());
                            item.SubItems.Add(product.Amount.ToString());
                            item.SubItems.Add(product.Product.UnitNavigation.UnitName);
                            item.SubItems.Add(product.Product.Producer.Name);
                        }));
                    else
                    {
                        var item = lstView.Items.Add(product.ProductId.ToString());
                        item.SubItems.Add(product.Product.Name);
                        item.SubItems.Add(product.Product.Model);
                        item.SubItems.Add(product.Product.Price.ToString());
                        item.SubItems.Add(product.Amount.ToString());
                        item.SubItems.Add(product.Product.UnitNavigation.UnitName);
                        item.SubItems.Add(product.Product.Producer.Name);
                    }
                }
            }
        }

        private async void btnReduce_Click(object sender, EventArgs e)
        {
            using(var db = new AppDbContext(connString))
            {
                var products = await db.Products.ToListAsync();
                foreach(var product in products)
                {
                    product.Price = product.Price * (decimal)(1 - 0.03);
                }
                await db.SaveChangesAsync();
            }
            await UpdateList();
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lstView.SelectedItems[0].Text);
            using(var db = new AppDbContext(connString))
            {
                var supply = await db.SuppliedProducts.FirstOrDefaultAsync(s=>s.ProductId == id);
                db.Remove(supply);
                await db.SaveChangesAsync();
            }
            await UpdateList();
        }

        private void btnRealize_Click(object sender, EventArgs e)
        {
            (Owner as MainForm).isRealizeClicked = true;
            (Owner as MainForm).prodIdRealize = Convert.ToInt32(lstView.SelectedItems[0].Text);
            (Owner as MainForm).Realize();
            this.Close();
        }
    }
}