using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarDealershipFinal.DatabaseFiles;

namespace CarDealershipFinal
{
    public partial class frmUserLogin : Form
    {
        private Dictionary<string, string[]> users = UserDB.Get();

        public frmUserLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (users.ContainsKey(txtUsername.Text))
            {
                if (txtPassword.Text == users[txtUsername.Text][0])
                {
                    frmCarListings.userLoggedIn = true;
                    frmCarListings.userRole = users[txtUsername.Text][1];
                    Tag = users[txtUsername.Text][1] + " " + txtUsername.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username and/or password do not match.");
                }
            }
            else
            {
                MessageBox.Show("Username and/or password do not match.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
