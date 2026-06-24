namespace SAHIBINDENapplication.Controls
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblTagline = new Label();
            lblBrand = new Label();
            pnlRight = new Panel();
            btnBackToListings = new Button();
            chkShowPassword = new CheckBox();
            lblStatus = new Label();
            btnLogin = new Button();
            btnGoRegister = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblTitle = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(26, 26, 46);
            pnlLeft.Controls.Add(lblTagline);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(319, 700);
            pnlLeft.TabIndex = 0;
            pnlLeft.Paint += pnlLeft_Paint;
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 10F);
            lblTagline.ForeColor = Color.FromArgb(180, 180, 200);
            lblTagline.Location = new Point(61, 233);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(206, 19);
            lblTagline.TabIndex = 1;
            lblTagline.Text = "Buy and sell anything, anywhere";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 29F, FontStyle.Bold);
            lblBrand.ForeColor = Color.Yellow;
            lblBrand.Location = new Point(20, 171);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(293, 52);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "🏪 Sahibinden";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(247, 247, 247);
            pnlRight.Controls.Add(btnBackToListings);
            pnlRight.Controls.Add(chkShowPassword);
            pnlRight.Controls.Add(lblStatus);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(btnGoRegister);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(319, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(831, 700);
            pnlRight.TabIndex = 2;
            // 
            // btnBackToListings
            // 
            btnBackToListings.BackColor = Color.LightGray;
            btnBackToListings.Cursor = Cursors.Hand;
            btnBackToListings.FlatAppearance.BorderSize = 0;
            btnBackToListings.FlatStyle = FlatStyle.Flat;
            btnBackToListings.ForeColor = Color.FromArgb(150, 150, 150);
            btnBackToListings.Location = new Point(206, 433);
            btnBackToListings.Name = "btnBackToListings";
            btnBackToListings.Size = new Size(340, 42);
            btnBackToListings.TabIndex = 3;
            btnBackToListings.Text = "← Back to Listings";
            btnBackToListings.UseVisualStyleBackColor = false;
            btnBackToListings.VisibleChanged += btnBackToListings_VisibleChanged;
            btnBackToListings.Click += btnBackToListings_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.FlatStyle = FlatStyle.Flat;
            chkShowPassword.ForeColor = SystemColors.WindowFrame;
            chkShowPassword.Location = new Point(206, 204);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(105, 19);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(206, 261);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(340, 28);
            lblStatus.TabIndex = 5;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Click += lblStatus_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 96, 0);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(206, 309);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(340, 42);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnGoRegister
            // 
            btnGoRegister.Cursor = Cursors.Hand;
            btnGoRegister.FlatStyle = FlatStyle.Flat;
            btnGoRegister.Font = new Font("Segoe UI", 10F);
            btnGoRegister.ForeColor = Color.FromArgb(255, 96, 0);
            btnGoRegister.Location = new Point(206, 372);
            btnGoRegister.Name = "btnGoRegister";
            btnGoRegister.Size = new Size(340, 42);
            btnGoRegister.TabIndex = 3;
            btnGoRegister.Text = "Don't have an account? Register";
            btnGoRegister.UseVisualStyleBackColor = true;
            btnGoRegister.Click += btnGoRegister_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(206, 171);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(340, 27);
            txtPassword.TabIndex = 2;
            txtPassword.TabStop = false;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(206, 115);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(340, 27);
            txtUsername.TabIndex = 1;
            txtUsername.TabStop = false;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblTitle.Location = new Point(262, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome Back";
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "LoginControl";
            Size = new Size(1150, 700);
            Load += LoginControl_Load_1;
            VisibleChanged += LoginControl_VisibleChanged;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Label lblBrand;
        private Label lblTagline;
        private Panel pnlRight;
        private Label lblTitle;
        private Label lblStatus;
        private Button btnLogin;
        private Button btnGoRegister;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private CheckBox chkShowPassword;
        private Button btnBackToListings;
    }
}
