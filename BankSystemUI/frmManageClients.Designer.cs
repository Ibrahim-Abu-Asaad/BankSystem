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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvListClients = new Guna.UI2.WinForms.Guna2DataGridView();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges1;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1158, 7);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            guna2HtmlLabel2.Size = new Size(192, 22);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Apex - Manage Clients";
            // 
            // dgvListClients
            // 
            dgvListClients.AllowUserToAddRows = false;
            dgvListClients.AllowUserToDeleteRows = false;
            dgvListClients.AllowUserToOrderColumns = true;
            dgvListClients.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvListClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvListClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvListClients.ColumnHeadersHeight = 40;
            dgvListClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvListClients.DefaultCellStyle = dataGridViewCellStyle3;
            dgvListClients.GridColor = Color.FromArgb(231, 229, 255);
            dgvListClients.Location = new Point(172, 209);
            dgvListClients.Name = "dgvListClients";
            dgvListClients.ReadOnly = true;
            dgvListClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvListClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvListClients.RowHeadersVisible = false;
            dgvListClients.RowHeadersWidth = 51;
            dgvListClients.Size = new Size(844, 423);
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
            // frmManageClients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 827);
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
    }
}