namespace ExchangeShopApp
{
    partial class LoginForm
    {
        
        private System.ComponentModel.IContainer components = null;

       
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

       
        private void InitializeComponent()
        {
            lblUsernamePrompt = new Label();
            txtUsername = new TextBox();
            lblPasswordPrompt = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            lblLoginError = new Label();
            SuspendLayout();
           
            lblUsernamePrompt.AutoSize = true;
            lblUsernamePrompt.Location = new Point(51, 58);
            lblUsernamePrompt.Name = "lblUsernamePrompt";
            lblUsernamePrompt.Size = new Size(82, 20);
            lblUsernamePrompt.TabIndex = 0;
            lblUsernamePrompt.Text = "Username: ";
           
            txtUsername.Location = new Point(139, 51);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 1;
           
            lblPasswordPrompt.AutoSize = true;
            lblPasswordPrompt.Location = new Point(51, 99);
            lblPasswordPrompt.Name = "lblPasswordPrompt";
            lblPasswordPrompt.Size = new Size(73, 20);
            lblPasswordPrompt.TabIndex = 2;
            lblPasswordPrompt.Text = "Password:";
            
            txtPassword.Location = new Point(139, 92);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            
            btnLogin.Location = new Point(51, 149);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            
            btnCancel.Location = new Point(170, 149);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button1_Click;
           
            lblLoginError.AutoSize = true;
            lblLoginError.ForeColor = Color.Red;
            lblLoginError.Location = new Point(52, 205);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(0, 20);
            lblLoginError.TabIndex = 6;
            lblLoginError.Visible = false;
             
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(lblLoginError);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPasswordPrompt);
            Controls.Add(txtUsername);
            Controls.Add(lblUsernamePrompt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Click += LoginForm_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsernamePrompt;
        private TextBox txtUsername;
        private Label lblPasswordPrompt;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblLoginError;
    }
}