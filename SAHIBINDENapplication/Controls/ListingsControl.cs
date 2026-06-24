using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using SAHIBINDENapplication.Models;


namespace SAHIBINDENapplication.Controls
{
    public partial class ListingsControl : UserControl
    {

        public event Action OnAddListing;
        public event Action<int> OnEditListing;
        public event Action<int> OnViewDetail;
        public event Action OnMessages;
        public event Action OnAdmin;
        public event Action OnLogout;
        public event Action OnLoginClicked;
        public event Action OnFavorites;
        public event Action OnSettings;


        private bool _showingMyListings = false;
        public ListingsControl()
        {
            InitializeComponent();
        }
        public void RefreshSessionUI()
        {
            const int TOP_OFFSET = 106;  // y position where first nav button starts
            const int BTN_HEIGHT = 44;
            int y = TOP_OFFSET;

            if (Session.IsLoggedIn)
            {
                lblWelcome.Text = $"👤 {Session.CurrentUser.Username}";
                btnLoginRegister.Visible = false;
                btnLogout.Visible = true;

                bool isAdmin = Session.IsAdmin;

                if (isAdmin)
                {
                    btnAdmin.Visible = true;
                    btnAdmin.Location = new Point(0, y); y += BTN_HEIGHT;
                    btnAdmin.ForeColor = Color.White;
                    btnAdmin.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    btnHome.Visible = true;
                    btnHome.Location = new Point(0, y); y += BTN_HEIGHT;

                    btnAdd.Visible = false;
                    btnMyListings.Visible = false;
                    btnMessages.Visible = false;
                    btnFavorites.Visible = false;
                }
                else
                {
                    // Regular user sees: Browse Listings, My Listings, Messages, Favorites, Add Listing
                    btnAdmin.Visible = false;

                    btnHome.Visible = true;
                    btnHome.Location = new Point(0, y); y += BTN_HEIGHT;

                    btnMyListings.Visible = true;
                    btnMyListings.Location = new Point(0, y); y += BTN_HEIGHT;

                    btnMessages.Visible = true;
                    btnMessages.Location = new Point(0, y); y += BTN_HEIGHT;

                    btnFavorites.Visible = true;
                    btnFavorites.Location = new Point(0, y); y += BTN_HEIGHT;

                    btnAdd.Visible = true;
                }

                btnSettings.Visible = true;
                btnSettings.Location = new Point(0, y);
                y += BTN_HEIGHT;

                // Logout always sticks right after last visible button
                btnLogout.Location = new Point(0, y);
            }
            else
            {
                // Guest
                lblWelcome.Text = "👤 Guest";
                
                btnLogout.Visible = false;
                btnAdmin.Visible = false;
                btnAdmin.BackColor = Color.FromArgb(255, 96, 0);

                


                btnHome.Visible = true;
                btnHome.Location = new Point(0, TOP_OFFSET);

                btnMyListings.Visible = true;
                btnMyListings.Location = new Point(0, TOP_OFFSET + BTN_HEIGHT);

                btnMessages.Visible = true;
                btnMessages.Location = new Point(0, TOP_OFFSET + BTN_HEIGHT * 2);

                btnFavorites.Visible = true;
                btnFavorites.Location = new Point(0, TOP_OFFSET + BTN_HEIGHT * 3);

                btnAdd.Visible = true;

                btnSettings.Visible = true;
                btnSettings.Location = new Point(0, TOP_OFFSET + BTN_HEIGHT * 4);

                btnLoginRegister.Visible = true;
                btnLoginRegister.Location = new Point(0, TOP_OFFSET + BTN_HEIGHT * 5);
            }
        }

        
        private void ListingsControl_Load(object sender, EventArgs e)
        {
            InitSidebarHovers();
            LoadCategories();
            LoadSortOptions();
            LoadListings();
            RefreshSessionUI();



            txtSearch.TextChanged += (s, ev) => LoadListings();
            cmbCategory.SelectedIndexChanged += (s, ev) => LoadListings();
            cmbSort.SelectedIndexChanged += (s, ev) => LoadListings();

            pnlSidebar.Paint += (s, e) =>
            {
                // Draw a subtle line under the logo+welcome area
                using var pen = new Pen(Color.FromArgb(50, 50, 70), 1);
                e.Graphics.DrawLine(pen, 10, 100, 190, 100);  // line at y=100, just above first button
            };


        }
        // Called by MainShell when navigating back to this control
        public void LoadListings()
        {
            _showingMyListings = false;
            RefreshSessionUI();
            RunQuery(buildMyListingsFilter: false);
        }

        private void AddSidebarHover(Button btn, Color normalColor, Color hoverColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = normalColor;
        }

