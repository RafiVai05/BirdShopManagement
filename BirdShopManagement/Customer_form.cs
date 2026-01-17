using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Customer_form : Form
    {
        // Connection string sourced from your Birds/Accessories forms
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
                // Selects from birdsTab or acsTab based on selection
                string query = (selected == "Birds") ? "SELECT * FROM birdsTab" : "SELECT * FROM acsTab";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInventory.DataSource = dt;

                // Sync Product ID ComboBox with current table
                cmbProductID.Items.Clear();
                string idCol = (selected == "Birds") ? "P_ID" : "A_ID";

                foreach (DataRow row in dt.Rows)
                {
                    cmbProductID.Items.Add(row[idCol].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductID.SelectedItem == null) return;

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

                    int stock = Convert.ToInt32(row.Cells["Quantity"].Value);
                    lblStockCount.Text = "Stock: " + stock;

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

            // Adds item to the dgvCart grid on the right
            dgvCart.Rows.Add(cmbProductID.SelectedItem.ToString(), txtProductName.Text, numQuantity.Value, subtotal);
            CalculateTotal();
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
            dgvCart.Rows.Clear();
            lblTotal.Text = "0.00";
            txtProductName.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            lblStockCount.Text = "Stock: 0";
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

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Synchronize ComboBox with the clicked row
                string id = dgvInventory.Rows[e.RowIndex].Cells[0].Value?.ToString();
                cmbProductID.SelectedItem = id;
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Welcome_Form welcome = new Welcome_Form();
            welcome.Show();
            this.Close();
        }
    }
}