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
    public partial class frmCurrenciesSettings : Form
    {
        public frmCurrenciesSettings()
        {
            InitializeComponent();
        }

        private void frmCurrenciesSettings_Load(object sender, EventArgs e)
        {

            dgvCurrencies.DataSource = clsCurrency.GetAllCurrenciesAndRateToShowItInDGV();

            //lblNote.Text = $"Note: These Rates depend on USD (US Dollar) as of: {DateTime.Now.ToString("d/M/yyyy")}";
            lblNote.Text = $"Note: These Rates depend on USD (US Dollar) as of: 9/4/2026 (day/Month/Year)";
            //lblNote.ForeColor = Color.Gray;

        }
    }
}
