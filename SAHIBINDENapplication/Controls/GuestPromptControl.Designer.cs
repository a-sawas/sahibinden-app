namespace SAHIBINDENapplication.Controls
{
    partial class GuestPromptControl
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
            pnlOverlay = new Panel();
            pnlCard = new Panel();
            btnContinue = new Button();
            btnRegister = new Button();
            btnLogin = new Button();
            lblMessage = new Label();
            pnlCardTop = new Panel();
            lblTitle = new Label();
            lblIcon = new Label();
            pnlOverlay.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlCardTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOverlay
            // 
            pnlOverlay.Controls.Add(pnlCard);
            pnlOverlay.Dock = DockStyle.Fill;
            pnlOverlay.Location = new Point(0, 0);
            pnlOverlay.Name = "pnlOverlay";
            pnlOverlay.Size = new Size(1150, 700);
            pnlOverlay.TabIndex = 0;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(btnContinue);
            pnlCard.Controls.Add(btnRegister);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(lblMessage);
            pnlCard.Controls.Add(pnlCardTop);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(420, 280);
            pnlCard.TabIndex = 0;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.Gainsboro;
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.ForeColor = Color.FromArgb(150, 150, 150);
            btnContinue.Location = new Point(30, 237);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(360, 35);
            btnContinue.TabIndex = 5;
            btnContinue.Text = "Continue Browsing as Guest";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(26, 26, 46);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(30, 196);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(360, 35);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Create Free Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 96, 0);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 155);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login to My Account";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 10F);
            lblMessage.ForeColor = Color.FromArgb(80, 80, 80);
            lblMessage.Location = new Point(20, 95);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(380, 50);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardTop
            // 
            pnlCardTop.BackColor = Color.FromArgb(26, 26, 46);
            pnlCardTop.Controls.Add(lblTitle);
            pnlCardTop.Controls.Add(lblIcon);
            pnlCardTop.Dock = DockStyle.Top;
            pnlCardTop.Location = new Point(0, 0);
            pnlCardTop.Name = "pnlCardTop";
            pnlCardTop.Size = new Size(420, 80);
            pnlCardTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(75, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 28);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Members Only";
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI", 22F);
            lblIcon.ForeColor = Color.FromArgb(255, 96, 0);
            lblIcon.Location = new Point(20, 18);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(59, 41);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "🔒";
            // 
            // GuestPromptControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(pnlOverlay);
            Name = "GuestPromptControl";
            Size = new Size(1150, 700);
            Load += GuestPromptControl_Load;
            VisibleChanged += GuestPromptControl_VisibleChanged;
            pnlOverlay.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCardTop.ResumeLayout(false);
            pnlCardTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlOverlay;
        private Panel pnlCard;
        private Label lblMessage;
        private Panel pnlCardTop;
        private Label lblTitle;
        private Label lblIcon;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnContinue;
    }
}
