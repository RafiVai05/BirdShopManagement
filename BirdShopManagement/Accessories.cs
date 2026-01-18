using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Accessories : Form
    {
        // Centralized Connection String
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");

        // This variable MUST be set via the CellClick event for Update/Delete to work
        int acsId = 0;

        public Accessories() { InitializeComponent(); }

        private void Accessories_Load(object sender, EventArgs e) { LoadData(); }

        public void LoadData()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM acsTab", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Load Error: " + ex.Message); }
        }

        // 1. ADD LOGIC: Fixed the "IDENTITY_INSERT" error
        private void add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Please enter a name."); return; }

            try
            {
                // SOLUTION: We do NOT include A_ID in the columns or values list
                string query = "INSERT INTO acsTab (Name, Price, Quantity) VALUES (@name, @price, @qty)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Accessory Added!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { con.Close(); MessageBox.Show("Add Error: " + ex.Message); }
        }

        // 2. UPDATE LOGIC: Uses acsId captured from CellClick
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (acsId == 0) { MessageBox.Show("Select an item from the list first!"); return; }

            try
            {
                string query = "UPDATE acsTab SET Name=@name, Price=@price, Quantity=@qty WHERE A_ID=@id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));
                    cmd.Parameters.AddWithValue("@id", acsId); // Tells SQL which record to update

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Accessory Updated!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { con.Close(); MessageBox.Show("Update Error: " + ex.Message); }
        }

        // 3. DELETE LOGIC: Removes record based on acsId
        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (acsId == 0) { MessageBox.Show("Select an item from the list first!"); return; }

            DialogResult res = MessageBox.Show("Delete this accessory?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM acsTab WHERE A_ID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", acsId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Accessory Deleted!");
                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex) { con.Close(); MessageBox.Show("Delete Error: " + ex.Message); }
            }
        }

        // CRITICAL: Captures the ID so Update/Delete know which row to target
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                {
                    acsId = Convert.ToInt32(row.Cells[0].Value);
                    txtName.Text = row.Cells[1].Value?.ToString();
                    txtPrice.Text = row.Cells[2].Value?.ToString();
                    txtQty.Text = row.Cells[3].Value?.ToString();
                }
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            acsId = 0;
        }
    }
}