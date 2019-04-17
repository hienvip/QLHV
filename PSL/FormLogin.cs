using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }



        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                txtUsername.Text = "Enter your user name";
            txtUsername.ForeColor = Color.DarkGray;
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter your user name")
                txtUsername.Text = null;
            txtUsername.ForeColor = Color.Black;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
                txtPassword.Text = "Enter your password";
            txtPassword.ForeColor = Color.DarkGray;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password")
                txtPassword.Text = null;
            txtPassword.ForeColor = Color.Black;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;
            password = Encryption.Encrypt(password);
            using (DataTable dttmp = SQLConnector.ExecuteReturnDataTable("sp_checkLogin", "@user", user, "@password", password))
            {
                if (dttmp != null && dttmp.Rows.Count > 0)
                {
                    if (dttmp.Rows[0][0] is int _login && dttmp.Rows[0][1] is bool _admin)
                    {
                        UserInfo.UserID = _login;
                        this.DialogResult = DialogResult.OK;
                        SQLConnector.is_login = true;
                        SQLConnector.username = user;
                        SQLConnector.is_admin = _admin;
                        
                        this.Close();
                    }
                    else
                    {

                        MessageBox.Show("sp_checkLogin wrong");
                    }
                }
                else
                {
                    SQLConnector.is_login = false;
                    MessageBox.Show("User or password wrong");
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
