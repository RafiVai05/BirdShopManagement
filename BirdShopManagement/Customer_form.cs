using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Customer_form : Form
    {
        // Shared connection string used across the project
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");

        public Customer_form()
        {
            InitializeComponent();
        }

        // FETCH PRODUCTS: Automatically shows what employees added to birdsTab or acsTab
        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductType.SelectedItem == null) return;

                string selected = cmbProductType.SelectedItem.ToString();

                // Selects from the table managed by employees based on category
                string query = (selected == "Birds") ? "SELECT * FROM birdsTab" : "SELECT * FROM acsTab";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Binds employee data to the inventory grid
                dgvInventory.DataSource = dt;

                // Sync the Product ID ComboBox for selection
                cmbProductID.Items.Clear();
                string idCol = (selected == "Birds") ? "P_ID" : "A_ID";

                foreach (DataRow row in dt.Rows)
                {
                    cmbProductID.Items.Add(row[idCol].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading inventory: " + ex.Message); }
        }

        // SYNC SELECTION: Populates textboxes when a product is clicked in the grid
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Grabs ID from the first column and selects it in the ComboBox
                string id = dgvInventory.Rows[e.RowIndex].Cells[0].Value?.ToString();
                cmbProductID.SelectedItem = id;
            }
        }

        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem == null || cmbProductType.SelectedItem == null) return;

            string selectedId = cmbProductID.SelectedItem.ToString();
            string selectedType = cmbProductType.SelectedItem.ToString();

            // Determine column names based on category
            string idCol = (selectedType == "Birds") ? "P_ID" : "A_ID";
            string nameCol = (selectedType == "Birds") ? "Bird_Name" : "Name";

            // Loop through the inventory grid to find the matching ID
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells[idCol].Value?.ToString() == selectedId)
                {
                    // Populate the textboxes automatically
                    txtProductName.Text = row.Cells[nameCol].Value?.ToString();
                    txtPrice.Text = row.Cells["Price"].Value?.ToString();

                    // Set stock information
                    int stock = Convert.ToInt32(row.Cells["Quantity"].Value);
                    lblStockCount.Text = "Stock: " + stock;

                    // Set purchase limits
                    numQuantity.Maximum = stock;
                    numQuantity.Value = (stock > 0) ? 1 : 0;
                    break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedIndex == -1 || numQuantity.Value <= 0)
            {
                MessageBox.Show("Please select a product and valid quantity.");
                return;
            }

            double unitPrice = Convert.ToDouble(txtPrice.Text);
            double subtotal = unitPrice * (double)numQuantity.Value;

            // Adds item to the cart grid on the right
            dgvCart.Rows.Add(cmbProductID.SelectedItem.ToString(), txtProductName.Text, numQuantity.Value, subtotal);
            CalculateTotal();
        }

        // PAYMENT LOGIC: Updates (reduces) database stock after purchase
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!");
                return;
            }

            try
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string id = row.Cells[0].Value.ToString();
                        int qtyPurchased = Convert.ToInt32(row.Cells[2].Value);
                        string selectedType = cmbProductType.SelectedItem.ToString();

                        // UPDATE query to subtract quantity from database
                        string updateQuery = (selectedType == "Birds")
                            ? "UPDATE birdsTab SET Quantity = Quantity - @qty WHERE P_ID = @id"
                            : "UPDATE acsTab SET Quantity = Quantity - @qty WHERE A_ID = @id";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", qtyPurchased);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Purchase Successful! Stock has been updated.");

                    ClearAllFields();
                    cmbProductType_SelectedIndexChanged(null, null); // Refreshes inventory view
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Payment Failed: " + ex.Message);
                }
            }
            catch (Exception ex) { MessageBox.Show("Connection Error: " + ex.Message); }
            finally { con.Close(); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                {
                    dgvCart.Rows.Remove(row);
                }
                CalculateTotal();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            dgvCart.Rows.Clear();
            lblTotal.Text = "0.00";
            txtProductName.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            lblStockCount.Text = "Stock: 0";
            cmbProductID.SelectedIndex = -1;
        }

        private void CalculateTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    total += Convert.ToDouble(row.Cells[3].Value);
                }
            }
            lblTotal.Text = total.ToString("N2");
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Close(); // Closes the customer form
        }
    }
}