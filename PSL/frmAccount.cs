﻿using System;
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
            FormMain frm = new FormMain();
            frm.ShowDialog();
            this.Hide();
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

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
