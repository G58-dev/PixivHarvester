namespace UI.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLogIn = new Button();
            panel1 = new Panel();
            pictureBoxIcon = new PictureBox();
            textBoxEnterSession = new TextBox();
            labelEnterSession = new Label();
            panel2 = new Panel();
            pictureBoxBanner = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBanner).BeginInit();
            SuspendLayout();
            // 
            // buttonLogIn
            // 
            buttonLogIn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogIn.Location = new Point(121, 335);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(262, 41);
            buttonLogIn.TabIndex = 0;
            buttonLogIn.Text = "Log in";
            buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBoxIcon);
            panel1.Controls.Add(textBoxEnterSession);
            panel1.Controls.Add(labelEnterSession);
            panel1.Controls.Add(buttonLogIn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 426);
            panel1.TabIndex = 1;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = Properties.Resources.favicon;
            pictureBoxIcon.Location = new Point(177, 50);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(150, 150);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 3;
            pictureBoxIcon.TabStop = false;
            // 
            // textBoxEnterSession
            // 
            textBoxEnterSession.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEnterSession.Location = new Point(26, 257);
            textBoxEnterSession.Name = "textBoxEnterSession";
            textBoxEnterSession.PlaceholderText = "PHPSESSID";
            textBoxEnterSession.Size = new Size(452, 33);
            textBoxEnterSession.TabIndex = 2;
            // 
            // labelEnterSession
            // 
            labelEnterSession.AutoSize = true;
            labelEnterSession.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEnterSession.Location = new Point(154, 229);
            labelEnterSession.Name = "labelEnterSession";
            labelEnterSession.Size = new Size(197, 25);
            labelEnterSession.TabIndex = 1;
            labelEnterSession.Text = "Enter your PHPSESSID";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxBanner);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(505, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 426);
            panel2.TabIndex = 2;
            // 
            // pictureBoxBanner
            // 
            pictureBoxBanner.Dock = DockStyle.Fill;
            pictureBoxBanner.Location = new Point(0, 0);
            pictureBoxBanner.Name = "pictureBoxBanner";
            pictureBoxBanner.Size = new Size(295, 426);
            pictureBoxBanner.TabIndex = 0;
            pictureBoxBanner.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxBanner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLogIn;
        private Panel panel1;
        private PictureBox pictureBoxIcon;
        private TextBox textBoxEnterSession;
        private Label labelEnterSession;
        private Panel panel2;
        private PictureBox pictureBoxBanner;
    }
}