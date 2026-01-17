using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Accessories : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");
        int acsId = 0;

        public Accessories() { InitializeComponent(); }

        private void Accesories_Load(object sender, EventArgs e) { LoadData(); }

        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM acsTab", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // ACCESSORIES ADD LOGIC
        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"))
                {
                    // Use acsTab and Name column
                    string query = "INSERT INTO acsTab (Name, Price, Quantity) VALUES (@name, @price, @qty)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Accessory Added!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ACCESSORIES UPDATE LOGIC
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (acsId == 0) { MessageBox.Show("Select an item first!"); return; }
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"))
                {
                    string query = "UPDATE acsTab SET Name=@name, Price=@price, Quantity=@qty WHERE A_ID=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));
                    cmd.Parameters.AddWithValue("@id", acsId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Accessory Updated!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (acsId == 0)
            {
                MessageBox.Show("Select an item from the list first!");
                return;
            }

            DialogResult res = MessageBox.Show("Delete this accessory?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conLocal = new SqlConnection(con.ConnectionString))
                    {
                        string query = "DELETE FROM acsTab WHERE A_ID=@id";
                        SqlCommand cmd = new SqlCommand(query, conLocal);
                        cmd.Parameters.AddWithValue("@id", acsId);

                        conLocal.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conLocal.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Accessory Deleted!");
                            acsId = 0;
                            txtName.Clear();
                            txtPrice.Clear();
                            txtQty.Clear();
                            LoadData();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Use column index 0 for A_ID
                if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                {
                    acsId = Convert.ToInt32(row.Cells[0].Value);
                    txtName.Text = row.Cells[1].Value?.ToString();
                    txtPrice.Text = row.Cells[2].Value?.ToString();
                    txtQty.Text = row.Cells[3].Value?.ToString();
                }
            }
        }
    }
}