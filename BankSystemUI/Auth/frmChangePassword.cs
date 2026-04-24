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

namespace BankSystemUI.Auth
{
    public partial class frmChangePassword : Form
    {

        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            _User = clsUser.GetUserByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            chbShowPassword.Checked = false;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

        }

        private bool _ValidatePasswords()
        {
            errorProvider1.Clear();
            bool isValid = true;

            // some validation
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "Required!");
                isValid = false;
            }

            // current password matches stored hash Or Not .
            else if (!BCrypt.Net.BCrypt.Verify(txtCurrentPassword.Text, _User.Password))
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password is incorrect!");
                isValid = false;
            }

            // some validation
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || txtNewPassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtNewPassword, "Password must be at least 8 characters");
                isValid = false;
            }

            // some validation
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match!");
                isValid = false;
            }

            return isValid;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            if (!_ValidatePasswords()) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to change your password?",
                "Confirm Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {

                _User.Password = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text);
                _User.Mode = clsUser.enMode.Update;

                if (_User.Save())
                {
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            bool show = chbShowPassword.Checked;
            txtCurrentPassword.UseSystemPasswordChar = !show;
            txtNewPassword.UseSystemPasswordChar = !show;
            txtConfirmPassword.UseSystemPasswordChar = !show;

        }
    }
}
