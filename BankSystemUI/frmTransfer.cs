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
    public partial class frmTransfer : Form
    {
        public frmTransfer()
        {
            InitializeComponent();
        }

        clsClient _FromClient;
        clsClient _ToClient;

        private void frmTransfer_Load(object sender, EventArgs e)
        {


            cbFromAccountNO.DisplayMember = "AccountNO";
            cbFromAccountNO.ValueMember = "ID";

            cbToAccountNO.DisplayMember = "AccountNO";
            cbToAccountNO.ValueMember = "ID";

            DataTable _dtclients = clsClient.ListAllClients();

            if (_dtclients.Rows.Count >= 2)
            {

                cbFromAccountNO.DataSource = _dtclients;
                cbFromAccountNO.SelectedIndex = 0;

                cbToAccountNO.SelectedIndex = 0;
            }


        }

        private void cbFromAccountNO_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFromAccountNO.SelectedValue == null || !(cbFromAccountNO.SelectedValue is int))
                return;

            int fromID = (int)cbFromAccountNO.SelectedValue;
            _FromClient = clsClient.GetClientByClientID(fromID);

            if (_FromClient != null)
            {
                lblFromBalance.Text = _FromClient.Balance + " USD";

                cbToAccountNO.DataSource = clsClient.ListAllClientsWithoutThisClient(fromID);
            }

        }

        private void cbToAccountNO_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbToAccountNO.SelectedValue == null) return;

            int toID = (int)cbToAccountNO.SelectedValue;

            _ToClient = clsClient.GetClientByClientID(toID);

            lblToBalance.Text = _ToClient.Balance + " USD";




        }



        private bool _IsValid()
        {

            errorProvider1.Clear();
            bool isValid = true;

            if (nudAmount.Value <= 0)
            {
                errorProvider1.SetError(nudAmount, "Please enter an amount greater than 0");
                isValid = false;
            }

            if (_FromClient != null && nudAmount.Value > _FromClient.Balance)
            {
                errorProvider1.SetError(nudAmount, "Insufficient balance in source account!");
                isValid = false;
            }

            if (cbFromAccountNO.SelectedValue != null && cbToAccountNO.SelectedValue != null)
            {
                if ((int)cbFromAccountNO.SelectedValue == (int)cbToAccountNO.SelectedValue)
                {
                    errorProvider1.SetError(cbToAccountNO, "Cannot transfer to the same account!");
                    isValid = false;
                }
            }

            return isValid;

        }

        private void _RefreshData()
        {

            _FromClient = clsClient.GetClientByClientID(_FromClient.ID);
            _ToClient = clsClient.GetClientByClientID(_ToClient.ID);

            lblFromBalance.Text = _FromClient.Balance.ToString("N2") + " USD";
            lblToBalance.Text = _ToClient.Balance.ToString("N2") + " USD";

            nudAmount.Value = 0;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            if (!_IsValid())
                return;

            string msg = $"Are you sure you want to transfer {nudAmount.Value}$ " +
                     $"from [{_FromClient.AccountNO}] to [{_ToClient.AccountNO}]?";


            if (MessageBox.Show(msg, "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsTransactions.Transfer(_FromClient.ID, _ToClient.ID, nudAmount.Value))
                {
                    MessageBox.Show("Transfer completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    _RefreshData();

                }
                else
                {
                    MessageBox.Show("Transfer failed! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }
    }
}
