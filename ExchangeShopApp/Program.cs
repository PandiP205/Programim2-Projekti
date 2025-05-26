

using System;
using System.Windows.Forms;
using ExchangeShopApp.Entities;

namespace ExchangeShopApp
{
    static class Program 
    {

        public static User CurrentUser { get; private set; }

     
        [STAThread]
        static void Main()
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);


            LoginForm loginForm = new LoginForm();
            DialogResult loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK && loginForm.AuthenticatedUser != null)
            {
                CurrentUser = loginForm.AuthenticatedUser;

                if (CurrentUser.RoleID == 1) 
                {
                    Application.Run(new AdminMainForm());
                }
                else if (CurrentUser.RoleID == 2) 
                {
                    Application.Run(new UserMainForm());
                }
                else
                {
                    MessageBox.Show($"User '{CurrentUser.Username}' has an unknown or unsupported role (RoleID: {CurrentUser.RoleID}). Application will now exit.",
                                    "Unsupported Role", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }
    }
}