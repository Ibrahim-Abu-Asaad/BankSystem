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
    public partial class frmBankSystem : Form
    {

        public clsUser _User = new clsUser();
        public int _UserID = -1;

        public frmBankSystem(int UserID)
        {
            InitializeComponent();

            _User = clsUser.GetUserByUserID(UserID);
            //_UserID = UserID;



        }

        private void frmBankSystem_Load(object sender, EventArgs e)
        {



            lblLogedIn.Text = $"Welcome {_User.FirstName}";

            if (_User.Permissions == 15)
                lblRole.Text = "Role : Admin";
            else lblRole.Text = "Role : User";

            //lblInfo.AutoSize = false;
            //lblInfo.Width = 500;
            //lblInfo.Height = 1500;

            //lblInfo.Text = $" Username = {_User.Username}\nPassword = {_User.Password}\nPermissions = {_User.Permissions}\nLastLogin = {_User.LastLogin}\nName = {_User.Name}\nEmail = {_User.Email}\nBirthDate = {_User.BirthDate}\nAddress = {_User.Address}\nImagePath = {_User.ImagePath}\n Country = {_User.Country}\n Phone = {_User.Phone}";

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
            Form frm = new frmManageUsers(_User.UserID);
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageClients();
            frm.ShowDialog();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {

            Form frm = new frmMyProfile(_User.UserID);
            frm.ShowDialog();


        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Form frm = new frmTransactions();
            frm.ShowDialog();
        }

        private void btnCurrenciesSettings_Click(object sender, EventArgs e)
        {
            Form frm = new frmCurrenciesSettings();
            frm.ShowDialog();
        }

        private void btnLoginsRegister_Click(object sender, EventArgs e)
        {
            Form frm = new frmLoginsRegister();
            frm.ShowDialog();
        }
    }
}
