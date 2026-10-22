using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CourseWork
{
    public partial class Supply : Form
    {
        class ProductInfo
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public decimal Price { get; set; }
            public string Unit { get; set; }
            public int Amount { get; set; }
        }

        class ProducerInfo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }

        class SupplierInfo
        {
            public string Name { get; set; }
            public string Bank { get; set; }
            public string Bill { get; set; }
            public string Phone { get; set; }
            public DateTime suppDate { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }

        enum EntState
        {
            Product,
            Producer,
            Supplier
        }

        private EntState state;
        private ProductInfo product;
        private ProducerInfo producer;
        private SupplierInfo supplier;
        string connString;
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

        bool isValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        bool isValidPhone(string email)
        {
            string pattern = @"^\(\d{3}\) \d{3}-\d{2}-\d{2}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
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
                    product = new ProductInfo
                    {
                        Name = txtName.Text,
                        Model = txtCustom1.Text,
                        Price = price,
                        Amount = amount,
                        Unit = txtCustom5.Text.ToLower()
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
                else if (!isValidEmail(txtCustom1.Text))
                    txtCustom1.BackColor = Color.Red;
                else if (!isValidPhone(txtCustom2.Text))
                    txtCustom2.BackColor = Color.Red;
                else
                {
                    producer = new ProducerInfo
                    {
                        Name = txtName.Text,
                        Email = txtCustom1.Text,
                        Phone = txtCustom2.Text,
                        Street = txtStreet.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text
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
                else if (!isValidPhone(txtCustom4.Text))
                    txtCustom4.BackColor = Color.Red;
                try
                {
                    date = Convert.ToDateTime(txtCustom5.Text);
                }catch(Exception msg) { txtCustom5.BackColor = Color.Red; return; }
                if (date.Year < 2020)
                {
                    txtCustom5.BackColor = Color.Red;
                    return;
                }
                supplier = new SupplierInfo
                {
                    Name = txtName.Text,
                    Bank = txtCustom1.Text,
                    Bill = txtCustom2.Text,
                    Phone = txtCustom4.Text,
                    Street= txtStreet.Text,
                    City= txtCity.Text,
                    Country = txtCountry.Text, 
                    suppDate = date
                };
                txtName.Text = txtCustom1.Text = txtCustom2.Text = txtCustom4.Text = txtCustom5.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                Ok ok = new Ok();
                byte unitId;
                int producerAddId;
                int suppAddId;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Units where UnitName = N'{product.Unit}') begin insert into Units(UnitName) values(N'{product.Unit}') select UnitId from Units where UnitName = N'{product.Unit}' " +
                        $"end else select UnitId from Units where UnitName = N'{product.Unit}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    unitId = reader.GetByte(0);
                }
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Address where Street = N'{producer.Street}' and City = N'{producer.City}' and CountryName = N'{producer.Country}') begin " +
                        $"insert into Address(Street, City, CountryName) values(N'{producer.Street}', N'{producer.City}', N'{producer.Country}') " +
                        $"select AddressId from Address where Street = N'{producer.Street}' and City = N'{producer.City}' and CountryName = N'{producer.Country}' " +
                        $"end else select AddressId from Address where Street = N'{producer.Street}' and City = N'{producer.City}' and CountryName = N'{producer.Country}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    producerAddId = reader.GetInt32(0);
                }
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Address where Street = N'{supplier.Street}' and City = N'{supplier.City}' and CountryName = N'{supplier.Country}') begin " +
                        $"insert into Address(Street, City, CountryName) values(N'{supplier.Street}', N'{supplier.City}', N'{supplier.Country}') " +
                        $"select AddressId from Address where Street = N'{supplier.Street}' and City = N'{supplier.City}' and CountryName = N'{supplier.Country}' " +
                        $"end else select AddressId from Address where Street = N'{supplier.Street}' and City = N'{supplier.City}' and CountryName = N'{supplier.Country}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    suppAddId = reader.GetInt32(0);
                }
                int producerId;
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Producer where Name = N'{producer.Name}' and AddressId = {producerAddId} and Email = N'{producer.Email}' and Phone = N'{producer.Phone}') begin " +
                        $"insert into Producer(Name, AddressId, Email, Phone) values(N'{producer.Name}', {producerAddId}, N'{producer.Email}', N'{producer.Phone}')  " +
                        $"select ProducerId from Producer where Name = N'{producer.Name}' and AddressId = {producerAddId} and Email = N'{producer.Email}' and Phone = N'{producer.Phone}' " +
                        $"end else select ProducerId from Producer where Name = N'{producer.Name}' and AddressId = {producerAddId} and Email = N'{producer.Email}' and Phone = N'{producer.Phone}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    producerId = reader.GetInt32(0);
                }
                int supplierId;
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Supplier where Name = N'{supplier.Name}' and AddressId = {suppAddId} and Phone = N'{supplier.Phone}' and Bank = N'{supplier.Bank}' and Bill = N'{supplier.Bill}') begin " +
                        $"insert into Supplier(Name, AddressId, Phone, Bank, Bill) values(N'{supplier.Name}', {suppAddId}, N'{supplier.Phone}', N'{supplier.Bank}', N'{supplier.Bill}')  " +
                        $"select SupplierId from Supplier where Name = N'{supplier.Name}' and AddressId = {suppAddId} and Phone = N'{supplier.Phone}' and Bank = N'{supplier.Bank}' and Bill = N'{supplier.Bill}' " +
                        $"end else select SupplierId from Supplier where Name = N'{supplier.Name}' and AddressId = {suppAddId} and Phone = N'{supplier.Phone}' and Bank = N'{supplier.Bank}' and Bill = N'{supplier.Bill}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    supplierId = reader.GetInt32(0);
                }
                int productId;
                using(SqlConnection conn  = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Product where Name = N'{product.Name}' and Model = N'{product.Model}' and Price = {product.Price} and Unit = {unitId} and ProducerId = {producerId}) begin " +
                        $"insert into Product(Name, Model, Price, Unit, ProducerId) values(N'{product.Name}', N'{product.Model}', {product.Price}, {unitId}, {producerId})  " +
                        $"select ProductId from Product where Name = N'{product.Name}' and Model = N'{product.Model}' and Price = {product.Price} and Unit = {unitId} and ProducerId = {producerId} " +
                        $"end else select ProductId from Product where Name = N'{product.Name}' and Model = N'{product.Model}' and Price = {product.Price} and Unit = {unitId} and ProducerId = {producerId}";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    productId = reader.GetInt32(0);
                }
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@DATE", supplier.suppDate);
                    cmd.CommandText = $"if not exists (select 1 from SuppliedProducts where SupDate = @DATE and Amount = {product.Amount} and SupplierId = {supplierId} and ProductId = {productId} and OriginalAmount = {product.Amount}) begin " +
                        $"insert into SuppliedProducts(SupDate, Amount, OriginalAmount, SupplierId, ProductId) values(@DATE, {product.Amount}, {product.Amount}, {supplierId}, {productId})  " +
                        $"end";
                    cmd.ExecuteNonQuery();
                }
                ok.ShowDialog();
                state = 0;
                ChangeContent();
            }
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
                txtCustom2.Mask = "(000) 000-00-00";
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
                txtCustom4.Mask = "(000) 000-00-00";
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