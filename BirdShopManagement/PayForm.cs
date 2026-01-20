using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class PayForm : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";
        
        DataTable cartItems;
        string grandTotal;

        public PayForm(DataTable dt, string total)
        {
            InitializeComponent();
            this.cartItems = dt;
            this.grandTotal = total;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserSession.CurrentUsername))
            {
                MessageBox.Show("No active user session found. Please log in again.");
                this.Close();
                return;
            }
            LoadUserData();
        }

        // FIX: Restoring the missing LoadUserData method
        private void LoadUserData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string query = "SELECT Address, Contact FROM signUpTab WHERE Username = @u";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@u", UserSession.CurrentUsername);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        txtaddress.Text = dt.Rows[0]["Address"].ToString();
                        txtcontact.Text = dt.Rows[0]["Contact"].ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading user data: " + ex.Message); }
        }

        // FIX: Renamed method to match the new event name from Step 1
        private void btnPayReceipt_Click(object sender, EventArgs e)
        {
            if (cartItems == null || cartItems.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            if (UpdateInventory())
            {
                PrintDocument receipt = new PrintDocument();
                receipt.PrintPage += Receipt_PrintPage;
                
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = receipt;
                preview.WindowState = FormWindowState.Maximized;
                preview.ShowDialog();
            }
        }

        private bool UpdateInventory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        foreach (DataRow row in cartItems.Rows)
                        {
                            string id = row["ID"].ToString();
                            int qty = Convert.ToInt32(row["Quantity"]);
                            string category = row["Category"].ToString();

                            string query = (category == "Birds") 
                                ? "UPDATE birdsTab SET Quantity = Quantity - @q WHERE P_ID = @id"
                                : "UPDATE acsTab SET Quantity = Quantity - @q WHERE A_ID = @id";

                            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@q", qty);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex) 
                    { 
                        transaction.Rollback(); 
                        MessageBox.Show("Inventory update failed: " + ex.Message);
                        return false; 
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); return false; }
        }

        private void Receipt_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold); // Created for bold headers
            Font fontBody = new Font("Arial", 10, FontStyle.Regular);
            Font fontItalic = new Font("Arial", 10, FontStyle.Italic); // FIX: FontStyle.Italic used here
            
            float y = 20;
            g.DrawString("BIRD SHOP RECEIPT", fontTitle, Brushes.Black, 60, y);
            y += 40;
            g.DrawString("Customer: " + UserSession.CurrentUsername, fontBody, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("Address: " + txtaddress.Text, fontBody, Brushes.Black, 10, y);
            y += 40;

            // FIX: Use fontHeader (bold) and Brushes.Black (brush)
            g.DrawString("Items purchased:", fontHeader, Brushes.Black, 10, y);
            y += 25;

            foreach (DataRow row in cartItems.Rows)
            {
                g.DrawString($"{row["Name"]} x{row["Quantity"]} - BDT {row["Total"]}", fontBody, Brushes.Black, 10, y);
                y += 20;
            }

            y += 20;
            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;
            g.DrawString("GRAND TOTAL: BDT " + grandTotal, fontTitle, Brushes.DarkGreen, 10, y);
            y += 40;
            g.DrawString("Thank you for your purchase!", fontItalic, Brushes.Black, 10, y);
        }

        // FIX: Restoring the missing update_btn_Click method
        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string query = "UPDATE signUpTab SET Address=@ad, Contact=@ct WHERE Username=@un";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ad", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@ct", txtcontact.Text);
                    cmd.Parameters.AddWithValue("@un", UserSession.CurrentUsername);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Profile Updated Successfully!");
                    LoadUserData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}