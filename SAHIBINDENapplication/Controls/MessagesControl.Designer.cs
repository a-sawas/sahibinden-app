namespace SAHIBINDENapplication.Controls
{
    partial class MessagesControl
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblHeader = new Label();
            btnBack = new Button();
            pnlLeft = new Panel();
            pnlConversations = new Panel();
            flpConversations = new FlowLayoutPanel();
            lblConvHeader = new Label();
            pnlRight = new Panel();
            pnlChat = new Panel();
            flpMessages = new FlowLayoutPanel();
            pnlReply = new Panel();
            btnSend = new Button();
            txtReply = new TextBox();
            lblConvTitle = new Label();
            ctxMessage = new ContextMenuStrip(components);
            mnuReport = new ToolStripMenuItem();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlConversations.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlChat.SuspendLayout();
            pnlReply.SuspendLayout();
            ctxMessage.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 26, 46);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.25F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(413, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(142, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "✉ Messages";
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
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(pnlConversations);
            pnlLeft.Controls.Add(lblConvHeader);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 60);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(260, 640);
            pnlLeft.TabIndex = 2;
            // 
            // pnlConversations
            // 
            pnlConversations.BackColor = Color.FromArgb(30, 30, 45);
            pnlConversations.Controls.Add(flpConversations);
            pnlConversations.Dock = DockStyle.Fill;
            pnlConversations.Location = new Point(0, 17);
            pnlConversations.Name = "pnlConversations";
            pnlConversations.Size = new Size(260, 623);
            pnlConversations.TabIndex = 1;
            // 
            // flpConversations
            // 
            flpConversations.AutoScroll = true;
            flpConversations.Dock = DockStyle.Fill;
            flpConversations.FlowDirection = FlowDirection.TopDown;
            flpConversations.Location = new Point(0, 0);
            flpConversations.Name = "flpConversations";
            flpConversations.Padding = new Padding(0, 5, 0, 5);
            flpConversations.Size = new Size(260, 623);
            flpConversations.TabIndex = 7;
            flpConversations.WrapContents = false;
            // 
            // lblConvHeader
            // 
            lblConvHeader.AutoSize = true;
            lblConvHeader.BackColor = Color.White;
            lblConvHeader.Dock = DockStyle.Top;
            lblConvHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConvHeader.ForeColor = Color.Black;
            lblConvHeader.Location = new Point(0, 0);
            lblConvHeader.Name = "lblConvHeader";
            lblConvHeader.Size = new Size(95, 17);
            lblConvHeader.TabIndex = 0;
            lblConvHeader.Text = "Conversations";
            lblConvHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(247, 247, 247);
            pnlRight.Controls.Add(pnlChat);
            pnlRight.Controls.Add(pnlReply);
            pnlRight.Controls.Add(lblConvTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(260, 60);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(890, 640);
            pnlRight.TabIndex = 2;
            // 
            // pnlChat
            // 
            pnlChat.AutoScroll = true;
            pnlChat.Controls.Add(flpMessages);
            pnlChat.Dock = DockStyle.Fill;
            pnlChat.Location = new Point(0, 21);
            pnlChat.Name = "pnlChat";
            pnlChat.Size = new Size(890, 563);
            pnlChat.TabIndex = 6;
            // 
            // flpMessages
            // 
            flpMessages.AutoSize = true;
            flpMessages.Dock = DockStyle.Top;
            flpMessages.FlowDirection = FlowDirection.TopDown;
            flpMessages.Location = new Point(0, 0);
            flpMessages.Name = "flpMessages";
            flpMessages.Padding = new Padding(10, 0, 0, 0);
            flpMessages.Size = new Size(890, 0);
            flpMessages.TabIndex = 0;
            flpMessages.WrapContents = false;
            flpMessages.SizeChanged += flpMessages_SizeChanged;
            // 
            // pnlReply
            // 
            pnlReply.BackColor = Color.White;
            pnlReply.Controls.Add(btnSend);
            pnlReply.Controls.Add(txtReply);
            pnlReply.Dock = DockStyle.Bottom;
            pnlReply.Location = new Point(0, 584);
            pnlReply.Name = "pnlReply";
            pnlReply.Size = new Size(890, 56);
            pnlReply.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(255, 96, 0);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(612, 19);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(120, 25);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send ➤";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtReply
            // 
            txtReply.Font = new Font("Segoe UI", 10F);
            txtReply.Location = new Point(6, 19);
            txtReply.Name = "txtReply";
            txtReply.PlaceholderText = "Type a message...";
            txtReply.Size = new Size(600, 25);
            txtReply.TabIndex = 4;
            txtReply.KeyDown += txtReply_KeyDown;
            // 
            // lblConvTitle
            // 
            lblConvTitle.BackColor = Color.White;
            lblConvTitle.Dock = DockStyle.Top;
            lblConvTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblConvTitle.ForeColor = Color.FromArgb(25, 25, 25);
            lblConvTitle.Location = new Point(0, 0);
            lblConvTitle.Name = "lblConvTitle";
            lblConvTitle.Padding = new Padding(10, 0, 0, 0);
            lblConvTitle.Size = new Size(890, 21);
            lblConvTitle.TabIndex = 0;
            lblConvTitle.Text = "Select a conversation";
            lblConvTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblConvTitle.Click += lblConvTitle_Click;
            // 
            // ctxMessage
            // 
            ctxMessage.Items.AddRange(new ToolStripItem[] { mnuReport });
            ctxMessage.Name = "ctxMessage";
            ctxMessage.Size = new Size(193, 26);
            // 
            // mnuReport
            // 
            mnuReport.Name = "mnuReport";
            mnuReport.Size = new Size(192, 22);
            mnuReport.Text = "⚑ Report this message";
            mnuReport.Click += mnuReport_Click;
            // 
            // MessagesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);
            Name = "MessagesControl";
            Size = new Size(1150, 700);
            Load += MessagesControl_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlConversations.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlChat.ResumeLayout(false);
            pnlChat.PerformLayout();
            pnlReply.ResumeLayout(false);
            pnlReply.PerformLayout();
            ctxMessage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnBack;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblConvHeader;
        private Panel pnlRight;
        private Label lblConvTitle;
        private Panel pnlReply;
        private Button btnSend;
        private TextBox txtReply;
        private Panel pnlChat;
        private FlowLayoutPanel flpMessages;
        private ContextMenuStrip ctxMessage;
        private ToolStripMenuItem mnuReport;
        private Panel pnlConversations;
        private FlowLayoutPanel flpConversations;
    }
}
