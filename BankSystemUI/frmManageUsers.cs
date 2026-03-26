using BankSystemBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystemUI
{
    public partial class frmManageUsers : Form
    {

        clsUser _User;

        public frmManageUsers(int UserID)
        {
            InitializeComponent();

            _User = clsUser.GetUserByUserID(UserID);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void _RefreshUsersList()
        {

            lblTotalUsers.Text = clsUser.GetUserCount().ToString();
            lblAdminCount.Text = clsUser.GetAdminCount().ToString();

            dgvListUsers.DataSource = clsUser.ListUsers();

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            _RefreshUsersList();

        }

        private void dgvListUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            int UserID = (int)dgvListUsers.Rows[e.RowIndex].Cells["UserID"].Value;

            if (dgvListUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {

                dgvListUsers.Cursor = Cursors.Hand;
                MessageBox.Show($"EDIT {UserID}");

                _RefreshUsersList();

            }

            if (dgvListUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {

                dgvListUsers.Cursor = Cursors.Hand;
                MessageBox.Show($"DELETE {UserID}");

                _RefreshUsersList();

            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblCount_Click(object sender, EventArgs e)
        {
            //
        }

        private void dgvListUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            //
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void dgvListUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && (dgvListUsers.Columns[e.ColumnIndex].Name == "colEdit" || dgvListUsers.Columns[e.ColumnIndex].Name == "colDelete"))
                dgvListUsers.Cursor = Cursors.Hand;

        }

        private void dgvListUsers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

            dgvListUsers.Cursor = Cursors.Default;

        }
    }
}
