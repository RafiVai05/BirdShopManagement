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
    public partial class Form_signup : Form
    {
        public Form_signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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

            string connStr =
                @"Data Source=localhost\SQLEXPRESS;
                  Initial Catalog=birdshopdb;
                  Integrated Security=True;
                  Encrypt=True;
                  TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string checkQuery =
                        "SELECT COUNT(*) FROM signInTab WHERE Username=@u";
                       
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@u", username);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Username already exists");
                        return;

                    }


                    string signupQuery =
                        "INSERT INTO signUpTab (Username, Password, Address, Contact) " +
                        "VALUES (@un,@pw,@ad,@ct)";

                    SqlCommand signupCmd = new SqlCommand(signupQuery, con);
                    signupCmd.Parameters.AddWithValue("@un", username);
                    signupCmd.Parameters.AddWithValue("@pw", password);
                    signupCmd.Parameters.AddWithValue("@ad", address);
                    signupCmd.Parameters.AddWithValue("@ct", contact);
                    signupCmd.ExecuteNonQuery();


                    string signinQuery =
                        "INSERT INTO signInTab (Username, Password) VALUES (@un,@pw)";

                    SqlCommand signinCmd = new SqlCommand(signinQuery, con);
                    signinCmd.Parameters.AddWithValue("@un", username);
                    signinCmd.Parameters.AddWithValue("@pw", password);
                    signinCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Signup successful! Please login.");


               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void signup_back_btn_click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_signup_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_bx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_bx_ShowPass.Checked)
            {
                txtPass.UseSystemPasswordChar = true;

            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
        }
    }
}
