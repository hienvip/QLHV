using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
{
    public partial class FormAddAccount : Form
    {
        QLHVEntities db;
        public FormAddAccount(Account obj)
        {
            InitializeComponent();
            bindingSourceAccount.DataSource = obj;
            if (cb_isAdmin.CheckState == CheckState.Checked)
                cb_isAdmin.Text = "Admin";
            else if (cb_isAdmin.CheckState == CheckState.Unchecked)
                cb_isAdmin.Text = "Not Admin";
        }

        private void FormAddAccount_Load(object sender, EventArgs e)
        {
           
        }

        private void Cb_isAdmin_CheckStateChanged(object sender, EventArgs e)
        {
            if (cb_isAdmin.CheckState == CheckState.Checked)
                cb_isAdmin.Text = "Admin";
            else if (cb_isAdmin.CheckState == CheckState.Unchecked)
                cb_isAdmin.Text = "Not Admin";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (FormMain frm = new FormMain())
            {
                frm.ShowDialog();
            }
        }

        public Account AccountInfo { get { return bindingSourceAccount.Current as Account; } }

        private void BtnRegis_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = Encryption.Encrypt(txtPassword.Text);
            bool is_admin=false;
            txtPassword.Text = Encryption.Encrypt(txtPassword.Text);
            if (cb_isAdmin.CheckState == CheckState.Checked)
            {
                is_admin = true;
            }else if (cb_isAdmin.CheckState == CheckState.Unchecked)
            {
                is_admin = false;
            }

            using (DataTable dttmp = SQLConnector.ExecuteReturnDataTable("sp_checkRegistry", "@user", username))
            {
                if(dttmp!=null && dttmp.Rows.Count > 0)
                {
                    MessageBox.Show("username already taken ! Please choose the other", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SQLConnector.checkRegistry = true;
                }
                else 
                {
                    bindingSourceAccount.EndEdit();
                    DialogResult = DialogResult.OK;
                    
                
                }
            }
            

            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cb_isAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
