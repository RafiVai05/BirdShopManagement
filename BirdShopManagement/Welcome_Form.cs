using System;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        private void textUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string selectedRole = comboBox1.SelectedItem.ToString();

            if (selectedRole == "ADMIN")
            {
                
                textUserName.Visible = true;
                textPassword.Visible = true;
                signin_btn.Visible = true;
                exit_btn.Visible = true;

                
                forget_btn.Visible = false;
                signup.Visible = false;
                no_account_lbl.Visible = false;
            }
            else if (selectedRole == "EMPLOYEE" )
            {
                textUserName.Visible = true;
                textPassword.Visible = true;
                signin_btn.Visible = true;
                exit_btn.Visible = true;

                forget_btn.Visible = false;
                signup.Visible = false;
                no_account_lbl.Visible = false;
            }
            else
            {
                
                textUserName.Visible = true;
                textPassword.Visible = true;
                signin_btn.Visible = true;
                exit_btn.Visible = true;
                forget_btn.Visible = true;
                signup.Visible = true;
            }
        }
        
        private void signin_btn_Click(object sender, EventArgs e)
        {

        }

        private void forget_btn_Click(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_signup f1 = new Form_signup();
            f1.Show();
            Visible = false;
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
    }
}
