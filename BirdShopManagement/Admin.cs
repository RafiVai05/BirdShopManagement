using System;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Admin : Form
    {
       // private string loggedUser;

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
            emp.Dock = DockStyle.Fill;
            rightPanel.Controls.Add(emp);

            emp.Show();
            // This calls the method we made 'public' in the Employee class
            emp.LoadEmployeeData();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Close();
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            // Clear the existing content in the right panel
            rightPanel.Controls.Clear();

            // Initialize the history form
            CustomerHistory history = new CustomerHistory();

            // Set properties to fit inside the panel
            history.TopLevel = false;
            history.FormBorderStyle = FormBorderStyle.None;
            history.Dock = DockStyle.Fill;

            // Add to panel and show
            rightPanel.Controls.Add(history);
            history.Show();
        }
    }
}
