using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace SAHIBINDENapplication.Controls
{
    public partial class AdminControl : UserControl
    {
        public event Action OnBack;

        private System.Windows.Forms.Timer _refreshTimer;

        public AdminControl()
        {
            InitializeComponent();

            // Auto-refresh timer — reloads the Users grid every 10 seconds
            // so online/offline status stays current without manual refresh
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 10000;
            _refreshTimer.Tick += (s, e) =>
            {
                
                if (tabControl1.SelectedIndex == 0)
                {
                    LoadUsers(
                        txtUserSearch.Text.Trim(),
                        cmbUserRoleFilter.SelectedItem?.ToString() ?? "All Roles"
                    );
                }
            };

            
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible) _refreshTimer.Start();
                else _refreshTimer.Stop();
            };
        }

        public void LoadData()
        {
            if (!Session.IsAdmin) { OnBack?.Invoke(); return; }

            StyleGrid(dgvUsers);
            StyleGrid(dgvAllListings);
            StyleGrid(dgvMessages);
            StyleGrid(dgvAuditLog);

            LoadUsers();
            LoadAllListings();
            LoadAllMessages();
            LoadAuditLog();
            LoadCategoryFilterOptions();

            // Populate role filter
            if (cmbUserRoleFilter.Items.Count == 0)
            {
                cmbUserRoleFilter.Items.AddRange(new object[] { "All Roles", "user", "admin" });
                cmbUserRoleFilter.SelectedIndex = 0;
            }

            // Populate status filter
            if (cmbListingStatusFilter.Items.Count == 0)
            {
                cmbListingStatusFilter.Items.AddRange(new object[] { "All Statuses", "active", "sold", "passive" });
                cmbListingStatusFilter.SelectedIndex = 0;
            }

            // Populate audit filters
            if (cmbAuditActionFilter.Items.Count == 0)
            {
                cmbAuditActionFilter.Items.AddRange(new object[] {
                "All Actions", "DELETE_USER", "DELETE_LISTING",
                "DELETE_MESSAGE", "SET_STATUS", "DISMISS_FLAG", "CHANGE_ROLE"
                });
                cmbAuditActionFilter.SelectedIndex = 0;
            }

            if (cmbAuditTargetFilter.Items.Count == 0)
            {
                cmbAuditTargetFilter.Items.AddRange(new object[] {
                "All Targets", "user", "listing", "message"
                });
                cmbAuditTargetFilter.SelectedIndex = 0;
            }

            // Wire up events — unsubscribe first to prevent double-firing on re-entry
            txtUserSearch.TextChanged -= OnUserSearchChanged;
            txtUserSearch.TextChanged += OnUserSearchChanged;
            cmbUserRoleFilter.SelectedIndexChanged -= OnUserRoleFilterChanged;
            cmbUserRoleFilter.SelectedIndexChanged += OnUserRoleFilterChanged;

            txtListingSearch.TextChanged -= OnListingSearchChanged;
            txtListingSearch.TextChanged += OnListingSearchChanged;
            cmbListingStatusFilter.SelectedIndexChanged -= OnListingFilterChanged;
            cmbListingStatusFilter.SelectedIndexChanged += OnListingFilterChanged;
            cmbListingCategoryFilter.SelectedIndexChanged -= OnListingFilterChanged;
            cmbListingCategoryFilter.SelectedIndexChanged += OnListingFilterChanged;

            txtAuditSearch.TextChanged -= OnAuditFilterChanged;
            txtAuditSearch.TextChanged += OnAuditFilterChanged;
            cmbAuditActionFilter.SelectedIndexChanged -= OnAuditFilterChanged;
            cmbAuditActionFilter.SelectedIndexChanged += OnAuditFilterChanged;
            cmbAuditTargetFilter.SelectedIndexChanged -= OnAuditFilterChanged;
            cmbAuditTargetFilter.SelectedIndexChanged += OnAuditFilterChanged;
            btnAuditRefresh.Click -= OnAuditRefreshClick;
            btnAuditRefresh.Click += OnAuditRefreshClick;
        }

        // ─────────────────────────────────────────────
        //  EVENT HANDLERS
        // ─────────────────────────────────────────────

        private void OnAuditFilterChanged(object sender, EventArgs e)
        {
            LoadAuditLog(
                txtAuditSearch.Text.Trim(),
                cmbAuditActionFilter.SelectedItem?.ToString() ?? "All Actions",
                cmbAuditTargetFilter.SelectedItem?.ToString() ?? "All Targets"
            );
        }

        private void OnAuditRefreshClick(object sender, EventArgs e)
        {
            txtAuditSearch.Clear();
            cmbAuditActionFilter.SelectedIndex = 0;
            cmbAuditTargetFilter.SelectedIndex = 0;
            LoadAuditLog();
        }

        private void OnUserSearchChanged(object sender, EventArgs e)
        {
            LoadUsers(txtUserSearch.Text.Trim(), cmbUserRoleFilter.SelectedItem?.ToString() ?? "All Roles");
        }

        private void OnUserRoleFilterChanged(object sender, EventArgs e)
        {
            LoadUsers(txtUserSearch.Text.Trim(), cmbUserRoleFilter.SelectedItem?.ToString() ?? "All Roles");
        }

        private void OnListingSearchChanged(object sender, EventArgs e)
        {
            LoadAllListings(
                txtListingSearch.Text.Trim(),
                cmbListingStatusFilter.SelectedItem?.ToString() ?? "All Statuses",
                cmbListingCategoryFilter.SelectedItem?.ToString() ?? "All Categories"
            );
        }

        private void OnListingFilterChanged(object sender, EventArgs e)
        {
            LoadAllListings(
                txtListingSearch.Text.Trim(),
                cmbListingStatusFilter.SelectedItem?.ToString() ?? "All Statuses",
                cmbListingCategoryFilter.SelectedItem?.ToString() ?? "All Categories"
            );
        }

        private void LoadCategoryFilterOptions()
        {
            cmbListingCategoryFilter.Items.Clear();
            cmbListingCategoryFilter.Items.Add("All Categories");
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("SELECT name FROM categories ORDER BY name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbListingCategoryFilter.Items.Add(reader.GetString(0));
            }
            catch { }
            cmbListingCategoryFilter.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────────
        //  GRID STYLING
        // ─────────────────────────────────────────────

        private void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 26, 46);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.Padding = new Padding(2, 3, 2, 3);
            dgv.RowTemplate.Height = 26;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
            dgv.GridColor = Color.FromArgb(220, 220, 220);
            
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.Cursor = Cursors.Hand;
        }

       

        private void LoadUsers(string search = "", string roleFilter = "All Roles")
        {
            dgvUsers.Rows.Clear();
            dgvUsers.Columns.Clear();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();


                string sql = @"
                SELECT u.id, u.username, u.full_name, u.email, u.phone,
                u.city, u.role, u.created_at,
                COUNT(l.id) AS listing_count,
                u.last_seen, u.is_online
                FROM users u
                LEFT JOIN listings l ON l.user_id = u.id
                WHERE (@isEmpty = TRUE OR
                u.username  ILIKE @searchVal OR
                u.full_name ILIKE @searchVal OR
                u.email     ILIKE @searchVal OR
                u.city      ILIKE @searchVal)
                AND (@role = 'All Roles' OR u.role = @role)
                GROUP BY u.id
                ORDER BY u.created_at DESC";

                using var cmd = new NpgsqlCommand(sql, conn);
                bool isEmpty = string.IsNullOrEmpty(search);
                cmd.Parameters.AddWithValue("isEmpty", isEmpty);
                cmd.Parameters.AddWithValue("searchVal", isEmpty ? "" : $"%{search}%");
                cmd.Parameters.AddWithValue("role", roleFilter);

                using var reader = cmd.ExecuteReader();

                // Build columns
                dgvUsers.Columns.Add("colUId", "ID");
                dgvUsers.Columns.Add("colUUsername", "Username");
                dgvUsers.Columns.Add("colUFullName", "Full Name");
                dgvUsers.Columns.Add("colUEmail", "Email");
                dgvUsers.Columns.Add("colUPhone", "Phone");
                dgvUsers.Columns.Add("colUCity", "City");
                dgvUsers.Columns.Add("colURole", "Role");
                dgvUsers.Columns.Add("colUJoined", "Joined");
                dgvUsers.Columns.Add("colUListings", "Listings");
                dgvUsers.Columns.Add("colULastSeen", "Last Seen");

                dgvUsers.Columns["colUId"].Visible = false;

                // Column widths
                dgvUsers.Columns["colUUsername"].Width = 110;
                dgvUsers.Columns["colUFullName"].Width = 130;
                dgvUsers.Columns["colUEmail"].Width = 180;
                dgvUsers.Columns["colUPhone"].Width = 110;
                dgvUsers.Columns["colUCity"].Width = 90;
                dgvUsers.Columns["colURole"].Width = 70;
                dgvUsers.Columns["colUJoined"].Width = 100;
                dgvUsers.Columns["colUListings"].Width = 65;
                dgvUsers.Columns["colULastSeen"].Width = 160;

                dgvUsers.Columns["colUEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                int count = 0;
                while (reader.Read())
                {
                    string role = reader.GetString(6);

                   
                    DateTime lastSeen = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                    bool isOnlineFlag = reader.IsDBNull(10) ? false : reader.GetBoolean(10);
                    string lastSeenText;
                    if (lastSeen == DateTime.MinValue)
                        lastSeenText = "Never";
                    
                    else if (isOnlineFlag && (DateTime.Now - lastSeen).TotalMinutes <= 3)
                        lastSeenText = "🟢 Online";
                    else
                        lastSeenText = lastSeen.ToString("dd MMM yyyy HH:mm");


                    string joinedText = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd MMM yyyy");
                    long listingCount = reader.IsDBNull(8) ? 0 : Convert.ToInt64(reader.GetValue(8));

                    int i = dgvUsers.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.IsDBNull(2) ? "" : reader.GetString(2),
                        reader.IsDBNull(3) ? "" : reader.GetString(3),
                        reader.IsDBNull(4) ? "" : reader.GetString(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        role,
                        joinedText,
                        listingCount,
                        lastSeenText
                    );

                    if (role == "admin")
                        dgvUsers.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(255, 96, 0);

                    count++;
                }

                dgvUsers.ClearSelection();
                lblUserCount.Text = $"{count} user{(count != 1 ? "s" : "")} found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LoadAllListings(string search = "", string statusFilter = "All Statuses", string categoryFilter = "All Categories")
        {
            dgvAllListings.Rows.Clear();
            dgvAllListings.Columns.Clear();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                    SELECT l.id, l.title, l.price, l.city, c.name,
                           l.status, l.view_count, l.created_at, u.username, u.id AS owner_id
                    FROM listings l
                    JOIN categories c ON c.id = l.category_id
                    JOIN users u ON u.id = l.user_id
                    WHERE (@isEmpty = TRUE OR
                           l.title    ILIKE @searchVal OR
                           u.username ILIKE @searchVal OR
                           l.city     ILIKE @searchVal)
                      AND (@status = 'All Statuses' OR l.status = @status)
                      AND (@cat    = 'All Categories' OR c.name = @cat)
                    ORDER BY l.created_at DESC";

                using var cmd = new NpgsqlCommand(sql, conn);
                bool isEmpty = string.IsNullOrEmpty(search);
                cmd.Parameters.AddWithValue("isEmpty", isEmpty);
                cmd.Parameters.AddWithValue("searchVal", isEmpty ? "" : $"%{search}%");
                cmd.Parameters.AddWithValue("status", statusFilter);
                cmd.Parameters.AddWithValue("cat", categoryFilter);

                using var reader = cmd.ExecuteReader();

                dgvAllListings.Columns.Add("colLId", "ID");
                dgvAllListings.Columns.Add("colLTitle", "Title");
                dgvAllListings.Columns.Add("colLPrice", "Price");
                dgvAllListings.Columns.Add("colLCity", "City");
                dgvAllListings.Columns.Add("colLCat", "Category");
                dgvAllListings.Columns.Add("colLStatus", "Status");
                dgvAllListings.Columns.Add("colLViews", "Views");
                dgvAllListings.Columns.Add("colLDate", "Posted");
                dgvAllListings.Columns.Add("colLOwner", "Owner");
                dgvAllListings.Columns.Add("colLOwnerId", "OwnerID");

                dgvAllListings.Columns["colLId"].Visible = false;
                dgvAllListings.Columns["colLOwnerId"].Visible = false;

                // Column widths
                dgvAllListings.Columns["colLTitle"].Width = 220;
                dgvAllListings.Columns["colLPrice"].Width = 100;
                dgvAllListings.Columns["colLCity"].Width = 90;
                dgvAllListings.Columns["colLCat"].Width = 110;
                dgvAllListings.Columns["colLStatus"].Width = 80;
                dgvAllListings.Columns["colLViews"].Width = 55;
                dgvAllListings.Columns["colLDate"].Width = 100;
                dgvAllListings.Columns["colLOwner"].Width = 110;

                dgvAllListings.Columns["colLTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                int count = 0;
                while (reader.Read())
                {
                    string status = reader.GetString(5);
                    int i = dgvAllListings.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDecimal(2).ToString("N0") + " ₺",
                        reader.IsDBNull(3) ? "" : reader.GetString(3),
                        reader.GetString(4),
                        status,
                        reader.GetInt32(6),
                        reader.GetDateTime(7).ToString("dd MMM yyyy"),
                        reader.GetString(8),
                        reader.GetInt32(9)
                    );

                    dgvAllListings.Rows[i].DefaultCellStyle.ForeColor = status switch
                    {
                        "active" => Color.FromArgb(39, 174, 96),
                        "sold" => Color.FromArgb(231, 76, 60),
                        "passive" => Color.Gray,
                        _ => Color.Black
                    };
                    count++;
                }

                dgvAllListings.ClearSelection();
                lblListingCount.Text = $"{count} listing{(count != 1 ? "s" : "")} found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading listings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LoadAllMessages()
        {
            dgvMessages.Rows.Clear();
            dgvMessages.Columns.Clear();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                    SELECT m.id,
                           su.username  AS from_user,
                           ru.username  AS to_user,
                           l.title      AS listing,
                           m.body,
                           m.sent_at,
                           f.status     AS flag_status,
                           f.id         AS flag_id
                    FROM message_flags f
                    JOIN messages  m  ON m.id  = f.message_id
                    JOIN users     su ON su.id = m.sender_id
                    JOIN users     ru ON ru.id = m.receiver_id
                    JOIN listings  l  ON l.id  = m.listing_id
                    WHERE f.status = 'pending'
                    ORDER BY f.flagged_at DESC";

                using var cmd = new NpgsqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                dgvMessages.Columns.Add("colMId", "ID");
                dgvMessages.Columns.Add("colMFrom", "From");
                dgvMessages.Columns.Add("colMTo", "To");
                dgvMessages.Columns.Add("colMListing", "Listing");
                dgvMessages.Columns.Add("colMBody", "Message");
                dgvMessages.Columns.Add("colMDate", "Sent");
                dgvMessages.Columns.Add("colMFlag", "Flag");

                dgvMessages.Columns["colMId"].Visible = false;

                // Column widths
                dgvMessages.Columns["colMFrom"].Width = 100;
                dgvMessages.Columns["colMTo"].Width = 100;
                dgvMessages.Columns["colMListing"].Width = 160;
                dgvMessages.Columns["colMBody"].Width = 280;
                dgvMessages.Columns["colMDate"].Width = 110;
                dgvMessages.Columns["colMFlag"].Width = 100;

                dgvMessages.Columns["colMBody"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                while (reader.Read())
                {
                    string body = reader.GetString(4);
                    bool isFlagged = !reader.IsDBNull(6);

                    int rowIdx = dgvMessages.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        body.Length > 60 ? body[..60] + "…" : body,
                        reader.GetDateTime(5).ToString("dd MMM HH:mm"),
                        isFlagged ? "⚑ Reported" : ""
                    );

                    if (isFlagged)
                    {
                        dgvMessages.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        dgvMessages.Rows[rowIdx].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading messages: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LoadAuditLog(string search = "", string actionFilter = "All Actions", string targetFilter = "All Targets")
        {
            dgvAuditLog.Rows.Clear();
            dgvAuditLog.Columns.Clear();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                    SELECT al.id, u.username, al.action,
                           al.target_type, al.target_id,
                           al.detail, al.logged_at
                    FROM admin_logs al
                    LEFT JOIN users u ON u.id = al.admin_id
                    WHERE (@isEmpty = TRUE OR
                           u.username  ILIKE @searchVal OR
                           al.detail   ILIKE @searchVal)
                      AND (@action = 'All Actions' OR al.action = @action)
                      AND (@target = 'All Targets' OR al.target_type = @target)
                    ORDER BY al.logged_at DESC
                    LIMIT 500";

                using var cmd = new NpgsqlCommand(sql, conn);
                bool isEmpty = string.IsNullOrEmpty(search);
                cmd.Parameters.AddWithValue("isEmpty", isEmpty);
                cmd.Parameters.AddWithValue("searchVal", isEmpty ? "" : $"%{search}%");
                cmd.Parameters.AddWithValue("action", actionFilter);
                cmd.Parameters.AddWithValue("target", targetFilter);

                using var reader = cmd.ExecuteReader();

                // Build columns
                dgvAuditLog.Columns.Add("colAId", "ID");
                dgvAuditLog.Columns.Add("colAAdmin", "Admin");
                dgvAuditLog.Columns.Add("colAAction", "Action");
                dgvAuditLog.Columns.Add("colAType", "Target");
                dgvAuditLog.Columns.Add("colATid", "Target ID");
                dgvAuditLog.Columns.Add("colADetail", "Detail");
                dgvAuditLog.Columns.Add("colATime", "Time");

                dgvAuditLog.Columns["colAId"].Visible = false;

                
                dgvAuditLog.Columns["colAAdmin"].Width = 110;
                dgvAuditLog.Columns["colAAction"].Width = 150;
                dgvAuditLog.Columns["colAType"].Width = 85;
                dgvAuditLog.Columns["colATid"].Width = 75;
                dgvAuditLog.Columns["colATime"].Width = 150;
               
                dgvAuditLog.Columns["colADetail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                int count = 0;
                while (reader.Read())
                {
                    string action = reader.GetString(2);
                    int i = dgvAuditLog.Rows.Add(
                        reader.GetInt32(0),
                        reader.IsDBNull(1) ? "deleted admin" : reader.GetString(1),
                        action,
                        reader.IsDBNull(3) ? "" : reader.GetString(3),
                        reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        reader.GetDateTime(6).ToString("dd MMM yyyy HH:mm")
                    );

                    dgvAuditLog.Rows[i].DefaultCellStyle.ForeColor = action switch
                    {
                        "DELETE_USER" => Color.FromArgb(192, 0, 0),
                        "DELETE_LISTING" => Color.FromArgb(200, 80, 0),
                        "DELETE_MESSAGE" => Color.FromArgb(180, 60, 0),
                        "CHANGE_ROLE" => Color.FromArgb(130, 0, 180),
                        "SET_STATUS" => Color.FromArgb(0, 120, 0),
                        "DISMISS_FLAG" => Color.FromArgb(0, 100, 160),
                        _ => Color.Black
                    };
                    count++;
                }

                dgvAuditLog.ClearSelection();
                lblAuditCount.Text = $"{count} log{(count != 1 ? "s" : "")} found";

                
                if (dgvAuditLog.Rows.Count > 0)
                    dgvAuditLog.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audit log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  ACTIONS — Users tab
        // ─────────────────────────────────────────────

        private void AdminControl_Load(object sender, EventArgs e) { }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            int id = (int)dgvUsers.SelectedRows[0].Cells["colUId"].Value;

            if (id == Session.CurrentUser.Id)
            {
                lblUserStatus.ForeColor = Color.Red;
                lblUserStatus.Text = "⚠ Cannot delete your own account.";
                return;
            }

            string uname = dgvUsers.SelectedRows[0].Cells["colUUsername"].Value.ToString();
            string role = dgvUsers.SelectedRows[0].Cells["colURole"].Value.ToString();

            // Prevent deleting other admins
            if (role == "admin")
            {
                lblUserStatus.ForeColor = Color.Red;
                lblUserStatus.Text = "⚠ Cannot delete another admin account.";
                return;
            }

            if (MessageBox.Show($"Delete user '{uname}' and all their data?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("DELETE FROM users WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                LogAction("DELETE_USER", "user", id, $"Deleted user: {uname}");
                lblUserStatus.ForeColor = Color.Green;
                lblUserStatus.Text = $"✔ User '{uname}' deleted.";
                LoadUsers();
            }
            catch (Exception ex)
            {
                lblUserStatus.ForeColor = Color.Red;
                lblUserStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnViewUserListings_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            string uname = dgvUsers.SelectedRows[0].Cells["colUUsername"].Value.ToString();

            // Switch to Listings tab and filter by this username
            tabControl1.SelectedIndex = 1;
            txtListingSearch.Text = uname;
        }

        // ─────────────────────────────────────────────
        //  ACTIONS — Listings tab
        // ─────────────────────────────────────────────

        private void btnForceDelete_Click(object sender, EventArgs e)
        {
            if (dgvAllListings.SelectedRows.Count == 0) return;
            int id = (int)dgvAllListings.SelectedRows[0].Cells["colLId"].Value;

            if (MessageBox.Show("Permanently delete this listing?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("DELETE FROM listings WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                LogAction("DELETE_LISTING", "listing", id, "Admin force-deleted listing");
                lblListingStatus.ForeColor = Color.Green;
                lblListingStatus.Text = "✔ Listing deleted.";
                LoadAllListings(
                    txtListingSearch.Text.Trim(),
                    cmbListingStatusFilter.SelectedItem?.ToString() ?? "All Statuses",
                    cmbListingCategoryFilter.SelectedItem?.ToString() ?? "All Categories"
                );
            }
            catch (Exception ex)
            {
                lblListingStatus.ForeColor = Color.Red;
                lblListingStatus.Text = "Error: " + ex.Message;
            }
        }

        private void SetListingStatus(string status)
        {
            if (dgvAllListings.SelectedRows.Count == 0) return;
            int id = (int)dgvAllListings.SelectedRows[0].Cells["colLId"].Value;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("UPDATE listings SET status=@s WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("s", status);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                LogAction("SET_STATUS", "listing", id, $"Status set to {status}");
                lblListingStatus.ForeColor = Color.Green;
                lblListingStatus.Text = $"✔ Status set to '{status}'.";
                LoadAllListings(
                    txtListingSearch.Text.Trim(),
                    cmbListingStatusFilter.SelectedItem?.ToString() ?? "All Statuses",
                    cmbListingCategoryFilter.SelectedItem?.ToString() ?? "All Categories"
                );
            }
            catch (Exception ex)
            {
                lblListingStatus.ForeColor = Color.Red;
                lblListingStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnSetActive_Click(object sender, EventArgs e) => SetListingStatus("active");
        private void btnSetPassive_Click(object sender, EventArgs e) => SetListingStatus("passive");

        private void dgvAllListings_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }

        // ─────────────────────────────────────────────
        //  ACTIONS — Messages tab
        // ─────────────────────────────────────────────

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count == 0) return;
            int id = (int)dgvMessages.SelectedRows[0].Cells["colMId"].Value;

            if (MessageBox.Show("Delete this message?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("DELETE FROM messages WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                LogAction("DELETE_MESSAGE", "message", id, "Admin deleted message");
                LoadAllMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDismissFlag_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count == 0) return;

            int msgId = (int)dgvMessages.SelectedRows[0].Cells["colMId"].Value;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                    UPDATE message_flags
                    SET status = 'dismissed', reviewed_at = NOW(), reviewed_by = @rid
                    WHERE message_id = @mid AND status = 'pending'";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("rid", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("mid", msgId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    LogAction("DISMISS_FLAG", "message", msgId, "Flag dismissed");
                    MessageBox.Show("Flag dismissed successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllMessages();
                }
                else
                {
                    MessageBox.Show("This message does not have a pending flag.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dismissing flag: " + ex.Message, "Error");
            }
        }

        // ─────────────────────────────────────────────
        //  NAVIGATION
        // ─────────────────────────────────────────────

        private void btnBack_Click(object sender, EventArgs e) => OnBack?.Invoke();

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUsers.ClearSelection();
            dgvAllListings.ClearSelection();
            dgvMessages.ClearSelection();
            dgvAuditLog.ClearSelection();
        }

        // ─────────────────────────────────────────────
        //  AUDIT LOGGING
        // ─────────────────────────────────────────────

        private void LogAction(string action, string targetType, int targetId, string detail = "")
        {
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                string sql = @"
                    INSERT INTO admin_logs (admin_id, action, target_type, target_id, detail)
                    VALUES (@aid, @act, @tt, @tid, @det)";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("aid", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("act", action);
                cmd.Parameters.AddWithValue("tt", targetType);
                cmd.Parameters.AddWithValue("tid", targetId);
                cmd.Parameters.AddWithValue("det", string.IsNullOrEmpty(detail) ? DBNull.Value : (object)detail);
                cmd.ExecuteNonQuery();

                LoadAuditLog();
            }
            catch { /* never let logging crash the main action */ }
        }
    }
}