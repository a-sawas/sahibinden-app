using Npgsql;
using SAHIBINDENapplication.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAHIBINDENapplication.Controls
{
    public partial class FavoritesControl : UserControl
    {
        public event Action OnBack;
        public event Action<int> OnViewListing;
        public FavoritesControl()
        {
            InitializeComponent();
        }
        private void PopulateCards(List<Listing> listings)
        {
            flpListings.Controls.Clear();

            if (listings.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No favorites yet.",
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
                BackColor = listing.Status == "active" ? Color.White : Color.FromArgb(245, 245, 245),
                Cursor = Cursors.Hand,
                Tag = listing.Id
            };

            card.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 220, 220), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            var pic = new PictureBox
            {
                Width = 195,
                Height = 140,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(220, 220, 220)
            };

            if (!string.IsNullOrEmpty(listing.CoverImagePath) && File.Exists(listing.CoverImagePath))
            {
                try { pic.Image = Image.FromFile(listing.CoverImagePath); }
                catch { }
            }

            // Gray overlay effect for inactive listings
            if (listing.Status != "active")
            {
                pic.BackColor = Color.FromArgb(200, 200, 200);
            }

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

            var lblTitle = new Label
            {
                Text = listing.Status != "active" ? $"[{listing.Status.ToUpper()}] {listing.Title}" : listing.Title,
                Location = new Point(8, 167),
                Width = 179,
                Height = 34,
                Font = listing.Status != "active"
                            ? new Font("Segoe UI", 9f, FontStyle.Strikeout)
                            : new Font("Segoe UI", 9f),
                ForeColor = listing.Status != "active" ? Color.Gray : Color.FromArgb(25, 25, 25),
                AutoEllipsis = true
            };

            var lblPrice = new Label
            {
                Text = listing.PriceFormatted,
                Location = new Point(8, 203),
                Width = 179,
                Height = 26,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = listing.Status != "active" ? Color.Gray : Color.FromArgb(220, 85, 0)
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

            EventHandler onClick = (s, e) =>
            {
                if (listing.Status != "active")
                {
                    MessageBox.Show("This listing is no longer active.", "Unavailable",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                OnViewListing?.Invoke((int)card.Tag);
            };

            card.Click += onClick;
            pic.Click += onClick;
            lblTitle.Click += onClick;
            lblPrice.Click += onClick;

            Action setHover = () => { if (listing.Status == "active") card.BackColor = Color.FromArgb(255, 248, 240); };
            Action clearHover = () => { card.BackColor = listing.Status == "active" ? Color.White : Color.FromArgb(245, 245, 245); };

            foreach (Control c in new Control[] { card, pic, lblTitle, lblPrice, lblBadge })
            {
                c.MouseEnter += (s, e) => setHover();
                c.MouseLeave += (s, e) => clearHover();
            }

            return card;
        }
        private void FavoritesControl_Load(object sender, EventArgs e)
        {
            LoadFavorites();
        }
        public void LoadFavorites()
        {
            var listings = new List<Listing>();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
            SELECT l.id, l.title, l.price, l.city, c.name,
                   l.condition, l.status, l.view_count, l.created_at,
                   u.full_name, f.id AS fav_id,
                   (SELECT image_path FROM listing_images
                    WHERE listing_id = l.id AND is_cover = TRUE
                    LIMIT 1) AS cover_image
                    FROM favorites f
                    JOIN listings l ON l.id = f.listing_id
                    JOIN categories c ON c.id = l.category_id
                    JOIN users u ON u.id = l.user_id
                    WHERE f.user_id = @uid
                    ORDER BY f.saved_at DESC";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
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
                        CoverImagePath = reader.IsDBNull(11) ? null : reader.GetString(11)
                    });
                }

                lblCount.Text = listings.Count == 0
                    ? "You have no saved favorites yet."
                    : $"{listings.Count} saved listing{(listings.Count != 1 ? "s" : "")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading favorites: " + ex.Message);
                return;
            }

            PopulateCards(listings);
        }

        

        
        
        

        private void btnBack_Click(object sender, EventArgs e) => OnBack?.Invoke();

    }
}
