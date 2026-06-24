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
    public partial class LoginControl : UserControl
    {
        public event Action OnRegisterClicked;
        public event Action OnLoginSuccess;
        public event Action OnBackToListings;

        public LoginControl()
        {
            InitializeComponent();
        }
        private void LoginControl_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            txtPassword.PasswordChar = '●';
            chkShowPassword.Checked = false;

        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.ForeColor = Color.OrangeRed;
                lblStatus.Text = "⚠ Please enter username and password.";
                return;
            }

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "⏳ Connecting...";
            this.Refresh();

            try
            {
                using var conn = DBHelper.GetConnection();
                conn.Open();

                string sql = "SELECT id, username, password, full_name, email, phone, city, role, created_at " +
                             "FROM users WHERE username=@u";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("u", username);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHash = reader.GetString(2);
                    // Verify the entered password against the stored hash
                    if (!PasswordHelper.Verify(password, storedHash))
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "✘ Invalid username or password.";
                        txtPassword.Clear();
                        return;
                    }



                    Session.CurrentUser = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = storedHash,
                        FullName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        Phone = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        City = reader.IsDBNull(6) ? "" : reader.GetString(6),
                        Role = reader.IsDBNull(7) ? "user" : reader.GetString(7),
                        CreatedAt = reader.GetDateTime(8)
                    };

                    Session.IsGuest = false;

                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "✔ Login successful!";

                    txtUsername.Clear();
                    txtPassword.Clear();

                    // Small delay so user sees the success message, then clear it
                    await Task.Delay(500);
                    lblStatus.Text = "";

                    OnLoginSuccess?.Invoke();
                    chkShowPassword.Checked = false;
                    txtPassword.PasswordChar = '●';
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "✘ Invalid username or password.";
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "DB Error: " + ex.Message;
            }
        }
        public void Reset()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblStatus.Text = "";
            this.ActiveControl = null;
        }

        private void btnGoRegister_Click(object sender, EventArgs e)
        {
            OnRegisterClicked?.Invoke();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void LoginControl_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true; // prevents "ding" sound
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
            txtPassword.Focus();
        }

        private void btnBackToListings_Click(object sender, EventArgs e) => OnBackToListings?.Invoke();

        private void btnBackToListings_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void LoginControl_VisibleChanged(object sender, EventArgs e)
        {
            btnBackToListings.Visible = Session.IsGuest;
        }
    }
}
