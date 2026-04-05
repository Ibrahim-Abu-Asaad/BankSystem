using BankSystemBLL;
using BCrypt.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankSystemUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private clsUser _User = new clsUser();
        private int _UserID = -1;


        private bool _ValidateUsernameAndPassword(string Username, string Password)
        {

            errorProvider1.Clear();

            if (Username == string.Empty && Password == string.Empty)
            {
                errorProvider1.SetError(txtUsername, "Username is required");
                errorProvider1.SetError(txtPassword, "Password is required");
                //MessageBox.Show("Username And Password Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Username == string.Empty)
            {
                errorProvider1.SetError(txtUsername, "Username is required");
                //MessageBox.Show("Username Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Password == string.Empty)
            {
                errorProvider1.SetError(txtPassword, "Password is required");
                //MessageBox.Show("Password Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ////_UserID = clsUser.IsUserExist(Username, Password);
            //_UserID = clsUser.IsUserExist(Username);

            //if (_UserID == -1)
            //{
            //    MessageBox.Show("Wronge Username", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            //_User = clsUser.GetUserByUserID(_UserID);

            //if (!clsUser.CheckIfPasswordRight(_UserID, Password))
            //{
            //    MessageBox.Show("Wronge Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}


            //return true;

            _User = clsUser.GetUserByUsername(Username);

            if (_User == null)
            {
                MessageBox.Show("There is not an account with this username", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_User.Password != Password)
            {
                MessageBox.Show("Wrong Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _UserID = _User.UserID;
            return true;



        }

        private bool _Login()
        {

            string Username = txtUsername.Text.ToString();
            string Password = txtPassword.Text.ToString();

            return _ValidateUsernameAndPassword(Username, Password);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (_Login())
            {

                Form frm = new frmBankSystem(_UserID);
                frm.ShowDialog();
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cbShowPassword.Checked = false;

                //MessageBox.Show($"Right Username And Right Password, Username: {_User.Username} Password: {_User.Password}");

            }
            //else
            //{

            //    MessageBox.Show("Incorrect Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

            if (txtUsername.Text.Length > 0)
                errorProvider1.SetError(txtUsername, "");

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (cbShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                //txtPassword.PasswordChar = '*';
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cbShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            if (txtPassword.Text.Length > 0)
                errorProvider1.SetError(txtPassword, "");

        }
    }
}
