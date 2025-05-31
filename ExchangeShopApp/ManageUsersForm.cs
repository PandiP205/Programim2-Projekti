using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography; // For password hashing
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeShopApp.Entities; // Assuming your entities are here
using Microsoft.Extensions.Configuration; // For connection string

namespace ExchangeShopApp
{
    public partial class ManageUsersForm : Form
    {
        private string _connectionString;
        private User _selectedUser = null; // To keep track of the currently selected user for editing

        public ManageUsersForm()
        {
            InitializeComponent();
            LoadConnectionString();
        }

        private void LoadConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _connectionString = configuration.GetConnectionString("ExchangeShopDB");
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            
            LoadRoles();
            LoadUsers();
            ClearInputFields(); // Start with clean fields
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false; // We've defined them manually or will do so
            // If you haven't added columns in the designer, you can add them here:
            // Example:
            // dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserID", HeaderText = "ID", DataPropertyName = "UserID", Visible = false });
            // dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Username", DataPropertyName = "Username" });
            // ... and so on for FullName, Email, RoleName, IsActive, LastLoginDate, CreatedAt

            // Ensure IsActive column shows as a checkbox if not already set in designer
            var isActiveCol = dgvUsers.Columns["IsActive"] as DataGridViewCheckBoxColumn;
            if (isActiveCol != null)
            {
                // It's already a checkbox column, good.
            }
            else
            {
                // If it's a text column showing True/False, you might need to handle its display or re-add it as a checkbox column.
                // For simplicity, ensure it's added as DataGridViewCheckBoxColumn in the designer or code.
            }
        }

