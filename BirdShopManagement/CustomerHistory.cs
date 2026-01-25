using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;           
using System.Drawing.Printing;  
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class CustomerHistory : Form
    {
        string connStr = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public CustomerHistory()
        {
            InitializeComponent();
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            LoadHistoryData();
        }

        public void LoadHistoryData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    
                    string query = "SELECT O_ID, Username, Product_Name, Category, Quantity, Total_Price, Order_Date FROM OrdersTab ORDER BY O_ID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHistory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click on an Order (row) to select it first.");
                return;
            }

            
            PrintDocument receipt = new PrintDocument();
            receipt.PrintPage += History_PrintPage;

           
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = receipt;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }


        private void History_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            DataGridViewRow row = dgvHistory.SelectedRows[0];

            string id = row.Cells["O_ID"].Value?.ToString() ?? "-";
            string user = row.Cells["Username"].Value?.ToString() ?? "-";
            string prod = row.Cells["Product_Name"].Value?.ToString() ?? "-";
            string cat = row.Cells["Category"].Value?.ToString() ?? "-";
            string qty = row.Cells["Quantity"].Value?.ToString() ?? "0";
            string price = row.Cells["Total_Price"].Value?.ToString() ?? "0.00";
            string date = row.Cells["Order_Date"].Value?.ToString() ?? DateTime.Now.ToString();

          
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontData = new Font("Arial", 12, FontStyle.Regular);

            float y = 40;
            int leftMargin = 50;
            int valuePos = 250; 

           
            g.DrawString("ORDER DETAILS RECEIPT", fontTitle, Brushes.DarkBlue, leftMargin + 80, y);
            y += 50;
            g.DrawLine(Pens.Black, leftMargin, y, 750, y);
            y += 30;

          

            
            g.DrawString("Order ID:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(id, fontData, Brushes.Black, valuePos, y);
            y += 30;

            
            g.DrawString("Customer Name:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(user, fontData, Brushes.Black, valuePos, y);
            y += 30;

            g.DrawString("Order Date:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(date, fontData, Brushes.Black, valuePos, y);
            y += 40; 

            
            g.DrawLine(Pens.Gray, leftMargin, y, 500, y);
            y += 20;

            
            g.DrawString("Product:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(prod, fontData, Brushes.Black, valuePos, y);
            y += 30;

            g.DrawString("Category:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(cat, fontData, Brushes.Black, valuePos, y);
            y += 30;

            g.DrawString("Quantity:", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString(qty, fontData, Brushes.Black, valuePos, y);
            y += 40; 

          
            g.DrawString("TOTAL PRICE:", fontTitle, Brushes.DarkGreen, leftMargin, y);
            g.DrawString("BDT " + price, fontTitle, Brushes.DarkGreen, valuePos, y);

           
            y += 100;
            g.DrawString("Thank you for shopping with Bird Shop!", new Font("Arial", 10, FontStyle.Italic), Brushes.Gray, leftMargin + 80, y);
        }
    }
}