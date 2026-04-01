using BankSystemBLL;
using System;
using System.Windows.Forms;

namespace BankSystemUI
{
    public partial class frmBankSystem : Form
    {

        public clsUser _User;
        public int _UserID = -1;


        public frmBankSystem(int UserID)
        {
            InitializeComponent();

            _User = clsUser.GetUserByUserID(UserID);
            clsUser.UpdateLastLoginAndAddedItToLoginsRegister(UserID);

            if (_User.RoleID == 1)
                lblRole.Text = "Admin";
            else lblRole.Text = "User";
            
        }


        private void frmBankSystem_Load(object sender, EventArgs e)
        {
            lblLogedIn.Text = $"Welcome {_User.FirstName}";

            _UpdateClock();
            timer1.Interval = 1000;
            timer1.Start();
        }



        private void _UpdateClock()
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt\ndddd, dd MMMM yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _UpdateClock();
        }


        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            if (!_User.HasPermission(clsPermission.enPermissions.User_AccessPage))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmManageUsers(_User.UserID);
            frm.ShowDialog();
        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            if (!_User.HasPermission(clsPermission.enPermissions.Client_AccessPage))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmManageClients();
            frm.ShowDialog();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            if (!_User.HasPermission(clsPermission.enPermissions.Transaction_AccessPage))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmTransactions();
            frm.ShowDialog();
        }

        private void btnCurrenciesSettings_Click(object sender, EventArgs e)
        {
            if (!_User.HasPermission(clsPermission.enPermissions.Currency_AccessPage))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmCurrenciesSettings();
            frm.ShowDialog();
        }

        private void btnLoginsRegister_Click(object sender, EventArgs e)
        {
            if (!_User.HasPermission(clsPermission.enPermissions.LoginsRegister_AccessPage))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmLoginsRegister();
            frm.ShowDialog();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            Form frm = new frmMyProfile(_User.UserID);
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void _AccessDenied()
        {
            MessageBox.Show("Access Denied! Check with your Admin.",
                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}


