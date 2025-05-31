namespace ExchangeShopApp
{
    partial class ManageCurrenciesForm
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
            dgvCurrencies = new DataGridView();
            colCurrencyID = new DataGridViewTextBoxColumn();
            colCurrencyCode = new DataGridViewTextBoxColumn();
            colCurrencyName = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            panelDetails = new Panel();
            txtCurrencyName = new TextBox();
            lblCurrencyName = new Label();
            txtCurrencyCode = new TextBox();
            lblCurrencyCode = new Label();
            txtCurrencyID = new TextBox();
            lblCurrencyID = new Label();
            btnAddNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCurrencies).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCurrencies
            // 
            dgvCurrencies.AllowUserToAddRows = false;
            dgvCurrencies.AllowUserToDeleteRows = false;
            dgvCurrencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrencies.Columns.AddRange(new DataGridViewColumn[] { colCurrencyID, colCurrencyCode, colCurrencyName, colCreatedAt });
            dgvCurrencies.Location = new Point(12, 15);
            dgvCurrencies.Margin = new Padding(3, 4, 3, 4);
            dgvCurrencies.MultiSelect = false;
            dgvCurrencies.Name = "dgvCurrencies";
            dgvCurrencies.ReadOnly = true;
            dgvCurrencies.RowHeadersWidth = 51;
            dgvCurrencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrencies.Size = new Size(560, 250);
            dgvCurrencies.TabIndex = 0;
            dgvCurrencies.SelectionChanged += dgvCurrencies_SelectionChanged;
            // 
            // colCurrencyID
            // 
            colCurrencyID.DataPropertyName = "CurrencyID";
            colCurrencyID.HeaderText = "ID";
            colCurrencyID.MinimumWidth = 6;
            colCurrencyID.Name = "colCurrencyID";
            colCurrencyID.ReadOnly = true;
            colCurrencyID.Width = 70;
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.DataPropertyName = "CurrencyCode";
            colCurrencyCode.HeaderText = "Code";
            colCurrencyCode.MinimumWidth = 6;
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.ReadOnly = true;
            // 
            // colCurrencyName
            // 
            colCurrencyName.DataPropertyName = "CurrencyName";
            colCurrencyName.HeaderText = "Name";
            colCurrencyName.MinimumWidth = 6;
            colCurrencyName.Name = "colCurrencyName";
            colCurrencyName.ReadOnly = true;
            colCurrencyName.Width = 200;
            // 
            // colCreatedAt
            // 
            colCreatedAt.DataPropertyName = "CreatedAt";
            colCreatedAt.HeaderText = "Created At";
            colCreatedAt.MinimumWidth = 6;
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.Width = 125;
            // 
            // panelDetails
            // 
            panelDetails.BorderStyle = BorderStyle.FixedSingle;
            panelDetails.Controls.Add(txtCurrencyName);
            panelDetails.Controls.Add(lblCurrencyName);
            panelDetails.Controls.Add(txtCurrencyCode);
            panelDetails.Controls.Add(lblCurrencyCode);
            panelDetails.Controls.Add(txtCurrencyID);
            panelDetails.Controls.Add(lblCurrencyID);
            panelDetails.Location = new Point(12, 285);
            panelDetails.Margin = new Padding(3, 4, 3, 4);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(560, 162);
            panelDetails.TabIndex = 1;
            // 
            // txtCurrencyName
            // 
            txtCurrencyName.Location = new Point(120, 100);
            txtCurrencyName.Margin = new Padding(3, 4, 3, 4);
            txtCurrencyName.MaxLength = 100;
            txtCurrencyName.Name = "txtCurrencyName";
            txtCurrencyName.Size = new Size(250, 27);
            txtCurrencyName.TabIndex = 5;
            // 
            // lblCurrencyName
            // 
            lblCurrencyName.AutoSize = true;
            lblCurrencyName.Location = new Point(15, 104);
            lblCurrencyName.Name = "lblCurrencyName";
            lblCurrencyName.Size = new Size(113, 20);
            lblCurrencyName.TabIndex = 4;
            lblCurrencyName.Text = "Currency Name:";
            // 
            // txtCurrencyCode
            // 
            txtCurrencyCode.Location = new Point(120, 56);
            txtCurrencyCode.Margin = new Padding(3, 4, 3, 4);
            txtCurrencyCode.MaxLength = 3;
            txtCurrencyCode.Name = "txtCurrencyCode";
            txtCurrencyCode.Size = new Size(100, 27);
            txtCurrencyCode.TabIndex = 3;
            // 
            // lblCurrencyCode
            // 
            lblCurrencyCode.AutoSize = true;
            lblCurrencyCode.Location = new Point(15, 60);
            lblCurrencyCode.Name = "lblCurrencyCode";
            lblCurrencyCode.Size = new Size(108, 20);
            lblCurrencyCode.TabIndex = 2;
            lblCurrencyCode.Text = "Currency Code:";
            // 
            // txtCurrencyID
            // 
            txtCurrencyID.Location = new Point(120, 12);
            txtCurrencyID.Margin = new Padding(3, 4, 3, 4);
            txtCurrencyID.Name = "txtCurrencyID";
            txtCurrencyID.ReadOnly = true;
            txtCurrencyID.Size = new Size(100, 27);
            txtCurrencyID.TabIndex = 1;
            // 
            // lblCurrencyID
            // 
            lblCurrencyID.AutoSize = true;
            lblCurrencyID.Location = new Point(15, 16);
            lblCurrencyID.Name = "lblCurrencyID";
            lblCurrencyID.Size = new Size(88, 20);
            lblCurrencyID.TabIndex = 0;
            lblCurrencyID.Text = "Currency ID:";
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(12, 469);
            btnAddNew.Margin = new Padding(3, 4, 3, 4);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 38);
            btnAddNew.TabIndex = 2;
            btnAddNew.Text = "Add New";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(122, 469);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 38);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(232, 469);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 38);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(472, 469);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 38);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ManageCurrenciesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 520);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnAddNew);
            Controls.Add(panelDetails);
            Controls.Add(dgvCurrencies);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageCurrenciesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Currencies";
            Load += ManageCurrenciesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCurrencies).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrencies;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.Label lblCurrencyName;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.Label lblCurrencyCode;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.Label lblCurrencyID;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
    }
}