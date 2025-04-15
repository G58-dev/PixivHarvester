using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            mainForm.LoadInnerForm(new Downloader());
            mainForm.updateToolStripMenuItem.Enabled = true;
        }
    }
}
