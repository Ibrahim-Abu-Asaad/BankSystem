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
    public partial class frmRolesAndPermissions : Form
    {

        clsUser _User;
        private int _selectedRoleID = -1;

        public frmRolesAndPermissions(int UserID)
        {

            InitializeComponent();

            _User = clsUser.GetUserByUserID(UserID);
            //MessageBox.Show($"{ _User.UserID}");



        }

        private void frmRolesAndPermissions_Load(object sender, EventArgs e)
        {

            //dgvListRoles.DataSource = clsRole.ListAllRoles();
            dgvListRoles.DataSource = clsRole.ListAllRolesWithoutAdmin();

            if (dgvListRoles.Columns.Contains("ID"))
                dgvListRoles.Columns["ID"].Visible = false;

            _FillAllPermissions();



            if (dgvListRoles.Rows.Count > 0)
            {
                dgvListRoles.ClearSelection();
                dgvListRoles.Rows[0].Selected = true;
                dgvListRoles_CellDoubleClick(dgvListRoles, new DataGridViewCellEventArgs(0, 0));
            }




        }

        private void _FillAllPermissions()
        {
            chlPermissions.Items.Clear();

            DataTable dt = clsPermission.ListAllPermissions();

            foreach (DataRow row in dt.Rows)
            {
                chlPermissions.Items.Add(new clsPermissionItem
                {
                    ID = (int)row["ID"],
                    Name = row["PermissionName"].ToString()
                });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void dgvListRoles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show($"{_User.Name}, {clsRole.GetRoleNameByRoleID(_User.RoleID)}");

        }



        private void dgvListRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                string roleName = dgvListRoles.Rows[e.RowIndex].Cells["RoleName"].Value.ToString();
                lblRoleName.Text = roleName;
            }

            //string Name = lblRoleName.Text;
            int RoleID = clsRole.GetRoleIDByRoleName(lblRoleName.Text);
            _selectedRoleID = RoleID;

            //int PermissionID = clsPermission.GetPermissionIDByName();
            int PermissionID = -1;

            string PermissionName = "";

            // Put all boxesChecked to false

            for (int i = 0; i < chlPermissions.Items.Count; i++)
                chlPermissions.SetItemChecked(i, false);


            for (int i = 0; i < chlPermissions.Items.Count; i++)
            {

                //PermissionName = chlPermissions.Items[i].ToString();
                //PermissionID = clsPermission.GetPermissionIDByName(PermissionName);

                PermissionID = ((clsPermissionItem)chlPermissions.Items[i]).ID;

                if (clsRole.HasPermission(RoleID, PermissionID))
                    chlPermissions.SetItemChecked(i, true);

            }






        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            List<int> SelectedIDs = new List<int>();

            foreach (object item in chlPermissions.CheckedItems)
            {
                clsPermissionItem permission = (clsPermissionItem)item;
                SelectedIDs.Add(permission.ID);
            }

            if (clsPermission.UpdateRolePermissions(_selectedRoleID, SelectedIDs))
                MessageBox.Show("Permissions updated successfully for role: " + lblRoleName.Text, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("An error occurred while saving permissions.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgvListRoles_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            //

        }

        private void dgvListRoles_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvListRoles.Cursor = Cursors.Default;
        }

        private void dgvListRoles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
                dgvListRoles.Cursor = Cursors.Hand;

        }

        private void btnAddNewRole_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddNewRole();
            frm.ShowDialog();

        }
    }
}