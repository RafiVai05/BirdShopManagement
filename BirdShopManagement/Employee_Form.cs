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
            Form f = null;

            // Make sure items "Birds" and "Accessories" are added to the ComboBox items collection
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "Birds")
            {
                f = new Birds();
            }
            else if (selected == "Accessories")
            {
                f = new Accessories();
            }

            if (f != null)
            {
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None; // Recommended for panels
                f.Dock = DockStyle.Fill;
                rightPanel.Controls.Add(f);
                f.Show();
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