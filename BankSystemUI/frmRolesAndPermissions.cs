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


        public frmRolesAndPermissions(int UserID)
        {

            InitializeComponent();

            _User = clsUser.GetUserByUserID(UserID);
            //MessageBox.Show($"{ _User.UserID}");



        }

        private void frmRolesAndPermissions_Load(object sender, EventArgs e)
        {

            dgvListRoles.DataSource = clsRole.ListAllRoles();

            if (dgvListRoles.Columns.Contains("ID"))
                dgvListRoles.Columns["ID"].Visible = false;

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

            //MessageBox.Show($"{_User.Name}, {clsRole.GetRoleNameByRoleID(_User.RoleID)}");
            //MessageBox.Show(dgvListRoles.Rows[e.RowIndex].ToString());
            


        }
    }
}