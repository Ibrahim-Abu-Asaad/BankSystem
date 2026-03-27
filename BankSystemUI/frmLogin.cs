using BankSystemBLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankSystemUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private int _UserID = -1;

        private bool _Login()
        {

            string Username = txtUsername.Text.ToString();
            string Password = txtPassword.Text.ToString();

            _UserID = clsUser.IsUserExist(Username, Password);

            return clsUser.IsUserExist(Username, Password) != -1;

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
                //this.Close();

            }
            else
            {

                MessageBox.Show("Incorrect Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            //
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
    }
}
