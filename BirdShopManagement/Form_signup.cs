using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Form_signup : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Form_signup() { InitializeComponent(); }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();
            string address = txtAdd.Text.Trim();
            string contact = txtContact.Text.Trim();

            if (username == "" || password == "" || address == "" || contact == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    // Check if exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM signInTab WHERE Username=@u", con);
                    checkCmd.Parameters.AddWithValue("@u", username);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Username already exists");
                        return;
                    }

                    // 1. Insert into Profile Table
                    string q1 = "INSERT INTO signUpTab (Username, Password, Address, Contact) VALUES (@un,@pw,@ad,@ct)";
                    SqlCommand cmd1 = new SqlCommand(q1, con);
                    cmd1.Parameters.AddWithValue("@un", username);
                    cmd1.Parameters.AddWithValue("@pw", password);
                    cmd1.Parameters.AddWithValue("@ad", address);
                    cmd1.Parameters.AddWithValue("@ct", contact);
                    cmd1.ExecuteNonQuery();

                    // 2. Insert into Auth Table with Role
                    string q2 = "INSERT INTO signInTab (Username, Password, UserRole) VALUES (@un, @pw, 'CUSTOMER')";
                    SqlCommand cmd2 = new SqlCommand(q2, con);
                    cmd2.Parameters.AddWithValue("@un", username);
                    cmd2.Parameters.AddWithValue("@pw", password);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Signup successful! Please login.");
                    new Welcome_Form().Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void signup_back_btn_click(object sender, EventArgs e)
        {
            new Welcome_Form().Show();
            this.Hide();
        }
    }
}