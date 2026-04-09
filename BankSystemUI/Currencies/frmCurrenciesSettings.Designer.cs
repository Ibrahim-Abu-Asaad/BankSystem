namespace BankSystemUI
{
    partial class frmCurrenciesSettings
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
            dgvCurrencies = new Guna.UI2.WinForms.Guna2DataGridView();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCurrencies).BeginInit();
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
            guna2ControlBox1.Location = new Point(948, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(288, 20);
            label1.TabIndex = 1;
            label1.Text = "Apex Bank - Currencies Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(386, 51);
            label2.Name = "label2";
            label2.Size = new Size(290, 54);
            label2.TabIndex = 2;
            label2.Text = "Currencies Rate";
            // 
            // dgvCurrencies
            // 
            dgvCurrencies.AllowUserToAddRows = false;
            dgvCurrencies.AllowUserToDeleteRows = false;
            dgvCurrencies.AllowUserToOrderColumns = true;
            dgvCurrencies.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvCurrencies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCurrencies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCurrencies.ColumnHeadersHeight = 40;
            dgvCurrencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCurrencies.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCurrencies.GridColor = Color.FromArgb(231, 229, 255);
            dgvCurrencies.Location = new Point(12, 179);
            dgvCurrencies.Name = "dgvCurrencies";
            dgvCurrencies.ReadOnly = true;
            dgvCurrencies.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCurrencies.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCurrencies.RowHeadersVisible = false;
            dgvCurrencies.RowHeadersWidth = 51;
            dgvCurrencies.Size = new Size(971, 415);
            dgvCurrencies.TabIndex = 4;
            dgvCurrencies.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvCurrencies.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCurrencies.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvCurrencies.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCurrencies.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCurrencies.ThemeStyle.BackColor = Color.White;
            dgvCurrencies.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvCurrencies.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvCurrencies.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCurrencies.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvCurrencies.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvCurrencies.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCurrencies.ThemeStyle.HeaderStyle.Height = 40;
            dgvCurrencies.ThemeStyle.ReadOnly = true;
            dgvCurrencies.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvCurrencies.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCurrencies.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvCurrencies.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvCurrencies.ThemeStyle.RowsStyle.Height = 29;
            dgvCurrencies.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvCurrencies.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(140, 22);
            label3.TabIndex = 5;
            label3.Text = "Currency: USD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(179, 145);
            label4.Name = "label4";
            label4.Size = new Size(150, 22);
            label4.TabIndex = 6;
            label4.Text = "Date: 9/4/2026";
            // 
            // frmCurrenciesSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 606);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvCurrencies);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCurrenciesSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCurrenciesSettings";
            Load += frmCurrenciesSettings_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCurrencies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCurrencies;
        private Label label4;
        private Label label3;
    }
}