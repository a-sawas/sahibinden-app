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
    public partial class AddEditControl : UserControl
    {
        public event Action OnSaved;
        public event Action OnCancelled;
        public event Action<int> OnSavedFromDetail;
        public event Action<int> OnCancelledFromDetail;
        private bool _cameFromDetail = false;
        private List<string> _imagePaths = new List<string>();

        private int _listingId = 0;

        public AddEditControl()
        {
            InitializeComponent();

            rtbDescription.Text = "Enter description here...";
            rtbDescription.ForeColor = Color.Gray;

            rtbDescription.Enter += (s, e) =>
            {
                if (rtbDescription.Text == "Enter description here..." && rtbDescription.ForeColor == Color.Gray)
                {
                    rtbDescription.Text = "";
                    rtbDescription.ForeColor = Color.Black;
                }
            };

            rtbDescription.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(rtbDescription.Text))
                {
                    rtbDescription.Text = "Enter description here...";
                    rtbDescription.ForeColor = Color.Gray;
                }
            };
        }

        private void ShowError(string message)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = message;
        }

        public void LoadForNew()
        {
            _listingId = 0;
            _imagePaths = new List<string>();
            _cameFromDetail = false;
            lblFormTitle.Text = "📋 New Listing";
            LoadCategories();
            LoadCities();
            cmbCondition.Items.Clear();
            cmbCondition.Items.Add("-- Select Condition --");
            cmbCondition.Items.AddRange(new object[] { "used", "new" });
            cmbCondition.SelectedIndex = 0;
            picPreview.Image = null;
            ClearForm();
            RefreshImageUI();
        }
        private void LoadExistingImages(int listingId)
        {
            _imagePaths.Clear();
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
                    _imagePaths.Add(reader.GetString(0));
            }
            catch { }

            RefreshImageUI();
        }

        private void RefreshImageUI()
        {
            lstImages.Items.Clear();

            for (int i = 0; i < _imagePaths.Count; i++)
            {
                string fileName = Path.GetFileName(_imagePaths[i]);
                string label = i == 0
                    ? $"⭐ {fileName} (cover)"
                    : $"   {fileName}";
                lstImages.Items.Add(label);
            }

            // Show first image as preview
            picPreview.Image = null;
            if (_imagePaths.Count > 0)
            {
                try
                {
                    using var stream = new FileStream(
                        _imagePaths[0], FileMode.Open, FileAccess.Read);
                    var original = Image.FromStream(stream);
                    picPreview.Image = new Bitmap(original, picPreview.Size);
                    original.Dispose();
                    lblCoverBadge.Visible = true;   
                    lblCoverBadge.BringToFront();   
                }
                catch { }
            }
            else
            {
                lblCoverBadge.Visible = false;   
            }

            lblStatus.ForeColor = _imagePaths.Count > 0 ? Color.Green : Color.Gray;
            lblStatus.Text = _imagePaths.Count > 0
                ? $"✔ {_imagePaths.Count} image(s). First one is cover."
                : "";
        }

        public void LoadForEdit(int listingId, bool fromDetail = false)
        {
            _cameFromDetail = fromDetail;
            _listingId = listingId;
            _imagePaths = new List<string>();
            lblFormTitle.Text = "✏ Edit Listing";
            LoadCategories();
            LoadCities();
            cmbCondition.Items.Clear();
            cmbCondition.Items.Add("-- Select Condition --");
            cmbCondition.Items.AddRange(new object[] { "used", "new" });
            cmbCondition.SelectedIndex = 0;
            LoadExistingImages(listingId);
            LoadExistingData();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            rtbDescription.Text = "Enter description here...";
            rtbDescription.ForeColor = Color.Gray;
            nudPrice.Value = 0;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbCity.Items.Count > 0) cmbCity.SelectedIndex = 0;
            lblStatus.Text = "";
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("-- Select Category --");
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("SELECT id, name FROM categories ORDER BY name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbCategory.Items.Add(new Models.Category { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            catch { }
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void LoadCities()
        {
            cmbCity.Items.Clear();
            cmbCity.Items.Add("-- Select City --");
            string[] cities = {
                "Adana","Adıyaman","Afyonkarahisar","Ağrı","Aksaray","Amasya","Ankara","Antalya",
                "Ardahan","Artvin","Aydın","Balıkesir","Bartın","Batman","Bayburt","Bilecik",
                "Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankırı","Çorum",
                "Denizli","Diyarbakır","Düzce","Edirne","Elazığ","Erzincan","Erzurum",
                "Eskişehir","Gaziantep","Giresun","Gümüşhane","Hakkari","Hatay","Iğdır",
                "Isparta","Istanbul","Izmir","Kahramanmaraş","Karabük","Karaman","Kars",
                "Kastamonu","Kayseri","Kırıkkale","Kırklareli","Kırşehir","Kilis","Kocaeli",
                "Konya","Kütahya","Malatya","Manisa","Mardin","Mersin","Muğla","Muş",
                "Nevşehir","Niğde","Ordu","Osmaniye","Rize","Sakarya","Samsun","Siirt",
                "Sinop","Sivas","Şanlıurfa","Şırnak","Tekirdağ","Tokat","Trabzon","Tunceli",
                "Uşak","Van","Yalova","Yozgat","Zonguldak"
            };
            cmbCity.Items.AddRange(cities);
            if (cmbCity.Items.Count > 0) cmbCity.SelectedIndex = 0;
        }

        private void LoadExistingData()
        {
            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();
                string sql = "SELECT title, description, price, category_id, city, condition FROM listings WHERE id=@id";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", _listingId);
                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTitle.Text = reader.GetString(0);

                    string existingDesc = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    if (!string.IsNullOrWhiteSpace(existingDesc))
                    {
                        rtbDescription.Text = existingDesc;
                        rtbDescription.ForeColor = Color.Black;
                    }
                    else
                    {
                        rtbDescription.Text = "Enter description here...";
                        rtbDescription.ForeColor = Color.Gray;
                    }

                    nudPrice.Value = reader.GetDecimal(2);

                    int catId = reader.GetInt32(3);
                    foreach (var item in cmbCategory.Items)
                        if (item is Models.Category c && c.Id == catId)
                        { cmbCategory.SelectedItem = item; break; }

                    string city = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    if (cmbCity.Items.Contains(city)) cmbCity.SelectedItem = city;

                    cmbCondition.SelectedItem = reader.GetString(5);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void AddEditControl_Load(object sender, EventArgs e) { }





        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_cameFromDetail)
                OnCancelledFromDetail?.Invoke(_listingId);
            else
                OnCancelled?.Invoke();


        }







        private void btnSetCover_Click_1(object sender, EventArgs e)
        {
            int idx = lstImages.SelectedIndex;
            if (idx <= 0)
            {
                MessageBox.Show("Select an image other than the current cover.");
                return;
            }

            // Move selected to first position — first is always cover
            string selected = _imagePaths[idx];
            _imagePaths.RemoveAt(idx);
            _imagePaths.Insert(0, selected);
            RefreshImageUI();
        }

        private void btnRemoveImage_Click_1(object sender, EventArgs e)
        {
            int idx = lstImages.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show("Please select an image to remove.");
                return;
            }

            _imagePaths.RemoveAt(idx);
            RefreshImageUI();
        }

        private void btnAddImage_Click_1(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp;*.tiff;*.ico",
                Title = "Select images",
                Multiselect = false
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _imagePaths.Add(dlg.FileName);
                RefreshImageUI();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            { ShowError("⚠ Title is required."); return; }

            if (cmbCondition.SelectedItem == null || cmbCondition.SelectedItem.ToString() == "-- Select Condition --")
            { ShowError("⚠ Please select a condition."); return; }

            if (cmbCategory.SelectedItem == null || cmbCategory.SelectedItem.ToString() == "-- Select Category --")
            { ShowError("⚠ Please select a category."); return; }

            if (cmbCity.SelectedItem == null || cmbCity.SelectedItem.ToString() == "-- Select City --")
            { ShowError("⚠ Please select a city."); return; }

            var category = (Models.Category)cmbCategory.SelectedItem;

            // Get description — ignore placeholder text
            string description = rtbDescription.ForeColor == Color.Gray ? "" : rtbDescription.Text.Trim();

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "⏳ Saving...";
            this.Refresh();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                if (_listingId == 0)
                {
                    string sql = @"INSERT INTO listings
                        (user_id, category_id, title, description, price, city, condition)
                        VALUES (@uid, @cat, @title, @desc, @price, @city, @cond)
                        RETURNING id";

                    using var cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.Parameters.AddWithValue("cat", category.Id);
                    cmd.Parameters.AddWithValue("title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("desc", description);
                    cmd.Parameters.AddWithValue("price", nudPrice.Value);
                    cmd.Parameters.AddWithValue("city", cmbCity.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("cond", cmbCondition.SelectedItem?.ToString() == "-- Select Condition --" ? "used" : cmbCondition.SelectedItem?.ToString() ?? "used");
                    int newId = (int)cmd.ExecuteScalar();

                    for (int i = 0; i < _imagePaths.Count; i++)
                    {
                        using var img = new NpgsqlCommand(
                            "INSERT INTO listing_images (listing_id, image_path, is_cover) " +
                            "VALUES (@lid, @path, @cover)", conn);
                        img.Parameters.AddWithValue("lid", newId);
                        img.Parameters.AddWithValue("path", _imagePaths[i]);
                        img.Parameters.AddWithValue("cover", i == 0);  // first image is cover
                        img.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = @"UPDATE listings SET
                        category_id=@cat, title=@title, description=@desc,
                        price=@price, city=@city, condition=@cond, updated_at=NOW()
                        WHERE id=@id AND user_id=@uid";

                    using var cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("cat", category.Id);
                    cmd.Parameters.AddWithValue("title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("desc", description);
                    cmd.Parameters.AddWithValue("price", nudPrice.Value);
                    cmd.Parameters.AddWithValue("city", cmbCity.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("cond", cmbCondition.SelectedItem?.ToString() ?? "used");
                    cmd.Parameters.AddWithValue("id", _listingId);
                    cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                    cmd.ExecuteNonQuery();

                    using var delImg = new NpgsqlCommand(
                    "DELETE FROM listing_images WHERE listing_id = @id", conn);
                    delImg.Parameters.AddWithValue("id", _listingId);
                    delImg.ExecuteNonQuery();

                    for (int i = 0; i < _imagePaths.Count; i++)
                    {
                        using var img = new NpgsqlCommand(
                            "INSERT INTO listing_images (listing_id, image_path, is_cover) " +
                            "VALUES (@lid, @path, @cover)", conn);
                        img.Parameters.AddWithValue("lid", _listingId);
                        img.Parameters.AddWithValue("path", _imagePaths[i]);
                        img.Parameters.AddWithValue("cover", i == 0);
                        img.ExecuteNonQuery();
                    }

                }

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "✔ Saved!";
                if (_cameFromDetail)
                    OnSavedFromDetail?.Invoke(_listingId);
                else
                    OnSaved?.Invoke();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void lstImages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int idx = lstImages.SelectedIndex;
            if (idx < 0 || idx >= _imagePaths.Count) return;

            try
            {
                using var stream = new FileStream(
                    _imagePaths[idx], FileMode.Open, FileAccess.Read);
                var original = Image.FromStream(stream);
                picPreview.Image = new Bitmap(original, picPreview.Size);
                original.Dispose();
            }
            catch { }

            lblCoverBadge.Visible = (idx == 0);
        }

        private void cmbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}