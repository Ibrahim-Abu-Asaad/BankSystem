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
    public partial class frmAddNewRole : Form
    {
        public frmAddNewRole()
        {
            InitializeComponent();
        }

        private void frmAddNewRole_Load(object sender, EventArgs e)
        {

            _FillAllPermissions();

        }

        private void _FillAllPermissions()
        {
            chlPermissions.Items.Clear();

            //DataTable dt = clsPermission.ListAllPermissions();
            DataTable dt = clsPermission.GetAllPermissionsWithoutRolePermissions();

            foreach (DataRow row in dt.Rows)
            {
                chlPermissions.Items.Add(new clsPermissionItem
                {
                    ID = (int)row["ID"],
                    Name = row["PermissionName"].ToString()
                });
            }
        }

        private bool _IsValidRoleName(string RoleName)
        {



            if (string.IsNullOrEmpty(RoleName))
            {
                MessageBox.Show("Please enter a Role Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (clsRole.IsRoleExist(RoleName))
            {
                MessageBox.Show("This role name already exists. Please choose a different name.", "Duplicate Role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string RoleName = txtRoleName.Text.Trim();

            if (!_IsValidRoleName(RoleName))
                return;

            int NewRoleID = clsRole.AddNewRole(RoleName);

            if (NewRoleID != -1)
            {
                List<int> SelectedIDs = new List<int>();
                foreach (object item in chlPermissions.CheckedItems)
                {
                    clsPermissionItem permission = (clsPermissionItem)item;
                    SelectedIDs.Add(permission.ID);
                }

                if (clsPermission.UpdateRolePermissions(NewRoleID, SelectedIDs))
                {
                    MessageBox.Show($"Role '{RoleName}' created and permissions assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Role was created, but there was an error saving the permissions.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Failed to create the new role. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
