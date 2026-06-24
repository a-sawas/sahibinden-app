namespace SAHIBINDENapplication.Controls
{
    partial class AddEditControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnBack = new Button();
            lblFormTitle = new Label();
            pnlMain = new Panel();
            pnlRight = new Panel();
            btnSetCover = new Button();
            btnRemoveImage = new Button();
            btnAddImage = new Button();
            lblImageCount = new Label();
            lstImages = new ListBox();
            lblCoverBadge = new Label();
            picPreview = new PictureBox();
            lblImagesHint = new Label();
            lblImagesTitle = new Label();
            pnlLeft = new Panel();
            lblStatus = new Label();
            btnSave = new Button();
            cmbCondition = new ComboBox();
            lblConditionHint = new Label();
            cmbCity = new ComboBox();
            lblCityHint = new Label();
            cmbCategory = new ComboBox();
            lblCategoryHint = new Label();
            nudPrice = new NumericUpDown();
            lblPriceHint = new Label();
            lblDescHint = new Label();
            rtbDescription = new RichTextBox();
            txtTitle = new TextBox();
            lblTitleHint = new Label();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1050, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 35);
            btnBack.TabIndex = 1;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(413, 9);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(166, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "📋 New Listing";
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(247, 247, 247);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 80);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30, 20, 30, 20);
            pnlMain.Size = new Size(1150, 620);
            pnlMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnSetCover);
            pnlRight.Controls.Add(btnRemoveImage);
            pnlRight.Controls.Add(btnAddImage);
            pnlRight.Controls.Add(lblImageCount);
            pnlRight.Controls.Add(lstImages);
            pnlRight.Controls.Add(lblCoverBadge);
            pnlRight.Controls.Add(picPreview);
            pnlRight.Controls.Add(lblImagesHint);
            pnlRight.Controls.Add(lblImagesTitle);
            pnlRight.Location = new Point(580, 20);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(20);
            pnlRight.Size = new Size(500, 580);
            pnlRight.TabIndex = 14;
            // 
            // btnSetCover
            // 
            btnSetCover.Cursor = Cursors.Hand;
            btnSetCover.FlatStyle = FlatStyle.Flat;
            btnSetCover.Location = new Point(310, 290);
            btnSetCover.Name = "btnSetCover";
            btnSetCover.Size = new Size(150, 36);
            btnSetCover.TabIndex = 8;
            btnSetCover.Text = "⭐ Set as Cover";
            btnSetCover.UseVisualStyleBackColor = true;
            btnSetCover.Click += btnSetCover_Click_1;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Cursor = Cursors.Hand;
            btnRemoveImage.FlatStyle = FlatStyle.Flat;
            btnRemoveImage.ForeColor = Color.Red;
            btnRemoveImage.Location = new Point(170, 290);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(130, 36);
            btnRemoveImage.TabIndex = 7;
            btnRemoveImage.Text = "🗑 Remove";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += btnRemoveImage_Click_1;
            // 
            // btnAddImage
            // 
            btnAddImage.BackColor = Color.FromArgb(26, 26, 46);
            btnAddImage.Cursor = Cursors.Hand;
            btnAddImage.FlatAppearance.BorderSize = 0;
            btnAddImage.FlatStyle = FlatStyle.Flat;
            btnAddImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddImage.ForeColor = Color.White;
            btnAddImage.Location = new Point(20, 290);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(140, 36);
            btnAddImage.TabIndex = 6;
            btnAddImage.Text = "➕ Add Image";
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click_1;
            // 
            // lblImageCount
            // 
            lblImageCount.AutoSize = true;
            lblImageCount.ForeColor = Color.Gray;
            lblImageCount.Location = new Point(20, 260);
            lblImageCount.Name = "lblImageCount";
            lblImageCount.Size = new Size(100, 15);
            lblImageCount.TabIndex = 5;
            lblImageCount.Text = "No images added";
            // 
            // lstImages
            // 
            lstImages.BorderStyle = BorderStyle.FixedSingle;
            lstImages.FormattingEnabled = true;
            lstImages.ItemHeight = 15;
            lstImages.Location = new Point(255, 70);
            lstImages.Name = "lstImages";
            lstImages.Size = new Size(210, 167);
            lstImages.TabIndex = 4;
            lstImages.SelectedIndexChanged += lstImages_SelectedIndexChanged_1;
            // 
            // lblCoverBadge
            // 
            lblCoverBadge.AutoSize = true;
            lblCoverBadge.BackColor = Color.FromArgb(255, 96, 0);
            lblCoverBadge.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCoverBadge.ForeColor = Color.White;
            lblCoverBadge.Location = new Point(20, 70);
            lblCoverBadge.Name = "lblCoverBadge";
            lblCoverBadge.Size = new Size(46, 12);
            lblCoverBadge.TabIndex = 3;
            lblCoverBadge.Text = "⭐ COVER";
            lblCoverBadge.TextAlign = ContentAlignment.MiddleCenter;
            lblCoverBadge.Visible = false;
            // 
            // picPreview
            // 
            picPreview.BackColor = SystemColors.ButtonFace;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(20, 70);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(220, 180);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 2;
            picPreview.TabStop = false;
            // 
            // lblImagesHint
            // 
            lblImagesHint.AutoSize = true;
            lblImagesHint.Font = new Font("Segoe UI", 8F);
            lblImagesHint.ForeColor = Color.Gray;
            lblImagesHint.Location = new Point(20, 45);
            lblImagesHint.Name = "lblImagesHint";
            lblImagesHint.Size = new Size(207, 13);
            lblImagesHint.TabIndex = 1;
            lblImagesHint.Text = "First image will be used as cover photo";
            // 
            // lblImagesTitle
            // 
            lblImagesTitle.AutoSize = true;
            lblImagesTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblImagesTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblImagesTitle.Location = new Point(20, 20);
            lblImagesTitle.Name = "lblImagesTitle";
            lblImagesTitle.Size = new Size(145, 20);
            lblImagesTitle.TabIndex = 0;
            lblImagesTitle.Text = "📷 Product Images";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(lblStatus);
            pnlLeft.Controls.Add(btnSave);
            pnlLeft.Controls.Add(cmbCondition);
            pnlLeft.Controls.Add(lblConditionHint);
            pnlLeft.Controls.Add(cmbCity);
            pnlLeft.Controls.Add(lblCityHint);
            pnlLeft.Controls.Add(cmbCategory);
            pnlLeft.Controls.Add(lblCategoryHint);
            pnlLeft.Controls.Add(nudPrice);
            pnlLeft.Controls.Add(lblPriceHint);
            pnlLeft.Controls.Add(lblDescHint);
            pnlLeft.Controls.Add(rtbDescription);
            pnlLeft.Controls.Add(txtTitle);
            pnlLeft.Controls.Add(lblTitleHint);
            pnlLeft.Location = new Point(20, 20);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(20);
            pnlLeft.Size = new Size(540, 580);
            pnlLeft.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(20, 448);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(500, 24);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "label1";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(255, 96, 0);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 390);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(500, 46);
            btnSave.TabIndex = 12;
            btnSave.Text = "💾 Save Listing";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // cmbCondition
            // 
            cmbCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondition.Font = new Font("Segoe UI", 10F);
            cmbCondition.FormattingEnabled = true;
            cmbCondition.Location = new Point(280, 320);
            cmbCondition.Name = "cmbCondition";
            cmbCondition.Size = new Size(240, 25);
            cmbCondition.TabIndex = 11;
            cmbCondition.SelectedIndexChanged += cmbCondition_SelectedIndexChanged;
            // 
            // lblConditionHint
            // 
            lblConditionHint.AutoSize = true;
            lblConditionHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConditionHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblConditionHint.Location = new Point(280, 298);
            lblConditionHint.Name = "lblConditionHint";
            lblConditionHint.Size = new Size(68, 15);
            lblConditionHint.TabIndex = 10;
            lblConditionHint.Text = "Condition *";
            // 
            // cmbCity
            // 
            cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCity.Font = new Font("Segoe UI", 10F);
            cmbCity.FormattingEnabled = true;
            cmbCity.Location = new Point(20, 320);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(240, 25);
            cmbCity.TabIndex = 9;
            // 
            // lblCityHint
            // 
            lblCityHint.AutoSize = true;
            lblCityHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCityHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblCityHint.Location = new Point(20, 298);
            lblCityHint.Name = "lblCityHint";
            lblCityHint.Size = new Size(36, 15);
            lblCityHint.TabIndex = 8;
            lblCityHint.Text = "City *";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(280, 250);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(240, 25);
            cmbCategory.TabIndex = 7;
            // 
            // lblCategoryHint
            // 
            lblCategoryHint.AutoSize = true;
            lblCategoryHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoryHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblCategoryHint.Location = new Point(280, 228);
            lblCategoryHint.Name = "lblCategoryHint";
            lblCategoryHint.Size = new Size(65, 15);
            lblCategoryHint.TabIndex = 6;
            lblCategoryHint.Text = "Category *";
            // 
            // nudPrice
            // 
            nudPrice.Font = new Font("Segoe UI", 10F);
            nudPrice.Location = new Point(20, 250);
            nudPrice.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(240, 25);
            nudPrice.TabIndex = 5;
            nudPrice.ThousandsSeparator = true;
            // 
            // lblPriceHint
            // 
            lblPriceHint.AutoSize = true;
            lblPriceHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriceHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblPriceHint.Location = new Point(20, 228);
            lblPriceHint.Name = "lblPriceHint";
            lblPriceHint.Size = new Size(61, 15);
            lblPriceHint.TabIndex = 4;
            lblPriceHint.Text = "Price (₺) *";
            // 
            // lblDescHint
            // 
            lblDescHint.AutoSize = true;
            lblDescHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblDescHint.Location = new Point(20, 90);
            lblDescHint.Name = "lblDescHint";
            lblDescHint.Size = new Size(71, 15);
            lblDescHint.TabIndex = 3;
            lblDescHint.Text = "Description";
            // 
            // rtbDescription
            // 
            rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            rtbDescription.Font = new Font("Segoe UI", 10F);
            rtbDescription.Location = new Point(20, 112);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbDescription.Size = new Size(500, 100);
            rtbDescription.TabIndex = 2;
            rtbDescription.Text = "";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 11F);
            txtTitle.Location = new Point(20, 42);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Enter listing title...";
            txtTitle.Size = new Size(500, 27);
            txtTitle.TabIndex = 1;
            // 
            // lblTitleHint
            // 
            lblTitleHint.AutoSize = true;
            lblTitleHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleHint.ForeColor = Color.FromArgb(80, 80, 80);
            lblTitleHint.Location = new Point(20, 20);
            lblTitleHint.Name = "lblTitleHint";
            lblTitleHint.Size = new Size(79, 15);
            lblTitleHint.TabIndex = 0;
            lblTitleHint.Text = "Listing Title *";
            // 
            // AddEditControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Name = "AddEditControl";
            Size = new Size(1150, 700);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnBack;
        private Label lblFormTitle;
        private Panel pnlMain;
        private Panel pnlLeft;
        private Label lblDescHint;
        private RichTextBox rtbDescription;
        private TextBox txtTitle;
        private Label lblTitleHint;
        private ComboBox cmbCategory;
        private Label lblCategoryHint;
        private NumericUpDown nudPrice;
        private Label lblPriceHint;
        private Label lblStatus;
        private Button btnSave;
        private ComboBox cmbCondition;
        private Label lblConditionHint;
        private ComboBox cmbCity;
        private Label lblCityHint;
        private Panel pnlRight;
        private PictureBox picPreview;
        private Label lblImagesHint;
        private Label lblImagesTitle;
        private Button btnAddImage;
        private Label lblImageCount;
        private ListBox lstImages;
        private Label lblCoverBadge;
        private Button btnSetCover;
        private Button btnRemoveImage;
    }
}
