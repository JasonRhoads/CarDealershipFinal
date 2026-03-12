using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarData;
using CarBusiness;

namespace CarDealershipFinal
{
    public partial class frmUserLogin : Form
    {
        private int failedAttempts = 0;
        private const int MaxAttempts = 3;

        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                Dictionary<string, string[]> users = UserDB.Get();

                if (users.ContainsKey(username))
                {
                    string storedHash = users[username][0];
                    string enteredHash = PasswordHasher.HashPassword(password);

                    if (enteredHash == storedHash)
                    {
                        failedAttempts = 0;

                        frmCarListings.userLoggedIn = true;
                        frmCarListings.userRole = users[username][1];
                        Tag = username + ": " + users[username][1];
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        HandleFailedLogin();
                    }
                }
                else
                {
                    HandleFailedLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void HandleFailedLogin()
        {
            failedAttempts++;

            if (failedAttempts >= MaxAttempts)
            {
                MessageBox.Show("Too many failed login attempts. Login has been disabled.");
                btnLogin.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Username and/or password do not match. Attempt {failedAttempts} of {MaxAttempts}.");
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegisterUser registerForm = new frmRegisterUser();
            registerForm.ShowDialog();
        }
    }
}