namespace ExchangeShopApp
{
    partial class ManageUsersForm
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
            dgvUsers = new DataGridView();
            colUserID = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colRoleName = new DataGridViewTextBoxColumn();
            colIsActive = new DataGridViewTextBoxColumn();
            colLastLoginDate = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            btnAddNew = new Button();
            btnSave = new Button();
            btnToggleActive = new Button();
            btnClose = new Button();
            panel1 = new Panel();
            chkIsActive = new CheckBox();
            cmbRole = new ComboBox();
            label6 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtUserID = new TextBox();
            label1 = new Label();
            btnTest = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colUserID, colFullName, colEmail, colRoleName, colIsActive, colLastLoginDate, colCreatedAt, colUsername });
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(797, 285);
            dgvUsers.TabIndex = 0;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // colUserID
            // 
            colUserID.DataPropertyName = "UserID";
            colUserID.HeaderText = "ID";
            colUserID.MinimumWidth = 6;
            colUserID.Name = "colUserID";
            colUserID.ReadOnly = true;
            colUserID.Width = 125;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.HeaderText = "Full Name";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            colFullName.Width = 125;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 125;
            // 
            // colRoleName
            // 
            colRoleName.DataPropertyName = "RoleName";
            colRoleName.HeaderText = "Role";
            colRoleName.MinimumWidth = 6;
            colRoleName.Name = "colRoleName";
            colRoleName.ReadOnly = true;
            colRoleName.Width = 125;
            // 
            // colIsActive
            // 
            colIsActive.DataPropertyName = "IsActive";
            colIsActive.HeaderText = "Active";
            colIsActive.MinimumWidth = 6;
            colIsActive.Name = "colIsActive";
            colIsActive.ReadOnly = true;
            colIsActive.Width = 125;
            // 
            // colLastLoginDate
            // 
            colLastLoginDate.DataPropertyName = "LastLoginDate";
            colLastLoginDate.HeaderText = "Last Login";
            colLastLoginDate.MinimumWidth = 6;
            colLastLoginDate.Name = "colLastLoginDate";
            colLastLoginDate.ReadOnly = true;
            colLastLoginDate.Width = 125;
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
            // colUsername
            // 
            colUsername.DataPropertyName = "Username";
            colUsername.HeaderText = "Username";
            colUsername.MinimumWidth = 6;
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            colUsername.Width = 125;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(50, 553);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(118, 29);
            btnAddNew.TabIndex = 1;
            btnAddNew.Text = "Add New User";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(190, 553);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnToggleActive
            // 
            btnToggleActive.Location = new Point(310, 553);
            btnToggleActive.Name = "btnToggleActive";
            btnToggleActive.Size = new Size(184, 29);
            btnToggleActive.TabIndex = 3;
            btnToggleActive.Text = "Deactivate/Activate User";
            btnToggleActive.UseVisualStyleBackColor = true;
            btnToggleActive.Click += btnToggleActive_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(518, 553);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(chkIsActive);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUserID);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 304);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 243);
            panel1.TabIndex = 5;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(84, 194);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(86, 24);
            chkIsActive.TabIndex = 12;
            chkIsActive.Text = "Is Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(84, 160);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(125, 28);
            cmbRole.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 163);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 10;
            label6.Text = "Role:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(84, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 132);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 8;
            label5.Text = "Password:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(84, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 102);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(84, 65);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(125, 27);
            txtFullName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 72);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 4;
            label3.Text = "Full Name:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(84, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 40);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            label2.Click += label2_Click;
            // 
            // txtUserID
            // 
            txtUserID.Enabled = false;
            txtUserID.Location = new Point(84, 0);
            txtUserID.Name = "txtUserID";
            txtUserID.ReadOnly = true;
            txtUserID.Size = new Size(125, 27);
            txtUserID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "UserID:";
            // 
            // btnTest
            // 
            btnTest.Location = new Point(641, 553);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(94, 29);
            btnTest.TabIndex = 6;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 594);
            Controls.Add(btnTest);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(btnToggleActive);
            Controls.Add(btnSave);
            Controls.Add(btnAddNew);
            Controls.Add(dgvUsers);
            Name = "ManageUsersForm";
            Text = "ManageUsersForm";
            Load += ManageUsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn colUserID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colRoleName;
        private DataGridViewTextBoxColumn colIsActive;
        private DataGridViewTextBoxColumn colLastLoginDate;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colUsername;
        private Button btnAddNew;
        private Button btnSave;
        private Button btnToggleActive;
        private Button btnClose;
        private Panel panel1;
        private TextBox txtUserID;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtFullName;
        private Label label3;
        private TextBox txtPassword;
        private Label label5;
        private ComboBox cmbRole;
        private Label label6;
        private CheckBox chkIsActive;
        private Button btnTest;
    }
}