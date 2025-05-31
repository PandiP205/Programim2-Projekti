namespace ExchangeShopApp
{
    partial class ManageExchangeRatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvExchangeRates = new DataGridView();
            gbRateDetails = new GroupBox();
            dtpLastUpdatedAt = new DateTimePicker();
            lblLastUpdatedAt = new Label();
            nudRate = new NumericUpDown();
            lblRate = new Label();
            cmbToCurrency = new ComboBox();
            lblToCurrency = new Label();
            cmbFromCurrency = new ComboBox();
            lblFromCurrency = new Label();
            txtExchangeRateID = new TextBox();
            lblExchangeRateID = new Label();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExchangeRates).BeginInit();
            gbRateDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRate).BeginInit();
            SuspendLayout();
            // 
            // dgvExchangeRates
            // 
            dgvExchangeRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExchangeRates.Location = new Point(16, 292);
            dgvExchangeRates.Margin = new Padding(4, 5, 4, 5);
            dgvExchangeRates.Name = "dgvExchangeRates";
            dgvExchangeRates.RowHeadersWidth = 51;
            dgvExchangeRates.Size = new Size(800, 308);
            dgvExchangeRates.TabIndex = 4;
            dgvExchangeRates.SelectionChanged += dgvExchangeRates_SelectionChanged;
            // 
            // gbRateDetails
            // 
            gbRateDetails.Controls.Add(dtpLastUpdatedAt);
            gbRateDetails.Controls.Add(lblLastUpdatedAt);
            gbRateDetails.Controls.Add(nudRate);
            gbRateDetails.Controls.Add(lblRate);
            gbRateDetails.Controls.Add(cmbToCurrency);
            gbRateDetails.Controls.Add(lblToCurrency);
            gbRateDetails.Controls.Add(cmbFromCurrency);
            gbRateDetails.Controls.Add(lblFromCurrency);
            gbRateDetails.Controls.Add(txtExchangeRateID);
            gbRateDetails.Controls.Add(lblExchangeRateID);
            gbRateDetails.Location = new Point(13, 17);
            gbRateDetails.Margin = new Padding(4, 5, 4, 5);
            gbRateDetails.Name = "gbRateDetails";
            gbRateDetails.Padding = new Padding(4, 5, 4, 5);
            gbRateDetails.Size = new Size(600, 265);
            gbRateDetails.TabIndex = 0;
            gbRateDetails.TabStop = false;
            gbRateDetails.Text = "Exchange Rate Details";
            // 
            // dtpLastUpdatedAt
            // 
            dtpLastUpdatedAt.Enabled = false;
            dtpLastUpdatedAt.Format = DateTimePickerFormat.Short;
            dtpLastUpdatedAt.Location = new Point(147, 208);
            dtpLastUpdatedAt.Margin = new Padding(4, 5, 4, 5);
            dtpLastUpdatedAt.Name = "dtpLastUpdatedAt";
            dtpLastUpdatedAt.Size = new Size(159, 27);
            dtpLastUpdatedAt.TabIndex = 9;
            // 
            // lblLastUpdatedAt
            // 
            lblLastUpdatedAt.AutoSize = true;
            lblLastUpdatedAt.Location = new Point(20, 214);
            lblLastUpdatedAt.Margin = new Padding(4, 0, 4, 0);
            lblLastUpdatedAt.Name = "lblLastUpdatedAt";
            lblLastUpdatedAt.Size = new Size(100, 20);
            lblLastUpdatedAt.TabIndex = 8;
            lblLastUpdatedAt.Text = "Last Updated:";
            // 
            // nudRate
            // 
            nudRate.DecimalPlaces = 6;
            nudRate.Location = new Point(147, 168);
            nudRate.Margin = new Padding(4, 5, 4, 5);
            nudRate.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudRate.Name = "nudRate";
            nudRate.Size = new Size(160, 27);
            nudRate.TabIndex = 7;
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Location = new Point(20, 174);
            lblRate.Margin = new Padding(4, 0, 4, 0);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(42, 20);
            lblRate.TabIndex = 6;
            lblRate.Text = "Rate:";
            // 
            // cmbToCurrency
            // 
            cmbToCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToCurrency.FormattingEnabled = true;
            cmbToCurrency.Location = new Point(147, 125);
            cmbToCurrency.Margin = new Padding(4, 5, 4, 5);
            cmbToCurrency.Name = "cmbToCurrency";
            cmbToCurrency.Size = new Size(159, 28);
            cmbToCurrency.TabIndex = 5;
            // 
            // lblToCurrency
            // 
            lblToCurrency.AutoSize = true;
            lblToCurrency.Location = new Point(20, 131);
            lblToCurrency.Margin = new Padding(4, 0, 4, 0);
            lblToCurrency.Name = "lblToCurrency";
            lblToCurrency.Size = new Size(89, 20);
            lblToCurrency.TabIndex = 4;
            lblToCurrency.Text = "To Currency:";
            // 
            // cmbFromCurrency
            // 
            cmbFromCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFromCurrency.FormattingEnabled = true;
            cmbFromCurrency.Location = new Point(147, 82);
            cmbFromCurrency.Margin = new Padding(4, 5, 4, 5);
            cmbFromCurrency.Name = "cmbFromCurrency";
            cmbFromCurrency.Size = new Size(159, 28);
            cmbFromCurrency.TabIndex = 3;
            // 
            // lblFromCurrency
            // 
            lblFromCurrency.AutoSize = true;
            lblFromCurrency.Location = new Point(20, 88);
            lblFromCurrency.Margin = new Padding(4, 0, 4, 0);
            lblFromCurrency.Name = "lblFromCurrency";
            lblFromCurrency.Size = new Size(107, 20);
            lblFromCurrency.TabIndex = 2;
            lblFromCurrency.Text = "From Currency:";
            // 
            // txtExchangeRateID
            // 
            txtExchangeRateID.Location = new Point(147, 40);
            txtExchangeRateID.Margin = new Padding(4, 5, 4, 5);
            txtExchangeRateID.Name = "txtExchangeRateID";
            txtExchangeRateID.ReadOnly = true;
            txtExchangeRateID.Size = new Size(132, 27);
            txtExchangeRateID.TabIndex = 1;
            // 
            // lblExchangeRateID
            // 
            lblExchangeRateID.AutoSize = true;
            lblExchangeRateID.Location = new Point(20, 46);
            lblExchangeRateID.Margin = new Padding(4, 0, 4, 0);
            lblExchangeRateID.Name = "lblExchangeRateID";
            lblExchangeRateID.Size = new Size(27, 20);
            lblExchangeRateID.TabIndex = 0;
            lblExchangeRateID.Text = "ID:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(627, 43);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(187, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(627, 88);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(187, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(627, 132);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(187, 35);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(627, 228);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(187, 35);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ManageExchangeRatesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 618);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(gbRateDetails);
            Controls.Add(dgvExchangeRates);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ManageExchangeRatesForm";
            Text = "Manage Exchange Rates";
            Load += ManageExchangeRatesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExchangeRates).EndInit();
            gbRateDetails.ResumeLayout(false);
            gbRateDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRate).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExchangeRates;
        private System.Windows.Forms.GroupBox gbRateDetails;
        private System.Windows.Forms.TextBox txtExchangeRateID;
        private System.Windows.Forms.Label lblExchangeRateID;
        private System.Windows.Forms.ComboBox cmbFromCurrency;
        private System.Windows.Forms.Label lblFromCurrency;
        private System.Windows.Forms.ComboBox cmbToCurrency;
        private System.Windows.Forms.Label lblToCurrency;
        private System.Windows.Forms.NumericUpDown nudRate;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.DateTimePicker dtpLastUpdatedAt;
        private System.Windows.Forms.Label lblLastUpdatedAt;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}