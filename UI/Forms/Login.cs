using UI.ThemeSources;

namespace UI.Forms
{
    public partial class Login : Form, IThemed
    {
        MainForm mainForm;
        public Login(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            ApplyTheme();
            Themes.ThemeChanged += ApplyTheme;
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
                mainForm.LoadInnerForm(new Downloader(mainForm));
                mainForm.updateToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("PHPSESSID is not a valid session.", "Invalid PHPSESSID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ApplyTheme()
        {
            #region Panels
            panel1.BackColor = Themes.Current.InnerPanel;
            panel2.BackColor = Themes.Current.OuterPanel;
            #endregion

            #region Label & TextBoxes
            labelEnterSession.ForeColor = Themes.Current.Text;
            textBoxEnterSession.BackColor = Themes.Current.TextBox.Base;
            textBoxEnterSession.ForeColor = Themes.Current.Text;
            #endregion
        }
    }
}
