using BankSystemBLL;
using Guna.UI2.WinForms;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbMyProfile.Image = Image.FromFile(openFileDialog.FileName);
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
            txtCountry.Text = _User.CountryID.ToString();
            txtPhone.Text = _User.Phone;
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtAddress.Text = _User.Address;

        }

        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            _FillInformation();
        }
    }
}
