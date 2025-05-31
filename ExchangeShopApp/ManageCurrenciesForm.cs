using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeShopApp.Entities;
using Microsoft.Extensions.Configuration;

namespace ExchangeShopApp
{
    public partial class ManageCurrenciesForm : Form
    {
        private string connectionString;

        public ManageCurrenciesForm()
        {
            InitializeComponent();
            InitializeConnectionString();
        }

        private void InitializeConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            connectionString = configuration.GetConnectionString("ExchangeShopDB");
        }

        private void ManageCurrenciesForm_Load(object sender, EventArgs e)
        {
            LoadCurrencies();
            ClearFormFields(); // Good practice to start with a clean slate for inputs
            // dgvCurrencies.ClearSelection(); // Optional: Deselect any auto-selected row
            // btnDelete.Enabled = false; // Initially disable delete until a row is selected
        }

        private void LoadCurrencies()
        {
            List<Currency> currencies = new List<Currency>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CurrencyID, CurrencyCode, CurrencyName, CreatedAt FROM Currencies ORDER BY CurrencyName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currencies.Add(new Currency
                                {
                                    CurrencyID = reader.GetInt32(reader.GetOrdinal("CurrencyID")),
                                    CurrencyCode = reader.GetString(reader.GetOrdinal("CurrencyCode")),
                                    CurrencyName = reader.GetString(reader.GetOrdinal("CurrencyName")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                });
                            }
                        }
                    }
                }

                dgvCurrencies.DataSource = null; // Clear previous data
                dgvCurrencies.AutoGenerateColumns = false; // We've defined columns in the designer

                // Ensure your DataGridView column DataPropertyNames match your Currency entity properties
                // These should have been set in ManageCurrenciesForm.Designer.cs:
                // colCurrencyID.DataPropertyName = "CurrencyID";
                // colCurrencyCode.DataPropertyName = "CurrencyCode";
                // colCurrencyName.DataPropertyName = "CurrencyName";
                // colCreatedAt.DataPropertyName = "CreatedAt";

                dgvCurrencies.DataSource = currencies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading currencies: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCurrencies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCurrencies.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCurrencies.SelectedRows[0];
                txtCurrencyID.Text = selectedRow.Cells["colCurrencyID"].Value?.ToString() ?? string.Empty;
                txtCurrencyCode.Text = selectedRow.Cells["colCurrencyCode"].Value?.ToString() ?? string.Empty;
                txtCurrencyName.Text = selectedRow.Cells["colCurrencyName"].Value?.ToString() ?? string.Empty;

                btnDelete.Enabled = true;
                btnSave.Text = "Update"; // Change Save button text to Update
            }
            else
            {
                // If no row is selected, or selection is cleared
                // ClearFormFields(); // Optionally clear fields when selection is lost
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
            }
        }

        private void ClearFormFields()
        {
            txtCurrencyID.Clear();
            txtCurrencyCode.Clear();
            txtCurrencyName.Clear();
            txtCurrencyCode.Focus(); // Set focus to the first editable field
            btnDelete.Enabled = false; // Disable delete when fields are cleared for a new entry
            btnSave.Text = "Save"; // Reset Save button text
            dgvCurrencies.ClearSelection(); // Deselect any row in the grid
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            if (string.IsNullOrWhiteSpace(txtCurrencyCode.Text))
            {
                MessageBox.Show("Currency Code cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrencyCode.Focus();
                return;
            }
            if (txtCurrencyCode.Text.Length != 3) // Basic validation for 3-letter code
            {
                MessageBox.Show("Currency Code must be 3 characters long (e.g., USD).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrencyCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCurrencyName.Text))
            {
                MessageBox.Show("Currency Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrencyName.Focus();
                return;
            }

            string currencyCode = txtCurrencyCode.Text.ToUpper(); // Store as uppercase
            string currencyName = txtCurrencyName.Text;
            bool isUpdate = !string.IsNullOrWhiteSpace(txtCurrencyID.Text); // If ID field has a value, it's an update

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    SqlCommand cmd;

                    if (isUpdate)
                    {
                        // --- UPDATE existing currency ---
                        query = "UPDATE Currencies SET CurrencyCode = @CurrencyCode, CurrencyName = @CurrencyName WHERE CurrencyID = @CurrencyID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CurrencyID", Convert.ToInt32(txtCurrencyID.Text));
                    }
                    else
                    {
                        // --- INSERT new currency ---
                        // Check if currency code already exists
                        string checkQuery = "SELECT COUNT(*) FROM Currencies WHERE CurrencyCode = @CurrencyCode";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("This Currency Code already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtCurrencyCode.Focus();
                                return;
                            }
                        }
                        query = "INSERT INTO Currencies (CurrencyCode, CurrencyName, CreatedAt) VALUES (@CurrencyCode, @CurrencyName, @CreatedAt)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    }

                    cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);
                    cmd.Parameters.AddWithValue("@CurrencyName", currencyName);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show($"Currency {(isUpdate ? "updated" : "saved")} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCurrencies();   // Refresh the grid
                        ClearFormFields();  // Clear fields for next operation
                    }
                    else
                    {
                        MessageBox.Show($"Failed to {(isUpdate ? "update" : "save")} currency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrencyID.Text))
            {
                MessageBox.Show("Please select a currency to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete {txtCurrencyCode.Text} - {txtCurrencyName.Text}?",
                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Currencies WHERE CurrencyID = @CurrencyID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CurrencyID", Convert.ToInt32(txtCurrencyID.Text));
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Currency deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCurrencies();   // Refresh the grid
                                ClearFormFields();  // Clear fields
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete currency. It might have already been deleted or does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Check for foreign key constraint violation (e.g., if currency is used in Transactions or ExchangeRates)
                    if (sqlEx.Number == 547) // SQL Server error code for foreign key violation
                    {
                        MessageBox.Show("Cannot delete this currency as it is being used in other records (e.g., transactions, exchange rates).", "Deletion Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Database error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}