using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarData;
using CarBusiness;

namespace CarDealershipFinal
{
    /// <summary>
    /// Form to delete a car from the listings
    /// </summary>
    public partial class frmDeleteCar : Form
    {

        // Define delegate type
        public delegate void RefreshEventHandler();

        // Define events
        public event RefreshEventHandler OnRefreshListings;
        public event RefreshEventHandler OnRefreshFilters;


        /// <summary>
        /// Get a full list of the current listings
        /// </summary>
        private CarListingService service = new CarListingService();
        private List<Listing> listings;

        private CarRepository repo = new CarRepository();

        public frmDeleteCar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the available cars to cboDeleteCar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDeleteCar_Load(object sender, EventArgs e)
        {
            listings = service.GetListings();
            FillCarFilters();
        }

        /// <summary>
        /// Clears cboDeleteCar adds select a car.. 
        /// then iterates through the listings to show the cars that can be deleted
        /// </summary>
        private void FillCarFilters()
        {
            cboDeleteCar.Items.Clear();
            cboDeleteCar.Items.Add("Select a car...");
            cboDeleteCar.SelectedIndex = 0;

            listings.Reverse();
            //Get every car and display the make model and price for a user to select
            foreach (var listing in listings)
            {
                cboDeleteCar.Items.Add($"{listing.Car.Make} {listing.Car.Model} {listing.Car.Price.ToString("c")}");
            }
        }

        /// <summary>
        /// Shows the full details of the car the user has selected to delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCarDeleteDetails(object sender, EventArgs e)
        {
            //Check to see if a car was selected and not on select a car...
            if (cboDeleteCar.SelectedIndex != 0)
            {
                //LINQ statement to display the details of the selected car
                var selectedListing = listings
                    .Where((listing, index) => index == cboDeleteCar.SelectedIndex - 1)
                    .FirstOrDefault();

                if (selectedListing != null)
                {
                    rchDeleteDetails.Text = selectedListing.ToString();
                }
            }
            else
            {
                //if nothing is selected clear the rich text box
                rchDeleteDetails.Text = "";
            }
        }


        /// <summary>
        /// delete car from the list of cars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDeleteCar.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a car to delete", "Entry Error");
                    return;
                }

                var selectedListing = listings[cboDeleteCar.SelectedIndex - 1];

                DialogResult result = MessageBox.Show(
                    $"Do you want to delete car: " +
                    $"{selectedListing.Car.Make} " +
                    $"{selectedListing.Car.Model} " +
                    $"{selectedListing.Car.Price.ToString("c")}?",
                    "Delete Car",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    repo.DeleteCar(selectedListing.Car.CarID);

                    MessageBox.Show(
                        $"Success car: {selectedListing.Car.Make} {selectedListing.Car.Model} deleted",
                        "Delete Success");

                    listings = service.GetListings();

                    OnRefreshListings?.Invoke();
                    OnRefreshFilters?.Invoke();

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("There was an error in deleting the car", "Entry Error");
            }
        }

        /// <summary>
        /// Cancel and close the delete form without deleting a car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
