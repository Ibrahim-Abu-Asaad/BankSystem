using BankSystemBLL;

namespace BankSystemUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int UserID = -1;

        private bool _Login()
        {

            string Username = txtUsername.Text.ToString();
            string Password = txtPassword.Text.ToString();

            UserID = clsUser.IsUserExist(Username, Password);

            return clsUser.IsUserExist(Username, Password) != -1;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (_Login())
            {

                Form frm = new frmBankSystem(UserID);
                frm.ShowDialog();
                //this.Close();

            }
            else
            {

                MessageBox.Show("Incorrect Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
    }
}
