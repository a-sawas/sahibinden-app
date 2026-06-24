namespace SAHIBINDENapplication.Controls
{
    partial class RegisterControl
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
            btnBack = new Button();
            btnRegister = new Button();
            lblStatus = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPhone = new TextBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            cmbCity = new ComboBox();
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
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 10F);
            lblTagline.ForeColor = Color.FromArgb(180, 180, 200);
            lblTagline.Location = new Point(50, 233);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(212, 19);
            lblTagline.TabIndex = 1;
            lblTagline.Text = "Join millions of buyers and sellers";
            lblTagline.Click += lblTagline_Click;
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
            pnlRight.Controls.Add(btnBack);
            pnlRight.Controls.Add(btnRegister);
            pnlRight.Controls.Add(lblStatus);
            pnlRight.Controls.Add(txtFullName);
            pnlRight.Controls.Add(txtEmail);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(txtPhone);
            pnlRight.Controls.Add(txtConfirmPassword);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(cmbCity);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(319, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(831, 700);
            pnlRight.TabIndex = 2;
            pnlRight.Paint += pnlRight_Paint;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.FromArgb(255, 96, 0);
            btnBack.Location = new Point(262, 317);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(203, 43);
            btnBack.TabIndex = 10;
            btnBack.Text = "← Back to Login";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 96, 0);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(17, 317);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(203, 43);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Create Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(17, 256);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(320, 28);
            lblStatus.TabIndex = 8;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(17, 89);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Full Name *";
            txtFullName.Size = new Size(203, 25);
            txtFullName.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(17, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email Address *";
            txtEmail.Size = new Size(203, 25);
            txtEmail.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(262, 89);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username *";
            txtUsername.Size = new Size(203, 25);
            txtUsername.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(262, 147);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(203, 25);
            txtPhone.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(351, 207);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.PlaceholderText = "Confirm Password *";
            txtConfirmPassword.Size = new Size(203, 25);
            txtConfirmPassword.TabIndex = 3;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            txtConfirmPassword.KeyDown += txtConfirmPassword_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(17, 207);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = " Password * (min 8 chars, letters + numbers)";
            txtPassword.Size = new Size(286, 25);
            txtPassword.TabIndex = 2;
            // 
            // cmbCity
            // 
            cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCity.Font = new Font("Segoe UI", 10F);
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(487, 89);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(170, 25);
            cmbCity.TabIndex = 1;
            cmbCity.SelectedIndexChanged += cmbCity_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblTitle.Location = new Point(262, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(213, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "RegisterControl";
            Size = new Size(1150, 700);
            Load += RegisterControl_Load;
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
        private Button btnBack;
        private Button btnRegister;
        private Label lblStatus;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPhone;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private ComboBox cmbCity;
    }
}
