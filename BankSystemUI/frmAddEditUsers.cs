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
    public partial class frmAddEditUsers : Form
    {

        clsUser _User;
        int _UserID = -1;
        clsUser.enMode _Mode = clsUser.enMode.Create;

        public frmAddEditUsers(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _User = clsUser.GetUserByUserID(UserID);
            
        }

        private void frmAddEditUsers_Load(object sender, EventArgs e)
        {

            if (_UserID == -1)
                _Mode = clsUser.enMode.Create;
            else
                _Mode = clsUser.enMode.Update;


            if(_Mode == clsUser.enMode.Create)
            {

                _User = new clsUser();
                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Add New User";
                lblTitleAddEditUser.Text = "Add New User";

            }
            else if(_Mode == clsUser.enMode.Update)
            {

                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Edit User";
                lblTitleAddEditUser.Text = "Edit User";

                lblTitleAddEditUser.Location = new Point(400, 76);

            }



        }
    }
}
