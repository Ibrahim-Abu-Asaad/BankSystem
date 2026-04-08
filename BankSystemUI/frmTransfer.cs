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
    }
}
