using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Employee_Form : Form
    {
        public Employee_Form()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "Birds")
            {
                Birds f = new Birds(); // Create instance
                f.TopLevel = false;
                
                f.Dock = DockStyle.Fill;
                rightPanel.Controls.Add(f);
                f.Show();
                f.LoadData(); // FORCED RELOAD: Ensures data shows immediately
            }
            else if (selected == "Accessories")
            {
                Accessories f = new Accessories(); // Create instance
                f.TopLevel = false;
                
                f.Dock = DockStyle.Fill;
                rightPanel.Controls.Add(f);
                f.Show();
                f.LoadData(); // FORCED RELOAD: Ensures data shows immediately
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Close();
        }
    }
}