using UI.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public static Panel MainPanel;
        public MainForm()
        {
            InitializeComponent();
            MainPanel = panelMain;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Dock = DockStyle.Fill;
            login.TopLevel = false;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(login);
            login.Show();

        }
    }
}
