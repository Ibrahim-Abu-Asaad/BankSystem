namespace BankSystemUI
{
    partial class frmRolesAndPermissions
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            label2 = new Label();
            dgvListRoles = new Guna.UI2.WinForms.Guna2DataGridView();
            chlPermissions = new CheckedListBox();
            label3 = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            lblRoleName = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAddNewRole = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvListRoles).BeginInit();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges5;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(818, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(289, 65);
            label1.Name = "label1";
            label1.Size = new Size(404, 54);
            label1.TabIndex = 1;
            label1.Text = "Roles And Permissions";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(261, 20);
            label2.TabIndex = 2;
            label2.Text = "Apex - Roles And Permissions";
            // 
            // dgvListRoles
            // 
            dgvListRoles.AllowUserToAddRows = false;
            dgvListRoles.AllowUserToDeleteRows = false;
            dgvListRoles.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvListRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListRoles.ColumnHeadersHeight = 30;
            dgvListRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvListRoles.DefaultCellStyle = dataGridViewCellStyle3;
            dgvListRoles.GridColor = Color.FromArgb(231, 229, 255);
            dgvListRoles.Location = new Point(79, 212);
            dgvListRoles.Name = "dgvListRoles";
            dgvListRoles.ReadOnly = true;
            dgvListRoles.RowHeadersVisible = false;
            dgvListRoles.RowHeadersWidth = 51;
            dgvListRoles.Size = new Size(313, 403);
            dgvListRoles.TabIndex = 3;
            dgvListRoles.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvListRoles.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvListRoles.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvListRoles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvListRoles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvListRoles.ThemeStyle.BackColor = Color.White;
            dgvListRoles.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvListRoles.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvListRoles.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvListRoles.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvListRoles.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvListRoles.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvListRoles.ThemeStyle.HeaderStyle.Height = 30;
            dgvListRoles.ThemeStyle.ReadOnly = true;
            dgvListRoles.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvListRoles.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListRoles.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvListRoles.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvListRoles.ThemeStyle.RowsStyle.Height = 29;
            dgvListRoles.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvListRoles.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvListRoles.CellClick += dgvListRoles_CellClick;
            dgvListRoles.CellContentDoubleClick += dgvListRoles_CellContentDoubleClick;
            dgvListRoles.CellDoubleClick += dgvListRoles_CellDoubleClick;
            dgvListRoles.CellLeave += dgvListRoles_CellLeave;
            dgvListRoles.CellMouseEnter += dgvListRoles_CellMouseEnter;
            dgvListRoles.CellMouseLeave += dgvListRoles_CellMouseLeave;
            // 
            // chlPermissions
            // 
            chlPermissions.FormattingEnabled = true;
            chlPermissions.Location = new Point(446, 279);
            chlPermissions.Name = "chlPermissions";
            chlPermissions.Size = new Size(282, 136);
            chlPermissions.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(446, 212);
            label3.Name = "label3";
            label3.Size = new Size(120, 27);
            label3.TabIndex = 5;
            label3.Text = "Role Name";
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 5;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges3;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(665, 553);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSave.Size = new Size(170, 56);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoleName.ForeColor = SystemColors.Highlight;
            lblRoleName.Location = new Point(568, 216);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(0, 22);
            lblRoleName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Mono", 9F);
            label4.Location = new Point(504, 421);
            label4.Name = "label4";
            label4.Size = new Size(252, 20);
            label4.TabIndex = 9;
            label4.Text = "Admins Have All Permissions";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Mono", 9F);
            label5.ForeColor = SystemColors.Highlight;
            label5.Location = new Point(446, 421);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 10;
            label5.Text = "Note:";
            // 
            // btnAddNewRole
            // 
            btnAddNewRole.BorderRadius = 5;
            btnAddNewRole.Cursor = Cursors.Hand;
            btnAddNewRole.CustomizableEdges = customizableEdges1;
            btnAddNewRole.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewRole.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewRole.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewRole.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewRole.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewRole.ForeColor = Color.White;
            btnAddNewRole.Location = new Point(446, 553);
            btnAddNewRole.Name = "btnAddNewRole";
            btnAddNewRole.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddNewRole.Size = new Size(170, 56);
            btnAddNewRole.TabIndex = 11;
            btnAddNewRole.Text = "Add New Role";
            btnAddNewRole.Click += btnAddNewRole_Click;
            // 
            // frmRolesAndPermissions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 641);
            Controls.Add(btnAddNewRole);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblRoleName);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(chlPermissions);
            Controls.Add(dgvListRoles);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRolesAndPermissions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRolesAndPermissions";
            Load += frmRolesAndPermissions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListRoles;
        private Label label3;
        private CheckedListBox chlPermissions;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Label lblRoleName;
        private Label label5;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Button btnAddNewRole;
    }
}