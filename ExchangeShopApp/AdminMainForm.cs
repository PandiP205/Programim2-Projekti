using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ExchangeShopApp.Entities;
using Microsoft.Extensions.Configuration;

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
            TransactionHistoryForm historyForm = new TransactionHistoryForm();
            historyForm.ShowDialog();
        }
        private void downloadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Retrieve your transactions; replace GetTransactions with your data logic.
            List<Transaction> transactions = GetTransactions();

            if (transactions == null || transactions.Count == 0)
            {
                MessageBox.Show("No transactions available to generate report.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = "TransactionReport.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        // Write CSV header:
                        sw.WriteLine("TransactionID,UserID,TransactionType,CustomerName,ForeignCurrencyID,AmountForeign,AmountLocal,ExchangeRateApplied,TransactionDate,ReceiptNotes");
                        // Write a CSV line for each transaction:
                        foreach (var t in transactions)
                        {
                            sw.WriteLine($"{t.TransactionID},{t.UserID},{t.TransactionType},{t.CustomerName},{t.ForeignCurrencyID},{t.AmountForeign},{t.AmountLocal},{t.ExchangeRateApplied},{t.TransactionDate},{t.ReceiptNotes}");
                        }
                    }
                    MessageBox.Show("Report generated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message);
                }
            }
        }

        // Sample method to simulate transaction retrieval - replace with your own data access.

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("ExchangeShopDB");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Include TransactionID in your SELECT to match your mapping.
                    string query = "SELECT TransactionID, UserID, FromCurrencyID, ToCurrencyID, AmountFrom, AmountTo, Rate, TransactionDate, TransactionType FROM Transactions";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map the database columns to your Transaction model.
                                Transaction t = new Transaction
                                {
                                    // Use GetInt64 because TransactionID is a long.
                                    TransactionID = Convert.ToInt64(reader.GetInt32(0)),
                                    UserID = reader.GetInt32(1),
                                    CustomerName = string.Empty,
                                    ForeignCurrencyID = reader.GetInt32(2),
                                    AmountForeign = reader.GetDecimal(4),
                                    AmountLocal = reader.GetDecimal(5),
                                    ExchangeRateApplied = reader.GetDecimal(6),
                                    TransactionDate = reader.GetDateTime(7),
                                    TransactionType = reader.GetString(8),
                                    ReceiptNotes = string.Empty
                                };
                                transactions.Add(t);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving transactions: " + ex.Message);
            }

            return transactions;
        }
    }
}