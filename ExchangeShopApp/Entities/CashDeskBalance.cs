using System;

namespace ExchangeShopApp.Entities
{
    public class CashDeskBalance
    {
        public int BalanceID { get; set; }
        public int CurrencyID { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime LastUpdated { get; set; }
        public CashDeskBalance()
        {
            LastUpdated = DateTime.UtcNow;
        }
    }
}