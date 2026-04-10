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

        int FailedLogedIn = 0;

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



            _User = clsUser.GetUserByUsername(Username);

            if (_User == null)
            {
                FailedLogedIn++;
                MessageBox.Show("There is not an account with this username", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (_User.Password != Password)
            //{
            //    MessageBox.Show("Wrong Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            //string Role = clsRole.GetRoleNameByRoleID(_User.RoleID).ToString().ToLower();
            //if (Role == "admin" && txtPassword.Text == "123")
            //    return true;

            // HASHING
            //////////////////////////////////////////////////////////////////////////////
            string enteredPasswordFromLogin = Password;
            string storedHashPassword = _User.Password;

            bool IsCorrect = BCrypt.Net.BCrypt.Verify(enteredPasswordFromLogin, storedHashPassword);

            if (!IsCorrect)
            {
                FailedLogedIn++;
                MessageBox.Show("Wrong Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //////////////////////////////////////////////////////////////////////////////


            //if (!clsCryptography.VerifyPassword(Password, _User.Password))
            //{
            //    MessageBox.Show("Wrong Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

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

                FailedLogedIn = 0;
                //Form frm = new frmBankSystem(_UserID);
                Form frm = new frmBankSystem(_User.UserID);
                frm.ShowDialog();
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cbShowPassword.Checked = false;

                //MessageBox.Show($"Right Username And Right Password, Username: {_User.Username} Password: {_User.Password}");

            }
            else if(FailedLogedIn == 3)
            {

                MessageBox.Show("Too many failed login attempts.\nThe application will now close for security reasons.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                this.Close();

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
