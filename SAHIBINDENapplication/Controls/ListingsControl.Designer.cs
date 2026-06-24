namespace SAHIBINDENapplication.Controls
{
    partial class ListingsControl
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
            pnlSidebar = new Panel();
            btnLoginRegister = new Button();
            btnFavorites = new Button();
            btnLogout = new Button();
            btnMyListings = new Button();
            btnAdmin = new Button();
            btnHome = new Button();
            btnMessages = new Button();
            lblWelcome = new Label();
            lblLogo = new Label();
            pnlFilters = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnAdd = new Button();
            lblCount = new Label();
            btnClear = new Button();
            btnSearch = new Button();
            nudMaxPrice = new NumericUpDown();
            nudMinPrice = new NumericUpDown();
            cmbSort = new ComboBox();
            cmbCategory = new ComboBox();
            txtSearch = new TextBox();
            statusStrip1 = new StatusStrip();
            tsslInfo = new ToolStripStatusLabel();
            pnlContent = new Panel();
            pnlListingsWrapper = new Panel();
            flpListings = new FlowLayoutPanel();

            btnSettings = new Button();

            pnlSidebar.SuspendLayout();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).BeginInit();
            statusStrip1.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlListingsWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(26, 26, 46);
            pnlSidebar.Controls.Add(btnLoginRegister);
            pnlSidebar.Controls.Add(btnFavorites);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnMyListings);
            pnlSidebar.Controls.Add(btnAdmin);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(btnMessages);
            pnlSidebar.Controls.Add(lblWelcome);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 700);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLoginRegister
            // 
            btnLoginRegister.BackColor = Color.FromArgb(26, 26, 46);
            btnLoginRegister.Cursor = Cursors.Hand;
            btnLoginRegister.FlatAppearance.BorderSize = 0;
            btnLoginRegister.FlatStyle = FlatStyle.Flat;
            btnLoginRegister.Font = new Font("Segoe UI", 10F);
            btnLoginRegister.ForeColor = Color.White;
            btnLoginRegister.Location = new Point(0, 356);
            btnLoginRegister.Name = "btnLoginRegister";
            btnLoginRegister.Padding = new Padding(15, 0, 0, 0);
            btnLoginRegister.Size = new Size(200, 44);
            btnLoginRegister.TabIndex = 10;
            btnLoginRegister.Text = "🔑 Login / Register";
            btnLoginRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnLoginRegister.UseVisualStyleBackColor = false;
            btnLoginRegister.Click += btnLoginRegister_Click;




            // btnSettings
            btnSettings.BackColor = Color.FromArgb(26, 26, 46);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 400); // position will be managed by RefreshSessionUI
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(200, 44);
            btnSettings.TabIndex = 11;
            btnSettings.Text = "⚙ Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;







            // 
            // btnFavorites
            // 
            btnFavorites.BackColor = Color.FromArgb(26, 26, 46);
            btnFavorites.Cursor = Cursors.Hand;
            btnFavorites.FlatAppearance.BorderSize = 0;
            btnFavorites.FlatStyle = FlatStyle.Flat;
            btnFavorites.Font = new Font("Segoe UI", 10F);
            btnFavorites.ForeColor = Color.White;
            btnFavorites.Location = new Point(0, 306);
            btnFavorites.Name = "btnFavorites";
            btnFavorites.Padding = new Padding(15, 0, 0, 0);
            btnFavorites.Size = new Size(200, 44);
            btnFavorites.TabIndex = 9;
            btnFavorites.Text = "❤ Favorites";
            btnFavorites.TextAlign = ContentAlignment.MiddleLeft;
            btnFavorites.UseVisualStyleBackColor = false;
            btnFavorites.Click += btnFavorites_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(26, 26, 46);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(0, 356);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(200, 44);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "🚪 Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMyListings
            // 
            btnMyListings.BackColor = Color.FromArgb(26, 26, 46);
            btnMyListings.Cursor = Cursors.Hand;
            btnMyListings.FlatAppearance.BorderSize = 0;
            btnMyListings.FlatStyle = FlatStyle.Flat;
            btnMyListings.Font = new Font("Segoe UI", 10F);
            btnMyListings.ForeColor = Color.White;
            btnMyListings.Location = new Point(0, 206);
            btnMyListings.Name = "btnMyListings";
            btnMyListings.Padding = new Padding(15, 0, 0, 0);
            btnMyListings.Size = new Size(200, 44);
            btnMyListings.TabIndex = 6;
            btnMyListings.Text = "📋 My Listings";
            btnMyListings.TextAlign = ContentAlignment.MiddleLeft;
            btnMyListings.UseVisualStyleBackColor = false;
            btnMyListings.Click += btnMyListings_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.FromArgb(255, 96, 0);
            btnAdmin.Cursor = Cursors.Hand;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 10F);
            btnAdmin.ForeColor = Color.White;
            btnAdmin.Location = new Point(0, 106);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Padding = new Padding(15, 0, 0, 0);
            btnAdmin.Size = new Size(200, 44);
            btnAdmin.TabIndex = 5;
            btnAdmin.Text = "🔧 Admin Panel";
            btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Visible = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(26, 26, 46);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 156);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(200, 44);
            btnHome.TabIndex = 4;
            btnHome.Text = "🏠 Browse Listings";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnMessages
            // 
            btnMessages.BackColor = Color.FromArgb(26, 26, 46);
            btnMessages.Cursor = Cursors.Hand;
            btnMessages.FlatAppearance.BorderSize = 0;
            btnMessages.FlatStyle = FlatStyle.Flat;
            btnMessages.Font = new Font("Segoe UI", 10F);
            btnMessages.ForeColor = Color.White;
            btnMessages.Location = new Point(-3, 256);
            btnMessages.Name = "btnMessages";
            btnMessages.Padding = new Padding(15, 0, 0, 0);
            btnMessages.Size = new Size(200, 44);
            btnMessages.TabIndex = 3;
            btnMessages.Text = " ✉ Messages";
            btnMessages.TextAlign = ContentAlignment.MiddleLeft;
            btnMessages.UseVisualStyleBackColor = false;
            btnMessages.Click += btnMessages_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.ForeColor = Color.FromArgb(180, 180, 200);
            lblWelcome.Location = new Point(3, 60);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(190, 30);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "label1";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLogo.ForeColor = Color.Yellow;
            lblLogo.Location = new Point(-3, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(200, 60);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🏪 Sahibinden";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(label2);
            pnlFilters.Controls.Add(label1);
            pnlFilters.Controls.Add(btnAdd);
            pnlFilters.Controls.Add(lblCount);
            pnlFilters.Controls.Add(btnClear);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Controls.Add(nudMaxPrice);
            pnlFilters.Controls.Add(nudMinPrice);
            pnlFilters.Controls.Add(cmbSort);
            pnlFilters.Controls.Add(cmbCategory);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 0);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(950, 111);
            pnlFilters.TabIndex = 0;
            pnlFilters.Paint += pnlFilters_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 60);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 9;
            label2.Text = "Max Price";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 58);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 8;
            label1.Text = "Min Price";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 96, 0);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(606, 56);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "+ Add Listing";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.BackColor = Color.White;
            lblCount.ForeColor = Color.Gray;
            lblCount.Location = new Point(13, 93);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(38, 15);
            lblCount.TabIndex = 1;
            lblCount.Text = "label1";
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(702, 13);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(255, 96, 0);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(606, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // nudMaxPrice
            // 
            nudMaxPrice.Location = new Point(277, 56);
            nudMaxPrice.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudMaxPrice.Name = "nudMaxPrice";
            nudMaxPrice.Size = new Size(120, 23);
            nudMaxPrice.TabIndex = 4;
            nudMaxPrice.Value = new decimal(new int[] { 99999999, 0, 0, 0 });
            // 
            // nudMinPrice
            // 
            nudMinPrice.Location = new Point(76, 56);
            nudMinPrice.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudMinPrice.Name = "nudMinPrice";
            nudMinPrice.Size = new Size(120, 23);
            nudMinPrice.TabIndex = 3;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(413, 55);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(170, 23);
            cmbSort.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(413, 13);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(13, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search by title...";
            txtSearch.Size = new Size(240, 25);
            txtSearch.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslInfo });
            statusStrip1.Location = new Point(0, 678);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(950, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslInfo
            // 
            tsslInfo.Name = "tsslInfo";
            tsslInfo.Size = new Size(39, 17);
            tsslInfo.Text = "Ready";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(247, 247, 247);
            pnlContent.Controls.Add(pnlListingsWrapper);
            pnlContent.Controls.Add(statusStrip1);
            pnlContent.Controls.Add(pnlFilters);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(200, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(950, 700);
            pnlContent.TabIndex = 8;
            // 
            // pnlListingsWrapper
            // 
            pnlListingsWrapper.BackColor = Color.WhiteSmoke;
            pnlListingsWrapper.Controls.Add(flpListings);
            pnlListingsWrapper.Dock = DockStyle.Fill;
            pnlListingsWrapper.Location = new Point(0, 111);
            pnlListingsWrapper.Name = "pnlListingsWrapper";
            pnlListingsWrapper.Size = new Size(950, 567);
            pnlListingsWrapper.TabIndex = 4;
            // 
            // flpListings
            // 
            flpListings.AutoScroll = true;
            flpListings.Dock = DockStyle.Fill;
            flpListings.Location = new Point(0, 0);
            flpListings.Name = "flpListings";
            flpListings.Padding = new Padding(10);
            flpListings.Size = new Size(950, 567);
            flpListings.TabIndex = 0;
            // 
            // ListingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "ListingsControl";
            Size = new Size(1150, 700);
            Load += ListingsControl_Load;
            VisibleChanged += ListingsControl_VisibleChanged;
            pnlSidebar.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPrice).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlListingsWrapper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblLogo;
        private Button btnMyListings;
        private Button btnAdmin;
        private Button btnHome;
        private Button btnMessages;
        private Label lblWelcome;
        private Button btnLogout;
        private Button btnFavorites;
        private Button btnLoginRegister;
        private Panel pnlFilters;
        private Label label2;
        private Label label1;
        private Button btnAdd;
        private Label lblCount;
        private Button btnClear;
        private Button btnSearch;
        private NumericUpDown nudMaxPrice;
        private NumericUpDown nudMinPrice;
        private ComboBox cmbSort;
        private ComboBox cmbCategory;
        private TextBox txtSearch;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslInfo;
        private Panel pnlContent;
        private Panel pnlListingsWrapper;
        private FlowLayoutPanel flpListings;
        private Button btnSettings;
    }
}
