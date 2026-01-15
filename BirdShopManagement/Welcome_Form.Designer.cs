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
            this.forget_btn = new System.Windows.Forms.Button();
            this.signup = new System.Windows.Forms.LinkLabel();
            this.no_account_lbl = new System.Windows.Forms.Label();
            this.signin_btn = new System.Windows.Forms.Button();
            this.check_bx_ShowPass = new System.Windows.Forms.CheckBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 610);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "      WELCOME TO\r\n ANGRY BIRD SHOP";
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
            // 
            // forget_btn
            // 
            this.forget_btn.BackColor = System.Drawing.Color.White;
            this.forget_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forget_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forget_btn.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.forget_btn.Location = new System.Drawing.Point(338, 408);
            this.forget_btn.Name = "forget_btn";
            this.forget_btn.Size = new System.Drawing.Size(216, 35);
            this.forget_btn.TabIndex = 67;
            this.forget_btn.Text = "FORGET PASSWORD";
            this.forget_btn.UseVisualStyleBackColor = false;
            this.forget_btn.Click += new System.EventHandler(this.forget_btn_Click);
            // 
            // signup
            // 
            this.signup.AutoSize = true;
            this.signup.LinkColor = System.Drawing.Color.MediumAquamarine;
            this.signup.Location = new System.Drawing.Point(417, 488);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(61, 16);
            this.signup.TabIndex = 66;
            this.signup.TabStop = true;
            this.signup.Text = "SIGN UP";
            this.signup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signup_LinkClicked);
            // 
            // no_account_lbl
            // 
            this.no_account_lbl.AutoSize = true;
            this.no_account_lbl.ForeColor = System.Drawing.Color.DarkGray;
            this.no_account_lbl.Location = new System.Drawing.Point(378, 472);
            this.no_account_lbl.Name = "no_account_lbl";
            this.no_account_lbl.Size = new System.Drawing.Size(143, 16);
            this.no_account_lbl.TabIndex = 65;
            this.no_account_lbl.Text = "Don\'t Have an Account";
            // 
            // signin_btn
            // 
            this.signin_btn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.signin_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signin_btn.FlatAppearance.BorderSize = 0;
            this.signin_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signin_btn.ForeColor = System.Drawing.Color.White;
            this.signin_btn.Location = new System.Drawing.Point(339, 343);
            this.signin_btn.Name = "signin_btn";
            this.signin_btn.Size = new System.Drawing.Size(216, 35);
            this.signin_btn.TabIndex = 63;
            this.signin_btn.Text = "SIGN IN";
            this.signin_btn.UseVisualStyleBackColor = false;
            this.signin_btn.Click += new System.EventHandler(this.signin_btn_Click);
            // 
            // check_bx_ShowPass
            // 
            this.check_bx_ShowPass.AutoSize = true;
            this.check_bx_ShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_bx_ShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_bx_ShowPass.ForeColor = System.Drawing.Color.DarkGray;
            this.check_bx_ShowPass.Location = new System.Drawing.Point(433, 298);
            this.check_bx_ShowPass.Name = "check_bx_ShowPass";
            this.check_bx_ShowPass.Size = new System.Drawing.Size(121, 20);
            this.check_bx_ShowPass.TabIndex = 62;
            this.check_bx_ShowPass.Text = "Show Password";
            this.check_bx_ShowPass.UseVisualStyleBackColor = true;
            this.check_bx_ShowPass.CheckedChanged += new System.EventHandler(this.check_bx_ShowPass_CheckedChanged);
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
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.ForeColor = System.Drawing.Color.White;
            this.exit_btn.Location = new System.Drawing.Point(517, 553);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(62, 35);
            this.exit_btn.TabIndex = 59;
            this.exit_btn.Text = "EXIT";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
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
            // Welcome_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.forget_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.no_account_lbl);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.check_bx_ShowPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.signin_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome_Form";
            this.Text = "Welcome Form";
            this.Load += new System.EventHandler(this.signin_btn_Click);
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
        private Button forget_btn;
        private LinkLabel signup;
        private Label no_account_lbl;
        private Button signin_btn;
        private CheckBox check_bx_ShowPass;
        private TextBox textPassword;
        private Label label6;
        private TextBox textUserName;
        private Label label8;
        private Label label1;
        private Button exit_btn;
        private ComboBox comboBox1;
    }
}

