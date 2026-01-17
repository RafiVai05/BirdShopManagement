namespace BirdShopManagement
{
    partial class Customer_form
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
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.leftBottomPanel = new System.Windows.Forms.Panel();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.upperFrontPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.MaskedTextBox();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProductID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftTopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.leftBottomPanel.SuspendLayout();
            this.upperFrontPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.AutoScroll = true;
            this.leftTopPanel.Controls.Add(this.panel3);
            this.leftTopPanel.Controls.Add(this.upperFrontPanel);
            this.leftTopPanel.Location = new System.Drawing.Point(200, 7);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(825, 382);
            this.leftTopPanel.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbProductType);
            this.panel1.Controls.Add(this.logout_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 590);
            this.panel1.TabIndex = 7;
            // 
            // logout_btn
            // 
            this.logout_btn.Location = new System.Drawing.Point(43, 541);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 37);
            this.logout_btn.TabIndex = 5;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Portal";
            // 
            // rightPanel
            // 
            this.rightPanel.AutoScroll = true;
            this.rightPanel.Controls.Add(this.btnPay);
            this.rightPanel.Controls.Add(this.lblTotal);
            this.rightPanel.Controls.Add(this.label9);
            this.rightPanel.Controls.Add(this.dgvCart);
            this.rightPanel.Location = new System.Drawing.Point(1048, 7);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(701, 583);
            this.rightPanel.TabIndex = 9;
            // 
            // leftBottomPanel
            // 
            this.leftBottomPanel.AutoScroll = true;
            this.leftBottomPanel.Controls.Add(this.label7);
            this.leftBottomPanel.Controls.Add(this.cmbProductID);
            this.leftBottomPanel.Controls.Add(this.label6);
            this.leftBottomPanel.Controls.Add(this.lblStockCount);
            this.leftBottomPanel.Controls.Add(this.btnRemove);
            this.leftBottomPanel.Controls.Add(this.btnClearAll);
            this.leftBottomPanel.Controls.Add(this.btnAdd);
            this.leftBottomPanel.Controls.Add(this.numQuantity);
            this.leftBottomPanel.Controls.Add(this.txtPrice);
            this.leftBottomPanel.Controls.Add(this.txtProductName);
            this.leftBottomPanel.Controls.Add(this.label5);
            this.leftBottomPanel.Controls.Add(this.label4);
            this.leftBottomPanel.Controls.Add(this.label3);
            this.leftBottomPanel.Location = new System.Drawing.Point(200, 416);
            this.leftBottomPanel.Name = "leftBottomPanel";
            this.leftBottomPanel.Size = new System.Drawing.Size(825, 162);
            this.leftBottomPanel.TabIndex = 9;
            // 
            // cmbProductType
            // 
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Items.AddRange(new object[] {
            "Birds",
            "Accessories"});
            this.cmbProductType.Location = new System.Drawing.Point(12, 208);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(162, 24);
            this.cmbProductType.TabIndex = 0;
            this.cmbProductType.SelectedIndexChanged += new System.EventHandler(this.cmbProductType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 16);
            this.label8.TabIndex = 59;
            this.label8.Text = "Select Product Type";
            // 
            // upperFrontPanel
            // 
            this.upperFrontPanel.AutoScroll = true;
            this.upperFrontPanel.Controls.Add(this.dgvInventory);
            this.upperFrontPanel.Location = new System.Drawing.Point(3, 56);
            this.upperFrontPanel.Name = "upperFrontPanel";
            this.upperFrontPanel.Size = new System.Drawing.Size(819, 310);
            this.upperFrontPanel.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, -125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(825, 175);
            this.panel3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Products";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_ID,
            this.colInventoryName,
            this.Price,
            this.Stock});
            this.dgvInventory.Location = new System.Drawing.Point(3, 3);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(642, 150);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 60;
            this.label3.Text = "Product Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 62;
            this.label5.Text = "Product Name:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(136, 54);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(120, 22);
            this.txtProductName.TabIndex = 63;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(136, 87);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(120, 22);
            this.txtPrice.TabIndex = 64;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(136, 16);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 22);
            this.numQuantity.TabIndex = 65;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(62, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(207, 34);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(301, 115);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(207, 34);
            this.btnRemove.TabIndex = 67;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(542, 115);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(207, 35);
            this.btnClearAll.TabIndex = 68;
            this.btnClearAll.Text = "CLEAR ALL";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(273, 22);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(54, 16);
            this.lblStockCount.TabIndex = 69;
            this.lblStockCount.Text = "Stock: 0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(392, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "Product ID:";
            // 
            // cmbProductID
            // 
            this.cmbProductID.FormattingEnabled = true;
            this.cmbProductID.Location = new System.Drawing.Point(486, 31);
            this.cmbProductID.Name = "cmbProductID";
            this.cmbProductID.Size = new System.Drawing.Size(121, 24);
            this.cmbProductID.TabIndex = 71;
            this.cmbProductID.SelectedIndexChanged += new System.EventHandler(this.cmbProductID_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(392, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Select Product ID";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Quantity,
            this.dataGridViewTextBoxColumn3});
            this.dgvCart.Location = new System.Drawing.Point(17, 15);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(642, 194);
            this.dgvCart.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(346, 280);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.ReadOnly = true;
            this.lblTotal.Size = new System.Drawing.Size(120, 22);
            this.lblTotal.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(235, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "TOTAL PRICE:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(259, 348);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(207, 34);
            this.btnPay.TabIndex = 67;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "P_ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "colCartName";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Price";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // P_ID
            // 
            this.P_ID.HeaderText = "P_ID";
            this.P_ID.MinimumWidth = 6;
            this.P_ID.Name = "P_ID";
            this.P_ID.ReadOnly = true;
            this.P_ID.Width = 125;
            // 
            // colInventoryName
            // 
            this.colInventoryName.HeaderText = "colInventoryName";
            this.colInventoryName.MinimumWidth = 6;
            this.colInventoryName.Name = "colInventoryName";
            this.colInventoryName.ReadOnly = true;
            this.colInventoryName.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 125;
            // 
            // Customer_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1761, 590);
            this.Controls.Add(this.leftBottomPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftTopPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Customer_form";
            this.Text = "Customer_form";
            this.leftTopPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.leftBottomPanel.ResumeLayout(false);
            this.leftBottomPanel.PerformLayout();
            this.upperFrontPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftBottomPanel;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Panel upperFrontPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.MaskedTextBox txtProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbProductID;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.MaskedTextBox lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}