using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Employee : Form
    {
        // Centralized Connection String
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");

        // Variable to store the selected Employee ID for Update/Delete
        int empId = 0;

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // Initial data load when the form opens
            LoadEmployeeData();
        }

        // Changed to 'public' so it can be called from the Admin form buttons
        public void LoadEmployeeData()
        {
            try
            {
                // Ensure connection is closed before starting a new operation
                if (con.State == ConnectionState.Open) con.Close();

                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Username, Password FROM Employees", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Binding the data to the DataGridView
                dataGridView1.DataSource = dt;

                // Optional UI: Adjust column headers
                if (dataGridView1.Columns["Id"] != null) dataGridView1.Columns["Id"].HeaderText = "ID";
                if (dataGridView1.Columns["Username"] != null) dataGridView1.Columns["Username"].HeaderText = "User Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Username, Password) VALUES (@u, @p)", con);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee Added Successfully!");
                LoadEmployeeData(); // Refresh grid
                ClearFields();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0)
            {
                MessageBox.Show("Please select an employee from the list first.");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employees SET Username=@u, Password=@p WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@id", empId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee Details Updated!");
                LoadEmployeeData(); // Refresh grid
                ClearFields();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (empId == 0)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", empId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Employee Deleted.");
                    LoadEmployeeData(); // Refresh grid
                    ClearFields();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                
                empId = Convert.ToInt32(row.Cells[0].Value);

                txtUsername.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();

                
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            empId = 0;
        }
    }
}