namespace SAHIBINDENapplication.Controls
{
    partial class AdminControl
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
            lblHeader = new Label();
            btnBack = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvUsers = new DataGridView();
            pnlUsersBottom = new Panel();
            btnViewUserListings = new Button();
            lblUserStatus = new Label();
            btnDeleteUser = new Button();
            pnlUserSearch = new Panel();
            lblUserCount = new Label();
            label1 = new Label();
            cmbUserRoleFilter = new ComboBox();
            txtUserSearch = new TextBox();
            tabPage2 = new TabPage();
            dgvAllListings = new DataGridView();
            pnlListingsBottom = new Panel();
            lblListingStatus = new Label();
            btnForceDelete = new Button();
            btnSetActive = new Button();
            btnSetPassive = new Button();
            pnlListingSearch = new Panel();
            txtListingSearch = new TextBox();
            lblListingCount = new Label();
            label2 = new Label();
            cmbListingStatusFilter = new ComboBox();
            cmbListingCategoryFilter = new ComboBox();
            tabPage3 = new TabPage();
            pnlMessagesBottom = new Panel();
            btnDismissFlag = new Button();
            btnDeleteMessage = new Button();
            dgvMessages = new DataGridView();
            tabAudit = new TabPage();
            dgvAuditLog = new DataGridView();
            pnlAuditSearch = new Panel();
            lblAuditCount = new Label();
            label5 = new Label();
            cmbAuditTargetFilter = new ComboBox();
            btnAuditRefresh = new Button();
            cmbAuditActionFilter = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtAuditSearch = new TextBox();
            pnlHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlUsersBottom.SuspendLayout();
            pnlUserSearch.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllListings).BeginInit();
            pnlListingsBottom.SuspendLayout();
            pnlListingSearch.SuspendLayout();
            tabPage3.SuspendLayout();
            pnlMessagesBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMessages).BeginInit();
            tabAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            pnlAuditSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.25F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(413, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(174, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "🔧 Admin Panel";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(882, 16);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabAudit);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.Location = new Point(0, 60);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1150, 640);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvUsers);
            tabPage1.Controls.Add(pnlUsersBottom);
            tabPage1.Controls.Add(pnlUserSearch);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1142, 610);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "👤 Users";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Cursor = Cursors.Hand;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 48);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1136, 499);
            dgvUsers.TabIndex = 0;
            // 
            // pnlUsersBottom
            // 
            pnlUsersBottom.BackColor = Color.White;
            pnlUsersBottom.Controls.Add(btnViewUserListings);
            pnlUsersBottom.Controls.Add(lblUserStatus);
            pnlUsersBottom.Controls.Add(btnDeleteUser);
            pnlUsersBottom.Dock = DockStyle.Bottom;
            pnlUsersBottom.Location = new Point(3, 547);
            pnlUsersBottom.Name = "pnlUsersBottom";
            pnlUsersBottom.Size = new Size(1136, 60);
            pnlUsersBottom.TabIndex = 4;
            // 
            // btnViewUserListings
            // 
            btnViewUserListings.Location = new Point(735, 18);
            btnViewUserListings.Name = "btnViewUserListings";
            btnViewUserListings.Size = new Size(143, 30);
            btnViewUserListings.TabIndex = 4;
            btnViewUserListings.Text = "📋 View Listings";
            btnViewUserListings.UseVisualStyleBackColor = true;
            btnViewUserListings.Click += btnViewUserListings_Click;
            // 
            // lblUserStatus
            // 
            lblUserStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserStatus.Location = new Point(123, 18);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(400, 24);
            lblUserStatus.TabIndex = 3;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.ForeColor = Color.Red;
            btnDeleteUser.Location = new Point(600, 18);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(118, 30);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "🗑 Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // pnlUserSearch
            // 
            pnlUserSearch.BackColor = Color.WhiteSmoke;
            pnlUserSearch.Controls.Add(lblUserCount);
            pnlUserSearch.Controls.Add(label1);
            pnlUserSearch.Controls.Add(cmbUserRoleFilter);
            pnlUserSearch.Controls.Add(txtUserSearch);
            pnlUserSearch.Dock = DockStyle.Top;
            pnlUserSearch.Location = new Point(3, 3);
            pnlUserSearch.Name = "pnlUserSearch";
            pnlUserSearch.Size = new Size(1136, 45);
            pnlUserSearch.TabIndex = 5;
            // 
            // lblUserCount
            // 
            lblUserCount.AutoSize = true;
            lblUserCount.ForeColor = Color.Gray;
            lblUserCount.Location = new Point(500, 13);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(45, 19);
            lblUserCount.TabIndex = 7;
            lblUserCount.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(28, 19);
            label1.TabIndex = 6;
            label1.Text = "🔍";
            // 
            // cmbUserRoleFilter
            // 
            cmbUserRoleFilter.FormattingEnabled = true;
            cmbUserRoleFilter.Items.AddRange(new object[] { "All Roles", "user", "admin" });
            cmbUserRoleFilter.Location = new Point(350, 10);
            cmbUserRoleFilter.Name = "cmbUserRoleFilter";
            cmbUserRoleFilter.Size = new Size(130, 25);
            cmbUserRoleFilter.TabIndex = 8;
            // 
            // txtUserSearch
            // 
            txtUserSearch.Location = new Point(35, 10);
            txtUserSearch.Name = "txtUserSearch";
            txtUserSearch.PlaceholderText = "Search by user";
            txtUserSearch.Size = new Size(300, 25);
            txtUserSearch.TabIndex = 9;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvAllListings);
            tabPage2.Controls.Add(pnlListingsBottom);
            tabPage2.Controls.Add(pnlListingSearch);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1142, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "📋 Listings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAllListings
            // 
            dgvAllListings.AllowUserToAddRows = false;
            dgvAllListings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllListings.Cursor = Cursors.Hand;
            dgvAllListings.Dock = DockStyle.Fill;
            dgvAllListings.Location = new Point(3, 48);
            dgvAllListings.Name = "dgvAllListings";
            dgvAllListings.ReadOnly = true;
            dgvAllListings.RowHeadersVisible = false;
            dgvAllListings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllListings.Size = new Size(1136, 499);
            dgvAllListings.TabIndex = 0;
            dgvAllListings.CellContentClick += dgvAllListings_CellContentClick;
            // 
            // pnlListingsBottom
            // 
            pnlListingsBottom.Controls.Add(lblListingStatus);
            pnlListingsBottom.Controls.Add(btnForceDelete);
            pnlListingsBottom.Controls.Add(btnSetActive);
            pnlListingsBottom.Controls.Add(btnSetPassive);
            pnlListingsBottom.Dock = DockStyle.Bottom;
            pnlListingsBottom.Location = new Point(3, 547);
            pnlListingsBottom.Name = "pnlListingsBottom";
            pnlListingsBottom.Size = new Size(1136, 60);
            pnlListingsBottom.TabIndex = 5;
            // 
            // lblListingStatus
            // 
            lblListingStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblListingStatus.Location = new Point(110, 16);
            lblListingStatus.Name = "lblListingStatus";
            lblListingStatus.Size = new Size(400, 27);
            lblListingStatus.TabIndex = 4;
            // 
            // btnForceDelete
            // 
            btnForceDelete.Cursor = Cursors.Hand;
            btnForceDelete.FlatStyle = FlatStyle.Flat;
            btnForceDelete.ForeColor = Color.Red;
            btnForceDelete.Location = new Point(813, 16);
            btnForceDelete.Name = "btnForceDelete";
            btnForceDelete.Size = new Size(118, 30);
            btnForceDelete.TabIndex = 1;
            btnForceDelete.Text = "🗑 Delete";
            btnForceDelete.UseVisualStyleBackColor = true;
            btnForceDelete.Click += btnForceDelete_Click;
            // 
            // btnSetActive
            // 
            btnSetActive.Cursor = Cursors.Hand;
            btnSetActive.FlatStyle = FlatStyle.Flat;
            btnSetActive.Location = new Point(689, 16);
            btnSetActive.Name = "btnSetActive";
            btnSetActive.Size = new Size(118, 30);
            btnSetActive.TabIndex = 2;
            btnSetActive.Text = "✔ Set Active";
            btnSetActive.UseVisualStyleBackColor = true;
            btnSetActive.Click += btnSetActive_Click;
            // 
            // btnSetPassive
            // 
            btnSetPassive.Cursor = Cursors.Hand;
            btnSetPassive.FlatStyle = FlatStyle.Flat;
            btnSetPassive.Location = new Point(556, 16);
            btnSetPassive.Name = "btnSetPassive";
            btnSetPassive.Size = new Size(118, 30);
            btnSetPassive.TabIndex = 3;
            btnSetPassive.Text = "⏸ Set Passive";
            btnSetPassive.UseVisualStyleBackColor = true;
            btnSetPassive.Click += btnSetPassive_Click;
            // 
            // pnlListingSearch
            // 
            pnlListingSearch.BackColor = Color.WhiteSmoke;
            pnlListingSearch.Controls.Add(txtListingSearch);
            pnlListingSearch.Controls.Add(lblListingCount);
            pnlListingSearch.Controls.Add(label2);
            pnlListingSearch.Controls.Add(cmbListingStatusFilter);
            pnlListingSearch.Controls.Add(cmbListingCategoryFilter);
            pnlListingSearch.Dock = DockStyle.Top;
            pnlListingSearch.Location = new Point(3, 3);
            pnlListingSearch.Name = "pnlListingSearch";
            pnlListingSearch.Size = new Size(1136, 45);
            pnlListingSearch.TabIndex = 6;
            // 
            // txtListingSearch
            // 
            txtListingSearch.Location = new Point(35, 10);
            txtListingSearch.Name = "txtListingSearch";
            txtListingSearch.PlaceholderText = "Search by user";
            txtListingSearch.Size = new Size(280, 25);
            txtListingSearch.TabIndex = 4;
            // 
            // lblListingCount
            // 
            lblListingCount.AutoSize = true;
            lblListingCount.ForeColor = Color.Gray;
            lblListingCount.Location = new Point(640, 13);
            lblListingCount.Name = "lblListingCount";
            lblListingCount.Size = new Size(45, 19);
            lblListingCount.TabIndex = 3;
            lblListingCount.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 13);
            label2.Name = "label2";
            label2.Size = new Size(28, 19);
            label2.TabIndex = 2;
            label2.Text = "🔍";
            // 
            // cmbListingStatusFilter
            // 
            cmbListingStatusFilter.FormattingEnabled = true;
            cmbListingStatusFilter.Items.AddRange(new object[] { "All Statuses", "active", "sold", "passive" });
            cmbListingStatusFilter.Location = new Point(330, 10);
            cmbListingStatusFilter.Name = "cmbListingStatusFilter";
            cmbListingStatusFilter.Size = new Size(130, 25);
            cmbListingStatusFilter.TabIndex = 1;
            // 
            // cmbListingCategoryFilter
            // 
            cmbListingCategoryFilter.FormattingEnabled = true;
            cmbListingCategoryFilter.Location = new Point(475, 10);
            cmbListingCategoryFilter.Name = "cmbListingCategoryFilter";
            cmbListingCategoryFilter.Size = new Size(150, 25);
            cmbListingCategoryFilter.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pnlMessagesBottom);
            tabPage3.Controls.Add(dgvMessages);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1142, 610);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "✉ Messages";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlMessagesBottom
            // 
            pnlMessagesBottom.Controls.Add(btnDismissFlag);
            pnlMessagesBottom.Controls.Add(btnDeleteMessage);
            pnlMessagesBottom.Dock = DockStyle.Bottom;
            pnlMessagesBottom.Location = new Point(3, 547);
            pnlMessagesBottom.Name = "pnlMessagesBottom";
            pnlMessagesBottom.Size = new Size(1136, 60);
            pnlMessagesBottom.TabIndex = 2;
            // 
            // btnDismissFlag
            // 
            btnDismissFlag.Cursor = Cursors.Hand;
            btnDismissFlag.FlatStyle = FlatStyle.Flat;
            btnDismissFlag.Location = new Point(616, 12);
            btnDismissFlag.Name = "btnDismissFlag";
            btnDismissFlag.Size = new Size(145, 30);
            btnDismissFlag.TabIndex = 3;
            btnDismissFlag.Text = "Dismiss Flag";
            btnDismissFlag.UseVisualStyleBackColor = true;
            btnDismissFlag.Click += btnDismissFlag_Click;
            // 
            // btnDeleteMessage
            // 
            btnDeleteMessage.Cursor = Cursors.Hand;
            btnDeleteMessage.FlatStyle = FlatStyle.Flat;
            btnDeleteMessage.ForeColor = Color.Red;
            btnDeleteMessage.Location = new Point(767, 12);
            btnDeleteMessage.Name = "btnDeleteMessage";
            btnDeleteMessage.Size = new Size(145, 30);
            btnDeleteMessage.TabIndex = 1;
            btnDeleteMessage.Text = "🗑 Delete Message";
            btnDeleteMessage.UseVisualStyleBackColor = true;
            btnDeleteMessage.Click += btnDeleteMessage_Click;
            // 
            // dgvMessages
            // 
            dgvMessages.AllowUserToAddRows = false;
            dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMessages.Cursor = Cursors.Hand;
            dgvMessages.Dock = DockStyle.Fill;
            dgvMessages.Location = new Point(3, 3);
            dgvMessages.Name = "dgvMessages";
            dgvMessages.ReadOnly = true;
            dgvMessages.RowHeadersVisible = false;
            dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMessages.Size = new Size(1136, 604);
            dgvMessages.TabIndex = 0;
            // 
            // tabAudit
            // 
            tabAudit.Controls.Add(dgvAuditLog);
            tabAudit.Controls.Add(pnlAuditSearch);
            tabAudit.Location = new Point(4, 26);
            tabAudit.Name = "tabAudit";
            tabAudit.Padding = new Padding(3);
            tabAudit.Size = new Size(1142, 610);
            tabAudit.TabIndex = 3;
            tabAudit.Text = "Audit Log";
            tabAudit.UseVisualStyleBackColor = true;
            // 
            // dgvAuditLog
            // 
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLog.Cursor = Cursors.Hand;
            dgvAuditLog.Dock = DockStyle.Fill;
            dgvAuditLog.Location = new Point(3, 53);
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLog.Size = new Size(1136, 554);
            dgvAuditLog.TabIndex = 0;
            // 
            // pnlAuditSearch
            // 
            pnlAuditSearch.Controls.Add(lblAuditCount);
            pnlAuditSearch.Controls.Add(label5);
            pnlAuditSearch.Controls.Add(cmbAuditTargetFilter);
            pnlAuditSearch.Controls.Add(btnAuditRefresh);
            pnlAuditSearch.Controls.Add(cmbAuditActionFilter);
            pnlAuditSearch.Controls.Add(label4);
            pnlAuditSearch.Controls.Add(label3);
            pnlAuditSearch.Controls.Add(txtAuditSearch);
            pnlAuditSearch.Dock = DockStyle.Top;
            pnlAuditSearch.Location = new Point(3, 3);
            pnlAuditSearch.Name = "pnlAuditSearch";
            pnlAuditSearch.Size = new Size(1136, 50);
            pnlAuditSearch.TabIndex = 1;
            // 
            // lblAuditCount
            // 
            lblAuditCount.AutoSize = true;
            lblAuditCount.ForeColor = Color.Gray;
            lblAuditCount.Location = new Point(810, 15);
            lblAuditCount.Name = "lblAuditCount";
            lblAuditCount.Size = new Size(45, 19);
            lblAuditCount.TabIndex = 7;
            lblAuditCount.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(510, 15);
            label5.Name = "label5";
            label5.Size = new Size(49, 19);
            label5.TabIndex = 6;
            label5.Text = "Target:";
            // 
            // cmbAuditTargetFilter
            // 
            cmbAuditTargetFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuditTargetFilter.FormattingEnabled = true;
            cmbAuditTargetFilter.Location = new Point(560, 12);
            cmbAuditTargetFilter.Name = "cmbAuditTargetFilter";
            cmbAuditTargetFilter.Size = new Size(120, 25);
            cmbAuditTargetFilter.TabIndex = 5;
            // 
            // btnAuditRefresh
            // 
            btnAuditRefresh.BackColor = Color.FromArgb(26, 26, 46);
            btnAuditRefresh.Cursor = Cursors.Hand;
            btnAuditRefresh.FlatAppearance.BorderSize = 0;
            btnAuditRefresh.FlatStyle = FlatStyle.Flat;
            btnAuditRefresh.ForeColor = Color.White;
            btnAuditRefresh.Location = new Point(700, 10);
            btnAuditRefresh.Name = "btnAuditRefresh";
            btnAuditRefresh.Size = new Size(90, 28);
            btnAuditRefresh.TabIndex = 4;
            btnAuditRefresh.Text = "🔄 Refresh";
            btnAuditRefresh.UseVisualStyleBackColor = false;
            // 
            // cmbAuditActionFilter
            // 
            cmbAuditActionFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuditActionFilter.FormattingEnabled = true;
            cmbAuditActionFilter.Location = new Point(335, 12);
            cmbAuditActionFilter.Name = "cmbAuditActionFilter";
            cmbAuditActionFilter.Size = new Size(160, 25);
            cmbAuditActionFilter.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 15);
            label4.Name = "label4";
            label4.Size = new Size(28, 19);
            label4.TabIndex = 2;
            label4.Text = "🔍";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 15);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 1;
            label3.Text = "Action:";
            // 
            // txtAuditSearch
            // 
            txtAuditSearch.Location = new Point(35, 10);
            txtAuditSearch.Name = "txtAuditSearch";
            txtAuditSearch.PlaceholderText = "Search by admin or detail...";
            txtAuditSearch.Size = new Size(200, 25);
            txtAuditSearch.TabIndex = 0;
            // 
            // AdminControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(pnlHeader);
            Name = "AdminControl";
            Size = new Size(1150, 700);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlUsersBottom.ResumeLayout(false);
            pnlUserSearch.ResumeLayout(false);
            pnlUserSearch.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAllListings).EndInit();
            pnlListingsBottom.ResumeLayout(false);
            pnlListingSearch.ResumeLayout(false);
            pnlListingSearch.PerformLayout();
            tabPage3.ResumeLayout(false);
            pnlMessagesBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMessages).EndInit();
            tabAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            pnlAuditSearch.ResumeLayout(false);
            pnlAuditSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnBack;
        private Label lblHeader;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvUsers;
        private Button btnDeleteUser;
        private Label lblUserStatus;
        private Label lblListingStatus;
        private Button btnSetPassive;
        private Button btnSetActive;
        private Button btnForceDelete;
        private DataGridView dgvMessages;
        private Button btnDeleteMessage;
        private DataGridView dgvAllListings;
        private Panel pnlUsersBottom;
        private Panel pnlListingsBottom;
        private Panel pnlMessagesBottom;
        private TabPage tabAudit;
        private DataGridView dgvAuditLog;
        private Button btnDismissFlag;
        private Label lblUserCount;
        private Label label1;
        private Panel pnlUserSearch;
        private ComboBox cmbUserRoleFilter;
        private TextBox txtUserSearch;
        private Panel pnlListingSearch;
        private TextBox txtListingSearch;
        private Label lblListingCount;
        private Label label2;
        private ComboBox cmbListingStatusFilter;
        private ComboBox cmbListingCategoryFilter;
        private Panel pnlAuditSearch;
        private Label lblAuditCount;
        private Label label5;
        private ComboBox cmbAuditTargetFilter;
        private Button btnAuditRefresh;
        private ComboBox cmbAuditActionFilter;
        private Label label4;
        private Label label3;
        private TextBox txtAuditSearch;
        private Button btnViewUserListings;
    }
}
