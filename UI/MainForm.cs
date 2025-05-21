using UI.Forms;
using UI.ThemeSources;

namespace UI
{
    public partial class MainForm : Form
    {
        private Form currentInnerForm = null!;
        public Core.Classes.Downloader coreDownloader = new();
        public MainForm()
        {
            InitializeComponent();
            menuStrip.Renderer = new BrowserMenuRenderer();
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

        #region Class to change the colors for the menuStrip
        public class BrowserMenuRenderer : ToolStripProfessionalRenderer
        {
            public BrowserMenuRenderer() : base(new BrowserColors()) { }
        }
        public class BrowserColors : ProfessionalColorTable
        {
            // MenuItemPressed (top items selected)
            public override Color MenuItemPressedGradientBegin => Themes.Current.MenuStrip.Pressed;
            public override Color MenuItemPressedGradientMiddle => Themes.Current.MenuStrip.Pressed;
            public override Color MenuItemPressedGradientEnd => Themes.Current.MenuStrip.Pressed;

            // MenuItemSelected (top items & inner items)
            public override Color MenuItemSelectedGradientBegin => Themes.Current.MenuStrip.Pressed;
            public override Color MenuItemSelectedGradientEnd => Themes.Current.MenuStrip.Pressed;

            // MenuItemBorder & InnerBorder
            public override Color MenuBorder => Themes.Current.MenuStrip.Border;
            public override Color MenuItemBorder => Themes.Current.MenuStrip.Border;

            // Image Color (left side)
            public override Color ImageMarginGradientBegin => Themes.Current.ItemImageBackground;
            public override Color ImageMarginGradientMiddle => Themes.Current.ItemImageBackground;
            public override Color ImageMarginGradientEnd => Themes.Current.ItemImageBackground;

            // Items background
            public override Color ToolStripDropDownBackground => Themes.Current.ItemBackground;
        }
        #endregion

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
