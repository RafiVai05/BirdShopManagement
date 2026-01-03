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
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {
           
        }
        private void Welcome_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void go2sign_up_btn_Click(object sender, EventArgs e)
        {
            Form_signup signup = new Form_signup();
            signup.Show();
            this.Hide();
        }

        private void go2sign_in_btn_Click(object sender, EventArgs e)
        {
            Form_signin signin = new Form_signin();
            signin.Show();
            this.Hide();
        }
    }
}
