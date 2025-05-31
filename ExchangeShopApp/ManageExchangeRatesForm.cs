using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeShopApp.Entities;


namespace ExchangeShopApp
{
    public partial class ManageExchangeRatesForm : Form
    {

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExchangeShopDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

        private List<Currency> currencies;
        public ManageExchangeRatesForm()
        {
            InitializeComponent();
        }

        private void ManageExchangeRatesForm_Load(object sender, EventArgs e)
        {
            LoadCurrencies();
            LoadExchangeRates();
            UpdateButtonStates();
        }

        private void LoadCurrencies()
        {
            currencies = new List<Currency>();
            string query = "SELECT CurrencyID, CurrencyCode, CurrencyName FROM dbo.Currencies ORDER BY CurrencyCode;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currencies.Add(new Currency
                                {
                                    CurrencyID = Convert.ToInt32(reader["CurrencyID"]),
                                    CurrencyCode = reader["CurrencyCode"].ToString(),
                                    CurrencyName = reader["CurrencyName"].ToString()
                                });
                            }
                        }
                    }
                }


                cmbFromCurrency.DataSource = new BindingList<Currency>(currencies);
                cmbFromCurrency.DisplayMember = "CurrencyCode";
                cmbFromCurrency.ValueMember = "CurrencyID";

                cmbToCurrency.DataSource = new BindingList<Currency>(currencies);
                cmbToCurrency.DisplayMember = "CurrencyCode";
                cmbToCurrency.ValueMember = "CurrencyID";

                cmbFromCurrency.SelectedIndex = -1;
                cmbToCurrency.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading currencies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExchangeRates()
        {
            string query = @"
                SELECT 
                    er.ExchangeRateID, 
                    er.FromCurrencyID, 
                    fc.CurrencyCode AS FromCurrencyCode,
                    er.ToCurrencyID, 
                    tc.CurrencyCode AS ToCurrencyCode,
                    er.Rate, 
                    er.LastUpdatedAt
                FROM dbo.ExchangeRates er
                JOIN dbo.Currencies fc ON er.FromCurrencyID = fc.CurrencyID
                JOIN dbo.Currencies tc ON er.ToCurrencyID = tc.CurrencyID
                ORDER BY er.FromCurrencyID, er.ToCurrencyID;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvExchangeRates.DataSource = dt;

                        if (dgvExchangeRates.Columns["ExchangeRateID"] != null)
                            dgvExchangeRates.Columns["ExchangeRateID"].HeaderText = "ID";
                        if (dgvExchangeRates.Columns["FromCurrencyID"] != null)
                            dgvExchangeRates.Columns["FromCurrencyID"].Visible = false;
                        if (dgvExchangeRates.Columns["FromCurrencyCode"] != null)
                            dgvExchangeRates.Columns["FromCurrencyCode"].HeaderText = "From";
                        if (dgvExchangeRates.Columns["ToCurrencyID"] != null)
                            dgvExchangeRates.Columns["ToCurrencyID"].Visible = false;
                        if (dgvExchangeRates.Columns["ToCurrencyCode"] != null)
                            dgvExchangeRates.Columns["ToCurrencyCode"].HeaderText = "To";
                        if (dgvExchangeRates.Columns["Rate"] != null)
                            dgvExchangeRates.Columns["Rate"].DefaultCellStyle.Format = "N6";
                        if (dgvExchangeRates.Columns["LastUpdatedAt"] != null)
                            dgvExchangeRates.Columns["LastUpdatedAt"].HeaderText = "Last Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exchange rates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvExchangeRates_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExchangeRates.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvExchangeRates.SelectedRows[0];
                txtExchangeRateID.Text = selectedRow.Cells["ExchangeRateID"].Value.ToString();
                cmbFromCurrency.SelectedValue = Convert.ToInt32(selectedRow.Cells["FromCurrencyID"].Value);
                cmbToCurrency.SelectedValue = Convert.ToInt32(selectedRow.Cells["ToCurrencyID"].Value);
                nudRate.Value = Convert.ToDecimal(selectedRow.Cells["Rate"].Value);
                dtpLastUpdatedAt.Value = Convert.ToDateTime(selectedRow.Cells["LastUpdatedAt"].Value);

                UpdateButtonStates(isEditing: true);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            UpdateButtonStates();
            cmbFromCurrency.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFromCurrency.SelectedValue == null)
            {
                MessageBox.Show("Please select a 'From' currency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromCurrency.Focus();
                return;
            }
            if (cmbToCurrency.SelectedValue == null)
            {
                MessageBox.Show("Please select a 'To' currency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToCurrency.Focus();
                return;
            }
            if (Convert.ToInt32(cmbFromCurrency.SelectedValue) == Convert.ToInt32(cmbToCurrency.SelectedValue))
            {
                MessageBox.Show("'From' currency and 'To' currency cannot be the same.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFromCurrency.Focus();
                return;
            }
            if (nudRate.Value <= 0)
            {
                MessageBox.Show("Rate must be a positive value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudRate.Focus();
                return;
            }

            ExchangeRate rate = new ExchangeRate
            {
                FromCurrencyID = Convert.ToInt32(cmbFromCurrency.SelectedValue),
                ToCurrencyID = Convert.ToInt32(cmbToCurrency.SelectedValue),
                Rate = nudRate.Value,
                LastUpdatedAt = DateTime.UtcNow
            };

            string query;
            bool isUpdate = !string.IsNullOrEmpty(txtExchangeRateID.Text);

            if (isUpdate)
            {
                rate.ExchangeRateID = Convert.ToInt32(txtExchangeRateID.Text);
                query = @"UPDATE dbo.ExchangeRates 
                          SET FromCurrencyID = @FromCurrencyID, 
                              ToCurrencyID = @ToCurrencyID, 
                              Rate = @Rate, 
                              LastUpdatedAt = @LastUpdatedAt 
                          WHERE ExchangeRateID = @ExchangeRateID;";
            }
            else
            {
                string checkQuery = "SELECT COUNT(*) FROM dbo.ExchangeRates WHERE FromCurrencyID = @FromCurrencyID AND ToCurrencyID = @ToCurrencyID;";
                int existingCount = 0;
                try
                {
                    using (SqlConnection connCheck = new SqlConnection(connectionString))
                    {
                        connCheck.Open();
                        using (SqlCommand cmdCheck = new SqlCommand(checkQuery, connCheck))
                        {
                            cmdCheck.Parameters.AddWithValue("@FromCurrencyID", rate.FromCurrencyID);
                            cmdCheck.Parameters.AddWithValue("@ToCurrencyID", rate.ToCurrencyID);
                            existingCount = (int)cmdCheck.ExecuteScalar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking for existing rate: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (existingCount > 0)
                {
                    MessageBox.Show("An exchange rate for this currency pair already exists. Please update the existing rate instead of adding a new one.", "Duplicate Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = @"INSERT INTO dbo.ExchangeRates (FromCurrencyID, ToCurrencyID, Rate, LastUpdatedAt) 
                          VALUES (@FromCurrencyID, @ToCurrencyID, @Rate, @LastUpdatedAt);";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromCurrencyID", rate.FromCurrencyID);
                        cmd.Parameters.AddWithValue("@ToCurrencyID", rate.ToCurrencyID);
                        cmd.Parameters.AddWithValue("@Rate", rate.Rate);
                        cmd.Parameters.AddWithValue("@LastUpdatedAt", rate.LastUpdatedAt);
                        if (isUpdate)
                        {
                            cmd.Parameters.AddWithValue("@ExchangeRateID", rate.ExchangeRateID);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Exchange rate {(isUpdate ? "updated" : "added")} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadExchangeRates();
                            ClearInputFields();
                            UpdateButtonStates();
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected. The operation might have failed silently.", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2601 || sqlEx.Number == 2627)
                {
                    MessageBox.Show("An exchange rate for this currency pair already exists. Please update the existing one.", "Duplicate Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving exchange rate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExchangeRateID.Text))
            {
                MessageBox.Show("Please select an exchange rate to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this exchange rate?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM dbo.ExchangeRates WHERE ExchangeRateID = @ExchangeRateID;";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ExchangeRateID", Convert.ToInt32(txtExchangeRateID.Text));
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Exchange rate deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadExchangeRates();
                                ClearInputFields();
                                UpdateButtonStates();
                            }
                            else
                            {
                                MessageBox.Show("Could not delete the exchange rate. It might have already been deleted.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting exchange rate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputFields()
        {
            txtExchangeRateID.Clear();
            cmbFromCurrency.SelectedIndex = -1;
            cmbToCurrency.SelectedIndex = -1;
            nudRate.Value = 0;
            dtpLastUpdatedAt.Value = DateTime.Now;
            dgvExchangeRates.ClearSelection();
        }

        private void UpdateButtonStates(bool isEditing = false)
        {
            if (isEditing || !string.IsNullOrEmpty(txtExchangeRateID.Text)) 
            {
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
            else
            {
                btnSave.Text = "Save New";
                btnDelete.Enabled = false;
            }
        }
    }
}