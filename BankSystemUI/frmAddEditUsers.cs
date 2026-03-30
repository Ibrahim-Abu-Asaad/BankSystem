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
using BankSystemDAL;
using Microsoft.VisualBasic;

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

            if (UserID == -1)
                llblRemove.Visible = false;

            _UserID = UserID;
            _User = clsUser.GetUserByUserID(UserID);

        }


        private void _FillTheFieldsWithUserInfoFromDatabase()
        {

            _User = clsUser.GetUserByUserID(_UserID);
            _User.Mode = clsUser.enMode.Update;

            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;
            txtAddress.Text = _User.Address;
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;

            dtpBirthdate.Text = _User.BirthDate.ToString();

            //cbCountry.DisplayMember = "Name";
            //cbCountry.ValueMember = "ID";
            //cbCountry.DataSource = clsUser.GetAllCountries();
            cbCountry.SelectedValue = _User.CountryID;

            int PermissionLevel = clsUser.GetPermissionLevelByPermissionID(_User.PermissionID);
            //MessageBox.Show($"{PermissionLevel}");
            chbManageUsers.Checked = (PermissionLevel & (int)clsUser.enPermissions.ManageUsers) == (int)clsUser.enPermissions.ManageUsers;
            chbManageClients.Checked = (PermissionLevel & (int)clsUser.enPermissions.ManageCLients) == (int)clsUser.enPermissions.ManageCLients;
            chbCurrenciesSettings.Checked = (PermissionLevel & (int)clsUser.enPermissions.ManageCurrencies) == (int)clsUser.enPermissions.ManageCurrencies;
            chbTransactions.Checked = (PermissionLevel & (int)clsUser.enPermissions.ManageTransactions) == (int)clsUser.enPermissions.ManageTransactions;
            chbLoginsRegister.Checked = (PermissionLevel & (int)clsUser.enPermissions.LoginsRegister) == (int)clsUser.enPermissions.LoginsRegister;

            if (_User.ImagePath != "" && File.Exists(_User.ImagePath))
            {
                pbUserImage.Load(_User.ImagePath);
                llblSetImage.Visible = false;
                llblRemove.Visible = true;
            }
            else
            {
                llblSetImage.Visible = true;
                llblRemove.Visible = false;
            }


            //_User.ImagePath = string.IsNullOrEmpty(_User.ImagePath) ? "" : _User.ImagePath;
            //_User.ImagePath =  _User.ImagePath;



            errorProvider1.Clear();

            //lblTitleAddEditUser.Text = "Add New User";

        }

        //private void _SetAllCheckBoxes(bool IsChecked)
        //{
        //    chbManageUsers.Checked = IsChecked;
        //    chbManageClients.Checked = IsChecked;
        //    chbCurrenciesSettings.Checked = IsChecked;
        //    chbTransactions.Checked = IsChecked;
        //    chbLoginsRegister.Checked = IsChecked;
        //}

        private void frmAddEditUsers_Load(object sender, EventArgs e)
        {

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsUser.GetAllCountries();

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

                _FillTheFieldsWithUserInfoFromDatabase();


                

            }

            //cbCountry.DisplayMember = "Name";
            //cbCountry.ValueMember = "ID";
            //cbCountry.DataSource = clsUser.GetAllCountries();
            cbCountry.MaxDropDownItems = 7;

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

            if (dtpBirthdate.Text.Length > 0)
                errorProvider1.SetError(dtpBirthdate, "");

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

        private bool _ValidateInfo()
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
            if (clsUser.IsEmailExist(txtEmail.Text, _User.UserID))
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
            else if (clsUser.IsPhoneExist(txtPhone.Text, _User.UserID))
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

        private int _GetThePermissionIDofTheUser()
        {

            int PermissionLevel = 0;

            if (chbManageUsers.Checked == true)
                PermissionLevel += (int)clsUser.enPermissions.ManageUsers;

            if (chbManageClients.Checked == true)
                PermissionLevel += (int)clsUser.enPermissions.ManageCLients;

            if (chbCurrenciesSettings.Checked == true)
                PermissionLevel += (int)clsUser.enPermissions.ManageCurrencies;

            if (chbTransactions.Checked == true)
                PermissionLevel += (int)clsUser.enPermissions.ManageTransactions;

            if (chbLoginsRegister.Checked == true)
                PermissionLevel += (int)clsUser.enPermissions.LoginsRegister;

            int PermissionID = clsUser.GetPermissionIDByPermissionLevel(PermissionLevel);

            //if (clsUser.IsPermissionLevelExist(PermissionLevel))
            //    PermissionID = clsUser.GetPermissionIDByPermissionLevel(PermissionLevel);
            //else
            //{

            //}

            if (PermissionID == -1)
                PermissionID = clsUser.AddNewPermission(PermissionLevel);

            return PermissionID;

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

            _User.Phone = txtPhone.Text;


            //_User.CountryID = 0;
            //_User.CountryID = (int)cbCountry.SelectedValue;

            //if(cbCountry.SelectedValue != null)
            //    _User.CountryID = (int)cbCountry.SelectedValue;

            _User.CountryID = cbCountry.SelectedValue != null ? (int)cbCountry.SelectedValue : 0;

            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;

            _User.PermissionID = _GetThePermissionIDofTheUser();



        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            //if (_Validate())
            //    MessageBox.Show("Inputs Are Valid!");


            string msg = "";

            if (_ValidateInfo())
            {

                _FillTheUserWithTheValidatedInfo();

                //MessageBox.Show($"UserID = {_User.UserID}, PersonID = {_User.PersonID}");
                //MessageBox.Show(_User.Mode.ToString());
                if (_User.Save())
                {


                    msg = "User added successfully!";
                    if (_Mode == clsUser.enMode.Update)
                        msg = "User Updated successfully!";


                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (_Mode == clsUser.enMode.Create)
                        _ResetFields();
                    else this.Close();


                }
                else
                {
                    msg = "User was not added";
                    if (_Mode == clsUser.enMode.Update)
                        msg = "User was not updated";

                    MessageBox.Show(msg, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }



        }

        private void _ResetFields()
        {

            _User = new clsUser();
            _Mode = clsUser.enMode.Create;

            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            dtpBirthdate.Value = DateTime.Now;
            if (cbCountry.Items.Count > 0) cbCountry.SelectedIndex = 0;

            chbManageUsers.Checked = false;
            chbManageClients.Checked = false;
            chbCurrenciesSettings.Checked = false;
            chbTransactions.Checked = false;
            chbLoginsRegister.Checked = false;

            pbUserImage.Image = Properties.Resources.InitPicProfile;

            errorProvider1.Clear();

            lblTitleAddEditUser.Text = "Add New User";



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

                    _User.ImagePath = openFileDialog.FileName;

                    llblSetImage.Visible = false;
                    llblRemove.Visible = true;
                }
            }

        }

        private void cbTransactions_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void chLoginsRegister_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void chManageClients_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void cbCurrenciesSettings_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_User.ImagePath != Properties.Resources.InitPicProfile.ToString())
            {
                _User.ImagePath = "";
                pbUserImage.Image = Properties.Resources.InitPicProfile;
                llblRemove.Visible = false;
                llblSetImage.Visible = true;
            }

        }

        private void dtpBirthdate_TextChanged(object sender, EventArgs e)
        {

            //if (txtUsername.Text.Length > 0)
            //    errorProvider1.SetError(txtUsername, "");

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
