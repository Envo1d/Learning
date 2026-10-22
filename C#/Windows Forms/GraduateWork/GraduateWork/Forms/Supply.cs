using EntityFramework.Exceptions.Common;
using GraduateWork.Common;
using GraduateWork.DB;
using GraduateWork.DB.Entity;

namespace GraduateWork
{
    public partial class Supply : Form
    {
        enum EntState
        {
            Product,
            Producer,
            Supplier
        }

        private EntState state;
        private Product? product;
        private Producer? producer;
        private Supplier? supplier;
        private SuppliedProduct? suppliedProduct;
        private Address? addressProducer;
        private Address? addressSupplier;
        private Unit? unit;
        private string connString;
        public Supply(string conn)
        {
            InitializeComponent();
            state = EntState.Product;
            lblAddress.Visible = false;
            lblStreet.Visible = false;
            txtStreet.Visible = false;
            lblCity.Visible = false;
            txtCity.Visible = false;
            lblCountry.Visible = false;
            txtCountry.Visible = false;
            connString = conn;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(state == EntState.Product)
            {
                decimal price;
                int amount;
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCustom1.Text))
                    txtCustom1.BackColor = Color.Red;
                else if (!decimal.TryParse(txtCustom2.Text, out price))
                    txtCustom2.BackColor = Color.Red;
                else if (!int.TryParse(txtCustom4.Text, out amount))
                    txtCustom4.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCustom5.Text))
                    txtCustom5.BackColor = Color.Red;
                else
                {
                    product = new Product
                    {
                        Name = txtName.Text,
                        Model = txtCustom1.Text,
                        Price = price
                    };
                    unit = new Unit
                    {
                        UnitName = txtCustom5.Text.ToUpper()
                    };
                    suppliedProduct = new SuppliedProduct
                    {
                        Amount = amount,
                        OriginalAmount = amount
                    };
                    txtName.Text = txtCustom1.Text = txtCustom2.Text = txtCustom4.Text = txtCustom5.Text = "";
                    state++;
                    ChangeContent();
                }
            }
            else if(state == EntState.Producer)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (!RegexChecker.IsValidEmail(txtCustom1.Text))
                    txtCustom1.BackColor = Color.Red;
                else if (!RegexChecker.IsValidPhone(txtCustom2.Text))
                    txtCustom2.BackColor = Color.Red;
                else
                {
                    producer = new Producer
                    {
                        Name = txtName.Text,
                        Email = txtCustom1.Text,
                        Phone = txtCustom2.Text,
                    };
                    addressProducer = new Address
                    {
                        Street = txtStreet.Text,
                        City = txtCity.Text,
                        CountryName = txtCountry.Text
                    };
                    txtName.Text = txtCustom1.Text = txtCustom2.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                    state++;
                    ChangeContent();
                }
            }
            else
            {
                DateTime date = new DateTime();
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCustom1.Text))
                    txtCustom1.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCustom2.Text))
                    txtCustom2.BackColor = Color.Red;
                else if (!RegexChecker.IsValidPhone(txtCustom4.Text))
                    txtCustom4.BackColor = Color.Red;
                try
                {
                    date = Convert.ToDateTime(txtCustom5.Text);
                }catch(Exception) { txtCustom5.BackColor = Color.Red; return; }
                if (date.Year < 2020)
                {
                    txtCustom5.BackColor = Color.Red;
                    return;
                }
                supplier = new Supplier
                {
                    Name = txtName.Text,
                    Bank = txtCustom1.Text,
                    Bill = txtCustom2.Text,
                    Phone = txtCustom4.Text,
                };
                suppliedProduct.SupDate = date;
                addressSupplier = new Address
                {
                    Street = txtStreet.Text,
                    City = txtCity.Text,
                    CountryName = txtCountry.Text
                };

                try
                {
                    Ok ok = new Ok();

                    using (var db = new AppDbContext(connString))
                    {
                        if (!db.Units.Any(u => u.UnitName == unit.UnitName))
                            db.Units.Add(unit);
                        product.UnitNavigation = unit;
                        if (!db.Addresses.Any(a=> a.Street == addressProducer.Street))
                            db.Addresses.Add(addressProducer);
                        producer.Address = addressProducer;
                        if (!db.Addresses.Any(a=> a.Street == addressSupplier.Street))
                            db.Addresses.Add(addressSupplier);
                        supplier.Address = addressSupplier;
                        if (!db.Producers.Any(p=>p.Name == producer.Name))
                            db.Producers.Add(producer);
                        product.Producer = producer;
                        if (!db.Suppliers.Any(s=>s.Name == supplier.Name))
                            db.Suppliers.Add(supplier);
                        suppliedProduct.Supplier = supplier;
                        if (!db.Products.Any(p=>p.Name == product.Name && p.Model == product.Model))
                            db.Products.Add(product);
                        suppliedProduct.Product = product;
                        unit.Products.Add(product);
                        supplier.SuppliedProducts.Add(suppliedProduct);
                        product.SuppliedProducts.Add(suppliedProduct);
                        producer.Products.Add(product);
                        addressProducer.Producers.Add(producer);
                        addressSupplier.Suppliers.Add(supplier);

                        db.SaveChanges();
                    }

                    txtName.Text = txtCustom1.Text = txtCustom2.Text = txtCustom4.Text = txtCustom5.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                    ResetObjects();

                    ok.ShowDialog();
                    state = 0;
                    ChangeContent();
                }
                catch (Exception ex)
                {
                    ErrorMessage error = new ErrorMessage(ex.Message);
                    error.ShowDialog();
                }
            }
        }

        private void ResetObjects()
        {
            product = null;
            producer = null;
            supplier = null;
            suppliedProduct = null;
            addressProducer = null;
            addressSupplier = null;
            unit = null;
        }

        private void ChangeContent()
        {
            if(state == EntState.Product)
            {
                btnNext.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
                lblType.Text = "Product";
                lblName.Text = "Product Name";
                lblCustom1.Text = "Model";
                lblCustom2.Text = "Price";
                lblCustom4.Text = "Amount";
                lblCustom5.Text = "Unit";
                txtCustom1.Mask = "";
                txtCustom2.Mask = "";
                txtCustom4.Mask = "";
                txtCustom5.Mask = "";
                lblAddress.Visible = false;
                lblStreet.Visible = false;
                txtStreet.Visible = false;
                lblCity.Visible = false;
                txtCity.Visible = false;
                lblCountry.Visible = false;
                txtCountry.Visible = false;
            }
            else if(state == EntState.Producer)
            {
                lblType.Text = "Producer";
                lblName.Text = "Producer Name";
                lblCustom1.Text = "E-mail";
                lblCustom2.Text = "Phone";
                txtCustom2.Mask = "+00 (000) 000-00-00";
                lblCustom4.Visible = false;
                txtCustom4.Visible = false;
                lblCustom5.Visible = false;
                txtCustom5.Visible = false;
                lblAddress.Visible = true;
                lblStreet.Visible = true;
                txtStreet.Visible = true;
                lblCity.Visible = true;
                txtCity.Visible = true;
                lblCountry.Visible = true;
                txtCountry.Visible = true;
            }
            else
            {
                btnNext.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
                lblType.Text = "Supplier";
                lblName.Text = "Supplier Name";
                lblCustom1.Text = "Bank";
                lblCustom2.Text = "Bill";
                lblCustom4.Text = "Phone";
                txtCustom2.Mask = ""; 
                txtCustom4.Mask = "+00 (000) 000-00-00";
                txtCustom5.Mask = "00/00/0000";
                lblCustom4.Visible = true;
                txtCustom4.Visible = true;
                txtCustom5.Visible = true;
                lblCustom5.Visible = true;
                lblCustom5.Text = "Supply Date";
                lblAddress.Visible = true;
                lblStreet.Visible = true;
                txtStreet.Visible = true;
                lblCity.Visible = true;
                txtCity.Visible = true;
                lblCountry.Visible = true;
                txtCountry.Visible = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).BackColor = Color.LightGray;
        }
    }
}