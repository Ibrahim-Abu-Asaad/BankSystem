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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            label2 = new Label();
            dgvListRoles = new Guna.UI2.WinForms.Guna2DataGridView();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges3;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1114, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(411, 84);
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
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvListRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvListRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvListRoles.ColumnHeadersHeight = 30;
            dgvListRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvListRoles.DefaultCellStyle = dataGridViewCellStyle6;
            dgvListRoles.GridColor = Color.FromArgb(231, 229, 255);
            dgvListRoles.Location = new Point(79, 212);
            dgvListRoles.Name = "dgvListRoles";
            dgvListRoles.ReadOnly = true;
            dgvListRoles.RowHeadersVisible = false;
            dgvListRoles.RowHeadersWidth = 51;
            dgvListRoles.Size = new Size(483, 257);
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
            // 
            // frmRolesAndPermissions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 716);
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
    }
}