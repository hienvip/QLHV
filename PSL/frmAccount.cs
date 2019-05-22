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
    public partial class frmAccount : Form
    {
        QLHVEntities db;
        public frmAccount()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FormAddAccount frm = new FormAddAccount(new Account()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        accountBindingSource.Add(frm.AccountInfo);
                        db.Accounts.Add(frm.AccountInfo);
                        await db.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frm = new frmMenu();
            frm.ShowDialog();
            
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            db = new QLHVEntities();
            accountBindingSource.DataSource = db.Accounts.ToList();
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
                        db.Accounts.Remove(dataGridView1.Rows[i].DataBoundItem as Account);
                        accountBindingSource.RemoveAt(dataGridView1.Rows[i].Index);
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
                    accountBindingSource.EndEdit();
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
            accountBindingSource.DataSource = db.Accounts.ToList();
            Cursor.Current = Cursors.Default;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            Account obj = accountBindingSource.Current as Account;
            if (obj != null)
            {
                using (FormAddAccount frm = new FormAddAccount(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            accountBindingSource.EndEdit();
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
