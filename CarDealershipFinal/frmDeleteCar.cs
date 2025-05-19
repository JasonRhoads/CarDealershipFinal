using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipFinal
{
    public partial class frmDeleteCar : Form
    {

        private List<Listing> listings = CarListingsDB.GetListings(); 
        public frmDeleteCar()
        {
            InitializeComponent();
        }

        private void frmDeleteCar_Load(object sender, EventArgs e)
        {
            FillCarFilters();
        }

        private void FillCarFilters()
        {
            cboDeleteCar.Items.Clear();
            cboDeleteCar.Items.Add("Select a car...");
            cboDeleteCar.SelectedIndex = 0;
       
            //Get every car and display the make model and price for a user to select
            foreach (var listing in listings)
            {
                cboDeleteCar.Items.Add($"{listing.Car.Make} {listing.Car.Model} {listing.Car.Price.ToString("c")}");
            }
        }

        //Shows the full details of the car the user has selected to delete
        private void ShowCarDeleteDetails(object sender, EventArgs e)
        {
            if (cboDeleteCar.SelectedIndex != 0)
            {
                rchDeleteDetails.Text = listings[cboDeleteCar.SelectedIndex - 1].ToString();
            }
            else
            {
                rchDeleteDetails.Text = "";
            }
        }


        //delete car from the list of cars.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //make sure the user really wants to delete this car
                DialogResult result = MessageBox.Show($"Do you want to delete car: " +
                    $"{listings[cboDeleteCar.SelectedIndex - 1].Car.Make} " +
                    $"{listings[cboDeleteCar.SelectedIndex - 1].Car.Model} " +
                    $"{listings[cboDeleteCar.SelectedIndex - 1].Car.Price.ToString("c")}?",
                    "Delete Car",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Show success delete message
                    MessageBox.Show($"Success car: " +
                        $"{listings[cboDeleteCar.SelectedIndex - 1].Car.Make} " +
                        $"{listings[cboDeleteCar.SelectedIndex - 1].Car.Model} " +
                        $"deleted", "Delete Success");

                    //remove the car from the listings
                    listings.RemoveAt(cboDeleteCar.SelectedIndex - 1);


                    //need to now rewrite the file with the car deleted
                    CarListingsDB.UpdateAfterDeleted(listings);

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("There was an error in deleting the car", "Entry Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
