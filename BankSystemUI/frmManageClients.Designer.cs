namespace BankSystemUI
{
    partial class frmManageClients
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvListClients = new Guna.UI2.WinForms.Guna2DataGridView();
            txtSearchBy = new Guna.UI2.WinForms.Guna2TextBox();
            cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            btnAddNewClients = new Guna.UI2.WinForms.Guna2Button();
            lblTotalClients = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListClients).BeginInit();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges15;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1158, 7);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            guna2ControlBox1.Click += guna2ControlBox1_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.Highlight;
            guna2HtmlLabel1.Location = new Point(470, 46);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(270, 56);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Manage Clients";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel2.Location = new Point(2, 6);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(237, 22);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Apex Bank - Manage Clients";
            // 
            // dgvListClients
            // 
            dgvListClients.AllowUserToAddRows = false;
            dgvListClients.AllowUserToDeleteRows = false;
            dgvListClients.AllowUserToOrderColumns = true;
            dgvListClients.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvListClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvListClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvListClients.ColumnHeadersHeight = 40;
            dgvListClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvListClients.DefaultCellStyle = dataGridViewCellStyle7;
            dgvListClients.GridColor = Color.FromArgb(231, 229, 255);
            dgvListClients.Location = new Point(82, 266);
            dgvListClients.Name = "dgvListClients";
            dgvListClients.ReadOnly = true;
            dgvListClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvListClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvListClients.RowHeadersVisible = false;
            dgvListClients.RowHeadersWidth = 51;
            dgvListClients.Size = new Size(1039, 503);
            dgvListClients.TabIndex = 3;
            dgvListClients.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvListClients.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvListClients.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvListClients.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvListClients.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvListClients.ThemeStyle.BackColor = Color.White;
            dgvListClients.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvListClients.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvListClients.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvListClients.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvListClients.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvListClients.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvListClients.ThemeStyle.HeaderStyle.Height = 40;
            dgvListClients.ThemeStyle.ReadOnly = true;
            dgvListClients.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvListClients.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListClients.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvListClients.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvListClients.ThemeStyle.RowsStyle.Height = 29;
            dgvListClients.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvListClients.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // txtSearchBy
            // 
            txtSearchBy.BorderRadius = 4;
            txtSearchBy.Cursor = Cursors.Hand;
            txtSearchBy.CustomizableEdges = customizableEdges13;
            txtSearchBy.DefaultText = "";
            txtSearchBy.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchBy.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchBy.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBy.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchBy.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBy.Font = new Font("Cascadia Mono", 7.8F);
            txtSearchBy.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchBy.Location = new Point(82, 206);
            txtSearchBy.Margin = new Padding(3, 4, 3, 4);
            txtSearchBy.Name = "txtSearchBy";
            txtSearchBy.PlaceholderText = "";
            txtSearchBy.SelectedText = "";
            txtSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtSearchBy.Size = new Size(180, 36);
            txtSearchBy.TabIndex = 4;
            // 
            // cbSearchBy
            // 
            cbSearchBy.BackColor = Color.Transparent;
            cbSearchBy.BorderRadius = 4;
            cbSearchBy.Cursor = Cursors.Hand;
            cbSearchBy.CustomizableEdges = customizableEdges11;
            cbSearchBy.DrawMode = DrawMode.OwnerDrawFixed;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FocusedColor = Color.FromArgb(94, 148, 255);
            cbSearchBy.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbSearchBy.Font = new Font("Cascadia Mono", 7.8F);
            cbSearchBy.ForeColor = Color.FromArgb(68, 88, 112);
            cbSearchBy.ItemHeight = 30;
            cbSearchBy.Location = new Point(268, 206);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cbSearchBy.Size = new Size(124, 36);
            cbSearchBy.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(470, 206);
            label1.Name = "label1";
            label1.Size = new Size(182, 30);
            label1.TabIndex = 6;
            label1.Text = "Total Clients";
            // 
            // btnAddNewClients
            // 
            btnAddNewClients.BorderRadius = 5;
            btnAddNewClients.Cursor = Cursors.Hand;
            btnAddNewClients.CustomizableEdges = customizableEdges9;
            btnAddNewClients.DisabledState.BorderColor = Color.DarkGray;
            btnAddNewClients.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNewClients.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNewClients.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNewClients.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewClients.ForeColor = Color.White;
            btnAddNewClients.Location = new Point(957, 186);
            btnAddNewClients.Name = "btnAddNewClients";
            btnAddNewClients.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAddNewClients.Size = new Size(164, 56);
            btnAddNewClients.TabIndex = 7;
            btnAddNewClients.Text = "Add New Client";
            // 
            // lblTotalClients
            // 
            lblTotalClients.AutoSize = true;
            lblTotalClients.Font = new Font("Cascadia Mono", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalClients.ForeColor = SystemColors.Highlight;
            lblTotalClients.Location = new Point(670, 206);
            lblTotalClients.Name = "lblTotalClients";
            lblTotalClients.Size = new Size(39, 30);
            lblTotalClients.TabIndex = 8;
            lblTotalClients.Text = "47";
            // 
            // frmManageClients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 827);
            Controls.Add(lblTotalClients);
            Controls.Add(btnAddNewClients);
            Controls.Add(label1);
            Controls.Add(cbSearchBy);
            Controls.Add(txtSearchBy);
            Controls.Add(dgvListClients);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmManageClients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmManageClients";
            Load += frmManageClients_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListClients;
        private Guna.UI2.WinForms.Guna2Button btnAddNewClients;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBy;
        private Label lblTotalClients;
    }
}