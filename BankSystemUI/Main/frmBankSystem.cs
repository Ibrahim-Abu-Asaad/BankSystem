using BankSystemBLL;
using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

            //if (_User.RoleID == clsRole.GetRoleIDByRoleName("Admin"))
            //    lblRole.Text = "Admin";
            //else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Account Manager"))
            //    lblRole.Text = "Account Manager";
            //else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Finance Manager"))
            //    lblRole.Text = "Finance Manager";
            //else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Standard User"))
            //    lblRole.Text = "Standard User";

            if (_User.RoleID == clsRole.GetRoleIDByRoleName("Admin"))
                btnRoundedRole.Text = "Admin";
            else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Account Manager"))
                btnRoundedRole.Text = "Account Manager";
            else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Finance Manager"))
                btnRoundedRole.Text = "Finance Manager";
            else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Standard User"))
                btnRoundedRole.Text = "Standard User";


        }


        private void frmBankSystem_Load(object sender, EventArgs e)
        {
            lblLogedIn.Text = $"Welcome {_User.FirstName}";

            _UpdateClock();
            timer1.Interval = 1000;
            timer1.Start();

            //btnRoundedRole.Click = true;

            btnRoundedRole_Click(sender, e);

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

            int PermissionID = clsPermission.GetPermissionIDByName("User_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmManageUsers(_User.UserID);
            frm.ShowDialog();

        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            int PermissionID = clsPermission.GetPermissionIDByName("Client_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmManageClients();
            frm.ShowDialog();
      
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

            int PermissionID = clsPermission.GetPermissionIDByName("Transaction_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmTransactions();
            frm.ShowDialog();

        }

        private void btnCurrenciesSettings_Click(object sender, EventArgs e)
        {

            int PermissionID = clsPermission.GetPermissionIDByName("CurrencySettings_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmCurrenciesSettings();
            frm.ShowDialog();

        }

        private void btnLoginsRegister_Click(object sender, EventArgs e)
        {

            int PermissionID = clsPermission.GetPermissionIDByName("LoginsRegister_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
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

            int MarkDeleted = clsUser.GetUserByUserID(_User.UserID).MarkDeleted;

            if (MarkDeleted == 1)
                this.Close();

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

        private void btnRoundedRole_Click(object sender, EventArgs e)
        {

            //btnRoundedRole.Enabled = false;
            //btnRoundedRole.ForeColor = SystemColors.GradientActiveCaption;
            //btnRoundedRole.BorderColor = SystemColors.GradientActiveCaption;

            btnRoundedRole.TextAlign = HorizontalAlignment.Center;
            //btnRoundedRole.TextAlign = VerticalAlignment.Center;

            if (btnRoundedRole.Text.Length <= 6)
            {
                btnRoundedRole.Size = new Size(110, 42);
                btnRoundedRole.BorderRadius = 22;
            }
            else
            {
                btnRoundedRole.Size = new Size(190, 42);
                btnRoundedRole.BorderRadius = 22;
            }

            // Define your "Active" color
            Color myHighlight = SystemColors.GradientActiveCaption;
            Color myText = SystemColors.Highlight;

            // 1. Set the main colors
            btnRoundedRole.FillColor = myHighlight;
            btnRoundedRole.ForeColor = myText;
            btnRoundedRole.BorderColor = myText;

            // 2. STOP the "Hover" effect (The color won't change when mouse moves over it)
            btnRoundedRole.HoverState.FillColor = myHighlight;
            btnRoundedRole.HoverState.ForeColor = myText;
            btnRoundedRole.HoverState.BorderColor = myText;

            //// 3. STOP the "Click" effect (The color won't change when clicked)
            //btnRoundedRole.PressedState.FillColor = myHighlight;
            //btnRoundedRole.PressedState.ForeColor = myText;
            //btnRoundedRole.PressedState.BorderColor = myText;

            btnRoundedRole.PressedColor = myHighlight;
            btnRoundedRole.PressedDepth = 0; // Set depth to 0 to remove the "pushing down" effect

            // 4. Change the cursor so it doesn't look like a button
            btnRoundedRole.Cursor = Cursors.Default;



        }

        private void btnRolesAndPermissions_Click(object sender, EventArgs e)
        {

            int PermissionID = clsPermission.GetPermissionIDByName("RolesAndPermissions_AccessPage");

            if (!_User.HasPermission(_User.RoleID, PermissionID))
            {
                _AccessDenied();
                return;
            }

            Form frm = new frmRolesAndPermissions(_User.UserID);
            frm.ShowDialog();

        }
    }
}


