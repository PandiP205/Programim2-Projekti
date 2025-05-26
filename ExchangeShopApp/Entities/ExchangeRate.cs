using System;

namespace ExchangeShopApp.Entities
{
    public class ExchangeRate
    {
        public int ExchangeRateID { get; set; }
        public int FromCurrencyID { get; set; }
        public int ToCurrencyID { get; set; }
        public decimal Rate { get; set; }
        public DateTime LastUpdatedAt { get; set; }

    }
}