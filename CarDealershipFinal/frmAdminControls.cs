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
    public partial class frmAdminControls: Form
    {
        private Dictionary<string, string[]> users = UserDB.Get();

        public frmAdminControls()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!users.ContainsKey(txtUser.Text))
            {
                if (txtUser.Text != "" && txtPass.Text != "" && txtRole.Text != "")
                {
                    UserDB.Add(txtUser.Text, txtPass.Text, txtRole.Text);
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtRole.Text = "";
                    MessageBox.Show("User successfully added.");
                }
                else
                {
                    MessageBox.Show("No blank fields please,");
                }

            }
            else
            {
                MessageBox.Show("Username already exists.");
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (users.ContainsKey(txtUser.Text))
            {
                if (txtUser.Text != "")
                {
                    UserDB.Remove(txtUser.Text);
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtRole.Text = "";
                    MessageBox.Show("User successfully deleted.");
                }
                else
                {
                    MessageBox.Show("Please put in a username.");
                }

            }
            else
            {
                MessageBox.Show("Username doesn't exist.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
