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
    public partial class frmClass : Form
    {
        QLHVEntities db;
        public frmClass()
        {
            
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddClass frm = new frmAddClass(new Class()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        classBindingSource.Add(frm.ClassInfo);
                        db.Classes.Add(frm.ClassInfo);
                        await db.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FrmClass_Load(object sender, EventArgs e)
        {
            db = new QLHVEntities();
            classBindingSource.DataSource = db.Classes.ToList();
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
