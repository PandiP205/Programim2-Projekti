using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeShopApp.DataAccess;
using ExchangeShopApp.Entities;

namespace ExchangeShopApp
{
    public partial class LoginForm : Form
    {
        public User AuthenticatedUser { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;


            if (string.IsNullOrWhiteSpace(username))
            {
                lblLoginError.Text = "Username cannot be empty.";
                lblLoginError.Visible = true;
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                lblLoginError.Text = "Password cannot be empty.";
                lblLoginError.Visible = true;
                txtPassword.Focus();
                return;
            }

            lblLoginError.Visible = false;

            UserRepository userRepository = new UserRepository();
            User authenticatedUser = userRepository.AuthenticateUser(username, password);

            if (authenticatedUser != null)
            {
                this.AuthenticatedUser = authenticatedUser;

                string roleName = "Unknown Role";
                if (authenticatedUser.RoleID == 1) roleName = "Administrator";
                else if (authenticatedUser.RoleID == 2) roleName = "Operator";

                MessageBox.Show($"Login Successful!\nWelcome, {authenticatedUser.FullName} ({roleName}).",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblLoginError.Text = "Invalid username or password.";
                lblLoginError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
                this.AuthenticatedUser = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
