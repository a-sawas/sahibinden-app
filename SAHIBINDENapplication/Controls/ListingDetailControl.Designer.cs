namespace SAHIBINDENapplication.Controls
{
    partial class ListingDetailControl
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
            lblHeaderTitle = new Label();
            btnBack = new Button();
            pnlBody = new Panel();
            lblImageCount = new Label();
            btnNextImage = new Button();
            btnPrevImage = new Button();
            btnMessage = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnFavorite = new Button();
            rtbDescription = new RichTextBox();
            lblViews = new Label();
            lblDate = new Label();
            lblPostedBy = new Label();
            lblCondition = new Label();
            lblCategory = new Label();
            lblCity = new Label();
            lblPrice = new Label();
            lblTitle = new Label();
            picMain = new PictureBox();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMain).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(413, 9);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(142, 30);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Listing Detail";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(840, 16);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(136, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back to Listings";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(lblImageCount);
            pnlBody.Controls.Add(btnNextImage);
            pnlBody.Controls.Add(btnPrevImage);
            pnlBody.Controls.Add(btnMessage);
            pnlBody.Controls.Add(btnEdit);
            pnlBody.Controls.Add(btnDelete);
            pnlBody.Controls.Add(btnFavorite);
            pnlBody.Controls.Add(rtbDescription);
            pnlBody.Controls.Add(lblViews);
            pnlBody.Controls.Add(lblDate);
            pnlBody.Controls.Add(lblPostedBy);
            pnlBody.Controls.Add(lblCondition);
            pnlBody.Controls.Add(lblCategory);
            pnlBody.Controls.Add(lblCity);
            pnlBody.Controls.Add(lblPrice);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Controls.Add(picMain);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 60);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(1150, 640);
            pnlBody.TabIndex = 2;
            // 
            // lblImageCount
            // 
            lblImageCount.AutoSize = true;
            lblImageCount.Font = new Font("Segoe UI", 8F);
            lblImageCount.ForeColor = Color.Gray;
            lblImageCount.Location = new Point(5, 312);
            lblImageCount.Name = "lblImageCount";
            lblImageCount.Size = new Size(38, 13);
            lblImageCount.TabIndex = 16;
            lblImageCount.Text = "label1";
            // 
            // btnNextImage
            // 
            btnNextImage.BackColor = Color.Silver;
            btnNextImage.Cursor = Cursors.Hand;
            btnNextImage.FlatAppearance.BorderSize = 0;
            btnNextImage.FlatStyle = FlatStyle.Flat;
            btnNextImage.Location = new Point(250, 345);
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Size = new Size(30, 60);
            btnNextImage.TabIndex = 15;
            btnNextImage.Text = "❯";
            btnNextImage.UseVisualStyleBackColor = false;
            btnNextImage.Visible = false;
            btnNextImage.Click += btnNextImage_Click;
            // 
            // btnPrevImage
            // 
            btnPrevImage.BackColor = Color.Silver;
            btnPrevImage.Cursor = Cursors.Hand;
            btnPrevImage.FlatAppearance.BorderSize = 0;
            btnPrevImage.FlatStyle = FlatStyle.Flat;
            btnPrevImage.Location = new Point(44, 345);
            btnPrevImage.Name = "btnPrevImage";
            btnPrevImage.Size = new Size(30, 60);
            btnPrevImage.TabIndex = 14;
            btnPrevImage.Text = "❮";
            btnPrevImage.UseVisualStyleBackColor = false;
            btnPrevImage.Visible = false;
            btnPrevImage.Click += btnPrevImage_Click;
            // 
            // btnMessage
            // 
            btnMessage.BackColor = Color.FromArgb(255, 96, 0);
            btnMessage.Cursor = Cursors.Hand;
            btnMessage.FlatAppearance.BorderSize = 0;
            btnMessage.FlatStyle = FlatStyle.Flat;
            btnMessage.ForeColor = Color.White;
            btnMessage.Location = new Point(770, 192);
            btnMessage.Name = "btnMessage";
            btnMessage.Size = new Size(119, 23);
            btnMessage.TabIndex = 13;
            btnMessage.Text = "✉ Send Message";
            btnMessage.UseVisualStyleBackColor = false;
            btnMessage.Click += btnMessage_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(770, 266);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "✏ Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(770, 304);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "🗑 Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFavorite
            // 
            btnFavorite.Cursor = Cursors.Hand;
            btnFavorite.FlatStyle = FlatStyle.Flat;
            btnFavorite.Location = new Point(770, 228);
            btnFavorite.Name = "btnFavorite";
            btnFavorite.Size = new Size(75, 23);
            btnFavorite.TabIndex = 10;
            btnFavorite.Text = "\U0001f90d Save";
            btnFavorite.UseVisualStyleBackColor = true;
            btnFavorite.Click += btnFavorite_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.BackColor = Color.FromArgb(247, 247, 247);
            rtbDescription.BorderStyle = BorderStyle.None;
            rtbDescription.Font = new Font("Segoe UI", 10F);
            rtbDescription.Location = new Point(343, 66);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(560, 100);
            rtbDescription.TabIndex = 9;
            rtbDescription.Text = "";
            // 
            // lblViews
            // 
            lblViews.AutoSize = true;
            lblViews.ForeColor = Color.Gray;
            lblViews.Location = new Point(344, 280);
            lblViews.Name = "lblViews";
            lblViews.Size = new Size(38, 15);
            lblViews.TabIndex = 8;
            lblViews.Text = "label2";
            lblViews.Click += lblViews_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(344, 295);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(38, 15);
            lblDate.TabIndex = 7;
            lblDate.Text = "label1";
            // 
            // lblPostedBy
            // 
            lblPostedBy.AutoSize = true;
            lblPostedBy.Font = new Font("Segoe UI", 10F);
            lblPostedBy.Location = new Point(343, 261);
            lblPostedBy.Name = "lblPostedBy";
            lblPostedBy.Size = new Size(45, 19);
            lblPostedBy.TabIndex = 6;
            lblPostedBy.Text = "label4";
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Font = new Font("Segoe UI", 10F);
            lblCondition.Location = new Point(343, 242);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(45, 19);
            lblCondition.TabIndex = 5;
            lblCondition.Text = "label3";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.Location = new Point(343, 223);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(45, 19);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "label2";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Segoe UI", 10F);
            lblCity.Location = new Point(343, 204);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(45, 19);
            lblCity.TabIndex = 3;
            lblCity.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.FromArgb(255, 96, 0);
            lblPrice.Location = new Point(343, 179);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 25);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "label1";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblTitle.Location = new Point(5, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(403, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            // 
            // picMain
            // 
            picMain.BackColor = Color.Gainsboro;
            picMain.BorderStyle = BorderStyle.FixedSingle;
            picMain.Location = new Point(5, 66);
            picMain.Name = "picMain";
            picMain.Size = new Size(320, 240);
            picMain.SizeMode = PictureBoxSizeMode.Zoom;
            picMain.TabIndex = 0;
            picMain.TabStop = false;
            // 
            // ListingDetailControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Name = "ListingDetailControl";
            Size = new Size(1150, 700);
            Load += ListingDetailControl_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Button btnBack;
        private Panel pnlBody;
        private PictureBox picMain;
        private Label lblPrice;
        private Label lblTitle;
        private RichTextBox rtbDescription;
        private Label lblViews;
        private Label lblDate;
        private Label lblPostedBy;
        private Label lblCondition;
        private Label lblCategory;
        private Label lblCity;
        private Button btnFavorite;
        private Button btnMessage;
        private Button btnEdit;
        private Button btnDelete;
        private Label lblImageCount;
        private Button btnNextImage;
        private Button btnPrevImage;
    }
}
