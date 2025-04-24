namespace UI.Forms
{
    public partial class Downloader : Form
    {
        private FolderBrowserDialog _folderBrowerDialog;
        MainForm _mainForm;
        public Downloader(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
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
    }
}
