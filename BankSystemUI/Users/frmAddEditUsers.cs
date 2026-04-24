using BankSystemBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using BankSystemUI.Auth;

namespace BankSystemUI
{
    public partial class frmAddEditUsers : Form
    {

        clsUser _User = new clsUser();
        int _selectedUserID = -1;
        clsUser.enMode _Mode = clsUser.enMode.Create;

        clsUser LoggedInUser;


        public frmAddEditUsers(int selectedUserID, int LoggedInUserID)
        {
            InitializeComponent();

            if (selectedUserID == -1)
                llblRemove.Visible = false;

            _selectedUserID = selectedUserID;

            _User = clsUser.GetUserByUserID(selectedUserID);
            //_selectedUserID = _User.UserID;

            LoggedInUser = clsUser.GetUserByUserID(LoggedInUserID);
        }



        // Form Loading
        private void frmAddEditUsers_Load(object sender, EventArgs e)
        {

            //chbShowPassword.Checked = false;
            //txtPassword.UseSystemPasswordChar = true;
            //txtConfirmPassword.UseSystemPasswordChar = true;

            cbRole.DisplayMember = "Role";
            cbRole.ValueMember = "ID";

            if (clsRole.IsRoleAdmin(LoggedInUser.RoleID))
                cbRole.DataSource = clsRole.ListAllRolesWithoutAdmin();


            cbRole.SelectedIndex = 0;

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.MaxDropDownItems = 7;




            //if (_selectedUserID == -1)
            //    _Mode = clsUser.enMode.Create;
            //else
            //    _Mode = clsUser.enMode.Update;




            //if (_Mode == clsUser.enMode.Create)
            //{
            //    _User = new clsUser();
            //    _User.Mode = _Mode;

            //    //chbChangePassword.Visible = false;


            //    lblCornerNameAddEditUser.Text = "Apex Bank - Add New User";
            //    lblTitleAddEditUser.Text = "Add New User";

            //    rbtnMale.Checked = true;

            //}
            //else if (_Mode == clsUser.enMode.Update)
            //{
            //    _User.Mode = _Mode;

            //    lblCornerNameAddEditUser.Text = "Apex Bank - Edit User";
            //    lblTitleAddEditUser.Text = "Edit User";
            //    lblTitleAddEditUser.Location = new Point(490, 52);

            //    _FillTheFieldsWithUserInfoFromDatabase();

            //    //chbChangePassword.Visible = true;
            //    //chbChangePassword.Checked = false;

            //    //if (chbChangePassword.Checked == true)
            //    //{
            //    //    txtPassword.Enabled = txtConfirmPassword.Enabled = chbShowPassword.Enabled = true;
            //    //}
            //    //else
            //    //{
            //    //    txtPassword.Enabled = txtConfirmPassword.Enabled = chbShowPassword.Enabled = false;
            //    //}

            //}


            if (_selectedUserID == -1)
                _Mode = clsUser.enMode.Create;
            else
                _Mode = clsUser.enMode.Update;

            if (_Mode == clsUser.enMode.Create)
            {
                _User = new clsUser();
                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Add New User";
                lblTitleAddEditUser.Text = "Add New User";
                rbtnMale.Checked = true;

                txtPassword.Visible = true;
                txtConfirmPassword.Visible = true;
                lblPassword.Visible = true;
                lblConfirmPassword.Visible = true;
                llblChangePassword.Visible = false;

                chbShowPassword.Visible = true;
                chbShowPassword.Checked = false;
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;

            }
            else if (_Mode == clsUser.enMode.Update)
            {
                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Edit User";
                lblTitleAddEditUser.Text = "Edit User";
                lblTitleAddEditUser.Location = new Point(490, 52);

                _FillTheFieldsWithUserInfoFromDatabase();

                // --- PASSWORD LOGIC FOR UPDATE ---
                // Hide textboxes (they use a separate form), show the link
                txtPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                lblPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                llblChangePassword.Visible = true;
                chbShowPassword.Visible = false;


            }




        }


        private void _FillTheFieldsWithUserInfoFromDatabase()
        {
            _User = clsUser.GetUserByUserID(_selectedUserID);
            _User.Mode = clsUser.enMode.Update;

            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;
            txtAddress.Text = _User.Address;
            txtUsername.Text = _User.Username;




            //txtPassword.Text = "";
            //txtConfirmPassword.Text = "";






            dtpBirthdate.Text = _User.BirthDate.ToString();
            cbCountry.SelectedValue = _User.CountryID;

            if (_User.Gender.ToLower() == "male")
                rbtnMale.Checked = true;
            else if (_User.Gender.ToLower() == "female")
                rbtnFemale.Checked = true;


            if (_User.RoleID == clsRole.GetRoleIDByRoleName("Account Manager"))
                cbRole.SelectedValue = _User.RoleID;
            else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Finance Manager"))
                cbRole.SelectedValue = _User.RoleID;
            else if (_User.RoleID == clsRole.GetRoleIDByRoleName("Standard User"))
                cbRole.SelectedValue = _User.RoleID;

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

            errorProvider1.Clear();
        }

