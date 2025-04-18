using Core;

namespace UI.Forms
{
    public partial class Login : Form
    {
        MainForm mainForm;
        public Login(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private async void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (textBoxEnterSession.Text == string.Empty)
            {
                MessageBox.Show("PHPSESSID cannot be empty", "No PHPSESSID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (await mainForm.coreDownloader.IsRealSessionAsync(textBoxEnterSession.Text))
            {
                mainForm.coreDownloader.InitDownloader(textBoxEnterSession.Text);
                mainForm.LoadInnerForm(new Downloader());
                mainForm.updateToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("PHPSESSID is not a valid session.", "Invalid PHPSESSID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
