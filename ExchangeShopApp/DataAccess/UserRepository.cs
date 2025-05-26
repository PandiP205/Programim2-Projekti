using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using ExchangeShopApp.Entities;
using ExchangeShopApp.Utils;
using System.Diagnostics;

namespace ExchangeShopApp.DataAccess
{
    public class UserRepository
    {
        private readonly string _connectionString;
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 10000;

        public UserRepository()
        {
            _connectionString = DBConnection.ConnectionString;
        }
        private static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
            }
        }
        private static bool VerifyPassword(string password, string storedHashBase64, string storedSaltBase64)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSaltBase64);
            byte[] storedHashBytes = Convert.FromBase64String(storedHashBase64);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] computedHashBytes = pbkdf2.GetBytes(HashSize);
                for (int i = 0; i < computedHashBytes.Length; i++)
                {
                    if (computedHashBytes[i] != storedHashBytes[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public int AddUser(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }

            var (hash, salt) = HashPassword(password);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Users (Username, PasswordHash, PasswordSalt, FullName, Email, RoleID, CreatedAt, LastLoginDate)
                                 OUTPUT INSERTED.UserID
                                 VALUES (@Username, @PasswordHash, @PasswordSalt, @FullName, @Email, @RoleID, @CreatedAt, @LastLoginDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@RoleID", user.RoleID);
                    command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    command.Parameters.AddWithValue("@LastLoginDate", (object)user.LastLoginDate ?? DBNull.Value);

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
                        Debug.WriteLine($"SQL Error in AddUser: {ex.Message}");
                        if (ex.Number == 2627 || ex.Number == 2601) 
                        {
                            Debug.WriteLine($"Attempted to add a user with a duplicate username or email: {user.Username} / {user.Email}");
                        }
                        throw;
                    }
                }
            }
            return -1;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT UserID, Username, PasswordHash, PasswordSalt, FullName, Email, RoleID, CreatedAt, LastLoginDate
                                 FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = MapReaderToUser(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetUserByUsername: {ex.Message}");
                        throw;
                    }
                }
            }
            return user;
        }
        public User AuthenticateUser(string username, string password)
        {
            User user = GetUserByUsername(username);
            if (user != null && VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }
            return null;
        }


        public User GetUserById(int userId)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT UserID, Username, PasswordHash, PasswordSalt, FullName, Email, RoleID, CreatedAt, LastLoginDate
                                 FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = MapReaderToUser(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in GetUserById: {ex.Message}");
                        throw;
                    }
                }
            }
            return user;
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                
                string query = @"UPDATE Users SET
                                     Username = @Username,
                                     FullName = @FullName,
                                     Email = @Email,
                                     RoleID = @RoleID,
                                     LastLoginDate = @LastLoginDate
                                 WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@RoleID", user.RoleID);
                    command.Parameters.AddWithValue("@LastLoginDate", (object)user.LastLoginDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UserID", user.UserID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in UpdateUser: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public bool UpdateUserPassword(int userId, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("New password cannot be empty.", nameof(newPassword));
            }

            var (hash, salt) = HashPassword(newPassword);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Users SET
                                     PasswordHash = @PasswordHash,
                                     PasswordSalt = @PasswordSalt
                                 WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PasswordHash", hash);
                    command.Parameters.AddWithValue("@PasswordSalt", salt);
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in UpdateUserPassword: {ex.Message}");
                        throw;
                    }
                }
            }
        }


        public bool DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error in DeleteUser: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                UserID = Convert.ToInt32(reader["UserID"]),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                PasswordSalt = reader["PasswordSalt"].ToString(),
                FullName = reader["FullName"].ToString(),
                Email = reader["Email"].ToString(),
                RoleID = Convert.ToInt32(reader["RoleID"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastLoginDate"]) : (DateTime?)null
            };
        }
    }
}