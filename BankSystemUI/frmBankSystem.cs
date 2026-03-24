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
    public partial class frmBankSystem : Form
    {

        clsUser _User = null;
        int _UserID = -1;

        public frmBankSystem(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            lblLogedIn.Text = $"Welcome UserID = {UserID}";

        }
    }
}
