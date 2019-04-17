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
    public partial class FormAddEdit : Form
    {
        public FormAddEdit(Student obj)
        {
            InitializeComponent();
            bindingSourceStudent.DataSource = obj;
            if (chkbGender.CheckState == CheckState.Checked)
                chkbGender.Text = "Male";
            else if (chkbGender.CheckState == CheckState.Unchecked)
                chkbGender.Text = "Female";

        }
        public Student StudentInfo { get { return bindingSourceStudent.Current as Student; } }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bindingSourceStudent.EndEdit();
            DialogResult = DialogResult.OK;
            if (textBox1.Text == null)
            {
                MessageBox.Show("please fill data !!!", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormAddEdit_Load(object sender, EventArgs e)
        {
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "ClassID";
            using (QLHVEntities db = new QLHVEntities())
            {
                cbClass.DataSource = db.Classes.ToList();
            }
        }

        private void ChkbGender_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbGender.CheckState == CheckState.Checked)
                chkbGender.Text = "Male";
            else if (chkbGender.CheckState == CheckState.Unchecked)
                chkbGender.Text = "Female";
        }
    }
}
