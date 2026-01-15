using System;
using System.Windows.Forms;

namespace BirdShopManagement
{
    partial class Welcome_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.Registration = new System.Windows.Forms.Button();
            this.checkbxShowPas = new System.Windows.Forms.CheckBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 598);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "    BIRD SHOP \r\nMANAGEMENT";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1022, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1022, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label7.Location = new System.Drawing.Point(373, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 45);
            this.label7.TabIndex = 47;
            this.label7.Text = "SIGN IN";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.button2.Location = new System.Drawing.Point(338, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 35);
            this.button2.TabIndex = 67;
            this.button2.Text = "FORGET PASSWORD";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.MediumAquamarine;
            this.linkLabel1.Location = new System.Drawing.Point(401, 488);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 16);
            this.linkLabel1.TabIndex = 66;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Create Account";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(378, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "Don\'t Have an Account";
            // 
            // Registration
            // 
            this.Registration.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Registration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registration.FlatAppearance.BorderSize = 0;
            this.Registration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registration.ForeColor = System.Drawing.Color.White;
            this.Registration.Location = new System.Drawing.Point(339, 343);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(216, 35);
            this.Registration.TabIndex = 63;
            this.Registration.Text = "SIGN IN";
            this.Registration.UseVisualStyleBackColor = false;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // checkbxShowPas
            // 
            this.checkbxShowPas.AutoSize = true;
            this.checkbxShowPas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkbxShowPas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkbxShowPas.ForeColor = System.Drawing.Color.DarkGray;
            this.checkbxShowPas.Location = new System.Drawing.Point(433, 298);
            this.checkbxShowPas.Name = "checkbxShowPas";
            this.checkbxShowPas.Size = new System.Drawing.Size(121, 20);
            this.checkbxShowPas.TabIndex = 62;
            this.checkbxShowPas.Text = "Show Password";
            this.checkbxShowPas.UseVisualStyleBackColor = true;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPassword.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(338, 264);
            this.textPassword.Multiline = true;
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(216, 28);
            this.textPassword.TabIndex = 61;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(339, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 60;
            this.label6.Text = "Password";
            // 
            // textUserName
            // 
            this.textUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUserName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserName.Location = new System.Drawing.Point(338, 195);
            this.textUserName.Multiline = true;
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(216, 28);
            this.textUserName.TabIndex = 59;
            this.textUserName.TextChanged += new System.EventHandler(this.textUserName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(336, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 58;
            this.label8.Text = "Username";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.MediumAquamarine;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(517, 553);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(62, 35);
            this.buttonExit.TabIndex = 59;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ADMIN",
            "EMPLOYEE",
            "CUSTOMER"});
            this.comboBox1.Location = new System.Drawing.Point(338, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(216, 24);
            this.comboBox1.TabIndex = 68;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.admin_btn_Click);
            // 
            // Welcome_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.checkbxShowPas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Registration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome_Form";
            this.Text = "Welcome Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Label label7;
        private Button button2;
        private LinkLabel linkLabel1;
        private Label label5;
        private Button Registration;
        private CheckBox checkbxShowPas;
        private TextBox textPassword;
        private Label label6;
        private TextBox textUserName;
        private Label label8;
        private Label label1;
        private Button buttonExit;
        private ComboBox comboBox1;
    }
}

