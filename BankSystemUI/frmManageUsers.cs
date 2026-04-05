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
using System.Xml.Linq;

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

            cbSearchBy.Items.Add("Username");
            cbSearchBy.Items.Add("Name");

            cbSearchBy.SelectedIndex = 0;

        }



        private void dgvListUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0) return;

            int UserID = (int)dgvListUsers.Rows[e.RowIndex].Cells["ID"].Value;
            clsUser selectedUser = clsUser.GetUserByUserID(UserID);

            if (dgvListUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                if (!_User.HasPermission(_User.RoleID, clsPermission.GetPermissionIDByName("User_Edit")))
                {
                    MessageBox.Show("Access Denied! Check with your Admin.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Form frm = new frmAddEditUsers(UserID);
                frm.ShowDialog();
                _RefreshUsersList();
                txtSearchBy.Text = SEARCHING_Sentence;
                _Search();
            }

            else if (dgvListUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (!_User.HasPermission(_User.RoleID, clsPermission.GetPermissionIDByName("User_Delete")))
                {
                    MessageBox.Show("Access Denied! Check with your Admin.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete {selectedUser.Username}?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsUser.DeleteUser(UserID))
                    {

                        MessageBox.Show($"User deleted successfully: {selectedUser.Username}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (_User.UserID == selectedUser.UserID)
                            Application.Restart();
                        

                    }                         
                    else
                        MessageBox.Show($"User was not deleted: {selectedUser.Username}",
                            "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _RefreshUsersList();
                }
            }


        }

        private void _Search()
        {

            DataTable dtUsers = (DataTable)dgvListUsers.DataSource;

            if (txtSearchBy.Text == "")
            {
                dtUsers.DefaultView.RowFilter = "";
                return;
            }

            string filterColumn = "";

            if (cbSearchBy.SelectedIndex == 0)
                filterColumn = "Username";
            else if (cbSearchBy.SelectedIndex == 1)
                filterColumn = "Name";

            dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, txtSearchBy.Text.Trim());

            lblTotalUsers.Text = dgvListUsers.Rows.Count.ToString();

            // Admin

            int AdminCount = 0;
            foreach (DataGridViewRow row in dgvListUsers.Rows)
            {
                if (row.Cells["RoleName"].Value.ToString().ToLower() == "admin")
                    AdminCount++;

            }

            lblAdminCount.Text = AdminCount.ToString();

        }

        string SEARCHING_Sentence = "";

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchBy.Text == "")
                _RefreshUsersList();
            else _Search();

            SEARCHING_Sentence = txtSearchBy.Text;


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

            if (_User.HasPermission(_User.RoleID, clsPermission.GetPermissionIDByName("User_Create")))
            {

                Form frm = new frmAddEditUsers(-1);
                frm.ShowDialog();
                //_RefreshUsersList();

                _RefreshUsersList();
                txtSearchBy.Text = SEARCHING_Sentence;
                _Search();

            }
            else
            {
                MessageBox.Show("Access Denied");
            }

            

        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbSearchBy.SelectedIndex == 0)
                txtSearchBy.PlaceholderText = "Search By Username";
            else if (cbSearchBy.SelectedIndex == 1)
                txtSearchBy.PlaceholderText = "Search By Name";

            //_RefreshUsersList();
            //txtSearchBy.Text = "";
            _Search();

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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

            //txtSearchBy.Text = SEARCHING_Sentence;
            //_Search();

        }
    }
}
