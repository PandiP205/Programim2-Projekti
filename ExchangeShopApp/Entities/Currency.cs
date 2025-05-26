using System;

namespace ExchangeShopApp.Entities
{
    public class Currency
    {
        public int CurrencyID { get; set; }      
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public DateTime CreatedAt { get; set; }

        public Currency()
        {
            CurrencyCode = string.Empty;
            CurrencyName = string.Empty;
            CreatedAt = DateTime.UtcNow;
        }
    }
}