using UI.ThemeSources.ThemedControls;

namespace UI.Forms
{
    partial class Downloader
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelDownload = new Panel();
            panelInnerDownloaded = new Panel();
            listBoxDownloaded = new ListBox();
            buttonFolder = new ThemedButton();
            progressBarDownloading = new ThemedProgressBar();
            textBoxFolder = new TextBox();
            labelDownloading = new Label();
            textBoxId = new TextBox();
            buttonCancel = new ThemedButton();
            buttonId = new ThemedButton();
            buttonStop = new ThemedButton();
            buttonStart = new ThemedButton();
            panelQueue = new Panel();
            panelInnerQueue = new Panel();
            buttonRemoveAll = new ThemedButton();
            listBoxQueue = new ListBox();
            buttonRemove = new ThemedButton();
            panelUserInfo = new Panel();
            panelInnerUserInfo = new Panel();
            labelUserIllustsValue = new Label();
            labelUserIdValue = new Label();
            labelUsernameValue = new Label();
            labelUserIllusts = new Label();
            pictureBoxUser = new PictureBox();
            labelUserId = new Label();
            labelName = new Label();
            panelDownload.SuspendLayout();
            panelInnerDownloaded.SuspendLayout();
            panelQueue.SuspendLayout();
            panelInnerQueue.SuspendLayout();
            panelUserInfo.SuspendLayout();
            panelInnerUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).BeginInit();
            SuspendLayout();
            // 
            // panelDownload
            // 
            panelDownload.BackColor = SystemColors.Control;
            panelDownload.Controls.Add(panelInnerDownloaded);
            panelDownload.Dock = DockStyle.Left;
            panelDownload.Location = new Point(0, 0);
            panelDownload.Margin = new Padding(0);
            panelDownload.Name = "panelDownload";
            panelDownload.Padding = new Padding(20, 20, 10, 20);
            panelDownload.Size = new Size(450, 426);
            panelDownload.TabIndex = 0;
            // 
            // panelInnerDownloaded
            // 
            panelInnerDownloaded.BackColor = SystemColors.ControlLightLight;
            panelInnerDownloaded.Controls.Add(listBoxDownloaded);
            panelInnerDownloaded.Controls.Add(buttonFolder);
            panelInnerDownloaded.Controls.Add(progressBarDownloading);
            panelInnerDownloaded.Controls.Add(textBoxFolder);
            panelInnerDownloaded.Controls.Add(labelDownloading);
            panelInnerDownloaded.Controls.Add(textBoxId);
            panelInnerDownloaded.Controls.Add(buttonCancel);
            panelInnerDownloaded.Controls.Add(buttonId);
            panelInnerDownloaded.Controls.Add(buttonStop);
            panelInnerDownloaded.Controls.Add(buttonStart);
            panelInnerDownloaded.Location = new Point(20, 20);
            panelInnerDownloaded.Margin = new Padding(0);
            panelInnerDownloaded.Name = "panelInnerDownloaded";
            panelInnerDownloaded.Padding = new Padding(15);
            panelInnerDownloaded.Size = new Size(420, 386);
            panelInnerDownloaded.TabIndex = 10;
            // 
            // listBoxDownloaded
            // 
            listBoxDownloaded.BorderStyle = BorderStyle.FixedSingle;
            listBoxDownloaded.Enabled = false;
            listBoxDownloaded.FormattingEnabled = true;
            listBoxDownloaded.Location = new Point(15, 246);
            listBoxDownloaded.Name = "listBoxDownloaded";
            listBoxDownloaded.Size = new Size(390, 122);
            listBoxDownloaded.TabIndex = 9;
            listBoxDownloaded.TabStop = false;
            listBoxDownloaded.UseTabStops = false;
            // 
            // buttonFolder
            // 
            buttonFolder.Font = new Font("Segoe UI", 14.25F);
            buttonFolder.Location = new Point(15, 15);
            buttonFolder.Margin = new Padding(0);
            buttonFolder.Name = "buttonFolder";
            buttonFolder.Size = new Size(145, 33);
            buttonFolder.TabIndex = 0;
            buttonFolder.Text = "Choose Folder";
            buttonFolder.UseVisualStyleBackColor = true;
            buttonFolder.Click += buttonFolder_Click;
            // 
            // progressBarDownloading
            // 
            progressBarDownloading.BackColor = SystemColors.ControlLight;
            progressBarDownloading.Location = new Point(15, 186);
            progressBarDownloading.Margin = new Padding(0);
            progressBarDownloading.Name = "progressBarDownloading";
            progressBarDownloading.Size = new Size(390, 52);
            progressBarDownloading.Style = ProgressBarStyle.Continuous;
            progressBarDownloading.TabIndex = 8;
            // 
            // textBoxFolder
            // 
            textBoxFolder.BorderStyle = BorderStyle.FixedSingle;
            textBoxFolder.Cursor = Cursors.No;
            textBoxFolder.Enabled = false;
            textBoxFolder.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxFolder.Location = new Point(173, 15);
            textBoxFolder.Margin = new Padding(0);
            textBoxFolder.MaxLength = 3000;
            textBoxFolder.Multiline = true;
            textBoxFolder.Name = "textBoxFolder";
            textBoxFolder.Size = new Size(232, 33);
            textBoxFolder.TabIndex = 1;
            // 
            // labelDownloading
            // 
            labelDownloading.AutoSize = true;
            labelDownloading.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDownloading.Location = new Point(15, 161);
            labelDownloading.Name = "labelDownloading";
            labelDownloading.Size = new Size(63, 25);
            labelDownloading.TabIndex = 7;
            labelDownloading.Text = "label1";
            // 
            // textBoxId
            // 
            textBoxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxId.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxId.Location = new Point(15, 57);
            textBoxId.Margin = new Padding(0);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(235, 35);
            textBoxId.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 14.25F);
            buttonCancel.Location = new Point(284, 99);
            buttonCancel.Margin = new Padding(0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(121, 52);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonId
            // 
            buttonId.Font = new Font("Segoe UI", 14.25F);
            buttonId.Location = new Point(263, 57);
            buttonId.Margin = new Padding(0);
            buttonId.Name = "buttonId";
            buttonId.Size = new Size(142, 33);
            buttonId.TabIndex = 3;
            buttonId.Text = "Add ID";
            buttonId.UseVisualStyleBackColor = true;
            buttonId.Click += buttonId_Click;
            // 
            // buttonStop
            // 
            buttonStop.Font = new Font("Segoe UI", 14.25F);
            buttonStop.Location = new Point(149, 99);
            buttonStop.Margin = new Padding(0);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(121, 52);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 14.25F);
            buttonStart.Location = new Point(15, 99);
            buttonStart.Margin = new Padding(0);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(121, 52);
            buttonStart.TabIndex = 4;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // panelQueue
            // 
            panelQueue.BackColor = SystemColors.Control;
            panelQueue.Controls.Add(panelInnerQueue);
            panelQueue.Dock = DockStyle.Top;
            panelQueue.Location = new Point(450, 0);
            panelQueue.Margin = new Padding(0);
            panelQueue.Name = "panelQueue";
            panelQueue.Padding = new Padding(10, 20, 20, 10);
            panelQueue.Size = new Size(350, 266);
            panelQueue.TabIndex = 1;
            // 
            // panelInnerQueue
            // 
            panelInnerQueue.BackColor = SystemColors.ControlLightLight;
            panelInnerQueue.Controls.Add(buttonRemoveAll);
            panelInnerQueue.Controls.Add(listBoxQueue);
            panelInnerQueue.Controls.Add(buttonRemove);
            panelInnerQueue.Location = new Point(10, 20);
            panelInnerQueue.Margin = new Padding(0);
            panelInnerQueue.Name = "panelInnerQueue";
            panelInnerQueue.Padding = new Padding(15);
            panelInnerQueue.Size = new Size(320, 236);
            panelInnerQueue.TabIndex = 11;
            // 
            // buttonRemoveAll
            // 
            buttonRemoveAll.Font = new Font("Segoe UI", 14.25F);
            buttonRemoveAll.Location = new Point(188, 125);
            buttonRemoveAll.Margin = new Padding(0);
            buttonRemoveAll.Name = "buttonRemoveAll";
            buttonRemoveAll.Size = new Size(117, 94);
            buttonRemoveAll.TabIndex = 2;
            buttonRemoveAll.Text = "Remove All";
            buttonRemoveAll.UseVisualStyleBackColor = true;
            buttonRemoveAll.Click += buttonRemoveAll_Click;
            // 
            // listBoxQueue
            // 
            listBoxQueue.BorderStyle = BorderStyle.FixedSingle;
            listBoxQueue.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxQueue.FormattingEnabled = true;
            listBoxQueue.HorizontalScrollbar = true;
            listBoxQueue.Location = new Point(15, 15);
            listBoxQueue.Margin = new Padding(0);
            listBoxQueue.Name = "listBoxQueue";
            listBoxQueue.Size = new Size(160, 202);
            listBoxQueue.TabIndex = 3;
            // 
            // buttonRemove
            // 
            buttonRemove.Font = new Font("Segoe UI", 14.25F);
            buttonRemove.Location = new Point(188, 15);
            buttonRemove.Margin = new Padding(0);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(117, 94);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // panelUserInfo
            // 
            panelUserInfo.BackColor = SystemColors.Control;
            panelUserInfo.Controls.Add(panelInnerUserInfo);
            panelUserInfo.Dock = DockStyle.Fill;
            panelUserInfo.Location = new Point(450, 266);
            panelUserInfo.Margin = new Padding(0);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Padding = new Padding(10, 10, 20, 20);
            panelUserInfo.Size = new Size(350, 160);
            panelUserInfo.TabIndex = 2;
            // 
            // panelInnerUserInfo
            // 
            panelInnerUserInfo.BackColor = SystemColors.ControlLightLight;
            panelInnerUserInfo.Controls.Add(labelUserIllustsValue);
            panelInnerUserInfo.Controls.Add(labelUserIdValue);
            panelInnerUserInfo.Controls.Add(labelUsernameValue);
            panelInnerUserInfo.Controls.Add(labelUserIllusts);
            panelInnerUserInfo.Controls.Add(pictureBoxUser);
            panelInnerUserInfo.Controls.Add(labelUserId);
            panelInnerUserInfo.Controls.Add(labelName);
            panelInnerUserInfo.Location = new Point(10, 10);
            panelInnerUserInfo.Margin = new Padding(0);
            panelInnerUserInfo.Name = "panelInnerUserInfo";
            panelInnerUserInfo.Padding = new Padding(15);
            panelInnerUserInfo.Size = new Size(320, 130);
            panelInnerUserInfo.TabIndex = 12;
            // 
            // labelUserIllustsValue
            // 
            labelUserIllustsValue.AutoSize = true;
            labelUserIllustsValue.Font = new Font("Segoe UI", 12F);
            labelUserIllustsValue.Location = new Point(216, 93);
            labelUserIllustsValue.Name = "labelUserIllustsValue";
            labelUserIllustsValue.Size = new Size(52, 21);
            labelUserIllustsValue.TabIndex = 6;
            labelUserIllustsValue.Text = "label3";
            // 
            // labelUserIdValue
            // 
            labelUserIdValue.AutoSize = true;
            labelUserIdValue.Font = new Font("Segoe UI", 12F);
            labelUserIdValue.Location = new Point(190, 54);
            labelUserIdValue.Name = "labelUserIdValue";
            labelUserIdValue.Size = new Size(52, 21);
            labelUserIdValue.TabIndex = 5;
            labelUserIdValue.Text = "label2";
            // 
            // labelUsernameValue
            // 
            labelUsernameValue.AutoSize = true;
            labelUsernameValue.Font = new Font("Segoe UI", 12F);
            labelUsernameValue.Location = new Point(181, 15);
            labelUsernameValue.Name = "labelUsernameValue";
            labelUsernameValue.Size = new Size(52, 21);
            labelUsernameValue.TabIndex = 4;
            labelUsernameValue.Text = "label1";
            // 
            // labelUserIllusts
            // 
            labelUserIllusts.AutoSize = true;
            labelUserIllusts.Font = new Font("Segoe UI", 12F);
            labelUserIllusts.Location = new Point(120, 93);
            labelUserIllusts.Name = "labelUserIllusts";
            labelUserIllusts.Size = new Size(94, 21);
            labelUserIllusts.TabIndex = 3;
            labelUserIllusts.Text = "Illustrations:";
            // 
            // pictureBoxUser
            // 
            pictureBoxUser.Image = Properties.Resources.no_user;
            pictureBoxUser.Location = new Point(15, 15);
            pictureBoxUser.Margin = new Padding(0);
            pictureBoxUser.Name = "pictureBoxUser";
            pictureBoxUser.Size = new Size(100, 100);
            pictureBoxUser.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxUser.TabIndex = 0;
            pictureBoxUser.TabStop = false;
            // 
            // labelUserId
            // 
            labelUserId.AutoSize = true;
            labelUserId.Font = new Font("Segoe UI", 12F);
            labelUserId.Location = new Point(120, 54);
            labelUserId.Name = "labelUserId";
            labelUserId.Size = new Size(64, 21);
            labelUserId.TabIndex = 2;
            labelUserId.Text = "User ID:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(120, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(55, 21);
            labelName.TabIndex = 1;
            labelName.Text = "Name:";
            // 
            // Downloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(panelUserInfo);
            Controls.Add(panelQueue);
            Controls.Add(panelDownload);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Downloader";
            Text = "Downloader";
            panelDownload.ResumeLayout(false);
            panelInnerDownloaded.ResumeLayout(false);
            panelInnerDownloaded.PerformLayout();
            panelQueue.ResumeLayout(false);
            panelInnerQueue.ResumeLayout(false);
            panelUserInfo.ResumeLayout(false);
            panelInnerUserInfo.ResumeLayout(false);
            panelInnerUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDownload;
        private Panel panelQueue;
        private Panel panelUserInfo;
        private ThemedButton buttonRemoveAll;
        private ThemedButton buttonRemove;
        private Label labelUserIllusts;
        private Label labelUserId;
        private Label labelName;
        private PictureBox pictureBoxUser;
        private ListBox listBoxQueue;
        private Panel panelInnerDownloaded;
        private Panel panelInnerUserInfo;
        private Panel panelInnerQueue;
        private ThemedButton buttonFolder;
        private ThemedProgressBar progressBarDownloading;
        private TextBox textBoxFolder;
        private Label labelDownloading;
        private TextBox textBoxId;
        private ThemedButton buttonCancel;
        private ThemedButton buttonId;
        private ThemedButton buttonStop;
        private ThemedButton buttonStart;
        private Label labelUserIllustsValue;
        private Label labelUserIdValue;
        private Label labelUsernameValue;
        private ListBox listBoxDownloaded;
    }
}