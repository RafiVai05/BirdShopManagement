using System;
using System.Data;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Employee : Form
    {
        DataTable table = new DataTable();
        int index;

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Username");
            table.Columns.Add("Password");
            dataGridView1.DataSource = table;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fill all fields");
                return;
            }

            table.Rows.Add(txtUsername.Text, txtPassword.Text);
            clear();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            table.Rows[index]["Username"] = txtUsername.Text;
            table.Rows[index]["Password"] = txtPassword.Text;
            clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            table.Rows[index].Delete();
            clear();
        }

        private void click_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtUsername.Text = table.Rows[index]["Username"].ToString();
                txtPassword.Text = table.Rows[index]["Password"].ToString();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}

