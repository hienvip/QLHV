namespace PSL
{
    partial class FormAddAccount
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_isAdmin = new System.Windows.Forms.CheckBox();
            this.btnRegis = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingSourceAccount = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name";
            // 
            // txtUsername
            // 
            this.txtUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAccount, "username", true));
            this.txtUsername.Location = new System.Drawing.Point(140, 105);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(302, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAccount, "Pass", true));
            this.txtPassword.Location = new System.Drawing.Point(140, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(302, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Is_Admin";
            // 
            // cb_isAdmin
            // 
            this.cb_isAdmin.AutoSize = true;
            this.cb_isAdmin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceAccount, "is_admin", true));
            this.cb_isAdmin.Location = new System.Drawing.Point(140, 201);
            this.cb_isAdmin.Name = "cb_isAdmin";
            this.cb_isAdmin.Size = new System.Drawing.Size(138, 21);
            this.cb_isAdmin.TabIndex = 6;
            this.cb_isAdmin.Text = "Admin/Not Admin";
            this.cb_isAdmin.UseVisualStyleBackColor = true;
            this.cb_isAdmin.CheckStateChanged += new System.EventHandler(this.Cb_isAdmin_CheckStateChanged);
            // 
            // btnRegis
            // 
            this.btnRegis.Location = new System.Drawing.Point(45, 275);
            this.btnRegis.Name = "btnRegis";
            this.btnRegis.Size = new System.Drawing.Size(143, 37);
            this.btnRegis.TabIndex = 7;
            this.btnRegis.Text = "Registry";
            this.btnRegis.UseVisualStyleBackColor = true;
            this.btnRegis.Click += new System.EventHandler(this.BtnRegis_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAccount, "AccID", true));
            this.textBox1.Location = new System.Drawing.Point(299, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 9;
            // 
            // bindingSourceAccount
            // 
            this.bindingSourceAccount.DataSource = typeof(PSL.Account);
            // 
            // FormAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 393);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRegis);
            this.Controls.Add(this.cb_isAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAddAccount";
            this.Text = "FormAddAccount";
            this.Load += new System.EventHandler(this.FormAddAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_isAdmin;
        private System.Windows.Forms.Button btnRegis;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bindingSourceAccount;
        private System.Windows.Forms.TextBox textBox1;
    }
}