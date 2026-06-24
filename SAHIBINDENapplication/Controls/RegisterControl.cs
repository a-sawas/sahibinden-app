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

    public partial class RegisterControl : UserControl
    {
        public event Action OnBackClicked;
        public event Action OnRegistered;
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            LoadCities();
        }
        private void RegisterControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.ActiveControl = null;
                lblStatus.Text = "";
            }
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
            cmbCity.SelectedIndex = 0;
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ShowError(string msg)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = msg;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();
            string city = cmbCity.SelectedItem?.ToString() ?? "";

            // Validation
            if (string.IsNullOrEmpty(fullName))
            { ShowError("⚠ Full name is required."); return; }

            if (string.IsNullOrEmpty(username) || username.Length < 3)
            { ShowError("⚠ Username must be at least 3 characters."); return; }

            if (username.Contains(" "))
            { ShowError("⚠ Username cannot contain spaces."); return; }

            if (string.IsNullOrEmpty(email))
            { ShowError("⚠ Email address is required."); return; }

            if (!email.Contains("@") || !email.Contains("."))
            { ShowError("⚠ Please enter a valid email address."); return; }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            { ShowError("⚠ Password must be at least 8 characters."); return; }

            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);
            if (!hasLetter || !hasDigit)
            { ShowError("⚠ Password must contain both letters and numbers."); return; }


            if (password != confirm)
            { ShowError("⚠ Passwords do not match."); txtConfirmPassword.Clear(); return; }

            if (string.IsNullOrEmpty(city) || city == "-- Select City --")
            { ShowError("⚠ Please select a city."); return; }

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                // Check username uniqueness
                using (var check = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username=@u", conn))
                {
                    check.Parameters.AddWithValue("u", username);
                    if ((long)check.ExecuteScalar() > 0)
                    { ShowError("⚠ Username already taken."); return; }
                }

                // Check email uniqueness
                using (var check = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE email=@e", conn))
                {
                    check.Parameters.AddWithValue("e", email);
                    if ((long)check.ExecuteScalar() > 0)
                    { ShowError("⚠ Email already registered."); return; }
                }

                lblStatus.ForeColor = Color.Gray;
                lblStatus.Text = "⏳ Creating account...";
                this.Refresh();

                string sql = @"INSERT INTO users (username, password, full_name, email, phone, city, role)
                               VALUES (@u, @p, @fn, @e, @ph, @c, 'user')";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("u", username);
                cmd.Parameters.AddWithValue("p", PasswordHelper.Hash(password));
                cmd.Parameters.AddWithValue("fn", fullName);
                cmd.Parameters.AddWithValue("e", email);
                cmd.Parameters.AddWithValue("ph", string.IsNullOrEmpty(phone) ? DBNull.Value : (object)phone);
                cmd.Parameters.AddWithValue("c", city);
                cmd.ExecuteNonQuery();

                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "✔ Account created!";

                MessageBox.Show($"Welcome, {fullName}! 🎉\nYou can now login.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                txtFullName.Clear(); txtUsername.Clear(); txtEmail.Clear();
                txtPhone.Clear(); txtPassword.Clear(); txtConfirmPassword.Clear();

                OnRegistered?.Invoke();
            }
            catch (Exception ex)
            {
                ShowError("DB Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) => OnBackClicked?.Invoke();

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnRegister_Click(sender, e);

        }
        public void Reset()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            if (cmbCity.Items.Count > 0)
                cmbCity.SelectedIndex = 0;
            lblStatus.Text = "";
            this.ActiveControl = null;
        }

        private void lblTagline_Click(object sender, EventArgs e)
        {

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