        private void LoadRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roles.Add(new Role
                                {
                                    RoleID = reader.GetInt32(0),
                                    RoleName = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    // Adjusted query to match your User entity and database (FullName, Email, LastLoginDate)
                    string query = @"SELECT u.UserID, u.Username, u.FullName, u.Email, u.RoleID, r.RoleName, u.IsActive, u.CreatedAt, u.LastLoginDate, u.PasswordHash, u.PasswordSalt 
                                     FROM Users u 
                                     INNER JOIN Roles r ON u.RoleID = r.RoleID 
                                     ORDER BY u.Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    Username = reader.GetString(reader.GetOrdinal("Username")),
                                    FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FullName")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                    RoleName = reader.GetString(reader.GetOrdinal("RoleName")),
                                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                    LastLoginDate = reader.IsDBNull(reader.GetOrdinal("LastLoginDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastLoginDate")),
                                    PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")), // Store for potential operations, not display
                                    PasswordSalt = reader.GetString(reader.GetOrdinal("PasswordSalt"))  // Store for potential operations
                                });
                            }
                        }
                    }
                }
                dgvUsers.DataSource = null; // Clear previous data
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                _selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;
                if (_selectedUser != null)
                {
                    txtUserID.Text = _selectedUser.UserID.ToString();
                    txtUsername.Text = _selectedUser.Username;
                    txtUsername.Text = _selectedUser.FullName;
                    txtEmail.Text = _selectedUser.Email;
                    cmbRole.SelectedValue = _selectedUser.RoleID;
                    chkIsActive.Checked = _selectedUser.IsActive;
                    txtPassword.Clear(); // Clear password for security; only set if admin types a new one
                }
            }
            else
            {
                _selectedUser = null;
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txtUserID.Clear();
            txtUsername.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1; // Deselect
            chkIsActive.Checked = true; // Default for new user
            _selectedUser = null;
            txtUsername.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            dgvUsers.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return;
            }
            // For new users, password is required
            if (_selectedUser == null && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            string username = txtUsername.Text.Trim();
            string fullName = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            int roleId = (int)cmbRole.SelectedValue;
            bool isActive = chkIsActive.Checked;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query;
                    bool isNewUser = (_selectedUser == null || string.IsNullOrEmpty(txtUserID.Text));

                    if (isNewUser) // ADD NEW USER
                    {
                        if (string.IsNullOrWhiteSpace(txtPassword.Text)) // Should be caught by validation above, but double check
                        {
                            MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string salt = PasswordHelper.GenerateSalt();
                        string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text, salt);

                        query = @"INSERT INTO Users (Username, PasswordHash, PasswordSalt, FullName, RoleID, IsActive, CreatedAt, Email) 
                                  VALUES (@Username, @PasswordHash, @PasswordSalt, @FullName, @RoleID, @IsActive, @CreatedAt, @Email)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                            cmd.Parameters.AddWithValue("@PasswordSalt", salt);
                            cmd.Parameters.AddWithValue("@FullName", string.IsNullOrWhiteSpace(fullName) ? (object)DBNull.Value : fullName);
                            cmd.Parameters.AddWithValue("@RoleID", roleId);
                            cmd.Parameters.AddWithValue("@IsActive", isActive);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now); // Use current server time if possible or DateTime.UtcNow
                            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // UPDATE EXISTING USER
                    {
                        query = @"UPDATE Users SET Username = @Username, FullName = @FullName, RoleID = @RoleID, IsActive = @IsActive, Email = @Email";
                        // Only update password if a new one is provided
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            string salt = _selectedUser.PasswordSalt; // Re-use existing salt if not changing it OR generate new if policy requires
                                                                      // For simplicity, we are re-using. If you generate new salt, update PasswordSalt field too.
                            if (string.IsNullOrEmpty(salt)) // Should not happen for existing users from your DB schema
                            {
                                salt = PasswordHelper.GenerateSalt();
                                query += ", PasswordSalt = @PasswordSalt";
                            }
                            string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text, salt);
                            query += ", PasswordHash = @PasswordHash";
                        }
                        query += " WHERE UserID = @UserID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@FullName", string.IsNullOrWhiteSpace(fullName) ? (object)DBNull.Value : fullName);
                            cmd.Parameters.AddWithValue("@RoleID", roleId);
                            cmd.Parameters.AddWithValue("@IsActive", isActive);
                            cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmd.Parameters.AddWithValue("@UserID", _selectedUser.UserID);

                            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                            {
                                string saltToUse = _selectedUser.PasswordSalt;
                                if (string.IsNullOrEmpty(saltToUse)) saltToUse = PasswordHelper.GenerateSalt(); // Should have a salt

                                cmd.Parameters.AddWithValue("@PasswordHash", PasswordHelper.HashPassword(txtPassword.Text, saltToUse));
                                if (query.Contains("@PasswordSalt")) // if salt was newly generated for update
                                {
                                    cmd.Parameters.AddWithValue("@PasswordSalt", saltToUse);
                                }
                            }
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                LoadUsers(); // Refresh the grid
                ClearInputFields();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Unique constraint violation (e.g. duplicate username)
                {
                    MessageBox.Show($"Error saving user: Username '{username}' already exists. Please choose a different username.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error saving user: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Please select a user from the list first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Prevent deactivating the currently logged-in admin if you want that safety
            // if (_selectedUser.UserID == Program.CurrentUser.UserID && _selectedUser.IsActive) { ... return; }

            bool newActiveState = !_selectedUser.IsActive;
            string action = newActiveState ? "activate" : "deactivate";

            if (MessageBox.Show($"Are you sure you want to {action} user '{_selectedUser.Username}'?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Users SET IsActive = @IsActive WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@IsActive", newActiveState);
                            cmd.Parameters.AddWithValue("@UserID", _selectedUser.UserID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"User '{_selectedUser.Username}' has been {action}d.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers(); // Refresh grid
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    // --- Password Helper ---
    // You should ideally put this in a separate utility class file (e.g., Helpers/PasswordHelper.cs)
    public static class PasswordHelper
    {
        private static readonly int SaltSize = 16; // 128 bit
        private static readonly int HashSize = 20; // SHA-1
        private static readonly int Iterations = 10000; // PBKDF2 iterations

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // This method would be used in your LoginForm
        public static bool VerifyPassword(string password, string storedSalt, string storedHash)
        {
            string newHash = HashPassword(password, storedSalt);
            return newHash == storedHash;
        }
    }
}