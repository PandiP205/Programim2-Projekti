namespace ExchangeShopApp
{
    public partial class UserMainForm : Form
    {
        public UserMainForm()
        {
            InitializeComponent();
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUser != null)
            {
                lblUserWelcomeMessage.Text = $"Welcome, {Program.CurrentUser.FullName}!";
                this.Text = $"User Panel - {Program.CurrentUser.Username} - Exchange Shop";
            }
            else
            {
                MessageBox.Show("No user logged in. Closing user panel.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void exitToolStripMenuItemUser_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void performExchangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Perform Exchange form will open here.");
        }

        private void viewMyTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View My Transactions form will open here.");
        }

        private void viewCurrentRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Current Exchange Rates form will open here.");
        }
    }
}