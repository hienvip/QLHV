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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        QLHVEntities db;
        private void BtnOut_Click(object sender, EventArgs e)
        {

            
            using (frmMenu frm = new frmMenu())
            {
                this.Hide();
                frm.ShowDialog();
            }
                
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            db = new QLHVEntities();
            studentBindingSource.DataSource = db.Students.ToList();
            accountBindingSource.DataSource = db.Accounts.ToList();
            StudentClassIDComboBox.DataSource = db.Classes.ToList();
            
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FormAddEdit frm = new FormAddEdit(new Student() { gender = false }))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        studentBindingSource.Add(frm.StudentInfo);
                        db.Students.Add(frm.StudentInfo);
                        await db.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            studentBindingSource.DataSource = db.Students.ToList();
            Cursor.Current = Cursors.Default;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save the changes ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    studentBindingSource.EndEdit();
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int rows = dataGridView1.RowCount;
                for (int i = rows - 1; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        db.Students.Remove(dataGridView1.Rows[i].DataBoundItem as Student);
                        studentBindingSource.RemoveAt(dataGridView1.Rows[i].Index);
                        db.SaveChanges();
                    }
                }
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            Student obj = studentBindingSource.Current as Student;
            if (obj != null)
            {
                using (FormAddEdit frm = new FormAddEdit(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            studentBindingSource.EndEdit();
                            await db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
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

        private void BtnClass_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.ShowDialog();
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }
    }
}
