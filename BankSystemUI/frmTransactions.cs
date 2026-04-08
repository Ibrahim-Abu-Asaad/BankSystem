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

namespace BankSystemUI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }

        clsClient _Client;
        public enum enState
        {
            Withdraw,
            Deposite,
            Transfer
        }
        public enState State = enState.Withdraw;

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {

            lblTitleWithdrawDeposite.Text = "Withdraw";

            State = enState.Withdraw;

            //MessageBox.Show("Welcome To F**king Transaction");

            cbAccountNO.ValueMember = "ID";
            cbAccountNO.DisplayMember = "AccountNO";
            cbAccountNO.DataSource = clsClient.ListAllClients();
            cbAccountNO.MaxDropDownItems = 7;
            //cbAccountNO.SelectedIndex = 0;

            _Client = clsClient.GetClientByClientID((int)cbAccountNO.SelectedValue);
            lblBalance.Text = _Client.Balance.ToString("N2") + " USD";


        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lblTitleWithdrawDeposite.Text = "Withdraw";

            State = enState.Withdraw;

            btnWithdrawDeposite.Text = "Withdraw";

        }

        private void depositeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lblTitleWithdrawDeposite.Text = "Deposite";

            State = enState.Deposite;

            btnWithdrawDeposite.Text = "Deposite";

        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {

            State = enState.Transfer;

            Form frm = new frmTransfer();
            frm.ShowDialog();

            State = enState.Withdraw;
            lblTitleWithdrawDeposite.Text = "Withdraw";
            btnWithdrawDeposite.Text = "Withdraw";

        }

        private void cbAccountNO_SelectedIndexChanged(object sender, EventArgs e)
        {

            _Client = clsClient.GetClientByClientID((int)cbAccountNO.SelectedValue);
            lblBalance.Text = _Client.Balance.ToString("N2") + " USD";

        }

        private void _RefreshPage()
        {

            _Client = clsClient.GetClientByClientID(_Client.ID);

            if (_Client != null)
            {
                lblBalance.Text = _Client.Balance.ToString("N2") + " USD";
            }

            nudAmount.Value = 0;
            errorProvider1.Clear();

        }

        private bool _IsValid()
        {
            bool isValid = true;

            errorProvider1.Clear();

            if (nudAmount.Value <= 0)
            {
                errorProvider1.SetError(nudAmount, "Please enter an amount greater than 0");
                isValid = false;
            }

            if (State == enState.Withdraw)
            {
                if (nudAmount.Value > _Client.Balance)
                {
                    errorProvider1.SetError(nudAmount, $"Insufficient balance! Your current balance is {_Client.Balance} USD");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void btnWithdrawDeposite_Click(object sender, EventArgs e)
        {


            if (!_IsValid())
                return;


            if (State == enState.Withdraw)
            {

                if (MessageBox.Show($"Are You Sure You Want To Withdraw {nudAmount.Value.ToString()}$ From {_Client.AccountNO}", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (clsTransactions.Withdraw(_Client.ID, nudAmount.Value))
                    {

                        MessageBox.Show($"Withdraw Operation Has been Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshPage();

                    }
                    else
                    {

                        MessageBox.Show($"Withdraw Operation Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }



            }
            else
            {

                if (MessageBox.Show($"Are You Sure You Want To Deposite {nudAmount.Value.ToString()}$ To {_Client.AccountNO}", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (clsTransactions.Deposite(_Client.ID, nudAmount.Value))
                    {

                        MessageBox.Show($"Deposite Operation Has been Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshPage();

                    }
                    else
                    {

                        MessageBox.Show($"Deposite Operation Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }



            }


            _RefreshPage();

        }

        private void nudAmmount_ValueChanged(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            _IsValid();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //
        }

        private void transactionsRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmTransactionsRegister();
            frm.ShowDialog();

        }
    }
}
