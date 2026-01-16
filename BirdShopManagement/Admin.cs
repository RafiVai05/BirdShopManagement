using System;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Admin : Form
    {
        private string loggedUser;

        public Admin()
        {
            InitializeComponent();
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {
           
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
        }

        private void employee_btn_Click(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();

            Employee emp = new Employee();
            emp.TopLevel = false;
            emp.FormBorderStyle = FormBorderStyle.None;
            emp.Dock = DockStyle.Fill;

            rightPanel.Controls.Add(emp);
            emp.Show();
            emp.LoadEmployeeData();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
