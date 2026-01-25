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

        private void Admin_Load(object sender, EventArgs e)
        {
           
        }

       
        private void employee_btn_Click(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
            Employee emp = new Employee();
            emp.TopLevel = false;
            emp.Dock = DockStyle.Fill;
            rightPanel.Controls.Add(emp);

            emp.Show();
            
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
            rightPanel.Controls.Clear();
            CustomerHistory history = new CustomerHistory();

            history.TopLevel = false;
            history.FormBorderStyle = FormBorderStyle.None;
            history.Dock = DockStyle.Fill;

            rightPanel.Controls.Add(history);
            history.Show();

            
            history.LoadHistoryData();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)

        {

            // 1. Clear previous content

            rightPanel.Controls.Clear();



            // 2. Create the Dashboard Form

            Admin_dashboard dash = new Admin_dashboard();



            // 3. Set properties to embed it

            dash.TopLevel = false;

            dash.FormBorderStyle = FormBorderStyle.None;

            dash.Dock = DockStyle.Fill;



            // 4. Add to panel and show

            rightPanel.Controls.Add(dash);

            dash.Show();

        }
    }
}
