namespace BankSystemUI
{
    partial class frmTransactions
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            lblTitleWithdrawDeposite = new Label();
            menuStrip1 = new MenuStrip();
            withdrawToolStripMenuItem = new ToolStripMenuItem();
            depositeToolStripMenuItem = new ToolStripMenuItem();
            transferToolStripMenuItem = new ToolStripMenuItem();
            cbAccountNO = new Guna.UI2.WinForms.Guna2ComboBox();
            label13 = new Label();
            nudAmmount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            btnWithdrawDeposite = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            lblBalance = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmmount).BeginInit();
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
            guna2ControlBox1.CustomizableEdges = customizableEdges7;
            guna2ControlBox1.FillColor = Color.Tomato;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(899, 35);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            guna2ControlBox1.Click += guna2ControlBox1_Click;
            // 
            // lblTitleWithdrawDeposite
            // 
            lblTitleWithdrawDeposite.AutoSize = true;
            lblTitleWithdrawDeposite.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitleWithdrawDeposite.ForeColor = SystemColors.Highlight;
            lblTitleWithdrawDeposite.Location = new Point(338, 55);
            lblTitleWithdrawDeposite.Name = "lblTitleWithdrawDeposite";
            lblTitleWithdrawDeposite.Size = new Size(239, 54);
            lblTitleWithdrawDeposite.TabIndex = 1;
            lblTitleWithdrawDeposite.Text = "Transactions";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { withdrawToolStripMenuItem, depositeToolStripMenuItem, transferToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(946, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // withdrawToolStripMenuItem
            // 
            withdrawToolStripMenuItem.ImageTransparentColor = SystemColors.Control;
            withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            withdrawToolStripMenuItem.Size = new Size(87, 24);
            withdrawToolStripMenuItem.Text = "Withdraw";
            withdrawToolStripMenuItem.Click += withdrawToolStripMenuItem_Click;
            // 
            // depositeToolStripMenuItem
            // 
            depositeToolStripMenuItem.ImageTransparentColor = SystemColors.Control;
            depositeToolStripMenuItem.Name = "depositeToolStripMenuItem";
            depositeToolStripMenuItem.Size = new Size(83, 24);
            depositeToolStripMenuItem.Text = "Deposite";
            depositeToolStripMenuItem.Click += depositeToolStripMenuItem_Click;
            // 
            // transferToolStripMenuItem
            // 
            transferToolStripMenuItem.ImageTransparentColor = SystemColors.Control;
            transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            transferToolStripMenuItem.Size = new Size(75, 24);
            transferToolStripMenuItem.Text = "Transfer";
            transferToolStripMenuItem.Click += transferToolStripMenuItem_Click;
            // 
            // cbAccountNO
            // 
            cbAccountNO.BackColor = Color.Transparent;
            cbAccountNO.BorderRadius = 4;
            cbAccountNO.Cursor = Cursors.Hand;
            cbAccountNO.CustomizableEdges = customizableEdges5;
            cbAccountNO.DrawMode = DrawMode.OwnerDrawFixed;
            cbAccountNO.DropDownHeight = 240;
            cbAccountNO.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAccountNO.FocusedColor = Color.FromArgb(94, 148, 255);
            cbAccountNO.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbAccountNO.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbAccountNO.ForeColor = SystemColors.ControlText;
            cbAccountNO.IntegralHeight = false;
            cbAccountNO.ItemHeight = 30;
            cbAccountNO.Location = new Point(442, 173);
            cbAccountNO.MaxDropDownItems = 7;
            cbAccountNO.Name = "cbAccountNO";
            cbAccountNO.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbAccountNO.Size = new Size(162, 36);
            cbAccountNO.TabIndex = 20;
            cbAccountNO.SelectedIndexChanged += cbAccountNO_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(288, 180);
            label13.Name = "label13";
            label13.Size = new Size(150, 22);
            label13.TabIndex = 40;
            label13.Text = "Account Number";
            // 
            // nudAmmount
            // 
            nudAmmount.BackColor = Color.Transparent;
            nudAmmount.CustomizableEdges = customizableEdges3;
            nudAmmount.Font = new Font("Segoe UI", 9F);
            nudAmmount.Location = new Point(442, 255);
            nudAmmount.Margin = new Padding(3, 4, 3, 4);
            nudAmmount.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            nudAmmount.Name = "nudAmmount";
            nudAmmount.ShadowDecoration.CustomizableEdges = customizableEdges4;
            nudAmmount.Size = new Size(286, 39);
            nudAmmount.TabIndex = 67;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(737, 264);
            label3.Name = "label3";
            label3.Size = new Size(40, 22);
            label3.TabIndex = 68;
            label3.Text = "USD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(358, 264);
            label4.Name = "label4";
            label4.Size = new Size(80, 22);
            label4.TabIndex = 69;
            label4.Text = "Ammount";
            // 
            // btnWithdrawDeposite
            // 
            btnWithdrawDeposite.BorderRadius = 5;
            btnWithdrawDeposite.Cursor = Cursors.Hand;
            btnWithdrawDeposite.CustomizableEdges = customizableEdges1;
            btnWithdrawDeposite.DisabledState.BorderColor = Color.DarkGray;
            btnWithdrawDeposite.DisabledState.CustomBorderColor = Color.DarkGray;
            btnWithdrawDeposite.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnWithdrawDeposite.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnWithdrawDeposite.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWithdrawDeposite.ForeColor = Color.White;
            btnWithdrawDeposite.Location = new Point(379, 332);
            btnWithdrawDeposite.Name = "btnWithdrawDeposite";
            btnWithdrawDeposite.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnWithdrawDeposite.Size = new Size(159, 56);
            btnWithdrawDeposite.TabIndex = 70;
            btnWithdrawDeposite.Text = "Withdraw";
            btnWithdrawDeposite.Click += btnWithdrawDeposite_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(358, 220);
            label2.Name = "label2";
            label2.Size = new Size(80, 22);
            label2.TabIndex = 71;
            label2.Text = "Balance";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(442, 220);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(50, 22);
            lblBalance.TabIndex = 72;
            lblBalance.Text = "****";
            // 
            // frmTransactions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 435);
            Controls.Add(lblBalance);
            Controls.Add(label2);
            Controls.Add(btnWithdrawDeposite);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nudAmmount);
            Controls.Add(label13);
            Controls.Add(cbAccountNO);
            Controls.Add(lblTitleWithdrawDeposite);
            Controls.Add(guna2ControlBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "frmTransactions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTransactions";
            Load += frmTransactions_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label lblTitleWithdrawDeposite;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem withdrawToolStripMenuItem;
        private ToolStripMenuItem depositeToolStripMenuItem;
        private ToolStripMenuItem transferToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ComboBox cbAccountNO;
        private Label label13;
        private Label label4;
        private Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudAmmount;
        private Guna.UI2.WinForms.Guna2Button btnWithdrawDeposite;
        private Label lblBalance;
        private Label label2;
    }
}