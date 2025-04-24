namespace UI.Forms
{
    public partial class Downloader : Form
    {
        private FolderBrowserDialog _folderBrowerDialog;
        MainForm _mainForm;
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

        private void buttonStart_Click(object sender, EventArgs e)
        {

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
