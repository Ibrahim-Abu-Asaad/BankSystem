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
using System.Text.RegularExpressions;

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


            if (_Mode == clsUser.enMode.Create)
            {

                _User = new clsUser();
                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Add New User";
                lblTitleAddEditUser.Text = "Add New User";

            }
            else if (_Mode == clsUser.enMode.Update)
            {

                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Edit User";
                lblTitleAddEditUser.Text = "Edit User";

                lblTitleAddEditUser.Location = new Point(490, 52);

            }

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsUser.GetAllCountries();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //
        }

        //private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        //{

        //    if (txtUsername.Text.Length > 0)
        //        errorProvider1.SetError(txtUsername, "");

        //}

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
                e.Handled = true;



        }

        private bool _Validate()
        {


            bool isValid = true;


            // Validate Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name is required!");
                isValid = false;
            }
            else if (txtName.TextLength < 2)
            {
                errorProvider1.SetError(txtName, "Name must be at least 2 chars");
                isValid = false;
            }



            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "The email is required!");
                isValid = false;
            }
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider1.SetError(txtEmail, "Invalid email address!");
                isValid = false;
            }
            // From AI: Not used for now, maybe later 
            //string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            //if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            //{
            //    MessageBox.Show("Invalid email format. Please check again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (clsUser.IsEmailExist(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "This email is already exist, enter another one");
                isValid = false;
            }




            // Validate phone number
            if (txtPhone.TextLength == 0)
            {
                errorProvider1.SetError(txtPhone, "The phone number is required");
                isValid = false;
            }
            else if (txtPhone.TextLength < 8 || txtPhone.TextLength > 20)
            {
                errorProvider1.SetError(txtPhone, "The phone number length should be between 8 and 20 digits");
                isValid = false;
            }
            else if (clsUser.IsPhoneExist(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "This phone is already exist, enter another one");
                isValid = false;
            }




            // Validate Birthdate
            if (dtpBirthdate.Value > DateTime.Now)
            {
                errorProvider1.SetError(dtpBirthdate, "Birth date cannot be in the future");
                isValid = false;
            }


            // Validate Address
            if (txtAddress.TextLength == 0)
            {
                errorProvider1.SetError(txtAddress, "The address is required");
                isValid = false;
            }




            // Validate Username
            if (txtUsername.Text.Length == 0)
            {
                errorProvider1.SetError(txtUsername, "The username is required");
                isValid = false;
            }
            else if (clsUser.IsUsernameExist(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "This username is already exist, enter another one");
                isValid = false;
            }


            // Validate Password
            if (txtPassword.Text.Length == 0)
            {
                errorProvider1.SetError(txtPassword, "The password is required");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 8 characters.");
                isValid = false;
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match!");
                isValid = false;
            }





            return isValid;

        }



        private void frmAddEditUsers_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_Validate())
                MessageBox.Show("Inputs Are Valid!");

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

            if (txtName.Text.Length > 0)
                errorProvider1.SetError(txtName, "");

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            if (txtEmail.Text.Length > 0)
                errorProvider1.SetError(txtEmail, "");

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

            if (txtPhone.Text.Length > 0)
                errorProvider1.SetError(txtPhone, "");

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

            if (txtAddress.Text.Length > 0)
                errorProvider1.SetError(txtAddress, "");

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            if (txtPassword.Text.Length > 0)
                errorProvider1.SetError(txtPassword, "");

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

            if (txtConfirmPassword.Text.Length > 0)
                errorProvider1.SetError(txtConfirmPassword, "");

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

            if (txtUsername.Text.Length > 0)
                errorProvider1.SetError(txtUsername, "");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbUserImage.Image = Image.FromFile(openFileDialog.FileName);
                }
            }

        }
    }
}
