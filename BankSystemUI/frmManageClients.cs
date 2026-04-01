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

        private void _TestDGV()
        {

            //// Create the DataTable structure
            //DataTable dtClients = new DataTable();

            //// Define columns
            //dtClients.Columns.Add("ID", typeof(int));
            //dtClients.Columns.Add("Full Name", typeof(string));
            //dtClients.Columns.Add("Account Number", typeof(string));
            //dtClients.Columns.Add("Balance", typeof(decimal));
            //dtClients.Columns.Add("Status", typeof(string));
            //dtClients.Columns.Add("Last Activity", typeof(DateTime));

            //// Add some fake rows
            //dtClients.Rows.Add(101, "Ibrahim Abu-Asaad", "APEX-99283", 5250.75, "Active", DateTime.Now.AddDays(-2));
            //dtClients.Rows.Add(102, "Alice Johnson", "APEX-11204", 120.00, "Active", DateTime.Now.AddHours(-5));
            //dtClients.Rows.Add(103, "Mark Stevens", "APEX-55432", 0.00, "Suspended", DateTime.Now.AddMonths(-1));
            //dtClients.Rows.Add(104, "Sarah Connor", "APEX-88761", 15400.50, "Active", DateTime.Now);
            //dtClients.Rows.Add(105, "James Bond", "APEX-00007", 7000.00, "Under Review", DateTime.Now.AddDays(-10));

            //// Bind to your DataGridView
            //// Inside your Form_Load or Button_Click
            //dgvListClients.AutoGenerateColumns = true;
            //dgvListClients.DataSource = dtClients;

        }

        private void frmManageClients_Load(object sender, EventArgs e)
        {
            //_TestDGV();
        }
    }
}
