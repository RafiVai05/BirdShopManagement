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
    public partial class Product_Form : Form
    {
        public Product_Form()
        {
            InitializeComponent();
        }

        private void Birds_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Birds Products Opened");
        }

        private void Acs_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Accessories Products Opened");
        }
        private void Product_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
