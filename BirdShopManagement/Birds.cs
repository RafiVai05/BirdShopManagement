using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BirdShopManagement
{
    public partial class Birds : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");
        int birdId = 0;

        public Birds()
        {
            InitializeComponent();
        }

        private void Birds_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM birdsTab", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        // BIRDS ADD LOGIC
        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"))
                {
                    // Do NOT include P_ID in the columns list
                    string query = "INSERT INTO birdsTab (Bird_Name, Price, Quantity) VALUES (@name, @price, @qty)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Bird Added Successfully!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // BIRDS UPDATE LOGIC
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (birdId == 0) { MessageBox.Show("Select a bird from the list first!"); return; }
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"))
                {
                    string query = "UPDATE birdsTab SET Bird_Name=@name, Price=@price, Quantity=@qty WHERE P_ID=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text.Trim()));
                    cmd.Parameters.AddWithValue("@id", birdId); // This comes from dataGridView1_CellClick

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Bird Updated Successfully!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (birdId == 0) return;
            SqlCommand cmd = new SqlCommand("DELETE FROM birdsTab WHERE P_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", birdId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                birdId = Convert.ToInt32(row.Cells[0].Value);
                txtName.Text = row.Cells[1].Value.ToString();
                txtPrice.Text = row.Cells[2].Value.ToString();
                txtQty.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}