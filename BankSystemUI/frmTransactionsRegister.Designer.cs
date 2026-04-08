namespace BankSystemUI
{
    partial class frmTransactionsRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            lblCornerNameAddEditUser = new Label();
            dgvTransactionsRegister = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionsRegister).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 5;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BorderRadius = 15;
            guna2ControlBox1.Cursor = Cursors.Hand;
            guna2ControlBox1.CustomizableEdges = customizableEdges1;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1242, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(336, 85);
            label1.Name = "label1";
            label1.Size = new Size(386, 54);
            label1.TabIndex = 3;
            label1.Text = "Transactions Register";
            // 
            // lblCornerNameAddEditUser
            // 
            lblCornerNameAddEditUser.AutoSize = true;
            lblCornerNameAddEditUser.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCornerNameAddEditUser.Location = new Point(12, 9);
            lblCornerNameAddEditUser.Name = "lblCornerNameAddEditUser";
            lblCornerNameAddEditUser.Size = new Size(441, 20);
            lblCornerNameAddEditUser.TabIndex = 4;
            lblCornerNameAddEditUser.Text = "Apex Bank - Transactions - Transactions Register";
            // 
            // dgvTransactionsRegister
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvTransactionsRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTransactionsRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactionsRegister.ColumnHeadersHeight = 30;
            dgvTransactionsRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTransactionsRegister.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactionsRegister.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactionsRegister.Location = new Point(12, 242);
            dgvTransactionsRegister.Name = "dgvTransactionsRegister";
            dgvTransactionsRegister.RowHeadersVisible = false;
            dgvTransactionsRegister.RowHeadersWidth = 51;
            dgvTransactionsRegister.Size = new Size(1267, 412);
            dgvTransactionsRegister.TabIndex = 5;
            dgvTransactionsRegister.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvTransactionsRegister.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvTransactionsRegister.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvTransactionsRegister.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvTransactionsRegister.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvTransactionsRegister.ThemeStyle.BackColor = Color.White;
            dgvTransactionsRegister.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTransactionsRegister.ThemeStyle.HeaderStyle.Height = 30;
            dgvTransactionsRegister.ThemeStyle.ReadOnly = false;
            dgvTransactionsRegister.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTransactionsRegister.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactionsRegister.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactionsRegister.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvTransactionsRegister.ThemeStyle.RowsStyle.Height = 29;
            dgvTransactionsRegister.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTransactionsRegister.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // frmTransactionsRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 677);
            Controls.Add(dgvTransactionsRegister);
            Controls.Add(lblCornerNameAddEditUser);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTransactionsRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TransactionsRegister";
            Load += frmTransactionsRegister_Load_2;
            ((System.ComponentModel.ISupportInitialize)dgvTransactionsRegister).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label1;
        private Label lblCornerNameAddEditUser;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactionsRegister;
    }
}