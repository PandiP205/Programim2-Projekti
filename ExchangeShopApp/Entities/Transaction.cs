using System;

namespace ExchangeShopApp.Entities
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public int UserID { get; set; }             
        public string TransactionType { get; set; }
        public string CustomerName { get; set; }
        public int ForeignCurrencyID { get; set; } 
        public decimal AmountForeign { get; set; } 
        public decimal AmountLocal { get; set; }
        public decimal ExchangeRateApplied { get; set; } 
        public DateTime TransactionDate { get; set; }
        public string ReceiptNotes { get; set; }


        public Transaction()
        {
            TransactionDate = DateTime.UtcNow;
        }
    }
}