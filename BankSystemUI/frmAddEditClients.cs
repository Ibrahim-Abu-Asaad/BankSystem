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

namespace BankSystemUI
{
    public partial class frmAddEditClients : Form
    {


        clsClient _Client;
        int _CLientID = -1;
        clsClient.enMode _Mode;
        

        public frmAddEditClients(int ClientID)
        {

            InitializeComponent();

            _Client = clsClient.GetClientByClientID(ClientID);

            if (ClientID != -1)
                _CLientID = ClientID;


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
            cbCurrency.DataSource = clsCurrency.GetAllCurrencies();
            cbCurrency.MaxDropDownItems = 7;

            // Load all permissions into CheckedListBox
            //_LoadPermissionsIntoCheckedListBox();

            // Then Check the default ones
            //_LoadDefaultUserPermissions();

            if (_CLientID == -1)
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

            }
            else if (_Mode == clsClient.enMode.Update)
            {
                _Client.Mode = _Mode;

                lblCornerTitle.Text = "Apex Bank - Edit User";
                lblTitle.Text = "Edit User";
                lblTitle.Location = new Point(490, 52);

                _FillTheFieldsWithClientInfoFromDatabase();
            }



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


            if (_Client.ImagePath != "" && File.Exists(_Client.ImagePath))
            {
                pbCkientImage.Load(_Client.ImagePath);
                llblSetImage.Visible = false;
                llblRemove.Visible = true;
            }
            else
            {
                llblSetImage.Visible = true;
                llblRemove.Visible = false;
            }

            //errorProvider1.Clear();
        }



    }
}