        private void _FillTheUserWithTheValidatedInfo()
        {
            _User.UserID = _selectedUserID;
            _User.Name = txtName.Text;
            _User.Email = txtEmail.Text;
            _User.BirthDate = dtpBirthdate.Value;
            _User.Address = txtAddress.Text;
            _User.Phone = txtPhone.Text;
            _User.CountryID = cbCountry.SelectedValue != null ? (int)cbCountry.SelectedValue : 0;
            _User.Username = txtUsername.Text;

            //HASHING
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //if (_Mode == clsUser.enMode.Create)
            //{
            //    _User.Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            //}
            //else if (_Mode == clsUser.enMode.Update && chbChangePassword.Checked)
            //{
            //    _User.Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            //}
            //else
            //{
            //    _User.Password = "";
            //}

            if (_Mode == clsUser.enMode.Create)
            {
                // Only map password from textboxes during creation
                _User.Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rbtnMale.Checked == true)
                _User.Gender = "Male";
            else _User.Gender = "Female";



            _User.RoleID = cbRole.SelectedValue != null ? (int)cbRole.SelectedValue : -1;
        }


        private bool _ValidateInfo()
        {

            bool isValid = true;

            // Name
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

            // Email
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
            if (clsUser.IsEmailExist(txtEmail.Text, _User.PersonID) && _Mode == clsUser.enMode.Update)
            {
                errorProvider1.SetError(txtEmail, "This email already exists, enter another one");
                isValid = false;
            }

            // Phone
            if (txtPhone.TextLength == 0)
            {
                errorProvider1.SetError(txtPhone, "The phone number is required");
                isValid = false;
            }
            else if (txtPhone.TextLength < 8 || txtPhone.TextLength > 20)
            {
                errorProvider1.SetError(txtPhone, "Phone number length should be between 8 and 20 digits");
                isValid = false;
            }
            else if (clsUser.IsPhoneExist(txtPhone.Text, _User.PersonID) && _Mode == clsUser.enMode.Update)
            {
                errorProvider1.SetError(txtPhone, "This phone already exists, enter another one");
                isValid = false;
            }

            // Password
            if (_Mode == clsUser.enMode.Create)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, "The password is required");
                    isValid = false;
                }
                else if (txtPassword.Text.Length < 8)
                {
                    errorProvider1.SetError(txtPassword, "Password must be at least 8 characters");
                    isValid = false;
                }
                else if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    errorProvider1.SetError(txtConfirmPassword, "Passwords do not match!");
                    isValid = false;
                }
            }

            // Birthdate
            if (dtpBirthdate.Value > DateTime.Now)
            {
                errorProvider1.SetError(dtpBirthdate, "Birth date cannot be in the future");
                isValid = false;
            }

            // Address
            if (txtAddress.TextLength == 0)
            {
                errorProvider1.SetError(txtAddress, "The address is required");
                isValid = false;
            }

            // Username
            if (txtUsername.Text.Length == 0)
            {
                errorProvider1.SetError(txtUsername, "The username is required");
                isValid = false;
            }
            else if (clsUser.IsUsernameExist(txtUsername.Text, _User.UserID) && _Mode == clsUser.enMode.Update)
            {
                errorProvider1.SetError(txtUsername, "This username already exists, enter another one");
                isValid = false;
            }

            //// Password
            //if (_Mode == clsUser.enMode.Create || (_Mode == clsUser.enMode.Update && chbChangePassword.Visible == true && chbChangePassword.Checked == true))
            //{

            //    if (txtPassword.Text.Length == 0)
            //    {
            //        errorProvider1.SetError(txtPassword, "The password is required");
            //        isValid = false;
            //    }
            //    else if (txtPassword.Text.Length < 8)
            //    {
            //        errorProvider1.SetError(txtPassword, "Password must be at least 8 characters");
            //        isValid = false;
            //    }
            //    else if (txtConfirmPassword.Text != txtPassword.Text)
            //    {
            //        errorProvider1.SetError(txtConfirmPassword, "Passwords do not match!");
            //        isValid = false;
            //    }




            //}


            string currentUserRole = clsRole.GetRoleNameByRoleID(LoggedInUser.RoleID).ToLower();

            string selectedRoleName = cbRole.Text.ToLower();

            bool IsAdmin = clsRole.IsRoleAdmin(LoggedInUser.RoleID);


            if (clsRole.IsRoleAdmin(LoggedInUser.RoleID) && selectedRoleName != "admin" && _User.UserID == LoggedInUser.UserID && _Mode == clsUser.enMode.Update)
            {


                errorProvider1.SetError(cbRole, "As an Admin, you cannot change your own role. Only a System Administrator can perform this action.");

                isValid = false;

                // Reset the selection to prevent the change
                cbRole.Text = "Admin";

            }


            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";

            if (_ValidateInfo())
            {
                _FillTheUserWithTheValidatedInfo();

                if (_User.Save())
                {


                    if (_Mode == clsUser.enMode.Update)
                        msg = "User updated successfully!";
                    else msg = "User added successfully!";

                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (_Mode == clsUser.enMode.Create)
                        _ResetFields();
                    else
                        this.Close();

                }
                else
                {

                    if (_Mode == clsUser.enMode.Update)
                        msg = "User was not updated!";
                    else msg = "User was not added";

                    MessageBox.Show(msg, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void _ResetFields()
        {

            _User = new clsUser();
            _Mode = clsUser.enMode.Create;

            llblRemove.Visible = false;
            llblSetImage.Visible = true;

            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            chbShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            rbtnMale.Checked = true;

            dtpBirthdate.Value = DateTime.Now;
            if (cbCountry.Items.Count > 0) cbCountry.SelectedIndex = 0;

            cbRole.SelectedIndex = 0;

            pbUserImage.Image = Properties.Resources.InitPicProfile;
            lblTitleAddEditUser.Text = "Add New User";
            errorProvider1.Clear();

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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_User.ImagePath != Properties.Resources.InitPicProfile.ToString())
            {
                _User.ImagePath = "";

                if (rbtnMale.Checked == true)
                    pbUserImage.Image = Properties.Resources.InitPicProfile;
                else if (rbtnFemale.Checked == true)
                    pbUserImage.Image = Properties.Resources.initialPhotoWomen;

                llblRemove.Visible = false;
                llblSetImage.Visible = true;
            }
        }


        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
                e.Handled = true;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void frmAddEditUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }


        // Clear ErrorProvider On Change
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

            //if (txtPassword.Text.Length > 0)
            //    errorProvider1.SetError(txtPassword, "");

        }


        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

            //if (txtConfirmPassword.Text.Length > 0)
            //    errorProvider1.SetError(txtConfirmPassword, "");

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

            if (txtUsername.Text.Length > 0)
                errorProvider1.SetError(txtUsername, "");

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if (dtpBirthdate.Text.Length > 0)
                errorProvider1.SetError(dtpBirthdate, "");

        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnMale.Checked)
            {
                if (string.IsNullOrEmpty(_User.ImagePath))
                {
                    pbUserImage.Image = Properties.Resources.InitPicProfile;
                    //pbUserImage.Tag = "default";
                }
            }

        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFemale.Checked)
            {
                if (string.IsNullOrEmpty(_User.ImagePath))
                {
                    pbUserImage.Image = Properties.Resources.initialPhotoWomen;
                    //pbUserImage.Tag = "default";
                }
            }

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

            //

        }

        private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        Dictionary<int, List<int>> Perm = new Dictionary<int, List<int>>()
    {
    { 0, new List<int> { 1, 2, 3 } },
    { 4, new List<int> { 5, 6, 7 } },
    { 8, new List<int> { 9, 10, 11 } }
    };


        private void clbPermissions_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //

        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            //if (chbShowPassword.Checked == true)
            //{

            //    txtPassword.UseSystemPasswordChar = false;
            //    txtConfirmPassword.UseSystemPasswordChar = false;

            //}
            //else
            //{

            //    txtPassword.UseSystemPasswordChar = true;
            //    txtConfirmPassword.UseSystemPasswordChar = true;

            //}

        }

        private void label11_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblTitleAddEditUser_Click(object sender, EventArgs e)
        {
            //
        }

        private void chbChangePassword_CheckedChanged(object sender, EventArgs e)
        {


            //if (chbChangePassword.Checked == true)
            //    txtPassword.Enabled = txtConfirmPassword.Enabled = chbShowPassword.Enabled = true;
            //else
            //{
            //    txtPassword.Text = txtConfirmPassword.Text = "";
            //    txtPassword.Enabled = txtConfirmPassword.Enabled = chbShowPassword.Enabled = false;
            //}

        }

        private void llblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmChangePassword frm = new frmChangePassword(_selectedUserID);
            frm.ShowDialog();

            _User = clsUser.GetUserByUserID(_selectedUserID);

        }

        private void chbShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {

            txtPassword.UseSystemPasswordChar = !chbShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chbShowPassword.Checked;

        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {

            if (txtPassword.Text.Length > 0)
                errorProvider1.SetError(txtPassword, "");

        }

        private void txtConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {

            if (txtConfirmPassword.Text.Length > 0)
                errorProvider1.SetError(txtConfirmPassword, "");

        }
    }
}
