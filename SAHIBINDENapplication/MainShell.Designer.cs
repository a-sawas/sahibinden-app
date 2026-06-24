namespace SAHIBINDENapplication
{
    partial class MainShell
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlModal = new Panel();
            SuspendLayout();

            // pnlContainer
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(984, 561);
            pnlContainer.TabIndex = 0;
            pnlContainer.Paint += pnlContainer_Paint;

            // pnlModal — separate from pnlContainer, sits on top
            pnlModal.BackColor = Color.FromArgb(60, 60, 60);
            pnlModal.Dock = DockStyle.None;

            pnlModal.Location = new Point(
            (984 - 420) / 2,
            (561 - 280) / 2);
            pnlModal.Name = "pnlModal";
            pnlModal.Size = new Size(420, 280);
            pnlModal.TabIndex = 1;
            pnlModal.Visible = false;

            // MainShell
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 247);
            ClientSize = new Size(984, 561);
            Controls.Add(pnlContainer);
            Controls.Add(pnlModal);   // ← added to Form directly, AFTER pnlContainer
            MaximumSize = new Size(1000, 600);
            Name = "MainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sahibinden";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlModal;
    }
}
