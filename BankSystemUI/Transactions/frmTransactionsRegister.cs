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
    public partial class frmTransactionsRegister : Form
    {
        public frmTransactionsRegister()
        {
            InitializeComponent();
        }


        private void frmTransactionsRegister_Load_2(object sender, EventArgs e)
        {

            dgvTransactionsRegister.DataSource = clsTransactions.ListTransactionsRegister();

            if (dgvTransactionsRegister.Columns.Contains("TransactionID"))
                dgvTransactionsRegister.Columns["TransactionID"].Visible = false;

        }







    }
}
