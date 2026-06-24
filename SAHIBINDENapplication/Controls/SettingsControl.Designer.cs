namespace SAHIBINDENapplication.Controls
{
    partial class SettingsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            btnBack = new Button();
            pnlBody = new Panel();
            pnlNav = new Panel();
            pnlContent = new Panel();

            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 60);
            pnlHeader.TabIndex = 0;

            // lblHeader
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(413, 13);
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "⚙ Settings";

            // btnBack
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(870, 17);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 30);
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;

            // pnlBody
            pnlBody.Controls.Add(pnlContent);
            pnlBody.Controls.Add(pnlNav);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = Color.FromArgb(245, 245, 248);
            pnlBody.Name = "pnlBody";

            // pnlNav — left sidebar
            pnlNav.BackColor = Color.FromArgb(30, 30, 50);
            pnlNav.Dock = DockStyle.Left;
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(220, 640);

            // pnlContent — right section area
            pnlContent.BackColor = Color.FromArgb(245, 245, 248);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(40, 30, 40, 30);

            // SettingsControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Name = "SettingsControl";
            Size = new Size(1150, 700);
            Load += SettingsControl_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblHeader;
        private Button btnBack;
        private Panel pnlBody;
        private Panel pnlNav;
        private Panel pnlContent;
    }
}