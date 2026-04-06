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

            chbShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            cbRole.DisplayMember = "Role";
            cbRole.ValueMember = "ID";

            if (clsRole.IsRoleAdmin(LoggedInUser.RoleID))
                cbRole.DataSource = clsRole.ListAllRolesWithoutAdmin();

            
            cbRole.SelectedIndex = 0;

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.MaxDropDownItems = 7;

            // Load all permissions into CheckedListBox
            //_LoadPermissionsIntoCheckedListBox();

            // Then Check the default ones
            //_LoadDefaultUserPermissions();

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

            }
            else if (_Mode == clsUser.enMode.Update)
            {
                _User.Mode = _Mode;

                lblCornerNameAddEditUser.Text = "Apex Bank - Edit User";
                lblTitleAddEditUser.Text = "Edit User";
                lblTitleAddEditUser.Location = new Point(490, 52);

                _FillTheFieldsWithUserInfoFromDatabase();
            }
        }


        //private void _LoadPermissionsIntoCheckedListBox()
        //{
        //    clbPermissions.Items.Clear();

        //    DataTable dt = clsPermission.ListAllPermissions();

        //    foreach (DataRow row in dt.Rows)
        //        clbPermissions.Items.Add(row["PermissionName"].ToString());
        //}


        private void _FillTheFieldsWithUserInfoFromDatabase()
        {
            _User = clsUser.GetUserByUserID(_selectedUserID);
            _User.Mode = clsUser.enMode.Update;

            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;
            txtAddress.Text = _User.Address;
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            dtpBirthdate.Text = _User.BirthDate.ToString();
            cbCountry.SelectedValue = _User.CountryID;

            if (_User.Gender.ToLower() == "male")
                rbtnMale.Checked = true;
            else if (_User.Gender.ToLower() == "female")
                rbtnFemale.Checked = true;

            //_CheckUserPermissions();

            //if (_User.RoleID == clsRole.GetRoleIDByRoleName("Admin"))
            //    cbRole.SelectedValue = _User.RoleID;
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

        //private void _CheckUserPermissions()
        //{

        //    for (int i = 0; i < clbPermissions.Items.Count; i++)
        //    {
        //        string permName = clbPermissions.Items[i].ToString();
        //        clbPermissions.SetItemChecked(i, _User.PermissionNames.Contains(permName));
        //    }

        //}

        private void _LoadDefaultUserPermissions()
        {

            //var userPermissions = new List<string>
            //    {
            //    clsPermission.enPermissions.Client_AccessPage.ToString(),
            //    clsPermission.enPermissions.Client_Create.ToString(),
            //    clsPermission.enPermissions.Client_Edit.ToString(),
            //    clsPermission.enPermissions.Client_Delete.ToString(),
            //    clsPermission.enPermissions.Transaction_AccessPage.ToString(),
            //    clsPermission.enPermissions.Transaction_Withdraw.ToString(),
            //    clsPermission.enPermissions.Transaction_Deposit.ToString(),
            //    clsPermission.enPermissions.Transaction_Transfer.ToString(),
            //    clsPermission.enPermissions.Currency_AccessPage.ToString()
            //    };

            //for (int i = 0; i < clbPermissions.Items.Count; i++)
            //{
            //    if (userPermissions.Contains(clbPermissions.Items[i].ToString()))
            //    {
            //        clbPermissions.SetItemChecked(i, true);
            //    }
            //    else
            //    {
            //        clbPermissions.SetItemChecked(i, false);
            //    }
            //}

        }


        //private List<string> _GetSelectedPermissions()
        //{
        //    var permissions = new List<string>();

        //    foreach (var item in clbPermissions.CheckedItems)
        //        permissions.Add(item.ToString());

        //    return permissions;
        //}


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
            _User.Password = txtPassword.Text;

            if (rbtnMale.Checked == true)
                _User.Gender = "Male";
            else _User.Gender = "Female";

            //_User.PermissionNames = _GetSelectedPermissions();


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
            if (clsUser.IsEmailExist(txtEmail.Text, _User.PersonID))
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
            else if (clsUser.IsPhoneExist(txtPhone.Text, _User.PersonID))
            {
                errorProvider1.SetError(txtPhone, "This phone already exists, enter another one");
                isValid = false;
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
            else if (clsUser.IsUsernameExist(txtUsername.Text, _User.UserID))
            {
                errorProvider1.SetError(txtUsername, "This username already exists, enter another one");
                isValid = false;
            }

            // Password
            if (txtPassword.Text.Length == 0)
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

            //// Role
            //if (cbRole.SelectedValue.ToString().ToLower() != "account manager" && clsRole.GetRoleNameByRoleID(_User.RoleID).ToString().ToLower() == "account manager")
            //{
            //    MessageBox.Show("You are an Account Manager, You can not change your role, Check your admin",
            //        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    isValid = false;
            //}

            string currentUserRole = clsRole.GetRoleNameByRoleID(LoggedInUser.RoleID).ToLower();

            string selectedRoleName = cbRole.Text.ToLower();

            bool IsAdmin = clsRole.IsRoleAdmin(LoggedInUser.RoleID);


            //// Logic: If I am an Account Manager, and I am NOT an Admin, I cannot change my role.
            //if (currentUserRole == "account manager" && selectedRoleName != "account manager" && !IsAdmin && _Mode == clsUser.enMode.Update && _User.UserID == LoggedInUser.UserID)
            //{
            //    //MessageBox.Show("As an Account Manager, you cannot change your own role. Only your admin can perform this action.",
            //    //    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    errorProvider1.SetError(cbRole, "As an Account Manager, you cannot change your own role. Only your admin can perform this action.");

            //    isValid = false;

            //    // Reset the selection to prevent the change
            //    cbRole.Text = "Account Manager";
            //}


            if(clsRole.IsRoleAdmin(LoggedInUser.RoleID) && selectedRoleName != "admin" && _User.UserID == LoggedInUser.UserID && _Mode == clsUser.enMode.Update)
            {

                //MessageBox.Show("As an Admin, you cannot change your own role. Only a System Administrator can perform this action.",
                //    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

            rbtnMale.Checked = true;

            dtpBirthdate.Value = DateTime.Now;
            if (cbCountry.Items.Count > 0) cbCountry.SelectedIndex = 0;

            //// Uncheck all permissions
            //for (int i = 0; i < clbPermissions.Items.Count; i++)
            //    clbPermissions.SetItemChecked(i, false);

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

            //if (cbRole.Text.ToLower() == "admin")
            //{

            //    for (int i = 0; i < clbPermissions.Items.Count; i++)
            //    {
            //        //string permName = clbPermissions.Items[i].ToString();
            //        clbPermissions.SetItemChecked(i, true);
            //    }

            //}
            //else if (cbRole.Text.ToLower() == "user")
            //{


            //    _LoadDefaultUserPermissions();

            //    //for (int i = 0; i < clbPermissions.Items.Count; i++)
            //    //{
            //    //    //string permName = clbPermissions.Items[i].ToString();
            //    //    clbPermissions.SetItemChecked(i, false);
            //    //}

            //}

        }

        private void clbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        //Dictionary<int, int> Perm = new Dictionary<int, int>();
        Dictionary<int, List<int>> Perm = new Dictionary<int, List<int>>()
    {
    { 0, new List<int> { 1, 2, 3 } },
    { 4, new List<int> { 5, 6, 7 } },
    { 8, new List<int> { 9, 10, 11 } }
    };

        //private void _CheckAndUncheck(Dictionary<int, int> per)
        //{


        //    //


        //}

        private void clbPermissions_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //// Handle Master Unchecking (If Master is unchecked, uncheck all children)
            //if (Perm.ContainsKey(e.Index) && e.NewValue == CheckState.Unchecked)
            //{
            //    // Use BeginInvoke to allow the current event to finish before force-unchecking children
            //    this.BeginInvoke(new Action(() =>
            //    {
            //        foreach (int childIndex in Perm[e.Index])
            //        {
            //            clbPermissions.SetItemChecked(childIndex, false);
            //        }
            //    }));
            //}

            //// Handle Child Checking (If Child is checked, ensure Master is already checked)
            //foreach (var group in Perm)
            //{
            //    int masterIndex = group.Key;
            //    List<int> children = group.Value;

            //    if (children.Contains(e.Index) && e.NewValue == CheckState.Checked)
            //    {
            //        // If the master is currently unchecked, stop the user
            //        if (clbPermissions.GetItemCheckState(masterIndex) == CheckState.Unchecked)
            //        {
            //            e.NewValue = CheckState.Unchecked;
            //            string masterName = clbPermissions.Items[masterIndex].ToString();
            //            MessageBox.Show($"You must enable '{masterName}' before selecting this permission.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }

            //}
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (chbShowPassword.Checked == true)
            {

                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;

            }
            else
            {

                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;

            }

        }

        private void label11_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblTitleAddEditUser_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
