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

        private void LoadData()
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
            if (acsId == 0) return;
            SqlCommand cmd = new SqlCommand("DELETE FROM acsTab WHERE A_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", acsId);
            con.Open(); cmd.ExecuteNonQuery(); con.Close();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                acsId = Convert.ToInt32(row.Cells[0].Value);
                txtName.Text = row.Cells[1].Value.ToString();
                txtPrice.Text = row.Cells[2].Value.ToString();
                txtQty.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}