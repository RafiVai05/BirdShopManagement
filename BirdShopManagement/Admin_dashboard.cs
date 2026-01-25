using System;
using System.Data.SqlClient; // <--- This is required for SQL
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Admin_dashboard : Form
    {
        // 1. Connection String
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Admin_dashboard()
        {
            InitializeComponent();

            // 2. We call the function HERE so it runs immediately when the form opens
            LoadDashboardStats();
        }

        // 3. This is the custom function that fetches the numbers
        private void LoadDashboardStats()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    // --- Count Customers ---
                    string qCust = "SELECT COUNT(*) FROM userTab WHERE UserRole = 'CUSTOMER'";
                    SqlCommand cmdCust = new SqlCommand(qCust, con);
                    int custCount = (int)cmdCust.ExecuteScalar();
                    lblCustCount.Text = custCount.ToString();

                    // --- Count Employees ---
                    string qEmp = "SELECT COUNT(*) FROM Employees";
                    SqlCommand cmdEmp = new SqlCommand(qEmp, con);
                    int empCount = (int)cmdEmp.ExecuteScalar();
                    lblEmpCount.Text = empCount.ToString();

                    // --- Count Birds (Sum of Quantity) ---
                    string qBirds = "SELECT ISNULL(SUM(Quantity), 0) FROM birdsTab";
                    SqlCommand cmdBirds = new SqlCommand(qBirds, con);
                    object birdResult = cmdBirds.ExecuteScalar();
                    lblBirdCount.Text = birdResult.ToString();

                    // --- Count Accessories (Sum of Quantity) ---
                    string qAcs = "SELECT ISNULL(SUM(Quantity), 0) FROM acsTab";
                    SqlCommand cmdAcs = new SqlCommand(qAcs, con);
                    object acsResult = cmdAcs.ExecuteScalar();
                    lblAcsCount.Text = acsResult.ToString();

                    // --- Total Income ---
                    string qIncome = "SELECT ISNULL(SUM(Total_Price), 0) FROM OrdersTab";
                    SqlCommand cmdIncome = new SqlCommand(qIncome, con);
                    object incomeResult = cmdIncome.ExecuteScalar();

                    decimal income = Convert.ToDecimal(incomeResult);
                    lblTotalIncome.Text = "BDT " + income.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message);
            }
        }

        // These empty click methods were created when you double-clicked the labels.
        // You can leave them empty; it won't hurt anything.
        private void lblCustCount_Click(object sender, EventArgs e) { }
        private void lblEmpCount_Click(object sender, EventArgs e) { }
        private void lblBirdCount_Click(object sender, EventArgs e) { }
        private void lblAcsCount_Click(object sender, EventArgs e) { }
        private void lblTotalIncome_Click(object sender, EventArgs e) { }
    }
}