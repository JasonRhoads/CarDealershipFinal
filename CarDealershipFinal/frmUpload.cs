
using CarData;
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace CarDealershipFinal
{
    /// <summary>
    /// Form used to upload a new car
    /// </summary>
    public partial class frmUpload : Form
    {
        // Define delegate type
        public delegate void RefreshEventHandler();

        // Define events
        public event RefreshEventHandler OnRefreshListings;
        public event RefreshEventHandler OnRefreshFilters;

        private CarRepository repo = new CarRepository();

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
            //set initial status to false
            bool isValid = false;
            string msg = Validator.IsPresent(txtModel, txtModel.Tag.ToString());
            msg += Validator.IsPresent(txtAge, txtAge.Tag.ToString());
            msg += Validator.IsInt(txtAge, txtAge.Tag.ToString());
            msg += Validator.IsPresent(txtColor, txtColor.Tag.ToString());
            msg += Validator.IsPresent(txtPrice, txtPrice.Tag.ToString());
            msg += Validator.IsDecimal(txtPrice, txtPrice.Tag.ToString());
            msg += Validator.IsPresent(txtVarying, lblVarying.Text);

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
            if (IsValidData())
            {
                string selectedMake = cboMake.SelectedItem.ToString().Trim();

                CarRecord newRecord = new CarRecord
                {
                    Make = selectedMake,
                    Model = txtModel.Text.Trim(),
                    Color = txtColor.Text.Trim(),
                    AgeYears = Convert.ToInt32(txtAge.Text.Trim()),
                    Price = Convert.ToDecimal(txtPrice.Text.Trim()),
                    ExtraInfo = txtVarying.Text.Trim(),
                    DateListed = DateTime.Now,
                    SellerID = frmCarListings.currentUserID
                };

                try
                {
                    repo.SaveCar(newRecord);

                    MessageBox.Show("Car uploaded successfully.", "Upload Success");

                    OnRefreshListings?.Invoke();
                    OnRefreshFilters?.Invoke();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
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
        /// Set lblVarying.Text to match the appropriate Make
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboMake.SelectedIndex)
            {
                case 0 : 
                    lblVarying.Text = "Engine:";
                    break;
                case 1:
                    lblVarying.Text = "Height:";
                    break;
                case 2:
                    lblVarying.Text = "Trim:";
                    break;
                case 3:
                    lblVarying.Text = "Mileage:";
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
