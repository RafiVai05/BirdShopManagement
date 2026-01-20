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
                            string pName = row["Name"].ToString(); // Grab Product Name
                            int qty = Convert.ToInt32(row["Quantity"]);
                            decimal price = Convert.ToDecimal(row["Total"]); // Total price for this item
                            string category = row["Category"].ToString();

                            // 1. UPDATE STOCK LOGIC
                            string updateQuery = (category == "Birds")
                                ? "UPDATE birdsTab SET Quantity = Quantity - @q WHERE P_ID = @id"
                                : "UPDATE acsTab SET Quantity = Quantity - @q WHERE A_ID = @id";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@q", qty);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. SAVE TO HISTORY LOGIC (OrdersTab)
                            string historyQuery = "INSERT INTO OrdersTab (Username, Product_Name, Category, Quantity, Total_Price) " +
                                                  "VALUES (@un, @pn, @cat, @qty, @prc)";
                            using (SqlCommand historyCmd = new SqlCommand(historyQuery, con, transaction))
                            {
                                historyCmd.Parameters.AddWithValue("@un", UserSession.CurrentUsername);
                                historyCmd.Parameters.AddWithValue("@pn", pName);
                                historyCmd.Parameters.AddWithValue("@cat", category);
                                historyCmd.Parameters.AddWithValue("@qty", qty);
                                historyCmd.Parameters.AddWithValue("@prc", price);
                                historyCmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaction failed: " + ex.Message);
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
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold); 
            Font fontBody = new Font("Arial", 10, FontStyle.Regular);
            Font fontItalic = new Font("Arial", 10, FontStyle.Italic); 
            
            float y = 20;
            g.DrawString("BIRD SHOP RECEIPT", fontTitle, Brushes.Black, 60, y);
            y += 40;
            g.DrawString("Customer: " + UserSession.CurrentUsername, fontBody, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("Address: " + txtaddress.Text, fontBody, Brushes.Black, 10, y);
            y += 40;

            
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