using System;
using System.Data;
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

      

        

        private void SetLoginControlsVisibility(bool visible)
        {
            textUserName.Visible = textPassword.Visible = signin_btn.Visible =
            exit_btn.Visible = check_bx_ShowPass.Visible = visible;
        }

        private void signin_btn_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text.Trim();
            string password = textPassword.Text.Trim();
            string userRole = "";

            

            
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    
                    string query = "SELECT UserRole FROM userTab WHERE Username=@u AND Password=@p ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        //cmd.Parameters.AddWithValue("@r", selectedRole);
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        int count = dt.Rows.Count;
                        if (count > 0)
                        {

                            userRole = dt.Rows[0]["UserRole"].ToString();
                            UserSession.CurrentUsername = username;
                            if (userRole == "ADMIN")
                            {
                                NavigateToAdminDashboard();
                                return;
                            }
                            else if (userRole == "EMPLOYEE") NavigateToEmployeeDashboard();
                            else if (userRole == "CUSTOMER") NavigateToCustomerDashboard();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials for " + userRole);
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
            if (check_bx_ShowPass.Checked)
            {
                
                textPassword.UseSystemPasswordChar = true;
               
            }
            else
            {
                
                textPassword.UseSystemPasswordChar = false;
                
            }
        }

        private void exit_btn_Click(object sender, EventArgs e) => Application.Exit();
    }
}