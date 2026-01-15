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
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.sign_in_btn.Location = new System.Drawing.Point(104, 203);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(277, 87);
            this.sign_in_btn.TabIndex = 1;
            this.sign_in_btn.Text = "GO TO SIGN IN";
            this.sign_in_btn.UseVisualStyleBackColor = false;
            this.sign_in_btn.Click += new System.EventHandler(this.go2sign_in_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sign_in_btn);
            this.panel1.Location = new System.Drawing.Point(36, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 335);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "EXISTING USER?";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
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
            // sign_up_btn
            // 
            this.sign_up_btn.Location = new System.Drawing.Point(104, 203);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(290, 87);
            this.sign_up_btn.TabIndex = 0;
            this.sign_up_btn.Text = "GO TO SIGN UP";
            this.sign_up_btn.UseVisualStyleBackColor = false;
            this.sign_up_btn.Click += new System.EventHandler(this.go2sign_up_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 53);
            this.label2.TabIndex = 4;
            this.label2.Text = "NEW USER?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.sign_up_btn);
            this.panel2.Location = new System.Drawing.Point(600, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 335);
            this.panel2.TabIndex = 5;
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
            this.ClientSize = new System.Drawing.Size(1146, 619);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Welcome_Form";
            this.Text = "Welcome Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sign_in_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Button sign_up_btn;
        private Label label2;
        private Panel panel2;
        private Button button1;
    }
}

