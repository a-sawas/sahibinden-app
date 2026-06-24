namespace SAHIBINDENapplication.Controls
{
    partial class FavoritesControl
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
            pnlHeader = new Panel();
            lblCount = new Label();
            lblHeader = new Label();
            btnBack = new Button();
            pnlContent = new Panel();
            flpListings = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(lblCount);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.ForeColor = Color.Gray;
            lblCount.Location = new Point(10, 42);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(38, 15);
            lblCount.TabIndex = 0;
            lblCount.Text = "label1";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(413, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(167, 28);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "❤ My Favorites";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(880, 16);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(247, 247, 247);
            pnlContent.Controls.Add(flpListings);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1150, 640);
            pnlContent.TabIndex = 1;
            // 
            // flpListings
            // 
            flpListings.AutoScroll = true;
            flpListings.BackColor = Color.WhiteSmoke;
            flpListings.Dock = DockStyle.Fill;
            flpListings.Location = new Point(0, 0);
            flpListings.Name = "flpListings";
            flpListings.Size = new Size(1150, 640);
            flpListings.TabIndex = 3;
            // 
            // FavoritesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "FavoritesControl";
            Size = new Size(1150, 700);
            Load += FavoritesControl_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Button btnBack;
        private Panel pnlContent;
        private Label lblCount;
        private FlowLayoutPanel flpListings;
    }
}
