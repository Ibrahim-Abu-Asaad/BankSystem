namespace BankSystemUI
{
    partial class frmAddEditUsers
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
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            lblCornerNameAddEditUser = new Label();
            lblTitleAddEditUser = new Label();
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
            guna2ControlBox1.Location = new Point(927, 12);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox1.Size = new Size(37, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // lblCornerNameAddEditUser
            // 
            lblCornerNameAddEditUser.AutoSize = true;
            lblCornerNameAddEditUser.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCornerNameAddEditUser.Location = new Point(12, 9);
            lblCornerNameAddEditUser.Name = "lblCornerNameAddEditUser";
            lblCornerNameAddEditUser.Size = new Size(198, 20);
            lblCornerNameAddEditUser.TabIndex = 1;
            lblCornerNameAddEditUser.Text = "Apex Bank - Add Users";
            // 
            // lblTitleAddEditUser
            // 
            lblTitleAddEditUser.AutoSize = true;
            lblTitleAddEditUser.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitleAddEditUser.ForeColor = SystemColors.Highlight;
            lblTitleAddEditUser.Location = new Point(332, 98);
            lblTitleAddEditUser.Name = "lblTitleAddEditUser";
            lblTitleAddEditUser.Size = new Size(269, 54);
            lblTitleAddEditUser.TabIndex = 2;
            lblTitleAddEditUser.Text = "Add New User";
            lblTitleAddEditUser.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmAddEditUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 739);
            Controls.Add(lblTitleAddEditUser);
            Controls.Add(lblCornerNameAddEditUser);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAddEditUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddEditUsers";
            Load += frmAddEditUsers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label lblTitleAddEditUser;
        private Label lblCornerNameAddEditUser;
    }
}