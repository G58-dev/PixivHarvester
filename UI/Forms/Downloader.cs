using Core.Classes;

namespace UI.Forms
{
    public partial class Downloader : Form
    {
        private FolderBrowserDialog _folderBrowerDialog;
        MainForm _mainForm;

        // To stop downloading images
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        public Downloader(MainForm form)
        {
            InitializeComponent();
            buttonId.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            buttonCancel.Enabled = false;
            buttonRemove.Enabled = false;
            buttonRemoveAll.Enabled = false;
            _mainForm = form;
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

            DisableOrEnableButtons();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonCancel.Enabled = true;

            int userId = 0;

            Int32.TryParse(listBoxQueue.Items[0].ToString(), out userId);

            await _mainForm.coreDownloader.FetchUserAsync(userId);
            listBoxQueue.Items.Remove(listBoxQueue.Items[0]);

            _mainForm.coreDownloader.SaveUserToJSON();
            await _mainForm.coreDownloader.DownloadIllustAsync(_mainForm.coreDownloader.UserWeb.BgImage);

            pictureBoxUser.ImageLocation = @$"{_mainForm.coreDownloader.SavePath}\{_mainForm.coreDownloader.UserWeb.Id}\user_bg.png";
            labelUsernameValue.Text = _mainForm.coreDownloader.UserWeb.Name;
            labelUserIdValue.Text = _mainForm.coreDownloader.UserWeb.Id.ToString();
            labelUserIllustsValue.Text = _mainForm.coreDownloader.UserWeb.Illusts.Count.ToString();

            foreach (int illustID in _mainForm.coreDownloader.UserWeb.Illusts)
            {
                string originalURL = await _mainForm.coreDownloader.FetchIllustURLAsync(illustID);
                if (originalURL == "No Image")
                {
                    continue;
                }
                else
                {
                    await _mainForm.coreDownloader.DownloadIllustAsync(originalURL, illustID);
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

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
    }
}
