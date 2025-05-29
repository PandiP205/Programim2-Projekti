using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExchangeShopApp.Entities;

namespace ExchangeShopApp
{
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
        }

        private void TransactionHistoryForm_Load(object sender, EventArgs e)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                transactions = new AdminMainForm().GetTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving transactions: " + ex.Message);
            }

            dataGridViewTransactions.DataSource = transactions;
        }
    }
}