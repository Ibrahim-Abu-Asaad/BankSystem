using BankSystemBLL;
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
using System.IO;

namespace BankSystemUI
{
    public partial class frmAddEditClients : Form
    {


        clsClient _Client;
        int _ClientID = -1;
        clsClient.enMode _Mode;


        public frmAddEditClients(int ClientID)
        {

            InitializeComponent();

            _Client = clsClient.GetClientByClientID(ClientID);

            if (ClientID != -1)
                _ClientID = ClientID;


        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void frmAddEditClients_Load(object sender, EventArgs e)
        {

            chbShowPassword.Checked = false;
            txtPINcode.UseSystemPasswordChar = true;

            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "ID";
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.MaxDropDownItems = 7;

            cbCurrency.DisplayMember = "Name";
            cbCurrency.ValueMember = "ID";
            cbCurrency.DataSource = clsCurrency.GetAmericanCurrency();
            //cbCurrency.DataSource = clsCurrency.GetAmericanAndSyrianCurrencies();
            //cbCurrency.MaxDropDownItems = 7;
            cbCurrency.Enabled = false;

            if (_ClientID == -1)
                _Mode = clsClient.enMode.Create;
            else
                _Mode = clsClient.enMode.Update;



            if (_Mode == clsClient.enMode.Create)
            {
                _Client = new clsClient();
                _Client.Mode = _Mode;

                lblCornerTitle.Text = "Apex Bank - Add New Client";
                lblTitle.Text = "Add New Client";

                rbtnMale.Checked = true;
                nudBalance.Value = 500;

                llblRemove.Visible = false;
                llblSetImage.Visible = true;

            }
            else if (_Mode == clsClient.enMode.Update)
            {
                _Client.Mode = _Mode;

                lblCornerTitle.Text = "Apex Bank - Edit Client";
                lblTitle.Text = "Edit Client";
                lblTitle.Location = new Point(490, 52);

                _FillTheFieldsWithClientInfoFromDatabase();

                nudBalance.Enabled = false;
                cbCurrency.Enabled = false;

            }

            //if (pbClientImage.Image != Properties.Resources.InitPicProfile && pbClientImage.Image != Properties.Resources.initialPhotoWomen)
            //{
            //    llblRemove.Visible = true;
            //    llblSetImage.Visible = false;
            //}

            //if (pbClientImage.Image == Properties.Resources.InitPicProfile || pbClientImage.Image == Properties.Resources.initialPhotoWomen)
            //{
            //    llblRemove.Visible = false;
            //    llblSetImage.Visible = true;
            //}




        }

        private void _FillTheFieldsWithClientInfoFromDatabase()
        {
            //_Client = clsUser.GetUserByUserID(_selectedUserID);


            _Client.Mode = clsClient.enMode.Update;

            txtName.Text = _Client.Name;
            txtEmail.Text = _Client.Email;
            txtPhone.Text = _Client.Phone;
            txtAddress.Text = _Client.Address;
            txtAccountNO.Text = _Client.AccountNO;
            txtAccountNO.Text = _Client.PINcode;
            dtpBirthdate.Text = _Client.BirthDate.ToString();
            cbCountry.SelectedValue = _Client.CountryID;

            if (_Client.Gender.ToLower() == "male")
                rbtnMale.Checked = true;
            else if (_Client.Gender.ToLower() == "female")
                rbtnFemale.Checked = true;


            //if (_Client.ImagePath != "" && File.Exists(_Client.ImagePath))
            //{
            //    pbClientImage.Load(_Client.ImagePath);
            //    llblSetImage.Visible = false;
            //    llblRemove.Visible = true;
            //}
            //else
            //{
            //    llblSetImage.Visible = true;
            //    llblRemove.Visible = false;
            //}

            if (!string.IsNullOrEmpty(_Client.ImagePath) && File.Exists(_Client.ImagePath))
            {
                pbClientImage.Load(_Client.ImagePath);
                llblSetImage.Visible = false;
                llblRemove.Visible = true;
            }
            else
            {
                llblSetImage.Visible = true;
                llblRemove.Visible = false;

                if (_Client.Gender.ToLower() == "male")
                    pbClientImage.Image = Properties.Resources.InitPicProfile;
                else
                    pbClientImage.Image = Properties.Resources.initialPhotoWomen;
            }





            errorProvider1.Clear();


            txtAccountNO.Text = _Client.AccountNO.ToString();
            txtPINcode.Text = _Client.PINcode.ToString();
            nudBalance.Value = _Client.Balance;

            //cbCurrency.DisplayMember = "Name";
            //cbCurrency.ValueMember = "ID";
            //cbCurrency.DataSource = clsCurrency.GetAllCurrencies();
            //cbCurrency.SelectedValue = _Client

            cbCurrency.SelectedValue = _Client.CurrencyID;

            //MessageBox.Show($"{_Client.CurrencyID}");






        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (chbShowPassword.Checked == true)
                txtPINcode.UseSystemPasswordChar = false;
            else
                txtPINcode.UseSystemPasswordChar = true;

        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbClientImage.Image = Image.FromFile(openFileDialog.FileName);
                    _Client.ImagePath = openFileDialog.FileName;
                    llblSetImage.Visible = false;
                    llblRemove.Visible = true;
                }
            }

        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_Client.ImagePath != Properties.Resources.InitPicProfile.ToString())
            {
                _Client.ImagePath = "";

                if (rbtnMale.Checked == true)
                    pbClientImage.Image = Properties.Resources.InitPicProfile;
                else if (rbtnFemale.Checked == true)
                    pbClientImage.Image = Properties.Resources.initialPhotoWomen;

                llblRemove.Visible = false;
                llblSetImage.Visible = true;
            }

        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnMale.Checked)
            {
                if (string.IsNullOrEmpty(_Client.ImagePath) || pbClientImage.Image == Properties.Resources.initialPhotoWomen)
                {
                    pbClientImage.Image = Properties.Resources.InitPicProfile;
                    //pbUserImage.Tag = "default";
                }
            }

        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFemale.Checked)
            {
                if (string.IsNullOrEmpty(_Client.ImagePath))
                {
                    pbClientImage.Image = Properties.Resources.initialPhotoWomen;
                }
            }

        }

        private void _FillTheUserWithTheValidatedInfo()
        {

            int ClientID = _ClientID;

            _Client.ID = ClientID;
            _Client.Name = txtName.Text;
            _Client.Email = txtEmail.Text;
            _Client.BirthDate = dtpBirthdate.Value;
            _Client.Address = txtAddress.Text;
            _Client.Phone = txtPhone.Text;
            _Client.CountryID = cbCountry.SelectedValue != null ? (int)cbCountry.SelectedValue : 0;


            if (rbtnMale.Checked == true)
                _Client.Gender = "Male";
            else _Client.Gender = "Female";


            _Client.AccountNO = txtAccountNO.Text;
            _Client.PINcode = txtPINcode.Text;
            _Client.Balance = nudBalance.Value;
            _Client.CurrencyID = (int)cbCurrency.SelectedValue;



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
            if (clsUser.IsEmailExist(txtEmail.Text, _Client.PersonID))
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
            else if (clsUser.IsPhoneExist(txtPhone.Text, _Client.PersonID))
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

            // AccountNO
            if (txtAccountNO.Text.Length == 0)
            {
                errorProvider1.SetError(txtAccountNO, "The AccountNO is required");
                isValid = false;
            }
            else if (clsUser.IsUsernameExist(txtAccountNO.Text, _Client.ID))
            {
                errorProvider1.SetError(txtAccountNO, "This AccountNO already exists, enter another one");
                isValid = false;
            }

            // PINcode
            if (txtPINcode.Text.Length == 0)
            {
                errorProvider1.SetError(txtPINcode, "The PINcode is required");
                isValid = false;
            }
            else if (txtPINcode.Text.Length < 4)
            {
                errorProvider1.SetError(txtPINcode, "PINcode must be at least 8 characters");
                isValid = false;
            }


            // Balance
            if (nudBalance.Value < 500)
            {
                MessageBox.Show("The Balance Should be at least 500 dollar to create a new bank account", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;

        }

        private void _ResetFields()
        {

            //_Client = new clsClient();
            //_Mode = clsClient.enMode.Create;

            //llblRemove.Visible = false;
            //llblSetImage.Visible = true;

            //txtName.Text = "";
            //txtEmail.Text = "";
            //txtPhone.Text = "";
            //txtAddress.Text = "";
            //txtAccountNO.Text = "";
            //txtPINcode.Text = "";

            //rbtnMale.Checked = true;

            //dtpBirthdate.Value = DateTime.Now;
            //if (cbCountry.Items.Count > 0) cbCountry.SelectedIndex = 0;

            //pbCkientImage.Image = Properties.Resources.InitPicProfile;
            //lblTitle.Text = "Add New Client";
            //errorProvider1.Clear();

            _Client = new clsClient();
            _Mode = clsClient.enMode.Create;
            _Client.Mode = _Mode;

            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAccountNO.Text = "";
            txtPINcode.Text = "";
            dtpBirthdate.Value = DateTime.Now;

            if (cbCountry.Items.Count > 0) cbCountry.SelectedIndex = 0;
            if (cbCurrency.Items.Count > 0) cbCurrency.SelectedIndex = 0;

            rbtnMale.Checked = true;
            pbClientImage.Image = Properties.Resources.InitPicProfile;

            llblRemove.Visible = false;
            llblSetImage.Visible = true;

            lblTitle.Text = "Add New Client";
            errorProvider1.Clear();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            if (!_ValidateInfo()) return;

            _FillTheUserWithTheValidatedInfo();

            if (_Client.Save())
            {
                if (_Mode == clsClient.enMode.Create)
                {
                    MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetFields();
                }
                else
                {
                    MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Operation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length > 0)
                errorProvider1.SetError(txtPhone, "");
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
                e.Handled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length > 0)
                errorProvider1.SetError(txtEmail, "");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
                errorProvider1.SetError(txtName, "");
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length > 0)
                errorProvider1.SetError(txtAddress, "");
        }

        private void txtAccountNO_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountNO.Text.Length > 0)
                errorProvider1.SetError(txtAccountNO, "");
        }

        private void txtPINcode_TextChanged(object sender, EventArgs e)
        {
            if (txtPINcode.Text.Length > 0)
                errorProvider1.SetError(txtPINcode, "");
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            //if (txtBalance.Text.Length > 0)
            //    errorProvider1.SetError(txtBalance, "");
        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //
        }
    }
}

