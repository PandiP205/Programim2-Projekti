using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ExchangeShopApp.Entities;
using ExchangeShopApp.Utils;

namespace ExchangeShopApp.DataAccess
{
    public class CurrencyRepository
    {
        private readonly string _connectionString;

        public CurrencyRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public int AddCurrency(Currency currency)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Currencies (CurrencyCode, CurrencyName, CreatedAt)
                                 OUTPUT INSERTED.CurrencyID
                                 VALUES (@CurrencyCode, @CurrencyName, @CreatedAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyCode", currency.CurrencyCode.ToUpper());
                    command.Parameters.AddWithValue("@CurrencyName", currency.CurrencyName);
                    command.Parameters.AddWithValue("@CreatedAt", currency.CreatedAt);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in AddCurrency: {ex.Message}");
                        if (ex.Number == 2627 || ex.Number == 2601)
                        {
                            Debug.WriteLine($"Attempted to add a currency with a duplicate code: {currency.CurrencyCode}");
                        }
                        throw;
                    }
                }
            }
            return -1;
        }

        public Currency GetCurrencyByCode(string currencyCode)
        {
            Currency currency = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT CurrencyID, CurrencyCode, CurrencyName, CreatedAt
                                 FROM Currencies
                                 WHERE CurrencyCode = @CurrencyCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyCode", currencyCode.ToUpper());
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currency = MapReaderToCurrency(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetCurrencyByCode: {ex.Message}");
                        throw;
                    }
                }
            }
            return currency;
        }

        public Currency GetCurrencyById(int currencyId)
        {
            Currency currency = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT CurrencyID, CurrencyCode, CurrencyName, CreatedAt
                                 FROM Currencies
                                 WHERE CurrencyID = @CurrencyID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyID", currencyId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currency = MapReaderToCurrency(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetCurrencyById: {ex.Message}");
                        throw;
                    }
                }
            }
            return currency;
        }

        public List<Currency> GetAllCurrencies()
        {
            List<Currency> currencies = new List<Currency>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT CurrencyID, CurrencyCode, CurrencyName, CreatedAt
                                 FROM Currencies ORDER BY CurrencyCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currencies.Add(MapReaderToCurrency(reader));
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetAllCurrencies: {ex.Message}");
                        throw;
                    }
                }
            }
            return currencies;
        }

        private Currency MapReaderToCurrency(SqlDataReader reader)
        {
            return new Currency
            {
                CurrencyID = Convert.ToInt32(reader["CurrencyID"]),
                CurrencyCode = reader["CurrencyCode"].ToString(),
                CurrencyName = reader["CurrencyName"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
    }
}