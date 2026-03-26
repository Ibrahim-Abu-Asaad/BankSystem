namespace BankSystemUI
{
    partial class frmManageUsers
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            label2 = new Label();
            dgvListUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            colEdit = new DataGridViewImageColumn();
            colDelete = new DataGridViewImageColumn();
            btnAddNewUser = new Guna.UI2.WinForms.Guna2Button();
            txtSearchBy = new Guna.UI2.WinForms.Guna2TextBox();
            cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            label3 = new Label();
            label4 = new Label();
            lblTotalUsers = new Label();
            lblAdminCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListUsers).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BorderRadius = 15;
            guna2ControlBox1.Cursor = Cursors.Hand;
            guna2ControlBox1.CustomizableEdges = customizableEdges7;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1076, 6);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2ControlBox1.Size = new Size(36, 37);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(424, 56);
            label1.Name = "label1";
            label1.Size = new Size(267, 54);
            label1.TabIndex = 1;
            label1.Text = "Manage Users";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 6);
            label2.Name = "label2";
            label2.Size = new Size(225, 20);
            label2.TabIndex = 2;
            label2.Text = "Apex Bank - Manage Users";
            label2.Click += label2_Click;
            // 
            // dgvListUsers
            // 
            dgvListUsers.AllowUserToAddRows = false;
            dgvListUsers.AllowUserToDeleteRows = false;
            dgvListUsers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvListUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListUsers.ColumnHeadersHeight = 30;
            dgvListUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvListUsers.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvListUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvListUsers.GridColor = Color.FromArgb(231, 229, 255);
            dgvListUsers.Location = new Point(12, 279);
            dgvListUsers.Name = "dgvListUsers";
            dgvListUsers.ReadOnly = true;
            dgvListUsers.RowHeadersVisible = false;
            dgvListUsers.RowHeadersWidth = 51;
            dgvListUsers.Size = new Size(1103, 325);
            dgvListUsers.TabIndex = 3;
            dgvListUsers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvListUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvListUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvListUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvListUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvListUsers.ThemeStyle.BackColor = Color.White;
            dgvListUsers.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvListUsers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvListUsers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvListUsers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvListUsers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvListUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvListUsers.ThemeStyle.HeaderStyle.Height = 30;
            dgvListUsers.ThemeStyle.ReadOnly = true;
            dgvListUsers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvListUsers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListUsers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvListUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvListUsers.ThemeStyle.RowsStyle.Height = 29;
            dgvListUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvListUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvListUsers.CellClick += dgvListUsers_CellClick;
            dgvListUsers.CellContentClick += dgvListUsers_CellContentClick;
            dgvListUsers.CellMouseEnter += dgvListUsers_CellMouseEnter;
            dgvListUsers.CellMouseLeave += dgvListUsers_CellMouseLeave;
            // 
            // colEdit
            // 
            colEdit.FillWeight = 53.4759369F;
            colEdit.HeaderText = "";
            colEdit.Image = Properties.Resources.Edit;
            colEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            // 
            // colDelete
            // 
            colDelete.FillWeight = 146.524063F;
            colDelete.HeaderText = "";
            colDelete.Image = Properties.Resources.Trash;
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.BorderRadius = 5;
            btnAddNewUser.Cursor = Cursors.Hand;
            btnAddNewUser.CustomizableEdges = customizableEdges5;
            btnAddNewUser.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewUser.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewUser.ForeColor = Color.White;
            btnAddNewUser.Location = new Point(897, 204);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddNewUser.Size = new Size(163, 54);
            btnAddNewUser.TabIndex = 4;
            btnAddNewUser.Text = "Add New User";
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // txtSearchBy
            // 
            txtSearchBy.CustomizableEdges = customizableEdges3;
            txtSearchBy.DefaultText = "";
            txtSearchBy.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchBy.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchBy.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBy.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBy.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBy.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchBy.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBy.Location = new Point(60, 219);
            txtSearchBy.Margin = new Padding(3, 4, 3, 4);
            txtSearchBy.Name = "txtSearchBy";
            txtSearchBy.PlaceholderText = "Search By Username";
            txtSearchBy.SelectedText = "";
            txtSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearchBy.Size = new Size(193, 39);
            txtSearchBy.TabIndex = 5;
            txtSearchBy.TextChanged += guna2TextBox1_TextChanged;
            // 
            // cbSearchBy
            // 
            cbSearchBy.BackColor = Color.Transparent;
            cbSearchBy.Cursor = Cursors.Hand;
            cbSearchBy.CustomizableEdges = customizableEdges1;
            cbSearchBy.DrawMode = DrawMode.OwnerDrawFixed;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FocusedColor = Color.FromArgb(94, 148, 255);
            cbSearchBy.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbSearchBy.Font = new Font("Segoe UI", 10F);
            cbSearchBy.ForeColor = Color.FromArgb(68, 88, 112);
            cbSearchBy.ItemHeight = 30;
            cbSearchBy.Location = new Point(259, 222);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbSearchBy.Size = new Size(124, 36);
            cbSearchBy.TabIndex = 6;
            cbSearchBy.SelectedIndexChanged += cbSearchBy_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(547, 204);
            label3.Name = "label3";
            label3.Size = new Size(130, 22);
            label3.TabIndex = 7;
            label3.Text = "Total Users:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(547, 236);
            label4.Name = "label4";
            label4.Size = new Size(130, 22);
            label4.TabIndex = 8;
            label4.Text = "Admin Count:";
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Cascadia Mono", 12F);
            lblTotalUsers.ForeColor = SystemColors.Highlight;
            lblTotalUsers.Location = new Point(683, 199);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(36, 27);
            lblTotalUsers.TabIndex = 9;
            lblTotalUsers.Text = "28";
            lblTotalUsers.Click += label5_Click;
            // 
            // lblAdminCount
            // 
            lblAdminCount.AutoSize = true;
            lblAdminCount.Font = new Font("Cascadia Mono", 12F);
            lblAdminCount.ForeColor = SystemColors.Highlight;
            lblAdminCount.Location = new Point(683, 231);
            lblAdminCount.Name = "lblAdminCount";
            lblAdminCount.Size = new Size(24, 27);
            lblAdminCount.TabIndex = 10;
            lblAdminCount.Text = "5";
            lblAdminCount.Click += lblCount_Click;
            // 
            // frmManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 616);
            Controls.Add(lblAdminCount);
            Controls.Add(lblTotalUsers);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbSearchBy);
            Controls.Add(txtSearchBy);
            Controls.Add(btnAddNewUser);
            Controls.Add(dgvListUsers);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmManageUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmManageUsers";
            Load += frmManageUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListUsers;
        private Guna.UI2.WinForms.Guna2Button btnAddNewUser;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBy;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
        private Label label3;
        private Label lblAdminCount;
        private Label lblTotalUsers;
        private Label label4;
        private DataGridViewImageColumn colEdit;
        private DataGridViewImageColumn colDelete;
    }
}