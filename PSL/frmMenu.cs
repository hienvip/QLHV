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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Message", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void BtnClass_Click(object sender, EventArgs e)
        {
            using (frmClass frm = new frmClass())
            {
                this.Hide();
                frm.ShowDialog();
            }
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            using (frmAccount frm = new frmAccount())
            {
                this.Hide();
                frm.ShowDialog();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using(FormMain frm = new FormMain())
            {
                this.Hide();
                frm.ShowDialog();
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if (SQLConnector.username != "admin")
            {
                btnAdmin.Hide();

            }
        }
    }
}
