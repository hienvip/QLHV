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
            frmMenu frm = new frmMenu();
            frm.ShowDialog();
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
                        db.Classes.Remove(dataGridView1.Rows[i].DataBoundItem as Class);
                        classBindingSource.RemoveAt(dataGridView1.Rows[i].Index);
                        db.SaveChanges();
                    }
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save the changes ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    classBindingSource.EndEdit();
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            classBindingSource.DataSource = db.Classes.ToList();
            Cursor.Current = Cursors.Default;
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            Class obj = classBindingSource.Current as Class;
            if (obj != null)
            {
                using (frmAddClass frm = new frmAddClass(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            classBindingSource.EndEdit();
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
    }
}
