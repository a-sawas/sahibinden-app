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
    public partial class GuestPromptControl : UserControl
    {
        public event Action OnLoginClicked;
        public event Action OnRegisterClicked;
        public event Action OnContinueAsGuest;
        public GuestPromptControl()
        {
            InitializeComponent();
        }

        private void GuestPromptControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 60, 60);

            // Center the card on the screen
            pnlCard.Location = new Point(
                (this.Width - pnlCard.Width) / 2,
                (this.Height - pnlCard.Height) / 2);
        }
        // Call this before showing so the message is correct
        public void SetFeature(string featureName)
        {
            lblMessage.Text =
            $"{featureName} is available for registered users.\n" +
            "Sign in to continue.";
        }
        private void btnLogin_Click(object sender, EventArgs e) => OnLoginClicked?.Invoke();


        private void btnRegister_Click(object sender, EventArgs e) => OnRegisterClicked?.Invoke();


        private void btnContinue_Click(object sender, EventArgs e) => OnContinueAsGuest?.Invoke();

        private void GuestPromptControl_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
