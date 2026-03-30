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

        public void _RefreshUsersList()
        {

            lblTotalUsers.Text = clsUser.GetUserCount().ToString();
            lblAdminCount.Text = clsUser.GetAdminCount().ToString();

            dgvListUsers.DataSource = clsUser.ListUsers();
            dgvListUsers.Columns["ID"].Visible = false;

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            _RefreshUsersList();

        }

        private void dgvListUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            int UserID = (int)dgvListUsers.Rows[e.RowIndex].Cells["ID"].Value;
            //string Username = dgvListUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            _User = clsUser.GetUserByUserID(UserID);
            //int PersonID = _User.PersonID;

            if (dgvListUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {

                dgvListUsers.Cursor = Cursors.Hand;
                //MessageBox.Show($"EDIT {UserID}");

                Form frm = new frmAddEditUsers(UserID);
                frm.ShowDialog();

                _RefreshUsersList();

            }

            

            if (dgvListUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {


                dgvListUsers.Cursor = Cursors.Hand;
                //MessageBox.Show($"DELETE {UserID}");
                if (MessageBox.Show($"Are You Sure You Want To Delete {_User.Username}","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(clsUser.DeleteUser(UserID))
                        MessageBox.Show($"User Deleted Successfully {_User.Username}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"User Does Not Deleted! {_User.Username}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



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

            Form frm = new frmAddEditUsers(-1);
            frm.ShowDialog();
            _RefreshUsersList();

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
