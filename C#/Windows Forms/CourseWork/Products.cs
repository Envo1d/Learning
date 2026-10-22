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

namespace CourseWork
{
    public partial class Products : Form
    {
        string connString;
        public Products(string conn)
        {
            InitializeComponent();
            connString = conn;
            lstView.View = View.Details;
            lstView.Columns.Add("ID");
            lstView.Columns.Add("Name");
            lstView.Columns.Add("Model");
            lstView.Columns.Add("Purchase price");
            lstView.Columns.Add("Amount");
            lstView.Columns.Add("Unit");
            lstView.Columns.Add("Producer");
            lstView.FullRowSelect = true;
        }
        private void Products_Load(object sender, EventArgs e)
        {
            lstView.Items.Clear();
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select Product.ProductId, Product.Name, Product.Model, Product.Price, Amount, Units.UnitName, Producer.Name from SuppliedProducts " +
                    "join Product on Product.ProductId = SuppliedProducts.ProductId " +
                    "join Units on Units.UnitId = Product.Unit " +
                    "join Producer on Producer.ProducerId = Product.ProducerId";
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var item = lstView.Items.Add(reader.GetInt32(0).ToString());
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDecimal(3).ToString());
                    item.SubItems.Add(reader.GetInt32(4).ToString());
                    item.SubItems.Add(reader.GetString(5));
                    item.SubItems.Add(reader.GetString(6));
                }
            }
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Product set Price = Price*(1-0.03)";
                cmd.ExecuteNonQuery();
            }
            Products_Load(null, null);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lstView.SelectedItems[0].Text);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"delete from SuppliedProducts where ProductId = {id}";
                cmd.ExecuteNonQuery();
            }
            Products_Load(null, null);
        }

        private void btnRealize_Click(object sender, EventArgs e)
        {
            (Owner as Form1).isRealizeClicked = true;
            (Owner as Form1).prodIdRealize = Convert.ToInt32(lstView.SelectedItems[0].Text);
            (Owner as Form1).Realize();
            this.Close();
        }
    }
}