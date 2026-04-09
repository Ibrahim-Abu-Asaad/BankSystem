namespace BankSystemUI
{
    partial class frmLoginsRegister
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
            label1 = new Label();
            label2 = new Label();
            dgvLoginsRegister = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLoginsRegister).BeginInit();
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
            guna2ControlBox1.Location = new Point(969, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(36, 37);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(252, 20);
            label1.TabIndex = 1;
            label1.Text = "Apex Bank - Logins Register";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(376, 75);
            label2.Name = "label2";
            label2.Size = new Size(280, 54);
            label2.TabIndex = 2;
            label2.Text = "Logins Register";
            label2.Click += label2_Click;
            // 
            // dgvLoginsRegister
            // 
            dgvLoginsRegister.AllowUserToAddRows = false;
            dgvLoginsRegister.AllowUserToDeleteRows = false;
            dgvLoginsRegister.AllowUserToOrderColumns = true;
            dgvLoginsRegister.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvLoginsRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLoginsRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLoginsRegister.ColumnHeadersHeight = 30;
            dgvLoginsRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLoginsRegister.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLoginsRegister.GridColor = Color.FromArgb(231, 229, 255);
            dgvLoginsRegister.Location = new Point(12, 175);
            dgvLoginsRegister.Name = "dgvLoginsRegister";
            dgvLoginsRegister.ReadOnly = true;
            dgvLoginsRegister.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLoginsRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLoginsRegister.RowHeadersVisible = false;
            dgvLoginsRegister.RowHeadersWidth = 51;
            dgvLoginsRegister.Size = new Size(993, 299);
            dgvLoginsRegister.TabIndex = 3;
            dgvLoginsRegister.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvLoginsRegister.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLoginsRegister.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            dgvLoginsRegister.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvLoginsRegister.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvLoginsRegister.ThemeStyle.BackColor = Color.White;
            dgvLoginsRegister.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvLoginsRegister.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvLoginsRegister.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLoginsRegister.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvLoginsRegister.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvLoginsRegister.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLoginsRegister.ThemeStyle.HeaderStyle.Height = 30;
            dgvLoginsRegister.ThemeStyle.ReadOnly = true;
            dgvLoginsRegister.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvLoginsRegister.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLoginsRegister.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLoginsRegister.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvLoginsRegister.ThemeStyle.RowsStyle.Height = 29;
            dgvLoginsRegister.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvLoginsRegister.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvLoginsRegister.CellContentClick += dgvLoginsRegister_CellContentClick;
            // 
            // frmLoginsRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 494);
            Controls.Add(dgvLoginsRegister);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLoginsRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoginsRegister";
            Load += frmLoginsRegister_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLoginsRegister).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLoginsRegister;
    }
}