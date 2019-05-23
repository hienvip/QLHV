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
    public partial class frmAddClass : Form
    {
       
        public frmAddClass(Class obj)
        {         
            InitializeComponent();
            bindingSourceClass.DataSource = obj;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
           
            bindingSourceClass.EndEdit();
            DialogResult = DialogResult.OK;
        }
        public Class ClassInfo { get { return bindingSourceClass.Current as Class; } }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            using (frmClass frm = new frmClass())
            {
                this.Hide();
                frm.ShowDialog();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
