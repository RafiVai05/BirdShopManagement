using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class CustomerHistory : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public CustomerHistory()
        {
            InitializeComponent();
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }

        public void LoadHistoryData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    // Query to get all columns from the history table
                    string query = "SELECT O_ID as 'Order ID', Username, Product_Name as 'Product', " +
                                   "Category, Quantity, Total_Price as 'Total BDT', Order_Date as 'Date' " +
                                   "FROM OrdersTab ORDER BY O_ID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHistory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }
    }
}