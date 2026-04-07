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

            lblTotalClients.Text = clsClient.GetClientCount().ToString();
            //lblAdminCount.Text = clsUser.GetAdminCount().ToString();

            //dgvListUsers.DataSource = clsUser.ListUsers();
            dgvListClients.DataSource = clsClient.ListAllClients();
            //dgvListClients.Columns["ID"].Visible = false;

            //if (dgvListClients.Columns.Contains("ID"))
            //{
            //    dgvListClients.Columns["ID"].Visible = false;
            //}


        }

        private void btnAddNewClients_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddEditClients(-1);
            frm.ShowDialog();

        }

        private void dgvListClients_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    // Clear previous selections and select the row that was right-clicked
                    dgvListClients.ClearSelection();
                    dgvListClients.Rows[e.RowIndex].Selected = true;

                    // Get the mouse position relative to the grid
                    Point mousePosition = dgvListClients.PointToClient(Cursor.Position);

                    // Show the ContextMenuStrip at the mouse position
                    cmsClients.Show(dgvListClients, mousePosition);
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // EDIT

            if (dgvListClients.CurrentRow != null)
            {

                int _SelectedClientID = -1;
                _SelectedClientID = (int)dgvListClients.CurrentRow.Cells["ID"].Value;

                //MessageBox.Show($"{_SelectedClientID}");
                //return;

                clsClient _SelectedClient = clsClient.GetClientByClientID(_SelectedClientID);

                //if (_SelectedClient != null)
                //    MessageBox.Show($"Hello {_SelectedClient.Name}");
                //else MessageBox.Show("NULL");



                Form frm = new frmAddEditClients(_SelectedClientID);
                frm.ShowDialog();
                _RefreshClientsList();

                //txtSearchBy.Text = SEARCHING_Sentence;
                //_Search();




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

    }
}
