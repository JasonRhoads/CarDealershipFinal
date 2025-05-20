using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using ValidationLibrary;

namespace CarDealershipFinal
{
    /// <summary>
    /// Form used to upload a new car
    /// </summary>
    public partial class frmUpload : Form
    {
        public frmUpload()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check to see that all values were entered or selected.
        /// </summary>
        /// <returns>true when valid and false when invalid and displays a message</returns>
        private bool IsValidData()
        {
            //set inital status to false
            bool isValid = false;
            string msg = Validator.IsPresent(txtModel, txtModel.Tag.ToString());
            msg += Validator.IsPresent(txtAge, txtAge.Tag.ToString());
            msg += Validator.IsInt(txtAge, txtAge.Tag.ToString());
            msg += Validator.IsPresent(txtColor, txtColor.Tag.ToString());
            msg += Validator.IsPresent(txtPrice, txtPrice.Tag.ToString());
            msg += Validator.IsDecimal(txtPrice, txtPrice.Tag.ToString());
            msg += Validator.IsPresent(txtVaring, lblVaring.Text);

            //check to see that no error message was added
            if (msg == "")
            {
                //if msg is empty then set status to true
                isValid = true;
            }
            else
            {
                //display all of the msg in one message box 
                MessageBox.Show(msg, "Entry Error");
            }
            return isValid;
        }

        /// <summary>
        /// Add a new car to the full listing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Checks for valid data from the user
            if (IsValidData())
            {
                //check to see what make was chosen
                var selectedMake = cboMake.SelectedItem.ToString().Trim();
                if (selectedMake == nameof(BMW))
                {
                    BMW newCar = new BMW(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Toyota))
                {
                    Toyota newCar = new Toyota(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Ford))
                {
                    Ford newCar = new Ford(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }
                else if (selectedMake == nameof(Honda))
                {
                    Honda newCar = new Honda(txtModel.Text.ToString(),
                                    txtColor.Text.ToString(),
                                    Convert.ToInt32(txtAge.Text.ToString()),
                                    Convert.ToDecimal(txtPrice.Text.ToString()),
                                    txtVaring.Text.ToString());
                    CarListingsDB.Save(newCar);
                }

                this.Close();
            }
        }

        /// <summary>
        /// Cancel and close the form without adding a car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Set lblVaring.Text to match the appropriate Make
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboMake.SelectedIndex)
            {
                case 0 : 
                    lblVaring.Text = "Engine:";
                    break;
                case 1:
                    lblVaring.Text = "Height:";
                    break;
                case 2:
                    lblVaring.Text = "Trim:";
                    break;
                case 3:
                    lblVaring.Text = "Mileage:";
                    break;
            }
        }

        /// <summary>
        /// On form load clear cboMake and add the available makes to cboMake,
        /// then set the index to the first option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpload_Load(object sender, EventArgs e)
        {
            cboMake.Items.Clear();
            cboMake.Items.AddRange(CarMakesDB.Get().ToArray());
            cboMake.SelectedIndex = 0;
        }
    }
}
