using UI.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        private Form currentInnerForm = null!;
        public Core.Classes.Downloader coreDownloader = new();
        public MainForm()
        {
            InitializeComponent();
            LoadInnerForm(new Login(this)); // Loads Login page when App starts
            updateToolStripMenuItem.Enabled = false;
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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInnerForm(new Login(this));
            updateToolStripMenuItem.Enabled = false;
        }
    }
}
