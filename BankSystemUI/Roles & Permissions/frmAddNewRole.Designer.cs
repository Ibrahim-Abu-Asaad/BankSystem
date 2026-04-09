namespace BankSystemUI
{
    partial class frmAddNewRole
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new Label();
            label2 = new Label();
            chlPermissions = new CheckedListBox();
            txtRoleName = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
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
            guna2ControlBox1.Location = new Point(751, 12);
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
            label1.Location = new Point(296, 61);
            label1.Name = "label1";
            label1.Size = new Size(265, 54);
            label1.TabIndex = 1;
            label1.Text = "Add New Role";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(250, 22);
            label2.TabIndex = 2;
            label2.Text = "Apex Bank - Add New Role";
            // 
            // chlPermissions
            // 
            chlPermissions.FormattingEnabled = true;
            chlPermissions.Location = new Point(115, 170);
            chlPermissions.Name = "chlPermissions";
            chlPermissions.Size = new Size(214, 202);
            chlPermissions.TabIndex = 3;
            // 
            // txtRoleName
            // 
            txtRoleName.BorderRadius = 4;
            txtRoleName.CustomizableEdges = customizableEdges3;
            txtRoleName.DefaultText = "";
            txtRoleName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRoleName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRoleName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRoleName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRoleName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoleName.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoleName.ForeColor = Color.Black;
            txtRoleName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoleName.Location = new Point(410, 170);
            txtRoleName.Margin = new Padding(3, 4, 3, 4);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.PlaceholderText = "Role Name";
            txtRoleName.SelectedText = "";
            txtRoleName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtRoleName.Size = new Size(231, 36);
            txtRoleName.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 5;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(520, 315);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(121, 57);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // frmAddNewRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(txtRoleName);
            Controls.Add(chlPermissions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAddNewRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddNewRole";
            Load += frmAddNewRole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtRoleName;
        private CheckedListBox chlPermissions;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
    }
}