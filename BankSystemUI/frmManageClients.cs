using BankSystemBLL;
using Guna.UI2.WinForms;
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
    public partial class frmManageClients : Form
    {
        public frmManageClients()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void frmManageClients_Load(object sender, EventArgs e)
        {

            dgvListClients.DataSource = clsClient.ListAllClients();

        }
    }
}
