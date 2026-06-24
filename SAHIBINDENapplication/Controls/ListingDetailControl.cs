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
using SAHIBINDENapplication.Models;



namespace SAHIBINDENapplication.Controls
{
    public partial class ListingDetailControl : UserControl
    {
        public event Action OnBack;
        public event Action<int> OnEdit;
        public event Action<int, int> OnMessage;
        public event Action OnBackToFavorites;
        private string _source = "listings";
        public event Action OnFavoriteClicked;
        private List<string> _imageList = new List<string>();
        private int _currentImageIndex = 0;



        private Listing _listing;
        public ListingDetailControl()
        {
            InitializeComponent();
        }

        private void LoadAllImages(int listingId)
        {
            _imageList.Clear();
            _currentImageIndex = 0;

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "SELECT image_path FROM listing_images " +
                    "WHERE listing_id = @id ORDER BY is_cover DESC", conn);
                cmd.Parameters.AddWithValue("id", listingId);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string path = reader.GetString(0);
                    if (File.Exists(path))
                        _imageList.Add(path);
                }
            }
            catch { }

            ShowCurrentImage();
        }

        private void ShowCurrentImage()
        {
            picMain.Image = null;

            if (_imageList.Count == 0)
            {
                btnPrevImage.Visible = false;
                btnNextImage.Visible = false;
                lblImageCount.Text = "";
                return;
            }

            try
            {
                using var stream = new FileStream(
                    _imageList[_currentImageIndex], FileMode.Open, FileAccess.Read);
                var original = Image.FromStream(stream);
                picMain.Image = new Bitmap(original, picMain.Size);
                original.Dispose();
            }
            catch { }

            // Show arrows only if more than one image
            btnPrevImage.Visible = _imageList.Count > 1;
            btnNextImage.Visible = _imageList.Count > 1;
            lblImageCount.Text = $"{_currentImageIndex + 1} / {_imageList.Count}";
        }

        public void LoadListing(int listingId, string source = "listings")
        {
            _source = source;
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = @"
                    SELECT l.id, l.title, l.description, l.price, l.city,
                           c.name, l.condition, l.view_count, l.created_at,
                           u.full_name, u.phone, l.user_id
                    FROM listings l
                    JOIN categories c ON c.id = l.category_id
                    JOIN users u ON u.id = l.user_id
                    WHERE l.id = @id";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", listingId);
                using var reader = cmd.ExecuteReader();

                if (!reader.Read()) return;

                _listing = new Listing
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    City = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    CategoryName = reader.GetString(5),
                    Condition = reader.GetString(6),
                    ViewCount = reader.GetInt32(7),
                    CreatedAt = reader.GetDateTime(8),
                    OwnerName = reader.GetString(9),
                    UserId = reader.GetInt32(11)
                };

                lblTitle.Text = _listing.Title;
                lblPrice.Text = "💰 " + _listing.PriceFormatted;
                lblCity.Text = "📍 " + _listing.City;
                lblCategory.Text = "📂 " + _listing.CategoryName;
                lblCondition.Text = "🔖 " + _listing.Condition;
                lblViews.Text = "👁 " + _listing.ViewCount + " views";
                lblPostedBy.Text = "👤 " + _listing.OwnerName;
                lblDate.Text = "📅 " + _listing.TimeAgo;
                rtbDescription.Text = _listing.Description;

                picMain.Image = null;
                _imageList.Clear();
                _currentImageIndex = 0;

                bool isOwner = Session.IsLoggedIn && _listing.UserId == Session.CurrentUser.Id;
                bool isAdmin = Session.IsLoggedIn && Session.IsAdmin;

                // Admins and owners can see Edit/Delete
                btnEdit.Visible = isOwner || isAdmin;
                btnDelete.Visible = isOwner || isAdmin;

                // ONLY regular users looking at someone else's listing can see Message/Favorite
                btnMessage.Visible = !isOwner && !isAdmin;
                btnFavorite.Visible = !isOwner && !isAdmin;


                IncrementViewCount(listingId);
                CheckIfFavorited(listingId);
                LoadAllImages(listingId);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void IncrementViewCount(int id)
        {
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "UPDATE listings SET view_count=view_count+1 WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void CheckIfFavorited(int id)
        {
            if (!Session.IsLoggedIn) return;
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM favorites WHERE user_id=@uid AND listing_id=@lid", conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                cmd.Parameters.AddWithValue("lid", id);
                long count = (long)cmd.ExecuteScalar();
                btnFavorite.Text = count > 0 ? "❤ Saved" : "🤍 Save";
            }
            catch { }
        }
        private void ListingDetailControl_Load(object sender, EventArgs e)
        {

        }
        // Made public so MainShell can call it after login check
        public void ToggleFavorite()
        {
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                if (btnFavorite.Text.Contains("🤍"))
                {
                    using var cmd = new NpgsqlCommand(
                        "INSERT INTO favorites (user_id, listing_id) " +
                        "VALUES (@uid, @lid) ON CONFLICT DO NOTHING", conn);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.Parameters.AddWithValue("lid", _listing.Id);
                    cmd.ExecuteNonQuery();
                    btnFavorite.Text = "❤ Saved";
                }
                else
                {
                    using var cmd = new NpgsqlCommand(
                        "DELETE FROM favorites " +
                        "WHERE user_id=@uid AND listing_id=@lid", conn);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.Parameters.AddWithValue("lid", _listing.Id);
                    cmd.ExecuteNonQuery();
                    btnFavorite.Text = "🤍 Save";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                OnFavoriteClicked?.Invoke();
                return;
            }

            ToggleFavorite();
        }

        private void btnEdit_Click(object sender, EventArgs e) => OnEdit?.Invoke(_listing.Id);


        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_source == "favorites")
                OnBackToFavorites?.Invoke();
            else
                OnBack?.Invoke();
        }

        private void btnMessage_Click(object sender, EventArgs e) => OnMessage?.Invoke(_listing.UserId, _listing.Id);

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Delete this listing?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("DELETE FROM listings WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", _listing.Id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("✔ Listing deleted.");
                OnBack?.Invoke();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void lblViews_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (_imageList.Count == 0) return;
            _currentImageIndex = (_currentImageIndex - 1 + _imageList.Count) % _imageList.Count;
            ShowCurrentImage();
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (_imageList.Count == 0) return;
            _currentImageIndex = (_currentImageIndex + 1) % _imageList.Count;
            ShowCurrentImage();
        }
    }
}
