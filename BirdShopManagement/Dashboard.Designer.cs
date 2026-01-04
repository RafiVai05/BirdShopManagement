namespace BirdShopManagement
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age_in_months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.health_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1077, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 105);
            this.button1.TabIndex = 0;
            this.button1.Text = "Order Bird";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BirdName,
            this.Price,
            this.stock,
            this.age_in_months,
            this.health_status,
            this.CategoryId});
            this.dataGridView1.Location = new System.Drawing.Point(108, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 92;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(1220, 656);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // BirdName
            // 
            this.BirdName.HeaderText = "Bird Name";
            this.BirdName.MinimumWidth = 11;
            this.BirdName.Name = "BirdName";
            this.BirdName.Width = 225;
            // 
            // Price
            // 
            this.Price.HeaderText = "price";
            this.Price.MinimumWidth = 11;
            this.Price.Name = "Price";
            this.Price.Width = 225;
            // 
            // stock
            // 
            this.stock.HeaderText = "stock";
            this.stock.MinimumWidth = 11;
            this.stock.Name = "stock";
            this.stock.Width = 225;
            // 
            // age_in_months
            // 
            this.age_in_months.HeaderText = "age_in_months";
            this.age_in_months.MinimumWidth = 11;
            this.age_in_months.Name = "age_in_months";
            this.age_in_months.Width = 225;
            // 
            // health_status
            // 
            this.health_status.HeaderText = "health_status";
            this.health_status.MinimumWidth = 11;
            this.health_status.Name = "health_status";
            this.health_status.Width = 225;
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "Category ";
            this.CategoryId.MinimumWidth = 11;
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Width = 225;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 929);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn age_in_months;
        private System.Windows.Forms.DataGridViewTextBoxColumn health_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
    }
}