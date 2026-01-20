using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Welcome_Form : Form
    {
        // Centralized Connection String
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void Welcome_Form_Load(object sender, EventArgs e)
        {
            // Set up the ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("EMPLOYEE");
            comboBox1.Items.Add("CUSTOMER");

            // Initially hide login controls until a role is selected
            SetLoginControlsVisibility(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = comboBox1.SelectedItem?.ToString();

            // Show standard login fields
            SetLoginControlsVisibility(true);

            // Conditional visibility for Customer-specific links
            bool isCustomer = (role == "CUSTOMER");
            signup.Visible = isCustomer;
            no_account_lbl.Visible = isCustomer;
            forget_btn.Visible = isCustomer;
        }

        private void SetLoginControlsVisibility(bool visible)
        {
            textUserName.Visible = visible;
            textPassword.Visible = visible;
            signin_btn.Visible = visible;
            exit_btn.Visible = visible;
            check_bx_ShowPass.Visible = visible;
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();
            string selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRole))
            {
                
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    if (selectedRole == "ADMIN")
                    {
                        // Admin: Hard-coded security
                        if (username == "admin" && password == "admin")
                        {
                            NavigateToAdminDashboard();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Admin credentials.");
                        }
                    }
                    else if (selectedRole == "EMPLOYEE")
                    {
                        string query = "SELECT COUNT(*) FROM Employees WHERE Username=@u AND Password=@p";
                        if (ExecuteLoginQuery(query, username, password, con))
                        {
                            MessageBox.Show("Employee login successful!");
                            NavigateToEmployeeDashboard(); // FIXED: Changed from NavigateToAdminDashboard
                        }
                        else
                        {
                            MessageBox.Show("Invalid Employee credentials.");
                        }
                    }

                    else if (selectedRole == "CUSTOMER")
                    {
                        // Customer: Database Check (using your table name 'signUpTab')
                        string query = "SELECT COUNT(*) FROM signUpTab WHERE Username=@u AND Password=@p";
                        if (ExecuteLoginQuery(query, username, password, con))
                        {
                            UserSession.CurrentUsername = username;
                            MessageBox.Show("Customer login successful!");
                            // FIXED: Now calls the navigation method to open the portal
                            NavigateToCustomerDashboard();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Customer credentials.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }

        private bool ExecuteLoginQuery(string query, string user, string pass, SqlConnection con)
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void NavigateToAdminDashboard()
        {
            Admin adminForm = new Admin();
            adminForm.Show();
            this.Hide();
        }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_signup signupForm = new Form_signup();
            signupForm.Show();
            this.Hide();
        }

        private void check_bx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_bx_ShowPass.Checked)
            {
                textPassword.UseSystemPasswordChar = true;
            }
            // If unchecked, use the system password character (show stars/dots)
            else
            {
                textPassword.UseSystemPasswordChar = false;
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void NavigateToEmployeeDashboard()
        {
            Employee_Form empForm = new Employee_Form();
            empForm.Show();
            this.Hide();
        }
        private void NavigateToCustomerDashboard()
        {
            
            Customer_form customerPortal = new Customer_form();
            customerPortal.Show();
            this.Hide();
        }
    }
}