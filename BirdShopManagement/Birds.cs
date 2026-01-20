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

        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM birdsTab", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"))
                {
                    
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
                    cmd.Parameters.AddWithValue("@id", birdId); 

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
            
            if (birdId == 0)
            {
                MessageBox.Show("Select a bird from the list first!");
                return;
            }

            
            DialogResult res = MessageBox.Show("Are you sure you want to delete this bird?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                try
                {
                    
                    using (SqlConnection conLocal = new SqlConnection(con.ConnectionString))
                    {
                        string query = "DELETE FROM birdsTab WHERE P_ID=@id";
                        SqlCommand cmd = new SqlCommand(query, conLocal);
                        cmd.Parameters.AddWithValue("@id", birdId);

                        conLocal.Open();
                        int rowsAffected = cmd.ExecuteNonQuery(); 
                        conLocal.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bird Deleted Successfully!");

                            
                            birdId = 0;
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

                
                if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                {
                    birdId = Convert.ToInt32(row.Cells[0].Value);
                    txtName.Text = row.Cells[1].Value?.ToString();
                    txtPrice.Text = row.Cells[2].Value?.ToString();
                    txtQty.Text = row.Cells[3].Value?.ToString();
                }
            }
        }
    }
}