using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;           // <--- Added for Fonts/Graphics
using System.Drawing.Printing;  // <--- Added for PrintDocument
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
            // 1. Create the PrintDocument
            PrintDocument receipt = new PrintDocument();

            // 2. Attach the PrintPage event (where the drawing happens)
            receipt.PrintPage += History_PrintPage;

            // 3. Show the Preview Dialog
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = receipt;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        // --- THE PRINTING LOGIC ---
        private void History_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold);
            Font fontBody = new Font("Arial", 9, FontStyle.Regular);

            float y = 20; // Vertical position tracker
            int leftMargin = 10;

            // 1. Draw Title
            g.DrawString("CUSTOMER PURCHASE HISTORY", fontTitle, Brushes.Black, leftMargin + 30, y);
            y += 40;
            g.DrawString("Printed for: " + UserSession.CurrentUsername, fontHeader, Brushes.Black, leftMargin, y);
            y += 20;
            g.DrawString("Date: " + DateTime.Now.ToString(), fontHeader, Brushes.Black, leftMargin, y);
            y += 40;

            // 2. Draw Table Headers (Manually positioning columns)
            // Adjust the X coordinates (10, 80, 250, etc.) to fit your column widths
            g.DrawString("ID", fontHeader, Brushes.Black, leftMargin, y);
            g.DrawString("Product Name", fontHeader, Brushes.Black, leftMargin + 40, y);
            g.DrawString("Qty", fontHeader, Brushes.Black, leftMargin + 250, y);
            g.DrawString("Total", fontHeader, Brushes.Black, leftMargin + 300, y);
            g.DrawString("Date", fontHeader, Brushes.Black, leftMargin + 400, y);

            y += 20;
            g.DrawLine(Pens.Black, leftMargin, y, 750, y); // Draw a line under headers
            y += 10;

            // 3. Loop through DataGridView rows and draw them
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                // Skip empty new rows if any
                if (row.IsNewRow) continue;

                // Get values safely
                string id = row.Cells["O_ID"].Value?.ToString() ?? "";
                string prod = row.Cells["Product_Name"].Value?.ToString() ?? "";
                string qty = row.Cells["Quantity"].Value?.ToString() ?? "";
                string price = row.Cells["Total_Price"].Value?.ToString() ?? "";
                string date = row.Cells["Order_Date"].Value?.ToString() ?? "";

                // Shorten date to just the date part if it's too long
                if (date.Length > 10) date = date.Substring(0, 10);

                // Draw the Row Data
                g.DrawString(id, fontBody, Brushes.Black, leftMargin, y);
                g.DrawString(prod, fontBody, Brushes.Black, leftMargin + 40, y);
                g.DrawString(qty, fontBody, Brushes.Black, leftMargin + 250, y);
                g.DrawString(price, fontBody, Brushes.Black, leftMargin + 300, y);
                g.DrawString(date, fontBody, Brushes.Black, leftMargin + 400, y);

                y += 25; // Move down for next row

                // Simple check to stop printing if we run out of page space
                if (y > e.MarginBounds.Bottom + 100)
                {
                    // Note: This simple code doesn't handle multiple pages automatically
                    // It just stops printing at the bottom.
                    break;
                }
            }
        }
    }
}