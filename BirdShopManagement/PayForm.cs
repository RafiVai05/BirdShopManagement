using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class PayForm : Form
    {
        // Centralized Connection String
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public PayForm()
        {
            InitializeComponent();
            // Automatically generate columns in the grid based on database results
            dataGridView1.AutoGenerateColumns = true;
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            // Verify if a session exists
            if (string.IsNullOrEmpty(UserSession.CurrentUsername))
            {
                MessageBox.Show("No active user session found. Please log in again.");
                this.Close();
                return;
            }

            // Automatically pull data when the form opens
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    // Fetch only the Address and Contact for the current logged-in user
                    string query = "SELECT Address, Contact FROM signUpTab WHERE Username = @u";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@u", UserSession.CurrentUsername);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 1. Populate the DataGridView
                    dataGridView1.DataSource = dt;

                    // 2. AUTOMATICALLY fill the textboxes with the customer's details
                    if (dt.Rows.Count > 0)
                    {
                        txtaddress.Text = dt.Rows[0]["Address"].ToString();
                        txtcontact.Text = dt.Rows[0]["Contact"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No shipping details found for: " + UserSession.CurrentUsername);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtaddress.Text) || string.IsNullOrWhiteSpace(txtcontact.Text))
            {
                MessageBox.Show("Address and Contact fields cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    // Update only the current user's profile
                    string query = "UPDATE signUpTab SET Address=@ad, Contact=@ct WHERE Username=@un";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ad", txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@ct", txtcontact.Text.Trim());
                    cmd.Parameters.AddWithValue("@un", UserSession.CurrentUsername);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Profile Updated Successfully!");
                        LoadUserData(); // Refresh the grid and textboxes
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
            }
        }

        // Optional: Manual sync if a row is clicked in the grid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtaddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["Contact"].Value?.ToString() ?? "";
            }
        }

        private void pay_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Processed for: " + UserSession.CurrentUsername +
                            "\nShipping to: " + txtaddress.Text);
        }
    }
}