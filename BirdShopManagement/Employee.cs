using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Employee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");
        int empId = 0;
        string oldUsername = ""; 

        public Employee() { InitializeComponent(); }

        private void Employee_Load(object sender, EventArgs e) { LoadEmployeeData(); }

        public void LoadEmployeeData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Username, Password FROM Employees", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return;
            try
            {
                con.Open();
                
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Employees (Username, Password) VALUES (@u, @p)", con);
                cmd1.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd1.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd1.ExecuteNonQuery();

                
                SqlCommand cmd2 = new SqlCommand("INSERT INTO userTab (Username, Password, UserRole) VALUES (@u, @p, 'EMPLOYEE')", con);
                cmd2.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd2.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd2.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Employee Added!");
                LoadEmployeeData();
                ClearFields();
            }
            catch (Exception ex) { con.Close(); MessageBox.Show(ex.Message); }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0) return;
            try
            {
                con.Open();
                
                SqlCommand cmd1 = new SqlCommand("UPDATE Employees SET Username=@u, Password=@p WHERE Id=@id", con);
                cmd1.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd1.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd1.Parameters.AddWithValue("@id", empId);
                cmd1.ExecuteNonQuery();

                
                SqlCommand cmd2 = new SqlCommand("UPDATE userTab SET Username=@u, Password=@p WHERE Username=@oldU", con);
                cmd2.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd2.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd2.Parameters.AddWithValue("@oldU", oldUsername);
                cmd2.ExecuteNonQuery();

                con.Close();
                LoadEmployeeData();
                ClearFields();
            }
            catch (Exception ex) { con.Close(); MessageBox.Show(ex.Message); }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0) return;
            try
            {
                con.Open();
                new SqlCommand($"DELETE FROM Employees WHERE Id={empId}", con).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM userTab WHERE Username='{txtUsername.Text}'", con).ExecuteNonQuery();
                con.Close();
                LoadEmployeeData();
                ClearFields();
            }
            catch (Exception ex) { con.Close(); MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                empId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                txtUsername.Text = oldUsername = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void ClearFields() { txtUsername.Clear(); txtPassword.Clear(); empId = 0; }
    }
}