
using System;
using System.Windows.Forms;
using ExchangeShopApp.Entities;

namespace ExchangeShopApp
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUser != null)
            {
                lblAdminWelcomeMessage.Text = $"Welcome, {Program.CurrentUser.FullName} (Administrator)!";
                this.Text = $"Admin Dashboard - {Program.CurrentUser.Username} - Exchange Shop";
            }
            else
            {
                MessageBox.Show("No user logged in. Closing admin dashboard.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Users form will open here.");
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Currencies form will open here.");
        }

        private void exchangeRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Exchange Rates form will open here.");
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View All Transactions form will open here.");
        }

        private void downloadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Download Transaction Report form will open here.");
        }

    }
}