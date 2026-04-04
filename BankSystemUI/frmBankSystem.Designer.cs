//using BankSystemUI.UI_Components;

namespace BankSystemUI
{
    partial class frmBankSystem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            lblLogedIn = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            lblClock = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnManageClients = new Guna.UI2.WinForms.Guna2Button();
            btnTransactions = new Guna.UI2.WinForms.Guna2Button();
            btnManageUsers = new Guna.UI2.WinForms.Guna2Button();
            btnCurrenciesSettings = new Guna.UI2.WinForms.Guna2Button();
            btnLoginsRegister = new Guna.UI2.WinForms.Guna2Button();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            btnMyProfile = new Guna.UI2.WinForms.Guna2Button();
            lblMainInterface = new Label();
            btnRoundedRole = new Guna.UI2.WinForms.Guna2Button();
            btnRolesAndPermissions = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(307, 40);
            label1.Name = "label1";
            label1.Size = new Size(362, 71);
            label1.TabIndex = 0;
            label1.Text = "Apex Bank";
            // 
            // lblLogedIn
            // 
            lblLogedIn.AutoSize = true;
            lblLogedIn.Font = new Font("Cascadia Mono", 12F);
            lblLogedIn.Location = new Point(51, 138);
            lblLogedIn.Name = "lblLogedIn";
            lblLogedIn.Size = new Size(96, 27);
            lblLogedIn.TabIndex = 1;
            lblLogedIn.Text = "Welcome";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClock.Location = new Point(723, 143);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(60, 22);
            lblClock.TabIndex = 5;
            lblClock.Text = "Clock";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // btnManageClients
            // 
            btnManageClients.BorderRadius = 10;
            btnManageClients.Cursor = Cursors.Hand;
            btnManageClients.CustomizableEdges = customizableEdges17;
            btnManageClients.DisabledState.BorderColor = Color.DarkGray;
            btnManageClients.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageClients.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageClients.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageClients.Font = new Font("Cascadia Mono", 10.2F);
            btnManageClients.ForeColor = Color.White;
            btnManageClients.Location = new Point(375, 223);
            btnManageClients.Name = "btnManageClients";
            btnManageClients.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnManageClients.Size = new Size(240, 56);
            btnManageClients.TabIndex = 6;
            btnManageClients.Text = "Manage Clients";
            btnManageClients.Click += btnManageClients_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.BorderRadius = 10;
            btnTransactions.Cursor = Cursors.Hand;
            btnTransactions.CustomizableEdges = customizableEdges15;
            btnTransactions.DisabledState.BorderColor = Color.DarkGray;
            btnTransactions.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTransactions.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTransactions.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTransactions.Font = new Font("Cascadia Mono", 10.2F);
            btnTransactions.ForeColor = Color.White;
            btnTransactions.Location = new Point(375, 301);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnTransactions.Size = new Size(240, 56);
            btnTransactions.TabIndex = 7;
            btnTransactions.Text = "Transactions";
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BorderRadius = 10;
            btnManageUsers.Cursor = Cursors.Hand;
            btnManageUsers.CustomizableEdges = customizableEdges13;
            btnManageUsers.DisabledState.BorderColor = Color.DarkGray;
            btnManageUsers.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageUsers.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageUsers.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageUsers.Font = new Font("Cascadia Mono", 10.2F);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Location = new Point(375, 379);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnManageUsers.Size = new Size(240, 56);
            btnManageUsers.TabIndex = 8;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnCurrenciesSettings
            // 
            btnCurrenciesSettings.BorderRadius = 10;
            btnCurrenciesSettings.Cursor = Cursors.Hand;
            btnCurrenciesSettings.CustomizableEdges = customizableEdges11;
            btnCurrenciesSettings.DisabledState.BorderColor = Color.DarkGray;
            btnCurrenciesSettings.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCurrenciesSettings.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCurrenciesSettings.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCurrenciesSettings.Font = new Font("Cascadia Mono", 10.2F);
            btnCurrenciesSettings.ForeColor = Color.White;
            btnCurrenciesSettings.Location = new Point(375, 457);
            btnCurrenciesSettings.Name = "btnCurrenciesSettings";
            btnCurrenciesSettings.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnCurrenciesSettings.Size = new Size(240, 56);
            btnCurrenciesSettings.TabIndex = 9;
            btnCurrenciesSettings.Text = "Currency Settings";
            btnCurrenciesSettings.Click += btnCurrenciesSettings_Click;
            // 
            // btnLoginsRegister
            // 
            btnLoginsRegister.BorderRadius = 10;
            btnLoginsRegister.Cursor = Cursors.Hand;
            btnLoginsRegister.CustomizableEdges = customizableEdges9;
            btnLoginsRegister.DisabledState.BorderColor = Color.DarkGray;
            btnLoginsRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoginsRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoginsRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoginsRegister.Font = new Font("Cascadia Mono", 10.2F);
            btnLoginsRegister.ForeColor = Color.White;
            btnLoginsRegister.Location = new Point(375, 535);
            btnLoginsRegister.Name = "btnLoginsRegister";
            btnLoginsRegister.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLoginsRegister.Size = new Size(240, 56);
            btnLoginsRegister.TabIndex = 10;
            btnLoginsRegister.Text = "Logins Register";
            btnLoginsRegister.Click += btnLoginsRegister_Click;
            // 
            // btnLogout
            // 
            btnLogout.BorderRadius = 10;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.CustomizableEdges = customizableEdges7;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.Tomato;
            btnLogout.Font = new Font("Cascadia Mono", 10.2F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(51, 788);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLogout.Size = new Size(149, 56);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnExit_Click;
            // 
            // btnMyProfile
            // 
            btnMyProfile.BorderRadius = 10;
            btnMyProfile.Cursor = Cursors.Hand;
            btnMyProfile.CustomizableEdges = customizableEdges5;
            btnMyProfile.DisabledState.BorderColor = Color.DarkGray;
            btnMyProfile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMyProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMyProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMyProfile.Font = new Font("Cascadia Mono", 10.2F);
            btnMyProfile.ForeColor = Color.White;
            btnMyProfile.Location = new Point(375, 691);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnMyProfile.Size = new Size(240, 56);
            btnMyProfile.TabIndex = 12;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.Click += btnMyProfile_Click;
            // 
            // lblMainInterface
            // 
            lblMainInterface.AutoSize = true;
            lblMainInterface.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMainInterface.Location = new Point(3, 3);
            lblMainInterface.Name = "lblMainInterface";
            lblMainInterface.Size = new Size(153, 20);
            lblMainInterface.TabIndex = 13;
            lblMainInterface.Text = "Apex Bank - Home";
            // 
            // btnRoundedRole
            // 
            btnRoundedRole.BackColor = SystemColors.Control;
            btnRoundedRole.BorderRadius = 25;
            btnRoundedRole.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnRoundedRole.CustomizableEdges = customizableEdges3;
            btnRoundedRole.DisabledState.BorderColor = Color.DarkGray;
            btnRoundedRole.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRoundedRole.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRoundedRole.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRoundedRole.FillColor = SystemColors.GradientActiveCaption;
            btnRoundedRole.FocusedColor = SystemColors.Control;
            btnRoundedRole.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRoundedRole.ForeColor = SystemColors.Highlight;
            btnRoundedRole.HoverState.BorderColor = SystemColors.GradientActiveCaption;
            btnRoundedRole.HoverState.CustomBorderColor = SystemColors.GradientActiveCaption;
            btnRoundedRole.HoverState.FillColor = SystemColors.GradientActiveCaption;
            btnRoundedRole.HoverState.ForeColor = SystemColors.Highlight;
            btnRoundedRole.Location = new Point(51, 168);
            btnRoundedRole.Name = "btnRoundedRole";
            btnRoundedRole.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRoundedRole.Size = new Size(189, 53);
            btnRoundedRole.TabIndex = 15;
            btnRoundedRole.Text = "Role";
            btnRoundedRole.Click += btnRoundedRole_Click;
            // 
            // btnRolesAndPermissions
            // 
            btnRolesAndPermissions.BorderRadius = 10;
            btnRolesAndPermissions.Cursor = Cursors.Hand;
            btnRolesAndPermissions.CustomizableEdges = customizableEdges1;
            btnRolesAndPermissions.DisabledState.BorderColor = Color.DarkGray;
            btnRolesAndPermissions.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRolesAndPermissions.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRolesAndPermissions.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRolesAndPermissions.Font = new Font("Cascadia Mono", 10.2F);
            btnRolesAndPermissions.ForeColor = Color.White;
            btnRolesAndPermissions.Location = new Point(375, 613);
            btnRolesAndPermissions.Name = "btnRolesAndPermissions";
            btnRolesAndPermissions.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRolesAndPermissions.Size = new Size(240, 56);
            btnRolesAndPermissions.TabIndex = 16;
            btnRolesAndPermissions.Text = "Roles And Permissions";
            btnRolesAndPermissions.Click += btnRolesAndPermissions_Click;
            // 
            // frmBankSystem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 894);
            Controls.Add(btnRolesAndPermissions);
            Controls.Add(btnRoundedRole);
            Controls.Add(lblMainInterface);
            Controls.Add(btnMyProfile);
            Controls.Add(btnLogout);
            Controls.Add(btnLoginsRegister);
            Controls.Add(btnCurrenciesSettings);
            Controls.Add(btnManageUsers);
            Controls.Add(btnTransactions);
            Controls.Add(btnManageClients);
            Controls.Add(lblClock);
            Controls.Add(lblLogedIn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmBankSystem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bank System";
            Load += frmBankSystem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblLogedIn;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        //private clsRoundedLabel lblRole;
        private Label lblClock;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnLoginsRegister;
        private Guna.UI2.WinForms.Guna2Button btnCurrenciesSettings;
        private Guna.UI2.WinForms.Guna2Button btnManageUsers;
        private Guna.UI2.WinForms.Guna2Button btnTransactions;
        private Guna.UI2.WinForms.Guna2Button btnManageClients;
        private Guna.UI2.WinForms.Guna2Button btnMyProfile;
        private Label lblMainInterface;
        private Guna.UI2.WinForms.Guna2Button btnRoundedRole;
        private Guna.UI2.WinForms.Guna2Button btnRolesAndPermissions;
    }
}