        private void InitSidebarHovers()
        {
            Color normal = Color.FromArgb(26, 26, 46);
            Color hover = Color.FromArgb(45, 45, 75);

            btnHome.BackColor = normal;
            btnMyListings.BackColor = normal;
            btnMessages.BackColor = normal;
            btnFavorites.BackColor = normal;
            btnLoginRegister.BackColor = normal;
            btnLogout.BackColor = normal;
            btnSettings.BackColor = normal;

            AddSidebarHover(btnSettings, normal, hover);
            AddSidebarHover(btnHome, normal, hover);
            AddSidebarHover(btnMyListings, normal, hover);
            AddSidebarHover(btnMessages, normal, hover);
            AddSidebarHover(btnFavorites, normal, hover);
            AddSidebarHover(btnLoginRegister, normal, hover);
            AddSidebarHover(btnLogout, normal, Color.FromArgb(80, 20, 20));

            btnAdmin.BackColor = Color.FromArgb(255, 96, 0);
            btnAdmin.MouseEnter += (s, e) => btnAdmin.BackColor = Color.FromArgb(220, 80, 0);
            btnAdmin.MouseLeave += (s, e) => btnAdmin.BackColor = Color.FromArgb(255, 96, 0);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("-- Filter by Category --");
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("SELECT id, name FROM categories ORDER BY name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbCategory.Items.Add(new Category { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            catch { }
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadSortOptions()
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add("-- Sort By --");
            cmbSort.Items.AddRange(new object[]
            {
            "Newest First", "Oldest First",
            "Price: Low to High", "Price: High to Low", "Most Viewed"
            });
            cmbSort.SelectedIndex = 0;
        }

        private void PopulateCards(List<Listing> listings)
        {
            flpListings.Controls.Clear();

            if (listings.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No listings found.",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flpListings.Controls.Add(lbl);
                return;
            }

            flpListings.SuspendLayout();
            foreach (var listing in listings)
                flpListings.Controls.Add(BuildCard(listing));
            flpListings.ResumeLayout();
        }

        private Panel BuildCard(Listing listing)
        {
            var card = new Panel
            {
                Width = 195,
                Height = 260,
                Margin = new Padding(8),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = listing.Id
            };

            card.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 220, 220), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            // ── Cover image ──────────────────────────────────────
            var pic = new PictureBox
            {
                Width = 195,
                Height = 140,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            if (!string.IsNullOrEmpty(listing.CoverImagePath) && File.Exists(listing.CoverImagePath))
            {
                try { pic.Image = Image.FromFile(listing.CoverImagePath); }
                catch { }
            }

            if (pic.Image == null)
            {
                // Gray placeholder with camera icon feel
                pic.BackColor = Color.FromArgb(220, 220, 220);
            }

            // ── City + Category badge ─────────────────────────────
            var lblBadge = new Label
            {
                Text = $"{listing.City}  ·  {listing.CategoryName}",
                Location = new Point(8, 148),
                Width = 179,
                Height = 18,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                AutoEllipsis = true
            };

            // ── Title ─────────────────────────────────────────────
            var lblTitle = new Label
            {
                Text = listing.Title,
                Location = new Point(8, 167),
                Width = 179,
                Height = 34,
                Font = new Font("Segoe UI", 9f, FontStyle.Regular),
                ForeColor = Color.FromArgb(25, 25, 25),
                AutoEllipsis = true
            };

            // ── Price ─────────────────────────────────────────────
            var lblPrice = new Label
            {
                Text = listing.PriceFormatted,
                Location = new Point(8, 203),
                Width = 179,
                Height = 26,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 85, 0)
            };

            // ── Time ago (small, bottom-right) ───────────────────
            var lblTime = new Label
            {
                Text = listing.TimeAgo,
                Location = new Point(8, 238),
                Width = 179,
                Height = 16,
                Font = new Font("Segoe UI", 7f),
                ForeColor = Color.FromArgb(180, 180, 180),
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblBadge);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblTime);

            // ── Click: open detail ────────────────────────────────
            EventHandler onClick = (s, e) => OnViewDetail?.Invoke((int)card.Tag);
            card.Click += onClick;
            pic.Click += onClick;
            lblTitle.Click += onClick;
            lblPrice.Click += onClick;
            lblBadge.Click += onClick;

            // ── Hover highlight ───────────────────────────────────
            Action setHover = () => { card.BackColor = Color.FromArgb(255, 248, 240); };
            Action clearHover = () => { card.BackColor = Color.White; };

            foreach (Control c in new Control[] { card, pic, lblTitle, lblPrice, lblBadge, lblTime })
            {
                c.MouseEnter += (s, e) => setHover();
                c.MouseLeave += (s, e) => clearHover();
            }

