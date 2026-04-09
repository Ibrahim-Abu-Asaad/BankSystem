using BankSystemBLL;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
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


        DataTable _dtClients = clsClient.ListAllClients();

        public frmManageClients()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            _RefreshClientsList();
        }



        private void frmManageClients_Load(object sender, EventArgs e)
        {

            _RefreshClientsList();

            cbSearchBy.Items.Add("AccountNO");
            cbSearchBy.Items.Add("Name");

            cbSearchBy.SelectedIndex = 0;

        }


        private void _RefreshClientsList()
        {

            _dtClients = clsClient.ListAllClients();
            dgvListClients.DataSource = _dtClients;

            lblTotalClients.Text = _dtClients.Rows.Count.ToString();
            dgvListClients.Columns["ID"].Visible = false;


        }

        private void btnAddNewClients_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddEditClients(-1);
            frm.ShowDialog();
            _RefreshClientsList();

        }

        private void dgvListClients_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Right)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        // Clear previous selections and select the row that was right-clicked
            //        dgvListClients.ClearSelection();
            //        dgvListClients.Rows[e.RowIndex].Selected = true;

            //        // Get the mouse position relative to the grid
            //        Point mousePosition = dgvListClients.PointToClient(Cursor.Position);

            //        // Show the ContextMenuStrip at the mouse position
            //        cmsClients.Show(dgvListClients, mousePosition);
            //    }
            //}

            if (e.Button == MouseButtons.Right)
            {
                // Ensure we clicked on a valid row header or cell, not the column header
                if (e.RowIndex >= 0)
                {
                    dgvListClients.ClearSelection();
                    // Set the current row to the one right-clicked
                    dgvListClients.Rows[e.RowIndex].Selected = true;
                    dgvListClients.CurrentCell = dgvListClients.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Show the context menu at the mouse position
                    cmsClients.Show(Cursor.Position);
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dgvListClients.SelectedRows.Count > 0)
            {

                int selectedClientID = (int)dgvListClients.CurrentRow.Cells["ID"].Value;

                Form frm = new frmAddEditClients(selectedClientID);
                frm.ShowDialog();

                _RefreshClientsList();
            
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // DELETE

            if (dgvListClients.CurrentRow != null)
            {

                int _SelectedClientID = -1;
                _SelectedClientID = (int)dgvListClients.CurrentRow.Cells["ID"].Value;
                clsClient _SelectedClient = clsClient.GetClientByClientID(_SelectedClientID);

                int _SelectedPersonID = _SelectedClient.PersonID;

                //MessageBox.Show(_SelectedClientID.ToString());
                //MessageBox.Show(_SelectedPersonID.ToString());
                clsClient.DeleteClient(_SelectedPersonID);
                _RefreshClientsList();


            }


        }

        private void dgvListClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //

        }

        private void _ApplyFilter()
        {

            if (_dtClients == null) return;


            string columnName = cbSearchBy.Text;
            string value = txtSearchBy.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                _dtClients.DefaultView.RowFilter = "";
                return;
            }


            if (columnName == "AccountNO")
                _dtClients.DefaultView.RowFilter = $"AccountNO LIKE '{value}%'";
            else if (columnName == "Name")
                _dtClients.DefaultView.RowFilter = $"Name LIKE '%{value}%'";


        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {

            _ApplyFilter();

        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _ApplyFilter();

        }

        private void dgvListClients_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
    }
}
