using System;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
        }

        private void employee_btn_Click(object sender, EventArgs e)
        {
            // Clear previous controls
            rightPanel.Controls.Clear();

            // Create Employee form
            Employee emp = new Employee();

            // IMPORTANT: embed form inside panel
            emp.TopLevel = false;
            emp.FormBorderStyle = FormBorderStyle.None;
            emp.Dock = DockStyle.Fill;

            rightPanel.Controls.Add(emp);
            emp.Show();
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customer clicked");
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

