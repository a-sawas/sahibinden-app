using Npgsql;
using SAHIBINDENapplication.Controls;

namespace SAHIBINDENapplication
{
    public partial class MainShell : Form
    {
        internal LoginControl _login;
        internal RegisterControl _register;
        private ListingsControl _listings;
        private AddEditControl _addEdit;
        private ListingDetailControl _detail;
        private MessagesControl _messages;
        private AdminControl _admin;
        private FavoritesControl _favorites;
        private GuestPromptControl _guestPrompt;
        private SettingsControl _settings;

        public static MainShell Instance { get; private set; }
        public MainShell()
        {
            InitializeComponent();
            Instance = this;

            _login = new LoginControl();
            _register = new RegisterControl();
            _listings = new ListingsControl();
            _addEdit = new AddEditControl();
            _detail = new ListingDetailControl();
            _messages = new MessagesControl();
            _admin = new AdminControl();
            _favorites = new FavoritesControl();
            _guestPrompt = new GuestPromptControl();
            _settings = new SettingsControl();


            // Ping immediately on login
            UpdateOnlineStatus();

            // Keep pinging every 30 seconds while app is open
            var onlineTimer = new System.Windows.Forms.Timer();
            onlineTimer.Interval = 30000;
            onlineTimer.Tick += (s, e) => UpdateOnlineStatus();
            onlineTimer.Start();

            // Guest prompt events
            _guestPrompt.OnLoginClicked += () =>
            {
                HideGuestPrompt();
                Navigate(_login);
            };
            _guestPrompt.OnRegisterClicked += () =>
            {
                HideGuestPrompt();
                Navigate(_register);
            };
            _guestPrompt.OnContinueAsGuest += () => HideGuestPrompt();

            // Login / Register
            _login.OnRegisterClicked += () => Navigate(_register);
            _login.OnBackToListings += () => Navigate(_listings);
            _login.OnLoginSuccess += () =>
            {
                UpdateOnlineStatus();
                _listings.RefreshSessionUI();
                _listings.LoadListings();
                Navigate(_listings);
            };
            _register.OnBackClicked += () => Navigate(_login);
            _register.OnRegistered += () => Navigate(_login);

            // Listings
            _listings.OnAddListing += () =>
            {
                if (RequireLogin("add listings")) return;
                _addEdit.LoadForNew();
                Navigate(_addEdit);
            };  
            _listings.OnEditListing += (id) =>
            {
                if (RequireLogin("edit listings")) return;
                _addEdit.LoadForEdit(id, false);
                Navigate(_addEdit);
            };
            _listings.OnViewDetail += (id) =>
            {
                _detail.LoadListing(id, "listings");
                Navigate(_detail);
            };
            _listings.OnMessages += () =>
            {
                if (RequireLogin("send messages")) return;
                _messages.LoadData();
                Navigate(_messages);
            };
            _listings.OnAdmin += () =>
            {
                if (RequireLogin("access admin panel")) return;
                _admin.LoadData();
                Navigate(_admin);
            };
            _listings.OnFavorites += () =>
            {
                if (RequireLogin("view your favorites")) return;
                _favorites.LoadFavorites();
                Navigate(_favorites);
            };
            _listings.OnLoginClicked += () => Navigate(_login);
            _listings.OnLogout += () =>
            {
                SetOfflineStatus();
                Session.Logout();
                _listings.RefreshSessionUI();
                _listings.LoadListings();
                Navigate(_listings);
            };

            // AddEdit
            _addEdit.OnSaved += () =>
            {
                _listings.LoadListings();
                Navigate(_listings);
            };
            _addEdit.OnCancelled += () => Navigate(_listings);

            _addEdit.OnSavedFromDetail += (id) =>
            {
                _detail.LoadListing(id, "listings");
                Navigate(_detail);
            };
            _addEdit.OnCancelledFromDetail += (id) =>
            {
                _detail.LoadListing(id, "listings");
                Navigate(_detail);
            };

            // Detail
            _detail.OnBack += () =>
            {
                _listings.LoadListings();
                Navigate(_listings);
            };
            _detail.OnBackToFavorites += () =>
            {
                _favorites.LoadFavorites();
                Navigate(_favorites);
            };
            _detail.OnEdit += (id) =>
            {
                if (RequireLogin("edit listings")) return;
                _addEdit.LoadForEdit(id, true);
                Navigate(_addEdit);
            };
            _detail.OnMessage += (rid, lid) =>
            {
                if (RequireLogin("send messages")) return;
                _messages.OpenConversation(rid, lid);
                Navigate(_messages);
            };
            _detail.OnFavoriteClicked += () =>
            {
                if (RequireLogin("save listings to favorites")) return;
                _detail.ToggleFavorite();
            };

            // Favorites
            _favorites.OnBack += () => Navigate(_listings);
            _favorites.OnViewListing += (id) =>
            {
                _detail.LoadListing(id, "favorites");
                Navigate(_detail);
            };

            _listings.OnSettings += () =>
            {
                if (RequireLogin("access settings")) return;
                Navigate(_settings);
            };

            _settings.OnBack += () => Navigate(_listings);
            _messages.OnBack += () => Navigate(_listings);
            _admin.OnBack += () => Navigate(_listings);

            // Start as guest directly at listings
            Session.LoginAsGuest();
            Navigate(_listings);
        }

        private void UpdateOnlineStatus()
        {
            if (!Session.IsLoggedIn) return;
            try
            {
                using var conn = DBHelper.GetConnection(); conn.Open();
                // Sets to true AND updates the time
                using var cmd = new NpgsqlCommand(
                    "UPDATE users SET is_online = true, last_seen = NOW() WHERE id=@uid", conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }


        

        public void Navigate(UserControl control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
            control.BringToFront();

            // Always keep modal panel on top
            pnlModal.BringToFront();
        }

        // Shows the overlay on top of the current screen
        public bool RequireLogin(string featureName)
        {
            if (Session.IsLoggedIn) return false;

            ShowGuestPrompt(featureName);
            return true;
        }

        private void ShowGuestPrompt(string featureName)
        {
            _guestPrompt.SetFeature(featureName);
            _guestPrompt.Dock = DockStyle.Fill;

            pnlModal.Controls.Clear();
            pnlModal.Controls.Add(_guestPrompt);
            pnlModal.Visible = true;
            pnlModal.BringToFront();
        }

        private void HideGuestPrompt()
        {
            pnlModal.Visible = false;
            pnlModal.Controls.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SetOfflineStatus();
            Session.Logout();
            base.OnFormClosing(e);
        }

        private void SetOfflineStatus()
        {
            if (!Session.IsLoggedIn) return;
            try
            {
                using var conn = DBHelper.GetConnection(); conn.Open();
                // Instantly sets to false, saves the exact time
                using var cmd = new NpgsqlCommand(
                    "UPDATE users SET is_online = false, last_seen = NOW() WHERE id=@uid", conn);
                cmd.Parameters.AddWithValue("uid", Session.CurrentUser.Id);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
