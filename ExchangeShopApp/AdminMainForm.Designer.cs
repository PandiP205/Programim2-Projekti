namespace ExchangeShopApp
{
    partial class AdminMainForm
    {

        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            manageToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            currenciesToolStripMenuItem = new ToolStripMenuItem();
            exchangeRatesToolStripMenuItem = new ToolStripMenuItem();
            transactionsToolStripMenuItem = new ToolStripMenuItem();
            viewHistoryToolStripMenuItem = new ToolStripMenuItem();
            downloadReportToolStripMenuItem = new ToolStripMenuItem();
            lblAdminWelcomeMessage = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
         
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, manageToolStripMenuItem, transactionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
             
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
             
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem, currenciesToolStripMenuItem, exchangeRatesToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(77, 24);
            manageToolStripMenuItem.Text = "&Manage";
           
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(224, 26);
            usersToolStripMenuItem.Text = "&Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
           
            currenciesToolStripMenuItem.Name = "currenciesToolStripMenuItem";
            currenciesToolStripMenuItem.Size = new Size(224, 26);
            currenciesToolStripMenuItem.Text = "&Currencies";
            currenciesToolStripMenuItem.Click += currenciesToolStripMenuItem_Click;
            
            exchangeRatesToolStripMenuItem.Name = "exchangeRatesToolStripMenuItem";
            exchangeRatesToolStripMenuItem.Size = new Size(224, 26);
            exchangeRatesToolStripMenuItem.Text = "Exchange &Rates";
            exchangeRatesToolStripMenuItem.Click += exchangeRatesToolStripMenuItem_Click;
            
            transactionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewHistoryToolStripMenuItem, downloadReportToolStripMenuItem });
            transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            transactionsToolStripMenuItem.Size = new Size(104, 24);
            transactionsToolStripMenuItem.Text = "&Transactions";
           
            viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            viewHistoryToolStripMenuItem.Size = new Size(224, 26);
            viewHistoryToolStripMenuItem.Text = "&View History";
            viewHistoryToolStripMenuItem.Click += viewHistoryToolStripMenuItem_Click;
           
            downloadReportToolStripMenuItem.Name = "downloadReportToolStripMenuItem";
            downloadReportToolStripMenuItem.Size = new Size(224, 26);
            downloadReportToolStripMenuItem.Text = "&Download Report";
            downloadReportToolStripMenuItem.Click += downloadReportToolStripMenuItem_Click;
           
            lblAdminWelcomeMessage.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminWelcomeMessage.Location = new Point(12, 398);
            lblAdminWelcomeMessage.Name = "lblAdminWelcomeMessage";
            lblAdminWelcomeMessage.Size = new Size(184, 43);
            lblAdminWelcomeMessage.TabIndex = 1;
            lblAdminWelcomeMessage.Text = "Welcome!";
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAdminWelcomeMessage);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem currenciesToolStripMenuItem;
        private ToolStripMenuItem exchangeRatesToolStripMenuItem;
        private ToolStripMenuItem transactionsToolStripMenuItem;
        private ToolStripMenuItem viewHistoryToolStripMenuItem;
        private ToolStripMenuItem downloadReportToolStripMenuItem;
        private Label lblAdminWelcomeMessage;
    }
}