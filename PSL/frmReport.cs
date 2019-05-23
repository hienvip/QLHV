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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet.Student' table. You can move, or remove it, as needed.
            this.StudentTableAdapter.Fill(this.DataSet.Student);

            this.reportViewer1.RefreshReport();
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            using(frmMenu frm = new frmMenu())
            {
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}
