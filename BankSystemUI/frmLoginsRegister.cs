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
    public partial class frmLoginsRegister : Form
    {
        public frmLoginsRegister()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void _ShowLoginsRegisterTable()
        {

            dgvLoginsRegister.DataSource = clsUser.ListLoginsRegister();

        }

        private void frmLoginsRegister_Load(object sender, EventArgs e)
        {

            _ShowLoginsRegisterTable();

        }

        private void dgvLoginsRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
    }
}
