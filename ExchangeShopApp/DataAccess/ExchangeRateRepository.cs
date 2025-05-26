using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExchangeShopApp.Entities;
using ExchangeShopApp.Utils;
using System.Diagnostics;

namespace ExchangeShopApp.DataAccess
{
    public class ExchangeRateRepository
    {
        private readonly string _connectionString;

        public ExchangeRateRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }

        public int AddOrUpdateExchangeRate(ExchangeRate exchangeRate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT ExchangeRateID FROM ExchangeRates WHERE FromCurrencyID = @FromCurrencyID AND ToCurrencyID = @ToCurrencyID";
                int existingRateId = 0;
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, connection))
                {
                    selectCmd.Parameters.AddWithValue("@FromCurrencyID", exchangeRate.FromCurrencyID);
                    selectCmd.Parameters.AddWithValue("@ToCurrencyID", exchangeRate.ToCurrencyID);
                    object result = selectCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        existingRateId = Convert.ToInt32(result);
                    }
                }

                string query;
                if (existingRateId > 0)
                {
                    query = @"UPDATE ExchangeRates 
                              SET Rate = @Rate, LastUpdatedAt = @LastUpdatedAt 
                              WHERE ExchangeRateID = @ExchangeRateID";
                    exchangeRate.ExchangeRateID = existingRateId;
                }
                else
                {
                    query = @"INSERT INTO ExchangeRates (FromCurrencyID, ToCurrencyID, Rate, LastUpdatedAt) 
                              OUTPUT INSERTED.ExchangeRateID
                              VALUES (@FromCurrencyID, @ToCurrencyID, @Rate, @LastUpdatedAt)";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromCurrencyID", exchangeRate.FromCurrencyID);
                    command.Parameters.AddWithValue("@ToCurrencyID", exchangeRate.ToCurrencyID);
                    command.Parameters.AddWithValue("@Rate", exchangeRate.Rate);
                    command.Parameters.AddWithValue("@LastUpdatedAt", exchangeRate.LastUpdatedAt);
                    if (existingRateId > 0)
                    {
                        command.Parameters.AddWithValue("@ExchangeRateID", existingRateId);
                        command.ExecuteNonQuery();
                        return existingRateId;
                    }
                    else
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
        }

        public ExchangeRate GetExchangeRateById(int exchangeRateId)
        {
            ExchangeRate rate = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ExchangeRates WHERE ExchangeRateID = @ExchangeRateID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExchangeRateID", exchangeRateId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rate = MapReaderToExchangeRate(reader);
                        }
                    }
                }
            }
            return rate;
        }

        public ExchangeRate GetExchangeRateByPair(int fromCurrencyId, int toCurrencyId)
        {
            ExchangeRate rate = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ExchangeRates WHERE FromCurrencyID = @FromCurrencyID AND ToCurrencyID = @ToCurrencyID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromCurrencyID", fromCurrencyId);
                    command.Parameters.AddWithValue("@ToCurrencyID", toCurrencyId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rate = MapReaderToExchangeRate(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetExchangeRateByPair: {ex.Message}");
                        throw;
                    }
                }
            }
            return rate;
        }


        public List<ExchangeRate> GetAllExchangeRates()
        {
            List<ExchangeRate> rates = new List<ExchangeRate>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ExchangeRates";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rates.Add(MapReaderToExchangeRate(reader));
                        }
                    }
                }
            }
            return rates;
        }

        public bool DeleteExchangeRate(int exchangeRateId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM ExchangeRates WHERE ExchangeRateID = @ExchangeRateID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExchangeRateID", exchangeRateId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private ExchangeRate MapReaderToExchangeRate(SqlDataReader reader)
        {
            return new ExchangeRate
            {
                ExchangeRateID = Convert.ToInt32(reader["ExchangeRateID"]),
                FromCurrencyID = Convert.ToInt32(reader["FromCurrencyID"]),
                ToCurrencyID = Convert.ToInt32(reader["ToCurrencyID"]),
                Rate = Convert.ToDecimal(reader["Rate"]),
                LastUpdatedAt = Convert.ToDateTime(reader["LastUpdatedAt"])
            };
        }
    }
}