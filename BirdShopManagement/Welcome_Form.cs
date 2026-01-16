using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void Welcome_Form_Load(object sender, EventArgs e)
        {
            // Add roles to ComboBox
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("EMPLOYEE");
            comboBox1.Items.Add("CUSTOMER");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = comboBox1.SelectedItem?.ToString();

            // Make login controls visible
            textUserName.Visible = true;
            textPassword.Visible = true;
            signin_btn.Visible = true;
            exit_btn.Visible = true;

            // Only customers can sign up or see "Forgot Password"
            signup.Visible = role == "CUSTOMER";
            no_account_lbl.Visible = role == "CUSTOMER";
            forget_btn.Visible = role == "CUSTOMER";
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            string selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            string connStr = @"Data Source=localhost\SQLEXPRESS;
                               Initial Catalog=birdshopdb;
                               Integrated Security=True;
                               Encrypt=True;
                               TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    SqlCommand cmd = null;

                    if (selectedRole == "ADMIN")
                    {
                        // Hard-coded admin credentials
                        if (username == "admin" && password == "admin123")
                        {
                            Admin adminForm = new Admin();
                            adminForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Admin credentials.");
                        }
                    }
                    else if (selectedRole == "EMPLOYEE")
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE Username=@u AND Password=@p", con);
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Employee login successful!");
                            // Open Admin form and load Employee section inside rightPanel
                            Admin adminForm = new Admin();
                            adminForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Employee credentials.");
                        }
                    }
                    else if (selectedRole == "CUSTOMER")
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM signUpTab WHERE Username=@u AND Password=@p", con);
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Customer login successful!");
                            // TODO: Open Customer dashboard if needed
                        }
                        else
                        {
                            MessageBox.Show("Invalid Customer credentials.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid role selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_signup signupForm = new Form_signup();
            signupForm.Show();
            this.Hide();
        }

        private void check_bx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            textPassword.UseSystemPasswordChar = !check_bx_ShowPass.Checked;
        }
    }
}

