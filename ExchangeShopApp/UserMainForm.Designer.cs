namespace ExchangeShopApp
{
    partial class UserMainForm
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
            fileToolStripMenuItemUser = new ToolStripMenuItem();
            exitToolStripMenuItemUser = new ToolStripMenuItem();
            exchangeToolStripMenuItem = new ToolStripMenuItem();
            performExchangeToolStripMenuItem = new ToolStripMenuItem();
            viewMyTransactionsToolStripMenuItem = new ToolStripMenuItem();
            ratesToolStripMenuItem = new ToolStripMenuItem();
            viewCurrentRatesToolStripMenuItem = new ToolStripMenuItem();
            lblUserWelcomeMessage = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            
            
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItemUser, exchangeToolStripMenuItem, ratesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            
            fileToolStripMenuItemUser.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItemUser });
            fileToolStripMenuItemUser.Name = "fileToolStripMenuItemUser";
            fileToolStripMenuItemUser.Size = new Size(46, 24);
            fileToolStripMenuItemUser.Text = "&File";
            
            exitToolStripMenuItemUser.Name = "exitToolStripMenuItemUser";
            exitToolStripMenuItemUser.Size = new Size(116, 26);
            exitToolStripMenuItemUser.Text = "E&xit";
            
            exchangeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { performExchangeToolStripMenuItem, viewMyTransactionsToolStripMenuItem });
            exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
            exchangeToolStripMenuItem.Size = new Size(86, 24);
            exchangeToolStripMenuItem.Text = "&Exchange";
             
            performExchangeToolStripMenuItem.Name = "performExchangeToolStripMenuItem";
            performExchangeToolStripMenuItem.Size = new Size(233, 26);
            performExchangeToolStripMenuItem.Text = "&Perform Exchange";
           
            viewMyTransactionsToolStripMenuItem.Name = "viewMyTransactionsToolStripMenuItem";
            viewMyTransactionsToolStripMenuItem.Size = new Size(233, 26);
            viewMyTransactionsToolStripMenuItem.Text = "View &My Transactions";
           
            ratesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewCurrentRatesToolStripMenuItem });
            ratesToolStripMenuItem.Name = "ratesToolStripMenuItem";
            ratesToolStripMenuItem.Size = new Size(59, 24);
            ratesToolStripMenuItem.Text = "R&ates";
            
            viewCurrentRatesToolStripMenuItem.Name = "viewCurrentRatesToolStripMenuItem";
            viewCurrentRatesToolStripMenuItem.Size = new Size(216, 26);
            viewCurrentRatesToolStripMenuItem.Text = "View &Current Rates";
           
            lblUserWelcomeMessage.AutoSize = true;
            lblUserWelcomeMessage.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserWelcomeMessage.Location = new Point(0, 410);
            lblUserWelcomeMessage.Name = "lblUserWelcomeMessage";
            lblUserWelcomeMessage.Size = new Size(121, 31);
            lblUserWelcomeMessage.TabIndex = 1;
            lblUserWelcomeMessage.Text = "Welcome!";
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblUserWelcomeMessage);
            Controls.Add(menuStrip1);
            Name = "UserMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Panel";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItemUser;
        private ToolStripMenuItem exitToolStripMenuItemUser;
        private ToolStripMenuItem exchangeToolStripMenuItem;
        private ToolStripMenuItem performExchangeToolStripMenuItem;
        private ToolStripMenuItem viewMyTransactionsToolStripMenuItem;
        private ToolStripMenuItem ratesToolStripMenuItem;
        private ToolStripMenuItem viewCurrentRatesToolStripMenuItem;
        private Label lblUserWelcomeMessage;
    }
}