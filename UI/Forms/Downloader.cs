using UI.ThemeSources;

namespace UI.Forms
{
    public partial class Downloader : Form, IThemed
    {
        private FolderBrowserDialog _folderBrowerDialog;
        MainForm _mainForm;

        // To stop downloading images
        private CancellationTokenSource _cts;
        public Downloader(MainForm form)
        {
            InitializeComponent();
            buttonId.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonCancel.Enabled = false;
            buttonRemove.Enabled = false;
            buttonRemoveAll.Enabled = false;
            labelDownloading.Text = "";
            labelUsernameValue.Text = "";
            labelUserIdValue.Text = "";
            labelUserIllustsValue.Text = "";
            _mainForm = form;
            ApplyTheme();
            Themes.ThemeChanged += ApplyTheme;
        }

        // Toggles the enabled state of the download and remove buttons depending on the queue's content
        private void DisableOrEnableButtons()
        {
            if (listBoxQueue.Items.Count == 0)
            {
                buttonStart.Enabled = false;
                buttonRemove.Enabled = false;
                buttonRemoveAll.Enabled = false;
            }
            else
            {
                buttonStart.Enabled = true;
                buttonRemove.Enabled = true;
                buttonRemoveAll.Enabled = true;
            }
        }

        // Prompts the user to choose a destination folder before downloading 
        private void buttonFolder_Click(object sender, EventArgs e)
        {
            _folderBrowerDialog = new FolderBrowserDialog();
            _folderBrowerDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = _folderBrowerDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxFolder.Text = _folderBrowerDialog.SelectedPath;
                _mainForm.coreDownloader.SavePath = _folderBrowerDialog.SelectedPath;
                buttonId.Enabled = true;
            }
        }

        // Enqueues the selected ID for downloading and displays it in the user's download queue
        private void buttonId_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == string.Empty)
            {
                return;
            }

            listBoxQueue.Items.Add(textBoxId.Text);
            textBoxId.Text = "";

            DisableOrEnableButtons();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            var progressBar = new Progress<int>(value =>
            {
                progressBarDownloading.Value = value;
            });

            var progressDownload = new Progress<string>(value =>
            {
                listBoxDownloaded.Items.Add(value);
            });

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonCancel.Enabled = true;
            labelDownloading.Text = "Downloading...";

            int userId = 0;

            Int32.TryParse(listBoxQueue.Items[0].ToString(), out userId);

            await _mainForm.coreDownloader.FetchUserAsync(userId);
            listBoxQueue.Items.Remove(listBoxQueue.Items[0]);

            _mainForm.coreDownloader.CreateUserFolder();
            _mainForm.coreDownloader.UpdateUserIllusts();

            await _mainForm.coreDownloader.DownloadIllustAsync(_mainForm.coreDownloader.UserWeb.BgImage);

            pictureBoxUser.ImageLocation = @$"{_mainForm.coreDownloader.SavePath}\{_mainForm.coreDownloader.UserWeb.Id}\user_bg.png";
            labelUsernameValue.Text = _mainForm.coreDownloader.UserWeb.Name;
            labelUserIdValue.Text = _mainForm.coreDownloader.UserWeb.Id.ToString();
            labelUserIllustsValue.Text = _mainForm.coreDownloader.UserWeb.Illusts.Count.ToString();

            try
            {
                await _mainForm.coreDownloader.DownloadAllIllusts(token, progressBar, progressDownload);
                labelDownloading.Text = "Download successful";
            }
            catch (OperationCanceledException ex)
            {
                labelDownloading.Text = "Download cancelled.";
            }
            finally
            {
                _cts.Dispose();
                DisableOrEnableButtons();
                progressBarDownloading.Value = 0;
                listBoxDownloaded.Items.Clear();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            labelDownloading.Text = "Cancelling...";
            buttonCancel.Enabled = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxQueue.SelectedIndex == -1)
            {
                return;
            }
            else // Removes the selected Item
            {
                listBoxQueue.Items.Remove(listBoxQueue.Items[listBoxQueue.SelectedIndex]);
                listBoxQueue.ClearSelected();
            }

            DisableOrEnableButtons();
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            listBoxQueue.Items.Clear();

            DisableOrEnableButtons();
        }

        public void ApplyTheme()
        {
            #region Main panels & inner panels
            panelDownload.BackColor = Themes.Current.OuterPanel;
            panelInnerDownloaded.BackColor = Themes.Current.InnerPanel;
            panelQueue.BackColor = Themes.Current.OuterPanel;
            panelInnerQueue.BackColor = Themes.Current.InnerPanel;
            panelUserInfo.BackColor = Themes.Current.OuterPanel;
            panelInnerUserInfo.BackColor = Themes.Current.InnerPanel;
            #endregion

            #region Labels, Textboxes & Listboxes
            labelDownloading.ForeColor = Themes.Current.Text;
            labelName.ForeColor = Themes.Current.Text;
            labelUsernameValue.ForeColor = Themes.Current.Text;
            labelUserId.ForeColor = Themes.Current.Text;
            labelUserIdValue.ForeColor = Themes.Current.Text;
            labelUserIllusts.ForeColor = Themes.Current.Text;
            labelUserIllustsValue.ForeColor = Themes.Current.Text;

            textBoxFolder.BackColor = Themes.Current.TextBox.Disabled;
            textBoxFolder.ForeColor = Themes.Current.Text;
            textBoxId.BackColor = Themes.Current.TextBox.Base;
            textBoxId.ForeColor = Themes.Current.Text;

            listBoxDownloaded.BackColor = Themes.Current.ListBox.Base;
            listBoxDownloaded.ForeColor = Themes.Current.Text;
            listBoxQueue.BackColor = Themes.Current.ListBox.Base;
            listBoxQueue.ForeColor = Themes.Current.Text;
            #endregion
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Themes.ThemeChanged -= ApplyTheme;
            base.OnFormClosed(e);
        }
    }
}
