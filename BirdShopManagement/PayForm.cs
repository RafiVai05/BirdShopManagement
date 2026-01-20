using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class PayForm : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public PayForm()
        {
            InitializeComponent();
            // This ensures columns are created automatically from the database
            dataGridView1.AutoGenerateColumns = true;
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            // Debug check: If this shows a blank message, your Signup/Login didn't set the session!
            if (string.IsNullOrEmpty(UserSession.CurrentUsername))
            {
                MessageBox.Show("Debug: No user logged in. Please sign up first.");
                return;
            }
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    // Use a query that specifically targets the current user
                    string query = "SELECT Address, Contact FROM signUpTab WHERE Username = @u";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@u", UserSession.CurrentUsername);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Force the grid to refresh its data source
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Note: Use CellClick instead of CellContentClick if you want to click anywhere in the row
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Use .ToString() carefully in case values are null in DB
                txtaddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["Contact"].Value?.ToString() ?? "";
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string query = "UPDATE signUpTab SET Address=@ad, Contact=@ct WHERE Username=@un";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ad", txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@ct", txtcontact.Text.Trim());
                    cmd.Parameters.AddWithValue("@un", UserSession.CurrentUsername);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Profile Updated!");
                        LoadUserData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Failed: " + ex.Message); }
        }
    }
}