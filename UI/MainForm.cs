using UI.Forms;
using UI.ThemeSources;
using UI.ThemeSources.ThemedControls;

namespace UI
{
    public partial class MainForm : Form
    {
        private Form currentInnerForm = null!;
        public Core.Classes.Downloader coreDownloader = new();
        public MainForm()
        {
            InitializeComponent();
            menuStrip.Renderer = new ThemedMenuStrip();
            ApplyTheme();
            Themes.ThemeChanged += ApplyTheme;
            LoadInnerForm(new Login(this)); // Loads Login page when App starts
            updateToolStripMenuItem.Enabled = false;
            lightToolStripMenuItem.Checked = true;
        }

        public void LoadInnerForm(Form innerForm)
        {
            // If an InnerForm exists, it will be closed 
            if (currentInnerForm != null)
            {
                currentInnerForm.Close();
            }

            // Fills the Main Panel with the InnerForm
            currentInnerForm = innerForm;
            currentInnerForm.TopLevel = false;
            currentInnerForm.Dock = DockStyle.Fill;

            // Clears and Adds the InnerForm
            panelMain.Controls.Clear();
            panelMain.Controls.Add(currentInnerForm);

            // Shows the InnerForm
            currentInnerForm.Show();
        }

        public void ApplyTheme()
        {
            menuStrip.BackColor = Themes.Current.MenuStrip.Base;
            menuStrip.ForeColor = Themes.Current.Text;
            updateToolStripMenuItem.ForeColor = Themes.Current.Text;
            lightToolStripMenuItem.ForeColor = Themes.Current.Text;
            darkToolStripMenuItem.ForeColor = Themes.Current.Text;
            superDarkToolStripMenuItem.ForeColor = Themes.Current.Text;
            creditsToolStripMenuItem.ForeColor = Themes.Current.Text;
            versionToolStripMenuItem.ForeColor = Themes.Current.Text;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInnerForm(new Login(this));
            updateToolStripMenuItem.Enabled = false;
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Themes.ChangeTheme(ThemeType.Light);
            lightToolStripMenuItem.Checked = true;
            darkToolStripMenuItem.Checked = false;
            superDarkToolStripMenuItem.Checked = false;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Themes.ChangeTheme(ThemeType.Dark);
            lightToolStripMenuItem.Checked = false;
            darkToolStripMenuItem.Checked = true;
            superDarkToolStripMenuItem.Checked = false;
        }

        private void superDarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Themes.ChangeTheme(ThemeType.SuperDark);
            lightToolStripMenuItem.Checked = false;
            darkToolStripMenuItem.Checked = false;
            superDarkToolStripMenuItem.Checked = true;
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developmnet by: G58\nApp logo by: G58\nApp banner by: G58", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"App version: 0.4.1-beta\nExecuting in: {Environment.OSVersion}", "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
