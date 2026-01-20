using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Customer_form : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=birdshopdb; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");

        public Customer_form()
        {
            InitializeComponent();
        }

        
        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductType.SelectedItem == null) return;

                string selected = cmbProductType.SelectedItem.ToString();

                
                string query = (selected == "Birds") ? "SELECT * FROM birdsTab" : "SELECT * FROM acsTab";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                dgvInventory.DataSource = dt;

                
                cmbProductID.Items.Clear();
                string idCol = (selected == "Birds") ? "P_ID" : "A_ID";

                foreach (DataRow row in dt.Rows)
                {
                    cmbProductID.Items.Add(row[idCol].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading inventory: " + ex.Message); }
        }

        
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                string id = dgvInventory.Rows[e.RowIndex].Cells[0].Value?.ToString();
                cmbProductID.SelectedItem = id;
            }
        }

        
        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem == null || cmbProductType.SelectedItem == null) return;

            string selectedId = cmbProductID.SelectedItem.ToString();
            string selectedType = cmbProductType.SelectedItem.ToString();

            
            string idCol = (selectedType == "Birds") ? "P_ID" : "A_ID";
            string nameCol = (selectedType == "Birds") ? "Bird_Name" : "Name";

            
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells[idCol].Value?.ToString() == selectedId)
                {
                    
                    txtProductName.Text = row.Cells[nameCol].Value?.ToString();
                    txtPrice.Text = row.Cells["Price"].Value?.ToString();

                    
                    if (row.Cells["Quantity"].Value != null && row.Cells["Quantity"].Value != DBNull.Value)
                    {
                        int stock = Convert.ToInt32(row.Cells["Quantity"].Value);
                        lblStockCount.Text = "Stock: " + stock;

                        
                        numQuantity.Maximum = stock;
                        numQuantity.Value = (stock > 0) ? 1 : 0;
                    }
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

            
            dgvCart.Rows.Add(cmbProductID.SelectedItem.ToString(), txtProductName.Text, numQuantity.Value, subtotal);
            CalculateTotal();
        }

        
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
                    cmbProductType_SelectedIndexChanged(null, null); 
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
            this.Close(); 
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(UserSession.CurrentUsername))
            {
                MessageBox.Show("Error: Session expired. Please log in again.");
                Welcome_Form welcome = new Welcome_Form();
                welcome.Show();
                this.Close();
                return;
            }

            
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
            dt.Columns.Add("Category"); 

            
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;

                
                dt.Rows.Add(
                    row.Cells[0].Value,
                    row.Cells[1].Value,
                    row.Cells[2].Value,
                    row.Cells[3].Value,
                    cmbProductType.SelectedItem.ToString()
                );
            }

            
            PayForm pay = new PayForm(dt, lblTotal.Text);
            pay.Show();
            this.Hide();
        }
    }
}