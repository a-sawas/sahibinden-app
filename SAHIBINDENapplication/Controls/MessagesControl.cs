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
    public partial class MessagesControl : UserControl
    {
        public event Action OnBack;
        private int _selectedMessageId = 0;
        private int _activeReceiverId = -1;
        private int _activeListingId = -1;
        private string _activeChatName = "";
        private bool _isActiveUserOnline = false;
        public MessagesControl()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            // 1. Clear the chat area
            flpMessages.Controls.Clear();

            // 2. Hide the typing area so they can't type yet
            pnlReply.Visible = false;

            // 3. Reset the title
            _activeChatName = "";
            lblConvTitle.Invalidate();

            // 4. Reset our active tracking variables
            _activeReceiverId = -1;
            _activeListingId = -1;

            // 5. Load the list on the left
            LoadConversations();
        }

        public void OpenConversation(int receiverId, int listingId)
        {
            _activeReceiverId = receiverId;
            _activeListingId = listingId;  // kept so btnSend can tag new messages correctly

            pnlReply.Visible = true;
            flpMessages.Controls.Clear();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                SELECT 
                full_name, 
                EXTRACT(EPOCH FROM (NOW() - last_seen)) / 60.0 AS minutes_ago,
                is_online
                FROM users 
                WHERE id=@uid";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("uid", receiverId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _activeChatName = reader.GetString(0);

                    if (!reader.IsDBNull(1))
                    {
                        double minutesAgo = Convert.ToDouble(reader.GetValue(1));
                       
                        bool isOnlineFlag = reader.GetBoolean(2);

                      
                        _isActiveUserOnline = isOnlineFlag && (minutesAgo <= 3);
                    }
                    else
                    {
                        _isActiveUserOnline = false;
                    }
                }
                lblConvTitle.Invalidate(); // Repaint the header with the new status
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

            LoadConversations();
            LoadThread();
            lblConvTitle.Invalidate();
        }

        private void LoadConversations()
        {
            flpConversations.Controls.Clear();
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                SELECT DISTINCT ON (other_id)
                other_id, other_name, last_body, last_sent,
                unread_count
                FROM (
                SELECT
                    CASE WHEN m.sender_id=@uid THEN m.receiver_id ELSE m.sender_id END AS other_id,
                    CASE WHEN m.sender_id=@uid THEN ru.full_name   ELSE su.full_name END AS other_name,
                    m.body AS last_body,
                    m.sent_at AS last_sent,
                    (SELECT COUNT(*) FROM messages m2
                     WHERE m2.receiver_id=@uid
                       AND m2.sender_id = CASE WHEN m.sender_id=@uid THEN m.receiver_id ELSE m.sender_id END
                       AND m2.is_read = false) AS unread_count
                FROM messages m
                JOIN users su ON su.id = m.sender_id
                JOIN users ru ON ru.id = m.receiver_id
                WHERE m.sender_id=@uid OR m.receiver_id=@uid
                ORDER BY m.sent_at DESC
            ) sub
            ORDER BY other_id, last_sent DESC";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ConversationItem
                    {
                        OtherId = reader.GetInt32(0),
                        OtherName = reader.GetString(1),
                        LastMessage = reader.GetString(2),
                        LastSent = reader.GetDateTime(3),
                        UnreadCount = reader.GetInt32(4)
                    };
                    flpConversations.Controls.Add(BuildConversationCard(item));
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private Panel BuildConversationCard(ConversationItem item)
        {
            bool isSelected = item.OtherId == _activeReceiverId;

            var card = new Panel
            {
                Width = flpConversations.ClientSize.Width - 2,
                Height = 68,
                BackColor = isSelected
                            ? Color.FromArgb(255, 96, 0)
                            : Color.FromArgb(30, 30, 45),
                Cursor = Cursors.Hand,
                Tag = item,
                Margin = new Padding(0)
            };

            // Avatar circle
            var avatar = new Panel
            {
                Width = 40,
                Height = 40,
                Location = new Point(12, 14),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                string initials = item.OtherName.Length > 0
                    ? item.OtherName[0].ToString().ToUpper() : "?";
                using var bg = new SolidBrush(isSelected
                    ? Color.FromArgb(255, 140, 50)
                    : Color.FromArgb(80, 80, 110));
                e.Graphics.FillEllipse(bg, 0, 0, 39, 39);
                TextRenderer.DrawText(e.Graphics, initials,
                    new Font("Segoe UI", 14, FontStyle.Bold),
                    new Rectangle(0, 0, 40, 40), Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // Name label
            var lblName = new Label
            {
                Text = item.OtherName,
                Location = new Point(62, 12),
                Width = card.Width - 110,
                Height = 20,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            // Time label (top right)
            string timeStr = item.LastSent.Date == DateTime.Today
                ? item.LastSent.ToString("HH:mm")
                : item.LastSent.ToString("dd MMM");
            var lblTime = new Label
            {
                Text = timeStr,
                Location = new Point(card.Width - 52, 14),
                Width = 48,
                Height = 16,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = isSelected ? Color.White : Color.FromArgb(160, 160, 190),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };

            // Preview label
            string preview = item.LastMessage?.Length > 28
                ? item.LastMessage.Substring(0, 28) + "…" : item.LastMessage ?? "";
            var lblPreview = new Label
            {
                Text = preview,
                Location = new Point(62, 34),
                Width = card.Width - 110,
                Height = 18,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = isSelected ? Color.FromArgb(255, 230, 200) : Color.FromArgb(150, 150, 180),
                BackColor = Color.Transparent
            };

            // Unread badge
            if (item.UnreadCount > 0 && !isSelected)
            {
                var badge = new Panel
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(card.Width - 30, 34),
                    BackColor = Color.Transparent
                };
                badge.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using var bg = new SolidBrush(Color.FromArgb(255, 96, 0));
                    e.Graphics.FillEllipse(bg, 0, 0, 19, 19);
                    TextRenderer.DrawText(e.Graphics,
                        item.UnreadCount > 9 ? "9+" : item.UnreadCount.ToString(),
                        new Font("Segoe UI", 7.5f, FontStyle.Bold),
                        new Rectangle(0, 0, 20, 20), Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                };
                card.Controls.Add(badge);
            }

            // Bottom separator line
            card.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(50, 50, 65), 1);
                e.Graphics.DrawLine(pen, 0, card.Height - 1, card.Width, card.Height - 1);
            };

            card.Controls.Add(avatar);
            card.Controls.Add(lblName);
            card.Controls.Add(lblTime);
            card.Controls.Add(lblPreview);

            // Click handler
            EventHandler onClick = (s, e) =>
            {
                var ci = (ConversationItem)card.Tag;
                _activeReceiverId = ci.OtherId;
                _activeListingId = -1;
                _activeChatName = ci.OtherName;

                // Fetch online status for this user
                try
                {
                    using var conn2 = DBHelper.GetConnection();
                    conn2.Open();
                    using var cmd2 = new NpgsqlCommand(
                        @"SELECT EXTRACT(EPOCH FROM (NOW() - last_seen)) / 60.0
              FROM users WHERE id=@uid", conn2);
                    cmd2.Parameters.AddWithValue("uid", ci.OtherId);
                    var result = cmd2.ExecuteScalar();
                    _isActiveUserOnline = result != null && result != DBNull.Value
                        && Convert.ToDouble(result) <= 3;
                }
                catch { _isActiveUserOnline = false; }

                lblConvTitle.Invalidate();
                pnlReply.Visible = true;
                LoadThread();
                MarkAsRead();
                LoadConversations();
            };
            card.Click += onClick;
            avatar.Click += onClick;
            lblName.Click += onClick;
            lblPreview.Click += onClick;
            lblTime.Click += onClick;

            // Hover
            Action hoverOn = () => { if (!isSelected) card.BackColor = Color.FromArgb(45, 45, 65); };
            Action hoverOff = () => { if (!isSelected) card.BackColor = Color.FromArgb(30, 30, 45); };
            foreach (Control c in new Control[] { card, lblName, lblPreview, lblTime, avatar })
            {
                c.MouseEnter += (s, e) => hoverOn();
                c.MouseLeave += (s, e) => hoverOff();
            }

            return card;
        }

        private void MessagesControl_Load(object sender, EventArgs e)
        {
            lblConvTitle.AutoSize = false;  
            lblConvTitle.Dock = DockStyle.Top; 
                                              

          
            lblConvTitle.Text = "";
            lblConvTitle.Height = 60; 
            lblConvTitle.BackColor = Color.White;
            lblConvTitle.Cursor = Cursors.Hand;

            
            lblConvTitle.Paint += (s, ev) =>
            {
                var g = ev.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

             
                using var pen = new Pen(Color.FromArgb(230, 230, 230), 1);
                g.DrawLine(pen, 0, lblConvTitle.Height - 1, lblConvTitle.Width, lblConvTitle.Height - 1);

                if (string.IsNullOrEmpty(_activeChatName) || _activeReceiverId == -1)
                {
                    TextRenderer.DrawText(g, "💬 Select a conversation to view messages...",
                        new Font("Segoe UI", 11, FontStyle.Italic),
                        new Point(20, (lblConvTitle.Height - 20) / 2),
                        Color.FromArgb(150, 150, 150));
                    return;
                }

           
                int avatarSize = 40;
                int paddingLeft = 20;
                int avatarY = (lblConvTitle.Height - avatarSize) / 2;

                string initials = _activeChatName.Length > 0 ? _activeChatName[0].ToString().ToUpper() : "?";
                using var bgBrush = new SolidBrush(Color.FromArgb(255, 96, 0));
                g.FillEllipse(bgBrush, paddingLeft, avatarY, avatarSize, avatarSize);

                TextRenderer.DrawText(g, initials,
                    new Font("Segoe UI", 14, FontStyle.Bold),
                    new Rectangle(paddingLeft, avatarY, avatarSize, avatarSize),
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

               
                int textX = paddingLeft + avatarSize + 15;
                TextRenderer.DrawText(g, _activeChatName,
                    new Font("Segoe UI", 12, FontStyle.Bold),
                    new Point(textX, avatarY + 2),
                    Color.FromArgb(30, 30, 30));

                // --- Draw "Online" Status ---
                int dotSize = 8;
                int dotY = avatarY + 25;

                // Green for online, Gray for offline
                Color statusColor = _isActiveUserOnline ? Color.FromArgb(46, 204, 113) : Color.FromArgb(180, 180, 180);
                string statusText = _isActiveUserOnline ? "Online" : "Offline";

                using var dotBrush = new SolidBrush(statusColor);
                g.FillEllipse(dotBrush, textX, dotY, dotSize, dotSize);

                TextRenderer.DrawText(g, statusText,
                    new Font("Segoe UI", 8.5f),
                    new Point(textX + 12, dotY - 3),
                    Color.FromArgb(140, 140, 140));
            };

            
            lblConvHeader.Height = 45;
            lblConvHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConvHeader.ForeColor = Color.White;
            lblConvHeader.BackColor = Color.FromArgb(20, 20, 35);
            lblConvHeader.TextAlign = ContentAlignment.MiddleCenter;


            var refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000; // every 5 seconds
            refreshTimer.Tick += async (s, ev) =>
            {

                // Stop firing if user logged out
                if (!Session.IsLoggedIn)
                {
                    refreshTimer.Stop();
                    return;
                }
                // Refresh online status of current chat
                if (_activeReceiverId >= 0)
                {
                    try
                    {
                        using var conn = DBHelper.GetConnection();
                        conn.Open();

                        using var cmd = new NpgsqlCommand(
                            @"SELECT EXTRACT(EPOCH FROM (NOW() - last_seen)) / 60.0, is_online
                            FROM users WHERE id=@uid", conn);
                        cmd.Parameters.AddWithValue("uid", _activeReceiverId);

                        using var reader = cmd.ExecuteReader();

                        bool newStatus = false;
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            double minutesAgo = Convert.ToDouble(reader.GetValue(0));
                            bool isOnlineFlag = reader.GetBoolean(1);

                            newStatus = isOnlineFlag && (minutesAgo <= 3);
                        }

                        // Only repaint if status actually changed
                        if (newStatus != _isActiveUserOnline)
                        {
                            _isActiveUserOnline = newStatus;
                            lblConvTitle.Invalidate();
                        }
                    }
                    catch { }

                    // Silently refresh messages
                    LoadThread();
                }

                // Refresh conversation list (updates last message + unread badges)
                LoadConversations();
            };
            refreshTimer.Start();

            // Stop timer when control is hidden, restart when shown
            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible) refreshTimer.Start();
                else refreshTimer.Stop();
            };


        }

        

        private void LoadThread()
        {
            if (Session.CurrentUser == null) return;
            flpMessages.Controls.Clear();
            _selectedMessageId = 0;
            if (_activeReceiverId < 0) return;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                // Load ALL messages between these two users, across all listings
                string sql = @"
                SELECT m.id, m.body, m.sent_at, u.full_name, m.sender_id, 
                   m.listing_id, l.title
                    FROM messages m
                    JOIN users u ON u.id = m.sender_id
                    JOIN listings l ON l.id = m.listing_id
                    WHERE (m.sender_id=@uid AND m.receiver_id=@other)
                    OR (m.sender_id=@other AND m.receiver_id=@uid)
                    ORDER BY m.sent_at ASC";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("other", _activeReceiverId);
                using var reader = cmd.ExecuteReader();

                int lastListingId = -1;

                while (reader.Read())
                {
                    int msgId = reader.GetInt32(0);
                    string body = reader.GetString(1);
                    string time = reader.GetDateTime(2).ToString("dd MMM HH:mm");
                    string name = reader.GetString(3);
                    bool isMe = reader.GetInt32(4) == Session.CurrentUser.Id;
                    int listingId = reader.GetInt32(5);
                    string listingTitle = reader.GetString(6);

                    // Insert a listing badge divider when the topic changes
                    if (listingId != lastListingId)
                    {
                        AddListingBadge(listingTitle);
                        lastListingId = listingId;
                    }

                    AddBubble(msgId, body, time, name, isMe);
                }

                pnlChat.ScrollControlIntoView(
                    flpMessages.Controls.Count > 0
                        ? flpMessages.Controls[flpMessages.Controls.Count - 1]
                        : flpMessages);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void AddListingBadge(string listingTitle)
        {
            var badge = new Panel
            {
                Width = flpMessages.ClientSize.Width - 15,
                Height = 30,
                Margin = new Padding(0, 8, 0, 4),
                BackColor = Color.Transparent
            };

            badge.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw horizontal line left and right of the label
                int midY = badge.Height / 2;
                using var linePen = new Pen(Color.FromArgb(200, 200, 200), 1);
                g.DrawLine(linePen, 0, midY, badge.Width, midY);

                // Draw pill background
                string text = $"📋  {listingTitle}";
                var font = new Font("Segoe UI", 8.5f);
                var size = g.MeasureString(text, font);
                int pillW = (int)size.Width + 24;
                int pillH = 22;
                int pillX = (badge.Width - pillW) / 2;
                int pillY = (badge.Height - pillH) / 2;

                using var fill = new SolidBrush(Color.FromArgb(255, 243, 230));
                using var pen = new Pen(Color.FromArgb(255, 180, 100), 1);

                var rect = new Rectangle(pillX, pillY, pillW, pillH);
                int r = 11;
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                g.FillPath(fill, path);
                g.DrawPath(pen, path);

                TextRenderer.DrawText(g, text, font,
                    new Rectangle(pillX, pillY, pillW, pillH),
                    Color.FromArgb(180, 80, 0),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            flpMessages.Controls.Add(badge);
        }
        private void AddBubble(int msgId, string body, string time, string senderName, bool isMe)
        {
            var wrapper = new Panel
            {
                Width = flpMessages.ClientSize.Width - 15,
                AutoSize = true,
                Margin = new Padding(0, 4, 0, 4),
                BackColor = Color.Transparent,
                Tag = isMe
            };

            var lblMsg = new Label
            {
                Text = body,
                Font = new Font("Segoe UI", 10.5f),
                AutoSize = true,
                MaximumSize = new Size((int)(wrapper.Width * 0.65), 0),
                Padding = new Padding(14, 10, 14, 10),
                Cursor = Cursors.Hand,
                Tag = msgId,
                ForeColor = Color.Transparent,
                BackColor = Color.Transparent
            };

            // Time only — small, subtle, below bubble
            var lblTime = new Label
            {
                Text = time,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(160, 160, 160),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            lblMsg.Paint += (s, e) =>
            {
                var l = (Label)s;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                int r = 16;
                var rect = new Rectangle(1, 1, l.Width - 3, l.Height - 3);

                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                using (var brush = new SolidBrush(isMe
                    ? Color.FromArgb(255, 96, 0)
                    : Color.FromArgb(244, 243, 239)))
                    e.Graphics.FillPath(brush, path);

                if (!isMe)
                {
                    using var pen = new Pen(Color.FromArgb(210, 210, 210), 1);
                    e.Graphics.DrawPath(pen, path);
                }

                var textRect = new Rectangle(rect.X + 12, rect.Y + 8, rect.Width - 24, rect.Height - 16);
                TextRenderer.DrawText(e.Graphics, l.Text, l.Font, textRect,
                    isMe ? Color.White : Color.Black,
                    TextFormatFlags.WordBreak | TextFormatFlags.Left);
            };

            lblMsg.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    _selectedMessageId = (int)((Label)s).Tag;
                    ctxMessage.Show(lblMsg, e.Location);
                }
            };

            wrapper.Controls.Add(lblMsg);
            wrapper.Controls.Add(lblTime);
            wrapper.PerformLayout();

            if (isMe)
            {
                lblMsg.Left = wrapper.Width - lblMsg.Width;
                lblTime.Left = wrapper.Width - lblTime.Width;
            }
            else
            {
                lblMsg.Left = 5;
                lblTime.Left = 5;
            }

            lblMsg.Top = 0;
            lblTime.Top = lblMsg.Bottom + 2;
            wrapper.Height = lblTime.Bottom + 4;

            flpMessages.Controls.Add(wrapper);
        }

        private void MarkAsRead()
        {
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    @"UPDATE messages SET is_read=true 
              WHERE receiver_id=@uid AND sender_id=@other", conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("other", _activeReceiverId);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void txtReply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(sender, e);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_activeReceiverId < 0)
            { MessageBox.Show("Select a conversation first."); return; }

            string body = txtReply.Text.Trim();
            if (string.IsNullOrEmpty(body)) return;

            // If no listing context, find the most recent listing they talked about
            int listingIdToUse = _activeListingId;
            if (listingIdToUse <= 0)
            {
                try
                {
                    using var conn = DBHelper.GetConnection();
                    conn.Open();
                    using var cmd = new NpgsqlCommand(
                        @"SELECT listing_id FROM messages
                  WHERE (sender_id=@uid AND receiver_id=@other)
                     OR (sender_id=@other AND receiver_id=@uid)
                  ORDER BY sent_at DESC LIMIT 1", conn);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.Parameters.AddWithValue("other", _activeReceiverId);
                    var result = cmd.ExecuteScalar();
                    if (result != null) listingIdToUse = Convert.ToInt32(result);
                }
                catch { }
            }

            if (listingIdToUse <= 0)
            { MessageBox.Show("Cannot determine which listing this message is about."); return; }

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "INSERT INTO messages (sender_id, receiver_id, listing_id, body) VALUES (@s,@r,@l,@b)", conn);
                cmd.Parameters.AddWithValue("s", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("r", _activeReceiverId);
                cmd.Parameters.AddWithValue("l", listingIdToUse);
                cmd.Parameters.AddWithValue("b", body);
                cmd.ExecuteNonQuery();

                txtReply.Clear();
                LoadThread();
                LoadConversations();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

        }

        private void btnBack_Click(object sender, EventArgs e) => OnBack?.Invoke();

        private void mnuReport_Click(object sender, EventArgs e)
        {
            if (_selectedMessageId == 0) return;

            
            int messageIdToReport = _selectedMessageId;

            var result = MessageBox.Show("Report this message for inappropriate content?",
                "Report Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var conn = DBHelper.GetConnection();
                    conn.Open();

                    string flagSql = @"
                    INSERT INTO message_flags (message_id, reported_by, reason) 
                    VALUES (@mid, @uid, 'inappropriate') 
                    ON CONFLICT DO NOTHING";

                    using var cmd = new NpgsqlCommand(flagSql, conn);

                    // 2. USE THE CAPTURED ID HERE
                    cmd.Parameters.AddWithValue("mid", messageIdToReport);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Message reported to administrators.", "Success");
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }



        private void flpMessages_SizeChanged(object sender, EventArgs e)
        {
            flpMessages.SuspendLayout();

            foreach (Control ctrl in flpMessages.Controls)
            {
                if (ctrl is Panel wrapper && wrapper.Controls.Count >= 2)
                {
                    wrapper.Width = flpMessages.ClientSize.Width - 15;

                    var lblMsg = wrapper.Controls[0];
                    var lblMeta = wrapper.Controls[1];
                    bool isMe = (bool)wrapper.Tag; // We stored this flag earlier

                    lblMsg.MaximumSize = new Size((int)(wrapper.Width * 0.7), 0);

                    if (isMe)
                    {
                        lblMsg.Left = wrapper.Width - lblMsg.Width;
                        lblMeta.Left = wrapper.Width - lblMeta.Width;
                    }
                }
            }

            flpMessages.ResumeLayout();
        }

        private void lblConvTitle_Click(object sender, EventArgs e)
        {

        }
    }
    public class ConversationItem
    {
        public int OtherId { get; set; }
        public string OtherName { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastSent { get; set; }
        public int UnreadCount { get; set; }
        public int ListingId { get; set; }
    }
}
