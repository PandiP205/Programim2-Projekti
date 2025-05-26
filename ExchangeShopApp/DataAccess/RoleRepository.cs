using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExchangeShopApp.Entities;
using ExchangeShopApp.Utils;

namespace ExchangeShopApp.DataAccess
{
    public class RoleRepository
    {
        private readonly string _connectionString;

        public RoleRepository()
        {
            _connectionString = DBConnection.ConnectionString; 
        }

        public Role GetRoleById(int roleId)
        {
            Role role = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT RoleID, RoleName FROM Roles WHERE RoleID = @RoleID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                role = new Role
                                {
                                    RoleID = Convert.ToInt32(reader["RoleID"]),
                                    RoleName = reader["RoleName"].ToString()
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in GetRoleById: {ex.Message}");
                        throw;
                    }
                }
            }
            return role;
        }

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Role role = new Role
                                {
                                    RoleID = Convert.ToInt32(reader["RoleID"]),
                                    RoleName = reader["RoleName"].ToString()
                                };
                                roles.Add(role);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in GetAllRoles: {ex.Message}");
                        throw;
                    }
                }
            }
            return roles;
        }
    }
}