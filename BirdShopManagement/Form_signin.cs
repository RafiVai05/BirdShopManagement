using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Form_signin : Form
    {
        public Form_signin()
        {
            InitializeComponent();
        }

        private void Form_signin_Load(object sender, EventArgs e)
        {

        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            string connStr = @"Data Source=localhost\SQLEXPRESS;
                               Initial Catalog=birdshopmanagement;
                               Integrated Security=True;
                               Encrypt=True;
                               TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = "SELECT COUNT(*) FROM signInTab WHERE Username=@u AND Password=@p";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Sign In successful!");


                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void signin_back_btn_Click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Hide();
        }
    }
}
