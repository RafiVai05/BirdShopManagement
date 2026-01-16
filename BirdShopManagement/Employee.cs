using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Employee : Form
    {
        SqlConnection con = new SqlConnection(
            @"Data Source=localhost\SQLEXPRESS;
              Initial Catalog=birdshopmanagement;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True");

        int empId = 0;

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        void LoadEmployeeData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fill all fields");
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Employees (Username, Password) VALUES (@u, @p)", con);

            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Employee Added");
            LoadEmployeeData();
            clear();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0)
            {
                MessageBox.Show("Select a record first");
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "UPDATE Employees SET Username=@u, Password=@p WHERE Id=@id", con);

            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);
            cmd.Parameters.AddWithValue("@id", empId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Employee Updated");
            LoadEmployeeData();
            clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0)
            {
                MessageBox.Show("Select a record first");
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Employees WHERE Id=@id", con);

            cmd.Parameters.AddWithValue("@id", empId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Employee Deleted");
            LoadEmployeeData();
            clear();
        }

        private void click_btn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                empId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            }
        }

        void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            empId = 0;
        }
    }
}


