using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Welcome_Form : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void Welcome_Form_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("EMPLOYEE");
            comboBox1.Items.Add("CUSTOMER");
            SetLoginControlsVisibility(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLoginControlsVisibility(true);
            string role = comboBox1.SelectedItem.ToString();
            bool isCustomer = (role == "CUSTOMER");
            signup.Visible = isCustomer;
            no_account_lbl.Visible = isCustomer;
            forget_btn.Visible = isCustomer;
        }

        private void SetLoginControlsVisibility(bool visible)
        {
            textUserName.Visible = textPassword.Visible = signin_btn.Visible =
            exit_btn.Visible = check_bx_ShowPass.Visible = visible;
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();
            string selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRole)) return;

            
            if (selectedRole == "ADMIN" && username == "admin" && password == "admin")
            {
                NavigateToAdminDashboard();
                return;
            }

            
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    
                    string query = "SELECT COUNT(*) FROM signInTab WHERE Username=@u AND Password=@p AND UserRole=@r";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        cmd.Parameters.AddWithValue("@r", selectedRole);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            UserSession.CurrentUsername = username;
                            if (selectedRole == "EMPLOYEE") NavigateToEmployeeDashboard();
                            else if (selectedRole == "CUSTOMER") NavigateToCustomerDashboard();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials for " + selectedRole);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void NavigateToAdminDashboard() { new Admin().Show(); this.Hide(); }
        private void NavigateToEmployeeDashboard()
        {
            
            Employee_Form empDashboard = new Employee_Form();
            empDashboard.Show();
            this.Hide();
        }
        private void NavigateToCustomerDashboard() { new Customer_form().Show(); this.Hide(); }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form_signup().Show();
            this.Hide();
        }

        private void check_bx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = !check_bx_ShowPass.Checked;
        }

        private void exit_btn_Click(object sender, EventArgs e) => Application.Exit();
    }
}