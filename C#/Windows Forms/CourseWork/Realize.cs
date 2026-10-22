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
    public partial class Realize : Form
    {

        class Persone
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public int AddressID { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}";
            }
        }
        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Amount { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, Name: {Name}";
            }
        }

        enum State
        {
            Realizer,
            Customer,
            Product
        }

        private State state = State.Realizer;

        string connString;
        int id;
        bool isIdSet = false;
        bool isRealizersAdded = false;
        bool isProductAddedd = false;
        bool isNewClicked = false;
        bool isProd = false;
        Persone persone;

        public Realize(string conn)
        {
            InitializeComponent();
            connString = conn;
            btnConfirm.Visible = false;
            lblMarkup.Visible = false;
            lblCost.Visible = false;
            txtMarkup.Visible = false;
            txtCost.Visible = false;
            FillCombo();
            if (isRealizersAdded)
                TurnAll();
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
            FillCombo();
            if (isRealizersAdded)
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
        void FillCombo(bool prod = false)
        {
            if (!prod)
            {
                if (!isRealizersAdded)
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"select count(*) from Seller";
                        var reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.GetInt32(0) != 0)
                            isRealizersAdded = true;
                    }
                if(isRealizersAdded)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        cmbRealizers.Items.Clear();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"select SellerId, Name, Phone, Address.AddressId, Address.Street, Address.City, Address.CountryName from Seller " +
                            $"join Address on Address.AddressId = Seller.AddressId";
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmbRealizers.Items.Add(new Persone { Id = reader.GetInt32(0), Name = reader.GetString(1), Phone = reader.GetString(2), AddressID = reader.GetInt32(3), Street = reader.GetString(4), City = reader.GetString(5), Country = reader.GetString(6) });
                        }
                        cmbRealizers.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if(!isProductAddedd)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"select count(*) from SuppliedProducts";
                        var reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.GetInt32(0) != 0)
                            isProductAddedd = true;
                    }
                }
                if(isProductAddedd)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        cmbRealizers.Items.Clear();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = $"select Product.ProductId, Product.Name, Product.Price, OriginalAmount from SuppliedProducts " +
                            $"join Product on Product.ProductId = SuppliedProducts.ProductId";
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmbRealizers.Items.Add(new Product { Id = reader.GetInt32(0), Name = reader.GetString(1), Price = reader.GetDecimal(2), Amount = reader.GetInt32(3) });
                        }
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
        }
        bool isValidPhone(string email)
        {
            string pattern = @"^\(\d{3}\) \d{3}-\d{2}-\d{2}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (state == State.Realizer)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                    txtName.BackColor = Color.Red;
                else if (!isValidPhone(txtPhone.Text))
                    txtPhone.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtStreet.Text))
                    txtStreet.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCity.Text))
                    txtCity.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCountry.Text))
                    txtCountry.BackColor = Color.Red;
                else
                {
                    if(isNewClicked)
                    persone = new Persone
                    {
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Street = txtStreet.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text
                    };
                    else
                    {
                        persone = cmbRealizers.SelectedItem as Persone;
                    }
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
                else if (!isValidPhone(txtPhone.Text))
                    txtPhone.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtStreet.Text))
                    txtStreet.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCity.Text))
                    txtCity.BackColor = Color.Red;
                else if (string.IsNullOrEmpty(txtCountry.Text))
                    txtCountry.BackColor = Color.Red;
                else
                {
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
                try { id = Convert.ToInt32(txtName.Text); } catch (Exception msg) { txtName.BackColor = Color.Red; return; };
                try { amount = Convert.ToInt32(txtPhone.Text); } catch (Exception msg) { txtPhone.BackColor = Color.Red; return; };
                try { date = Convert.ToDateTime(txtStreet.Text); } catch (Exception msg) { txtStreet.BackColor = Color.Red; return; };
                try { price = Convert.ToInt32(txtCity.Text); } catch (Exception msg) { txtCity.BackColor = Color.Red; return; };
                try { decimal percent = Convert.ToDecimal(txtMarkup.Text); }catch(Exception msg) { txtMarkup.BackColor = Color.Red; return; };
                try { decimal cost = Convert.ToDecimal(txtCost.Text); }catch(Exception msg) { txtCost.BackColor = Color.Red; return; };
                try { decimal priceOfOne = Convert.ToDecimal(txtCountry.Text); }catch(Exception msg) { txtCountry.BackColor = Color.Red; return; };

                bool isProductExist = false;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if exists (select 1 from Product where ProductId = {id}) select 1 else select 0";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    isProductExist = Convert.ToBoolean(reader.GetInt32(0));
                }
                if (!isProductExist)
                {
                    txtName.BackColor = Color.Red;
                    ErrorMessage msg = new ErrorMessage("There is no product with this ID");
                    msg.ShowDialog();
                    return;
                }
                bool isAmountEnough = false;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if exists (select Amount from SuppliedProducts where ProductId = {id} and Amount >= {amount})  select 1 else select 0";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    isAmountEnough = Convert.ToBoolean(reader.GetInt32(0));
                }
                if (!isAmountEnough)
                {
                    txtPhone.BackColor = Color.Red;
                    ErrorMessage msg = new ErrorMessage("There is no such quantity in stock");
                    msg.ShowDialog();
                    return;
                }
                Ok ok = new Ok();
                int realizerId;
                int addressId;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Address where Street = N'{persone.Street}' and City = N'{persone.City}' and CountryName = N'{persone.Country}') begin " +
                        $"insert into Address(Street, City, CountryName) values(N'{persone.Street}', N'{persone.City}', N'{persone.Country}') " +
                        $"select AddressId from Address where Street = N'{persone.Street}' and City = N'{persone.City}' and CountryName = N'{persone.Country}' " +
                        $"end else select AddressId from Address where Street = N'{persone.Street}' and City = N'{persone.City}' and CountryName = N'{persone.Country}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    addressId = reader.GetInt32(0);
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"if not exists (select 1 from Seller where Name = N'{persone.Name}' and AddressId = {addressId} and Phone = N'{persone.Phone}') begin " +
                        $"insert into Seller(Name, AddressId, Phone) values(N'{persone.Name}', {addressId}, N'{persone.Phone}')  " +
                        $"select SellerId from Seller where Name = N'{persone.Name}' and AddressId = {addressId} and Phone = N'{persone.Phone}' " +
                        $"end else select SellerId from Seller where Name = N'{persone.Name}' and AddressId = {addressId} and Phone = N'{persone.Phone}'";
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    realizerId = reader.GetInt32(0);
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.CommandText = $"if not exists (select 1 from Sale where SaleDate = @DATE and SaledProductCount = {amount} and SellerId = {realizerId} and ProductId = {id} and Price = {price}) begin " +
                        $"insert into Sale(SaleDate, SaledProductCount, SellerId, ProductId, Price) values(@DATE, {amount}, {realizerId}, {id}, {price}) " +
                        $"update SuppliedProducts set Amount = Amount - {amount} where ProductId = {id} " +
                        $"end";
                    cmd.ExecuteNonQuery();
                }
                ok.ShowDialog();
                isProd = false;
                txtName.Text = txtPhone.Text = txtStreet.Text = txtCity.Text = txtCountry.Text = "";
                state = 0;
                ChangeStyle();
            }
        }

        private void ChangeStyle()
        {
            if (state == State.Realizer)
            {
                btnConfirm.Visible = false;
                iconType.IconChar = FontAwesome.Sharp.IconChar.Portrait;
                lblAddress.Visible = true;
                lblCity.Visible = true;
                lblCountry.Visible = true;
                txtCountry.Visible = true;
                txtStreet.Visible = true;
                lblName.Text = "Full Name";
                lblPhone.Text = "Phone";
                lblType.Text = "Realizer";
                lblStreet.Text = "Street";
                lblCity.Text = "City";
                txtPhone.Mask = "(000) 000-00-00";
                txtStreet.Mask = "";
                btnNext.Visible = true;
                lblList.Text = "Select realizer from BD";
                lblCountry.Text = "Country";
                lblMarkup.Visible = false;
                lblCost.Visible = false;
                txtMarkup.Visible = false;
                txtCost.Visible = false;
                TurnAll();
                FillCombo();
            }
            else if (state == State.Customer)
            {
                lblType.Text = "Customer";
            }
            else
            {
                if (!isIdSet)
                {
                    isProd = true;
                    TurnAll();
                    FillCombo(true);
                }
                else
                {
                    txtName.Text = $"{id}";
                }
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
            isNewClicked = true;
            btnConfirm.Visible = true;
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
            if (!isProd)
            {
                txtName.Text = (cmbRealizers.SelectedItem as Persone).Name;
                txtPhone.Text = (cmbRealizers.SelectedItem as Persone).Phone;
                txtStreet.Text = (cmbRealizers.SelectedItem as Persone).Street;
                txtCity.Text = (cmbRealizers.SelectedItem as Persone).City;
                txtCountry.Text = (cmbRealizers.SelectedItem as Persone).Country;
            }
            else
            {
                txtName.Text = $"{(cmbRealizers.SelectedItem as Product).Id}";
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
                txtCost.Text = $"{(cmbRealizers.SelectedItem as Product).Price / (cmbRealizers.SelectedItem as Product).Amount}";
                txtMarkup.Text = "0";
                txtCountry.Text = txtCost.Text;
                txtCity.Text = "0";
            }
        }
    }
}