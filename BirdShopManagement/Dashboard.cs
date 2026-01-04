using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdShopManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            PopulateGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PopulateGridView()
        {

            //Console.WriteLine("Test UserIDDDD");
            //Console.WriteLine(userId);


            string sql = "SELECT * FROM Products;";

            DataAccess da = new DataAccess();           //Access the data
            DataTable dt = da.ExecuteQueryTable(sql);   //exicuting the query and getting output
            Console.WriteLine(dt);

            // Continue if data is valid
            this.dataGridView1.AutoGenerateColumns = false; if (dt != null && dt.Rows.Count > 0)
            {
                this.dataGridView1.DataSource = dt;

                // Debugging: Check column names in DataTable
                Console.WriteLine("Columns in DataTable:");
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine(col.ColumnName);
                }

                // Bind columns to DataGridView
                this.dataGridView1.Columns["BirdName"].DataPropertyName = "BirdName";        // Bind "Name" to "UserName"
                this.dataGridView1.Columns["Price"].DataPropertyName = "Price";
                this.dataGridView1.Columns["Stock"].DataPropertyName = "Stock";
                this.dataGridView1.Columns["age_in_months"].DataPropertyName = "age_in_months";
                this.dataGridView1.Columns["health_status"].DataPropertyName = "health_status";
                //this.dataGridView1.Columns["category"].DataPropertyName = "category";
            }
            else
            {
                MessageBox.Show("No data found.");
            }
            Console.WriteLine(dt);
            //dataGridView1.DataSource = dt;


            //string sql1 = "SELECT * FROM Users WHERE Id = ";
            //DataSet ds = da.ExecuteQuery(sql1);
            //Console.WriteLine(ds);
            //string userName = ds.Tables[0].Rows[0]["Name"].ToString(); // Get the project name


            //Console.WriteLine(userName);
            //this.usernameLabel.Text = userName;
            //this.userIdLbl.Text = userId.ToString();

            //string userId = ds.Tables[0].Rows[0]["CreatedBy"].ToString(); // Get the User Id
            //this.userIdLabel.Text = userId;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    Console.WriteLine("Click working");
                    Console.WriteLine(this.dataGridView1.CurrentRow.Cells["BirdName"].Value?.ToString());
                    //int project = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["idd"].Value);

                    //ViewProjects viewww = new ViewProjects(project);
                    //viewww.Show();
                    //this.Hide();



                    //this.txtProductID.ReadOnly = true;
                    //this.txtProductID.Text = dgvProductList.CurrentRow.Cells["productId"].Value?.ToString();
                    //this.txtProductName.Text = dgvProductList.CurrentRow.Cells["productName"].Value?.ToString();
                    //this.txtPrice.Text = dgvProductList.CurrentRow.Cells["price"].Value?.ToString();
                    //this.txtQuantity.Text = dgvProductList.CurrentRow.Cells["quantity"].Value?.ToString();
                    //this.cmbCategory.Text = dgvProductList.CurrentRow.Cells["category"].Value?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Project details: " + ex.Message);
                }
            }
        }




    }
}
