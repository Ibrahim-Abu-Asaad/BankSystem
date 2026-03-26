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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            label2 = new Label();
            dgvListUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            lblInfo = new Label();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges3;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1003, 6);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox1.Size = new Size(36, 37);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(353, 42);
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
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvListUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvListUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvListUsers.ColumnHeadersHeight = 4;
            dgvListUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvListUsers.DefaultCellStyle = dataGridViewCellStyle6;
            dgvListUsers.GridColor = Color.FromArgb(231, 229, 255);
            dgvListUsers.Location = new Point(24, 146);
            dgvListUsers.Name = "dgvListUsers";
            dgvListUsers.ReadOnly = true;
            dgvListUsers.RowHeadersVisible = false;
            dgvListUsers.RowHeadersWidth = 51;
            dgvListUsers.Size = new Size(685, 423);
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
            dgvListUsers.ThemeStyle.HeaderStyle.Height = 4;
            dgvListUsers.ThemeStyle.ReadOnly = true;
            dgvListUsers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvListUsers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListUsers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvListUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvListUsers.ThemeStyle.RowsStyle.Height = 29;
            dgvListUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvListUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(737, 185);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(35, 20);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "info";
            // 
            // frmManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 594);
            Controls.Add(lblInfo);
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
        private Label lblInfo;
    }
}