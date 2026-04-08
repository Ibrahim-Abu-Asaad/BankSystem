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
            lblBalance.Text = _Client.Balance.ToString() + " USD";


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
            lblBalance.Text = _Client.Balance.ToString() + " USD";

        }

        private void btnWithdrawDeposite_Click(object sender, EventArgs e)
        {

            if(State == enState.Withdraw)
            {
                MessageBox.Show("Withdraw");
            }
            else
            {
                MessageBox.Show("Deposite");
            }

        }
    }
}
