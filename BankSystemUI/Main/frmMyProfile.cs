using BankSystemBLL;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmMyProfile : Form
    {

        clsUser _User;
        int _UserID = -1;

        public frmMyProfile(int UserID)
        {

            _User = clsUser.GetUserByUserID(UserID);
            _UserID = UserID;

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //
        }


        string _SelectedImagePath = "";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbMyProfile.Image = Image.FromFile(openFileDialog.FileName);
                    _SelectedImagePath = openFileDialog.FileName;

                    //_User.ImagePath = openFileDialog.FileName;

                    llblSetImage.Visible = false;
                    llblRemove.Visible = true;
                }
            }

        }

        private void pbMyProfile_Click(object sender, EventArgs e)
        {
            //
        }

        private void _FillInformation()
        {

            if (System.IO.File.Exists(_User.ImagePath))
                pbMyProfile.Image = Image.FromFile(_User.ImagePath);

            dtpBirthdate.Text = _User.BirthDate.ToString();
            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            //txtCountry.Text = _User.CountryID.ToString();
            txtPhone.Text = _User.Phone;
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtAddress.Text = _User.Address;

            if (_User.Gender.ToLower() == "male")
                rbtnMale.Checked = true;
            else rbtnFemale.Checked = true;

            _SelectedImagePath = _User.ImagePath;
            //_User.ImagePath = _SelectedImagePath;
            if (_User.ImagePath != "" && File.Exists(_User.ImagePath))
            {
                pbMyProfile.Load(_User.ImagePath);
                llblSetImage.Visible = false;
                llblRemove.Visible = true;
            }
            else
            {
                llblSetImage.Visible = true;
                llblRemove.Visible = false;
            }

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.SelectedValue = _User.CountryID;

            chbShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;


        }

        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            _FillInformation();

            if (clsRole.IsRoleAdmin(_User.RoleID))
                btnDeleteAccount.Visible = false;
        }
        
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private bool _ValidateInfo()
        {


            errorProvider1.Clear();

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
            if (clsUser.IsEmailExist(txtEmail.Text, _User.PersonID))
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
            else if (clsUser.IsPhoneExist(txtPhone.Text, _User.PersonID))
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
            else if (clsUser.IsUsernameExist(txtUsername.Text, _User.UserID))
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






            return isValid;

        }

        private void _FillTheUserWithTheValidatedInfo()
        {

            _User.UserID = _UserID;
            _User.Name = txtName.Text;
            _User.Email = txtEmail.Text;
            _User.BirthDate = dtpBirthdate.Value;
            _User.Address = txtAddress.Text;

            //if (_User.ImagePath == null)
            //    _User.ImagePath = "";

            //_User.ImagePath = _SelectedImagePath;
            if (!string.IsNullOrEmpty(_SelectedImagePath))
            {
                _User.ImagePath = _SelectedImagePath;
            }

            _User.Phone = txtPhone.Text;
            _User.CountryID = (int)cbCountry.SelectedValue;

            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;

            if (rbtnMale.Checked == true)
                _User.Gender = "Male";
            else _User.Gender = "Female";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            // Handled , Done
            if (_ValidateInfo())
            {

                _FillTheUserWithTheValidatedInfo();

                _User.Mode = clsUser.enMode.Update;

                if (_User.Save())
                    MessageBox.Show("Your Info Is Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Your Info Is NOT Saved", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);




                this.Close();

            }


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

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length > 0)
                errorProvider1.SetError(txtAddress, "");
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length > 0)
                errorProvider1.SetError(txtPhone, "");
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0)
                errorProvider1.SetError(txtUsername, "");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
                errorProvider1.SetError(txtPassword, "");
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_User.ImagePath != Properties.Resources.InitPicProfile.ToString())
            {
                _User.ImagePath = "";
                _SelectedImagePath = "";

                if (rbtnMale.Checked == true)
                    pbMyProfile.Image = Properties.Resources.InitPicProfile;
                else if (rbtnFemale.Checked == true)
                    pbMyProfile.Image = Properties.Resources.initialPhotoWomen;

                llblRemove.Visible = false;
                llblSetImage.Visible = true;
            }

        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnMale.Checked)
            {
                if (string.IsNullOrEmpty(_User.ImagePath) && string.IsNullOrEmpty(_SelectedImagePath))
                {
                    pbMyProfile.Image = Properties.Resources.InitPicProfile;
                    //pbMyProfile.Tag = "default";
                }
            }

        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFemale.Checked)
            {
                if (string.IsNullOrEmpty(_User.ImagePath) && string.IsNullOrEmpty(_SelectedImagePath))
                {
                    pbMyProfile.Image = Properties.Resources.initialPhotoWomen;
                    //pbMyProfile.Tag = "default";
                }
            }



        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (chbShowPassword.Checked == true)
            {

                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {

                txtPassword.UseSystemPasswordChar = true;

            }

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to delete your account?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_User.UserID))
                {

                    MessageBox.Show($"Your account has been deleted successfully",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Application.Restart();
                    this.Close();

                    //clsGlobal.Logout();

                }
                else
                    MessageBox.Show($"Your account was not deleted",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }


        // This should put in global class
        //public static void Logout()
        //{

        //    List<Form> openForms = new List<Form>(Application.OpenForms.Cast<Form>());
        //    foreach (Form frm in openForms)
        //    {
        //        frm.Hide();
        //    }

        //    frmLogin login = new frmLogin();
        //    login.ShowDialog();

        //    foreach (Form frm in openForms)
        //    {
        //        frm.Close();
        //    }

        //}

    }
}