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
            ManageUsersForm manageUsersForm = new ManageUsersForm();
            manageUsersForm.ShowDialog(this);
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCurrenciesForm manageCurrenciesForm = new ManageCurrenciesForm();
            manageCurrenciesForm.ShowDialog(this);
        }

        private void exchangeRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageExchangeRatesForm ratesForm = new ManageExchangeRatesForm();

            ratesForm.ShowDialog(this);
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionHistoryForm historyForm = new TransactionHistoryForm();
            historyForm.ShowDialog();
        }
        private void downloadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                        sw.WriteLine("TransactionID,UserID,TransactionType,CustomerName,ForeignCurrencyID,AmountForeign,AmountLocal,ExchangeRateApplied,TransactionDate,ReceiptNotes");
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
                    string query = "SELECT TransactionID, UserID, FromCurrencyID, ToCurrencyID, AmountFrom, AmountTo, Rate, TransactionDate, TransactionType FROM Transactions";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction t = new Transaction
                                {
                                    TransactionID = Convert.ToInt64(reader["TransactionID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    CustomerName = string.Empty,
                                    ForeignCurrencyID = Convert.ToInt32(reader["FromCurrencyID"]),
                                    AmountForeign = Convert.ToDecimal(reader["AmountFrom"]),
                                    AmountLocal = Convert.ToDecimal(reader["AmountTo"]),
                                    ExchangeRateApplied = Convert.ToDecimal(reader["Rate"]),
                                    TransactionDate = Convert.ToDateTime(reader["TransactionDate"]),
                                    TransactionType = reader["TransactionType"].ToString(),
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