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
        private string loginUsername, loginPassword;

        private Dictionary<string, string> users = UserDB.Get();

        public frmUserLogin()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (users.ContainsKey(txtUsername.Text))
            {
                if (txtPassword.Text == users[txtUsername.Text])
                {
                    frmCarListings.userLoggedIn = true;
                    DialogResult = DialogResult.OK;
                    Tag = txtUsername.Text;
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
