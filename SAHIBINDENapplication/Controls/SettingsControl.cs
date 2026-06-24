using Npgsql;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SAHIBINDENapplication.Controls
{
    public partial class SettingsControl : UserControl
    {
        public event Action OnBack;

        // Color palette
        private static readonly Color NavBg = Color.FromArgb(30, 30, 50);
        private static readonly Color NavHover = Color.FromArgb(50, 50, 75);
        private static readonly Color NavActive = Color.FromArgb(255, 96, 0);
        private static readonly Color AccentOrange = Color.FromArgb(255, 96, 0);
        private static readonly Color DarkBlue = Color.FromArgb(26, 26, 46);
        private static readonly Color PageBg = Color.FromArgb(245, 245, 248);
        private static readonly Color CardBg = Color.White;
        private static readonly Color BorderColor = Color.FromArgb(220, 220, 230);
        private static readonly Color TextDark = Color.FromArgb(25, 25, 40);
        private static readonly Color TextMuted = Color.FromArgb(140, 140, 160);

        
        private readonly (string icon, string label, string key)[] _navItems =
        {
            ("👤", "Profile",          "profile"),
            ("🔒", "Password",         "password"),
            ("🛡", "Privacy",          "privacy")
        };

        private string _activeSection = "profile";

        public SettingsControl()
        {
            InitializeComponent();

            this.VisibleChanged += SettingsControl_VisibleChanged;
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            BuildNav();
            ShowSection("profile");
        }



        private void SettingsControl_VisibleChanged(object sender, EventArgs e)
        {
            
            if (this.Visible && Session.CurrentUser != null)
            {
                ShowSection(_activeSection);
            }
        }
        // ─── NAV ───────────────────────────────────────────────────────────────

        private void BuildNav()
        {
            pnlNav.Controls.Clear();

            // Nav header
            var header = new Label
            {
                Text = "SETTINGS",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 130),
                Location = new Point(20, 20),
                Size = new Size(180, 18),
                BackColor = Color.Transparent
            };
            pnlNav.Controls.Add(header);

            int y = 52;
            foreach (var item in _navItems)
            {
                var navBtn = BuildNavItem(item.icon, item.label, item.key);
                navBtn.Location = new Point(0, y);
                pnlNav.Controls.Add(navBtn);
                y += 52;
            }
        }

        private Panel BuildNavItem(string icon, string label, string sectionKey)
        {
            bool isActive = _activeSection == sectionKey;

            var row = new Panel
            {
                Size = new Size(220, 48),
                BackColor = isActive ? NavActive : NavBg,
                Cursor = Cursors.Hand,
                Tag = sectionKey
            };

            // Active indicator bar (left edge)
            row.Paint += (s, e) =>
            {
                if ((string)row.Tag == _activeSection)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using var brush = new SolidBrush(Color.White);
                    e.Graphics.FillRectangle(brush, 0, 10, 4, 28);
                }
            };

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 14f),
                ForeColor = Color.White,
                Location = new Point(16, 9),
                Size = new Size(32, 30),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblText = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10f, (string)row.Tag == _activeSection ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(54, 14),
                Size = new Size(150, 20),
                BackColor = Color.Transparent
            };

            row.Controls.Add(lblIcon);
            row.Controls.Add(lblText);

            // Hover + click
            Action<bool> setHover = (on) =>
            {
                if ((string)row.Tag != _activeSection)
                    row.BackColor = on ? NavHover : NavBg;
            };

            foreach (Control c in new Control[] { row, lblIcon, lblText })
            {
                c.MouseEnter += (s, e) => setHover(true);
                c.MouseLeave += (s, e) => setHover(false);
                c.Click += (s, e) => ShowSection((string)row.Tag);
            }

            return row;
        }

        private void ShowSection(string key)
        {
            _activeSection = key;
            BuildNav(); // redraw nav with new active state

            pnlContent.Controls.Clear();

            switch (key)
            {
                case "profile": BuildProfileSection(); break;
                case "password": BuildPasswordSection(); break;
                case "privacy": BuildPrivacySection(); break;
            }
        }

        // ─── SHARED HELPERS ────────────────────────────────────────────────────

        private Panel MakeCard(string title, int yOffset = 0)
        {
            var card = new Panel
            {
                BackColor = CardBg,
                Padding = new Padding(28, 20, 28, 20),
                Location = new Point(0, yOffset),
                Width = pnlContent.ClientSize.Width - pnlContent.Padding.Left - pnlContent.Padding.Right,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);

                // Subtle top-left accent bar
                using var accent = new SolidBrush(AccentOrange);
                e.Graphics.FillRectangle(accent, 0, 0, 4, card.Height);
            };

            if (!string.IsNullOrEmpty(title))
            {
                var lbl = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    ForeColor = DarkBlue,
                    Location = new Point(28, 16),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                card.Controls.Add(lbl);
            }

            return card;
        }

        private TextBox MakeField(string placeholder, bool password = false)
        {
            return new TextBox
            {
                PlaceholderText = placeholder,
                Font = new Font("Segoe UI", 10.5f),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 30,
                PasswordChar = password ? '●' : '\0',
                BackColor = Color.FromArgb(252, 252, 255)
            };
        }

        private Label MakeFieldLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 100),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private Button MakePrimaryButton(string text, int width = 160)
        {
            var btn = new Button
            {
                Text = text,
                Width = width,
                Height = 38,
                BackColor = AccentOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(220, 80, 0);
            btn.MouseLeave += (s, e) => btn.BackColor = AccentOrange;
            return btn;
        }

        private Label MakeStatus() => new Label
        {
            AutoSize = false,
            Height = 22,
            Font = new Font("Segoe UI", 9f, FontStyle.Bold),
            BackColor = Color.Transparent,
            ForeColor = Color.Green
        };

        private void SetStatus(Label lbl, string msg, bool success)
        {
            lbl.ForeColor = success ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 0, 0);
            lbl.Text = msg;
        }

        // ─── SECTION: PROFILE ──────────────────────────────────────────────────

        private void BuildProfileSection()
        {
            var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            pnlContent.Controls.Add(scroll);

            // Page title
            var pageTitle = new Label
            {
                Text = "👤  Profile Information",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = DarkBlue,
                AutoSize = true,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            scroll.Controls.Add(pageTitle);

            var sub = new Label
            {
                Text = "Update your personal details. These are visible to other users on listings.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                AutoSize = true,
                Location = new Point(0, 32),
                BackColor = Color.Transparent
            };
            scroll.Controls.Add(sub);

            // Avatar card
            var avatarCard = MakeCard("", 70);
            avatarCard.Height = 100;
            scroll.Controls.Add(avatarCard);

            var avatarCircle = new Panel
            {
                Size = new Size(64, 64),
                Location = new Point(28, 18),
                BackColor = Color.Transparent
            };
            string initials = Session.CurrentUser?.FullName?.Length > 0
                ? Session.CurrentUser.FullName[0].ToString().ToUpper() : "?";
            avatarCircle.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var bg = new SolidBrush(AccentOrange);
                e.Graphics.FillEllipse(bg, 0, 0, 63, 63);
                TextRenderer.DrawText(e.Graphics, initials,
                    new Font("Segoe UI", 22, FontStyle.Bold),
                    new Rectangle(0, 0, 64, 64), Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
            avatarCard.Controls.Add(avatarCircle);

            var lblUserHandle = new Label
            {
                Text = $"@{Session.CurrentUser?.Username}",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = DarkBlue,
                Location = new Point(106, 18),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            var lblUserRole = new Label
            {
                Text = Session.IsAdmin ? "🔧 Administrator" : "Regular Member",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Session.IsAdmin ? AccentOrange : TextMuted,
                Location = new Point(106, 44),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            avatarCard.Controls.Add(lblUserHandle);
            avatarCard.Controls.Add(lblUserRole);

            // Fields card
            var fieldsCard = MakeCard("Personal Details", 190);
            fieldsCard.Height = 320;
            scroll.Controls.Add(fieldsCard);

            // Reduced sizes and offsets to prevent cut-offs
            int fxLeft = 28;
            int fxRight = 350;
            int colWidth = 280;
            int fy = 50;

            var lblFN = MakeFieldLabel("Full Name");
            lblFN.Location = new Point(fxLeft, fy); fieldsCard.Controls.Add(lblFN);
            var txtFN = MakeField("Full Name");
            txtFN.Location = new Point(fxLeft, fy + 22); txtFN.Width = colWidth; fieldsCard.Controls.Add(txtFN);

            var lblEmail = MakeFieldLabel("Email Address");
            lblEmail.Location = new Point(fxRight, fy); fieldsCard.Controls.Add(lblEmail);
            var txtEmail = MakeField("Email Address");
            txtEmail.Location = new Point(fxRight, fy + 22); txtEmail.Width = colWidth; fieldsCard.Controls.Add(txtEmail);

            fy += 80;
            var lblPhone = MakeFieldLabel("Phone Number");
            lblPhone.Location = new Point(fxLeft, fy); fieldsCard.Controls.Add(lblPhone);
            var txtPhone = MakeField("e.g. 0532 123 45 67");
            txtPhone.Location = new Point(fxLeft, fy + 22); txtPhone.Width = colWidth; fieldsCard.Controls.Add(txtPhone);

            var lblCity = MakeFieldLabel("City");
            lblCity.Location = new Point(fxRight, fy); fieldsCard.Controls.Add(lblCity);
            var cmbCity = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10f),
                Location = new Point(fxRight, fy + 22),
                Width = colWidth
            };
            string[] cities = { "Adana","Adıyaman","Afyonkarahisar","Ağrı","Aksaray","Amasya","Ankara","Antalya",
                "Ardahan","Artvin","Aydın","Balıkesir","Bartın","Batman","Bayburt","Bilecik",
                "Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankırı","Çorum",
                "Denizli","Diyarbakır","Düzce","Edirne","Elazığ","Erzincan","Erzurum",
                "Eskişehir","Gaziantep","Giresun","Gümüşhane","Hakkari","Hatay","Iğdır",
                "Isparta","Istanbul","Izmir","Kahramanmaraş","Karabük","Karaman","Kars",
                "Kastamonu","Kayseri","Kırıkkale","Kırklareli","Kırşehir","Kilis","Kocaeli",
                "Konya","Kütahya","Malatya","Manisa","Mardin","Mersin","Muğla","Muş",
                "Nevşehir","Niğde","Ordu","Osmaniye","Rize","Sakarya","Samsun","Siirt",
                "Sinop","Sivas","Şanlıurfa","Şırnak","Tekirdağ","Tokat","Trabzon","Tunceli",
                "Uşak","Van","Yalova","Yozgat","Zonguldak" };
            cmbCity.Items.AddRange(cities);
            fieldsCard.Controls.Add(cmbCity);

            // Pre-fill from DB
            try
            {
                using var conn = DBHelper.GetConnection(); conn.Open();
                using var cmd = new NpgsqlCommand(
                    "SELECT full_name, email, phone, city FROM users WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", Session.CurrentUser.Id);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    txtFN.Text = r.IsDBNull(0) ? "" : r.GetString(0);
                    txtEmail.Text = r.IsDBNull(1) ? "" : r.GetString(1);
                    txtPhone.Text = r.IsDBNull(2) ? "" : r.GetString(2);
                    string city = r.IsDBNull(3) ? "" : r.GetString(3);
                    if (cmbCity.Items.Contains(city)) cmbCity.SelectedItem = city;
                }
            }
            catch { }

            fy += 80;
            var statusLbl = MakeStatus();
            statusLbl.Location = new Point(fxLeft, fy + 10);
            statusLbl.Width = 300;
            fieldsCard.Controls.Add(statusLbl);

            var btnSave = MakePrimaryButton("💾  Save Changes", 200);
            btnSave.Location = new Point(fxRight + 80, fy);
            fieldsCard.Controls.Add(btnSave);

            btnSave.Click += (s, e) =>
            {
                string fn = txtFN.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string city = cmbCity.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(fn))
                { SetStatus(statusLbl, "⚠ Full name is required.", false); return; }
                if (!email.Contains("@") || !email.Contains("."))
                { SetStatus(statusLbl, "⚠ Invalid email address.", false); return; }

                try
                {
                    using var conn = DBHelper.GetConnection(); conn.Open();
                    using var cmd = new NpgsqlCommand(
                        "UPDATE users SET full_name=@fn, email=@e, phone=@ph, city=@c WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("fn", fn);
                    cmd.Parameters.AddWithValue("e", email);
                    cmd.Parameters.AddWithValue("ph", string.IsNullOrEmpty(phone) ? DBNull.Value : (object)phone);
                    cmd.Parameters.AddWithValue("c", city);
                    cmd.Parameters.AddWithValue("id", Session.CurrentUser.Id);
                    cmd.ExecuteNonQuery();

                    Session.CurrentUser.FullName = fn;
                    Session.CurrentUser.Email = email;
                    Session.CurrentUser.Phone = phone;
                    Session.CurrentUser.City = city;

                    SetStatus(statusLbl, "✔ Profile updated successfully!", true);
                }
                catch (Exception ex) { SetStatus(statusLbl, "Error: " + ex.Message, false); }
            };
        }

        // ─── SECTION: PASSWORD ─────────────────────────────────────────────────

        private void BuildPasswordSection()
        {
            var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            pnlContent.Controls.Add(scroll);

            var pageTitle = new Label
            {
                Text = "🔒  Change Password",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = DarkBlue,
                AutoSize = true,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            scroll.Controls.Add(pageTitle);

            var card = MakeCard("Security", 60);
            card.Height = 340;
            scroll.Controls.Add(card);

            int fx = 28, fy = 50;
            int colWidth = 340;

            var lblCurrent = MakeFieldLabel("Current Password");
            lblCurrent.Location = new Point(fx, fy); card.Controls.Add(lblCurrent);
            var txtCurrent = MakeField("Enter current password", true);
            txtCurrent.Location = new Point(fx, fy + 22); txtCurrent.Width = colWidth; card.Controls.Add(txtCurrent);

            fy += 78;
            var lblNew = MakeFieldLabel("New Password");
            lblNew.Location = new Point(fx, fy); card.Controls.Add(lblNew);
            var txtNew = MakeField("Min 8 chars, letters + numbers", true);
            txtNew.Location = new Point(fx, fy + 22); txtNew.Width = colWidth; card.Controls.Add(txtNew);

            fy += 78;
            var lblConfirm = MakeFieldLabel("Confirm New Password");
            lblConfirm.Location = new Point(fx, fy); card.Controls.Add(lblConfirm);
            var txtConfirm = MakeField("Re-enter new password", true);
            txtConfirm.Location = new Point(fx, fy + 22); txtConfirm.Width = colWidth; card.Controls.Add(txtConfirm);

            fy += 78;
            var statusLbl = MakeStatus();
            statusLbl.Location = new Point(fx, fy + 10); statusLbl.Width = 300;
            card.Controls.Add(statusLbl);

            var btnChange = MakePrimaryButton("🔒  Update Password", 200);
            btnChange.Location = new Point(360, fy - 10);
            card.Controls.Add(btnChange);

            btnChange.Click += (s, e) =>
            {
                string current = txtCurrent.Text.Trim();
                string newPwd = txtNew.Text.Trim();
                string confirm = txtConfirm.Text.Trim();

                if (string.IsNullOrEmpty(current))
                { SetStatus(statusLbl, "⚠ Enter your current password.", false); return; }
                if (newPwd.Length < 8 || !newPwd.Any(char.IsLetter) || !newPwd.Any(char.IsDigit))
                { SetStatus(statusLbl, "⚠ New password: min 8 chars, letters + numbers.", false); return; }
                if (newPwd != confirm)
                { SetStatus(statusLbl, "⚠ Passwords do not match.", false); return; }

                try
                {
                    using var conn = DBHelper.GetConnection(); conn.Open();
                    // Verify current
                    using var check = new NpgsqlCommand("SELECT password FROM users WHERE id=@id", conn);
                    check.Parameters.AddWithValue("id", Session.CurrentUser.Id);
                    string hash = (string)check.ExecuteScalar();
                    if (!PasswordHelper.Verify(current, hash))
                    { SetStatus(statusLbl, "⚠ Current password is incorrect.", false); return; }

                    // Update
                    using var update = new NpgsqlCommand("UPDATE users SET password=@p WHERE id=@id", conn);
                    update.Parameters.AddWithValue("p", PasswordHelper.Hash(newPwd));
                    update.Parameters.AddWithValue("id", Session.CurrentUser.Id);
                    update.ExecuteNonQuery();

                    txtCurrent.Clear(); txtNew.Clear(); txtConfirm.Clear();
                    SetStatus(statusLbl, "✔ Password changed successfully!", true);
                }
                catch (Exception ex) { SetStatus(statusLbl, "Error: " + ex.Message, false); }
            };
        }



        // ─── SECTION: PRIVACY ──────────────────────────────────────────────────

        private void BuildPrivacySection()
        {
            var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            pnlContent.Controls.Add(scroll);

            var pageTitle = new Label
            {
                Text = "🛡  Privacy Settings",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = DarkBlue,
                AutoSize = true,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            scroll.Controls.Add(pageTitle);

            var dangerCard = MakeCard("Account Management", 60);
            dangerCard.Height = 130;
            dangerCard.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(255, 80, 80), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, dangerCard.Width - 1, dangerCard.Height - 1);
                using var accent = new SolidBrush(Color.FromArgb(192, 0, 0));
                e.Graphics.FillRectangle(accent, 0, 0, 4, dangerCard.Height);
            };
            scroll.Controls.Add(dangerCard);

            var lblWarn = new Label
            {
                Text = "Deleting your account is permanent. All your listings, messages, and favorites will be removed immediately.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(150, 30, 30),
                Location = new Point(28, 50),
                Size = new Size(600, 40),
                BackColor = Color.Transparent
            };
            dangerCard.Controls.Add(lblWarn);

            var btnDelete = new Button
            {
                Text = "🗑  Delete My Account",
                Width = 200,
                Height = 36,
                Location = new Point(28, 82),
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = Color.FromArgb(160, 0, 0);
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnDelete.Click += (s, e) =>
            {
                var r = MessageBox.Show(
                    "This will permanently delete your account, all listings, messages, and favorites.\n\nThis action cannot be undone. Are you absolutely sure?",
                    "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) return;

                try
                {
                    using var conn = DBHelper.GetConnection(); conn.Open();
                    using var cmd = new NpgsqlCommand("DELETE FROM users WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("id", Session.CurrentUser.Id);
                    cmd.ExecuteNonQuery();
                    Session.Logout();
                    OnBack?.Invoke();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            };


            if (Session.IsAdmin)
            {
                lblWarn.Text = "Administrator accounts cannot be deleted for security and audit logging purposes. You must be demoted to a regular user first.";
                btnDelete.Visible = false;
            }
            dangerCard.Controls.Add(btnDelete);
        }

        

        private void btnBack_Click(object sender, EventArgs e) => OnBack?.Invoke();
    }
}