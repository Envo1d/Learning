using GraduateWork.Common;
using GraduateWork.DB;
using GraduateWork.DB.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace GraduateWork
{
    public partial class Realize : Form
    {
        enum State
        {
            Realizer,
            Customer,
            Product
        }

        private State state = State.Realizer;
        private string connString;
        private int id;
        private bool isIdSet = false;
        private bool isProd = false;
        private Seller seller;
        private Address sellerAddress;
        private Address customerAddress;
        private Customer customer;
        private Product product;
        private SuppliedProduct supply;
        private BackgroundWorker worker;

        public Realize(string conn)
        {
            InitializeComponent();
            connString = conn;
            btnConfirm.Visible = false;
            lblMarkup.Visible = false;
            lblCost.Visible = false;
            txtMarkup.Visible = false;
            txtCost.Visible = false;
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
            TurnAll();
        }

        private async void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            await FillCombo();
        }

        public Realize(string conn, int id)
        {
            InitializeComponent();
            connString = conn;
            this.id = id;
            isIdSet = true;
            btnConfirm.Visible = false;
            lblMarkup.Visible = false;
            lblCost.Visible = false;
            txtMarkup.Visible = false;
            txtCost.Visible = false;
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
            TurnAll();
        }
        void TurnAll()
        {
            lblList.Visible = true;
            cmbRealizers.Visible = true;
            btnNew.Visible = true;
            btnSelect.Visible = true;
            lblAddress.Visible = false;
            lblInfo.Visible = false;
            lblName.Visible = false;
            lblPhone.Visible = false;
            lblStreet.Visible = false;
            lblCity.Visible = false;
            lblCountry.Visible = false;
            txtCity.Visible = false;
            txtCountry.Visible = false;
            txtName.Visible = false;
            txtPhone.Visible = false;
            txtStreet.Visible = false;
            btnConfirm.Visible = false;
            lblMarkup.Visible = false;
            lblCost.Visible = false;
            txtMarkup.Visible = false;
            txtCost.Visible = false;
        }
        private async Task FillCombo(int productId = -1)
        {
            if (cmbRealizers.InvokeRequired)
                cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.Items.Clear()));
            else
                cmbRealizers.Items.Clear();

            switch (state)
            {
                case State.Realizer:
                    using (var db = new AppDbContext(connString))
                    {
                        var sellers = await db.Sellers.Include(s => s.Address).AsNoTracking().ToListAsync();
                        if (sellers.Count > 0)
                        {
                            foreach (var seller in sellers)
                            {
                                if (cmbRealizers.InvokeRequired)
                                    cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.Items.Add(seller)));
                                else
                                    cmbRealizers.Items.Add(seller);
                            }
                            if (cmbRealizers.InvokeRequired)
                                cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.SelectedIndex = 0));
                            else
                                cmbRealizers.SelectedIndex = 0;
                        }
                    }
                    break;
                case State.Customer:
                    using (var db = new AppDbContext(connString))
                    {
                        var customers = await db.Customers.Include(s => s.Address).AsNoTracking().ToListAsync();
                        if (customers.Count > 0)
                        {
                            foreach (var customer in customers)
                            {
                                if (cmbRealizers.InvokeRequired)
                                    cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.Items.Add(customer)));
                                else
                                    cmbRealizers.Items.Add(customer);
                            }
                            if (cmbRealizers.InvokeRequired)
                                cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.SelectedIndex = 0));
                            else
                                cmbRealizers.SelectedIndex = 0;
                        }
                    }
                    break;
                case State.Product:
                    using (var db = new AppDbContext(connString))
                    {
                        int counter = 0;
                        var products = await db.Products.AsNoTracking().ToListAsync();
                        if (products.Count > 0)
                        {
                            foreach (var product in products)
                            {
                                if (cmbRealizers.InvokeRequired)
                                    cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.Items.Add(product)));
                                else
                                    cmbRealizers.Items.Add(product);
                                if (productId != -1)
                                {
                                    if (product.ProductId == productId)
                                    {
                                        productId = -1;
                                    }
                                    counter++;
                                }
                            }
                            if (counter > 0)
                            {
                                if (cmbRealizers.InvokeRequired)
                                    cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.SelectedIndex = counter - 1));
                                else
                                    cmbRealizers.SelectedIndex = counter - 1;
                            }
                            else
                            {
                                if (cmbRealizers.InvokeRequired)
                                    cmbRealizers.BeginInvoke(new MethodInvoker(() => cmbRealizers.SelectedIndex = 0));
                                else
                                    cmbRealizers.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            ErrorMessage error = new ErrorMessage("No products for sale");
                            error.ShowDialog();
                            state = State.Realizer;
                            ChangeStyle();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (state == State.Realizer)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (!RegexChecker.IsValidPhone(txtPhone.Text))
                    txtPhone.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtStreet.Text))
                    txtStreet.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCity.Text))
                    txtCity.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCountry.Text))
                    txtCountry.BackColor = Color.Red;
                else
                {
                    seller = new Seller()
                    {
                        FullName = txtName.Text,
                        Phone = txtPhone.Text,
                    };
                    sellerAddress = new Address()
                    {
                        Street = txtStreet.Text,
                        City = txtCity.Text,
                        CountryName = txtCountry.Text
                    };
                    txtName.Text = txtPhone.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                    state++;
                    ChangeStyle();
                    txtName.Enabled = true;
                    txtPhone.Enabled = true;
                    txtStreet.Enabled = true;
                    txtCity.Enabled = true;
                    txtCountry.Enabled = true;
                }
            }
            else if (state == State.Customer)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (!RegexChecker.IsValidPhone(txtPhone.Text))
                    txtPhone.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtStreet.Text))
                    txtStreet.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCity.Text))
                    txtCity.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCountry.Text))
                    txtCountry.BackColor = Color.Red;
                else
                {
                    customer = new Customer()
                    {
                        FullName = txtName.Text,
                        Phone = txtPhone.Text
                    };
                    customerAddress = new Address()
                    {
                        Street = txtStreet.Text,
                        City = txtCity.Text,
                        CountryName = txtCountry.Text
                    };
                    txtName.Text = txtPhone.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                    state++;
                    ChangeStyle();
                }
            }
            else
            {
                DateTime date;
                decimal price;
                int amount;
                try { id = Convert.ToInt32(txtName.Text); } catch (Exception) { txtName.BackColor = Color.Red; return; };
                try { amount = Convert.ToInt32(txtPhone.Text); } catch (Exception) { txtPhone.BackColor = Color.Red; return; };
                try { date = Convert.ToDateTime(txtStreet.Text); } catch (Exception) { txtStreet.BackColor = Color.Red; return; };
                try { price = Convert.ToDecimal(txtCity.Text); } catch (Exception) { txtCity.BackColor = Color.Red; return; };
                try { decimal percent = Convert.ToDecimal(txtMarkup.Text); } catch (Exception) { txtMarkup.BackColor = Color.Red; return; };
                try { decimal cost = Convert.ToDecimal(txtCost.Text); } catch (Exception) { txtCost.BackColor = Color.Red; return; };
                try { decimal priceOfOne = Convert.ToDecimal(txtCountry.Text); } catch (Exception) { txtCountry.BackColor = Color.Red; return; };

                bool isAmountEnough = false;
                using (var db = new AppDbContext(connString))
                {
                    supply = await db.SuppliedProducts.Where(s => s.ProductId == id).Include(s => s.Product).SingleAsync();
                    product = supply.Product;
                    isAmountEnough = supply.Amount >= amount;
                }
                if (!isAmountEnough)
                {
                    txtPhone.BackColor = Color.Red;
                    ErrorMessage msg = new ErrorMessage("There is no such quantity in stock");
                    msg.ShowDialog();
                    return;
                }
                Sale sale = new Sale()
                {
                    SaledProductCount = amount,
                    SaleDate = date,
                    Price = price,
                };
                try
                {
                    Ok ok = new Ok();
                    using (var db = new AppDbContext(connString))
                    {
                        if (!db.Addresses.Any(a => a.Street == sellerAddress.Street))
                            db.Addresses.Add(sellerAddress);
                        if (!db.Addresses.Any(a => a.Street == customerAddress.Street))
                            db.Addresses.Add(customerAddress);
                        if (!db.Sellers.Any(s => s.FullName == seller.FullName))
                            db.Sellers.Add(seller);
                        if (!db.Customers.Any(c => c.FullName == customer.FullName))
                            db.Customers.Add(customer);
                        seller.Address = sellerAddress;
                        customer.Address = customerAddress;
                        db.Sales.Add(sale);
                        sale.Customer = customer;
                        sale.Seller = seller;
                        sale.Product = product;
                        seller.Sales.Add(sale);
                        product.Sales.Add(sale);
                        supply.Amount = supply.Amount - amount;
                        db.SaveChanges();
                    }
                    ok.ShowDialog();
                    isProd = false;
                    txtName.Text = txtPhone.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                    state = 0;
                    ChangeStyle();
                }
                catch (Exception ex)
                {
                    ErrorMessage error = new ErrorMessage(ex.Message);
                    Debug.WriteLine(ex.InnerException);
                    error.ShowDialog();
                }
            }
        }

        private async void ChangeStyle()
        {
            if (state == State.Realizer)
            {
                btnConfirm.Visible = false;
                iconType.IconChar = FontAwesome.Sharp.IconChar.Portrait;
                lblAddress.Visible = true;
                lblCity.Visible = true;
                btnNew.Visible = true;
                lblCountry.Visible = true;
                txtCountry.Visible = true;
                txtStreet.Visible = true;
                lblName.Text = "Full Name";
                lblPhone.Text = "Phone";
                lblType.Text = "Realizer";
                lblStreet.Text = "Street";
                lblCity.Text = "City";
                txtPhone.Mask = "+00 (000) 000-00-00";
                txtStreet.Mask = "";
                btnNext.Visible = true;
                lblList.Text = "Select realizer from BD";
                lblCountry.Text = "Country";
                lblMarkup.Visible = false;
                lblCost.Visible = false;
                txtMarkup.Visible = false;
                txtCost.Visible = false;
                TurnAll();
                await FillCombo();
            }
            else if (state == State.Customer)
            {
                lblType.Text = "Customer";
                lblList.Text = "Select customer from BD";
                TurnAll();
                await FillCombo();
            }
            else
            {
                TurnAll();
                if (isIdSet)
                {
                    isProd = true;
                    await FillCombo(id);
                    txtName.Text = $"{id}";
                }
                else
                {
                    isProd = true;
                    await FillCombo();
                }
                txtPhone.Enabled = true;
                txtStreet.Enabled = true;
                txtCity.Enabled = true;
                txtCountry.Enabled = true;
                btnNew.Visible = false;
                lblAddress.Visible = false;
                btnNext.Visible = false;
                iconType.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
                lblName.Text = "Product Id";
                lblPhone.Text = "Amount";
                txtPhone.Text = "0";
                txtPhone.Mask = "";
                lblStreet.Text = "Realization date";
                txtStreet.Mask = "00/00/0000";
                lblCity.Text = "Total price";
                lblCountry.Text = "Price for unit";
                lblType.Text = "Product";
                lblList.Text = "Select product from BD";
            }
        }

        private void txtTextChanged(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.LightGray;
            if (state == State.Product && ((sender as MaskedTextBox).Name == "txtCost" || (sender as MaskedTextBox).Name == "txtMarkup" || (sender as MaskedTextBox).Name == "txtPhone"))
            {
                decimal res, tmp1, tmp2; int tmp3;
                if (!decimal.TryParse(txtCost.Text, out tmp1))
                {
                    txtCost.BackColor = Color.Red;
                    return;
                }
                else if (!decimal.TryParse(txtMarkup.Text, out tmp2))
                {
                    txtMarkup.BackColor = Color.Red;
                    return;
                }
                else if (!int.TryParse(txtPhone.Text, out tmp3))
                {
                    txtPhone.BackColor = Color.Red;
                    return;
                }
                else
                {
                    res = tmp1 + (tmp1 * (tmp2 / 100));
                    txtCountry.Text = $"{res}";
                    txtCity.Text = $"{res * tmp3}";
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblList.Visible = false;
            cmbRealizers.Visible = false;
            btnNew.Visible = false;
            btnSelect.Visible = false;
            lblAddress.Visible = true;
            lblInfo.Visible = true;
            lblName.Visible = true;
            lblPhone.Visible = true;
            lblStreet.Visible = true;
            lblCity.Visible = true;
            lblCountry.Visible = true;
            txtCity.Visible = true;
            txtCountry.Visible = true;
            txtName.Visible = true;
            txtPhone.Visible = true;
            txtStreet.Visible = true;
            if(isProd)
            {
                btnConfirm.Visible = true;
                lblAddress.Visible = false;
                btnNext.Visible = false;
                lblMarkup.Visible = true;
                lblCost.Visible = true;
                txtMarkup.Visible = true;
                txtCost.Visible = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            lblList.Visible = false;
            cmbRealizers.Visible = false;
            btnNew.Visible = false;
            btnSelect.Visible = false;
            lblAddress.Visible = true;
            lblInfo.Visible = true;
            lblName.Visible = true;
            lblPhone.Visible = true;
            lblStreet.Visible = true;
            lblCity.Visible = true;
            lblCountry.Visible = true;
            txtCity.Visible = true;
            txtCountry.Visible = true;
            txtName.Visible = true;
            txtPhone.Visible = true;
            txtStreet.Visible = true;
            if (state == State.Realizer)
            {
                txtName.Text = (cmbRealizers.SelectedItem as Seller).FullName;
                txtPhone.Text = (cmbRealizers.SelectedItem as Seller).Phone;
                txtStreet.Text = (cmbRealizers.SelectedItem as Seller).Address.Street;
                txtCity.Text = (cmbRealizers.SelectedItem as Seller).Address.City;
                txtCountry.Text = (cmbRealizers.SelectedItem as Seller).Address.CountryName;
            }
            else if(state == State.Customer)
            {
                txtName.Text = (cmbRealizers.SelectedItem as Customer).FullName;
                txtPhone.Text = (cmbRealizers.SelectedItem as Customer).Phone;
                txtStreet.Text = (cmbRealizers.SelectedItem as Customer).Address.Street;
                txtCity.Text = (cmbRealizers.SelectedItem as Customer).Address.City;
                txtCountry.Text = (cmbRealizers.SelectedItem as Customer).Address.CountryName;
            }
            else
            {
                txtName.Text = $"{(cmbRealizers.SelectedItem as Product).ProductId}";
                txtCost.Text = $"{(cmbRealizers.SelectedItem as Product).Price}";
                btnConfirm.Visible = true;
                lblAddress.Visible = false;
                btnNext.Visible = false;
                lblMarkup.Visible = true;
                lblCost.Visible = true;
                txtMarkup.Visible = true;
                txtCost.Visible = true;
            }
            txtName.Enabled = false;
            if (!isProd)
            {
                txtPhone.Enabled = false;
                txtStreet.Enabled = false;
                txtCity.Enabled = false;
                txtCountry.Enabled = false;
            }
        }

        private void cmbRealizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(state == State.Product && cmbRealizers.SelectedIndex != -1 && cmbRealizers.Items.Count != 0)
            {
                txtMarkup.Text = "0";
                txtCountry.Text = txtCost.Text;
                txtCity.Text = "0";
            }
        }
    }
}