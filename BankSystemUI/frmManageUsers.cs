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

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            string info = $"{_User.Name}  {_User.Email}\n{_User.Username}  {_User.Password}";

            lblInfo.Text = info;

        }
    }
}