            return card;
        }
        private void RunQuery(bool buildMyListingsFilter)
        {
            var conditions = new List<string>();
            var parameters = new Dictionary<string, object>();

            if (buildMyListingsFilter)
            {
                conditions.Add("l.user_id = @uid");
                parameters["uid"] = Session.CurrentUser.Id;
            }
            else
            {
                conditions.Add("l.status = 'active'");

                string search = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(search) && !search.StartsWith("🔍"))
                {
                    conditions.Add("l.title ILIKE @search");
                    parameters["search"] = $"%{search}%";
                }

                if (cmbCategory.SelectedItem is Category cat)
                {
                    conditions.Add("l.category_id = @catId");
                    parameters["catId"] = cat.Id;
                }

                if (nudMinPrice.Value > 0)
                {
                    conditions.Add("l.price >= @minPrice");
                    parameters["minPrice"] = nudMinPrice.Value;
                }

                if (nudMaxPrice.Value < nudMaxPrice.Maximum)
                {
                    conditions.Add("l.price <= @maxPrice");
                    parameters["maxPrice"] = nudMaxPrice.Value;
                }
            }

            string orderBy = cmbSort.SelectedIndex switch
            {
                1 => "l.created_at ASC",
                2 => "l.price ASC",
                3 => "l.price DESC",
                4 => "l.view_count DESC",
                _ => "l.created_at DESC"
            };

            string where = string.Join(" AND ", conditions);
            string sql = $@"
            SELECT l.id, l.title, l.price, l.city, c.name,
               l.condition, l.status, l.view_count, l.created_at, u.full_name,
               (SELECT image_path FROM listing_images
                WHERE listing_id = l.id AND is_cover = TRUE
                LIMIT 1) AS cover_image
                FROM listings l
                JOIN categories c ON c.id = l.category_id
                JOIN users u ON u.id = l.user_id
                WHERE {where}
                ORDER BY {orderBy}";

            var listings = new List<Listing>();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue(p.Key, p.Value);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listings.Add(new Listing
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        City = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        CategoryName = reader.GetString(4),
                        Condition = reader.GetString(5),
                        Status = reader.GetString(6),
                        ViewCount = reader.GetInt32(7),
                        CreatedAt = reader.GetDateTime(8),
                        OwnerName = reader.GetString(9),
                        CoverImagePath = reader.IsDBNull(10) ? null : reader.GetString(10)
                    });
                }

                lblCount.Text = $"{listings.Count} listing{(listings.Count != 1 ? "s" : "")} found";
                tsslInfo.Text = Session.IsLoggedIn
                    ? $"Logged in as: {Session.CurrentUser.Username} | {DateTime.Now:dd MMM yyyy}"
                    : $"Browsing as Guest | {DateTime.Now:dd MMM yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            PopulateCards(listings);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void btnSearch_Click(object sender, EventArgs e) => LoadListings();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            nudMinPrice.Value = 0;
            nudMaxPrice.Value = nudMaxPrice.Maximum;
            LoadListings();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MainShell.Instance.RequireLogin("add listings")) return;

            if (Session.IsAdmin)
            {
                MessageBox.Show(
                    "Admin accounts cannot create listings.\n" +
                    "Please use a regular user account to buy and sell.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            OnAddListing?.Invoke();
        }



        private void btnMessages_Click(object sender, EventArgs e) => OnMessages?.Invoke();


        private void btnAdmin_Click(object sender, EventArgs e) => OnAdmin?.Invoke();

        private void btnMyListings_Click(object sender, EventArgs e)
        {
            if (MainShell.Instance.RequireLogin("view your listings")) return;
            _showingMyListings = true;
            RunQuery(buildMyListingsFilter: true);
        }

        private void btnHome_Click(object sender, EventArgs e) => LoadListings();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) OnLogout?.Invoke();
        }
        public void ReloadForUser()
        {
            lblWelcome.Text = $"👤 {Session.CurrentUser?.FullName}";
            btnAdmin.Visible = Session.IsAdmin;
            LoadListings();
        }

        public void Reset()
        {
            txtSearch.Clear();
            nudMinPrice.Value = 0;
            nudMaxPrice.Value = 99999999;
            cmbCategory.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlFilters_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFavorites_Click(object sender, EventArgs e) => OnFavorites?.Invoke();

        private void btnLoginRegister_Click(object sender, EventArgs e) => OnLoginClicked?.Invoke();

        private void ListingsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                RefreshSessionUI();
        }
        private void btnSettings_Click(object sender, EventArgs e) => OnSettings?.Invoke();
    }
}
