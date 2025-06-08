using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipFinal
{
    /// <summary>
    /// Main form for CarDealership
    /// </summary>
    public partial class frmCarListings : Form
    {
        public static bool userLoggedIn = false;
        public static int startIndex = 0;
        public static int endIndex = 0;

        public static List<string> paginationlistings = new List<string>();

        public frmCarListings()
        {
            InitializeComponent();
        }

        //Google searched and found a RefreshEventHandler
        //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.refresheventhandler?view=net-9.0

        // Define delegate
        public delegate void RefreshEventHandler();

        // Define event
        public event RefreshEventHandler OnRefreshListings;
        public event RefreshEventHandler OnRefreshFilters;

        //Load the filters and the full listing of cars
        private void frmCarListings_Load(object sender, EventArgs e)
        {
            FillListings();
            FillFilters();
        }

        /// <summary>
        /// Clear the filters and reload them incase some were added or removed
        /// </summary>
        private void FillFilters()
        {
            cboFilterBy.Items.Clear();
            cboFilterBy.Items.AddRange(Filters.Get());
            cboFilterBy.SelectedIndex = 0;

            OnRefreshFilters?.Invoke();
        }

        /// <summary>
        /// Show the full listing of cars starting with the newest at the top
        /// </summary>
        private void FillListings()
        {
            rchListings.Clear();
            paginationlistings.Clear();

            CarList<Listing> listings = CarListingsDB<Listing>.Get();
                     
            //have the newist listing at the top
            for (int i = 0; i < listings.Count; i++)
                paginationlistings.Add($"\t{listings[i].CreationTime.ToString()}\n" 
                    + $"{listings[i].Car.GetDisplayText()}\n");

            PaginateListings();

            OnRefreshListings?.Invoke();
        }

        /// <summary>
        /// Show the cars that matach the filter selected
        /// </summary>
        /// <param name="filter"></param>
        private void FillFilteredListings(string filter)
        {
            //check to see if a filter was slected
            if (cboFilterBy.SelectedIndex != 0)
            {
                //clear the rich text box
                rchListings.Clear();
                paginationlistings.Clear();


                //get a listing of all the cars
                var listings = CarListingsDB<Listing>.GetListings();

                //set the filterName to the appropriate type of filter
                FilterName filterName = FilterName.Null;
                if (CarMakesDB.Get().Contains(filter))
                    filterName = FilterName.Make;
                else if (CarColorsDB.Get().Contains(filter))
                    filterName = FilterName.Color;
                else if (CarAgeRangesDB.GetRanges().Contains(filter))
                    filterName = FilterName.Age;
                else if (CarPriceRangesDB.GetRanges().Contains(filter))
                    filterName = FilterName.Price;

                //find all the cars that match the filter
                foreach (var listing in listings)
                {
                    if (listing.GetFilteredString(filterName, filter) != null)
                    {
                        //have the newist listing at the top
                        paginationlistings.Add(listing.GetFilteredString(filterName, filter));
                    }
                }

                paginationlistings.Reverse();

                //set a new starting index for pagination
                startIndex = 0;
                PaginateListings();
            }
        }

        private void Login()
        {
            if (!userLoggedIn)
            {
                frmUserLogin loginForm = new frmUserLogin();

                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Unable to log in.");
                }
                else
                {
                    lblGreeting.Text = "Hello, " + loginForm.Tag.ToString();
                    btnUpload.Visible = true;
                    btnDelete.Visible = true;
                    btnLogin.Text = "Logout";

                    if (false) //replace with check for user role
                    {
                        btnAdmin.Visible = true;
                    }
                }
            }
            else
            {
                userLoggedIn = false;
                lblGreeting.Text = "Hello, Guest";
                btnUpload.Visible = false;
                btnDelete.Visible = false;
                btnAdmin.Visible = false;
                btnLogin.Text = "Login";
            }

        }

        /// <summary>
        /// If the user is logged in, opens the form to add a car, if not, pops up the login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (userLoggedIn)
            {
                //upload a new car
                var addFrm = new frmUpload();

                //Wire event to refresh the listings and filters to show the new car
                addFrm.OnRefreshListings += FillListings;
                addFrm.OnRefreshFilters += FillFilters;

                addFrm.ShowDialog();
            }
        }

        /// <summary>
        /// Opens the form to delete a car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userLoggedIn)
            {
                //check to see if there is at least one listing to delete
                if (CarListingsDB<Listing>.Get().Count != 0)
                {
                    var delFrm = new frmDeleteCar();
                    delFrm.OnRefreshListings += FillListings;
                    delFrm.OnRefreshFilters += FillFilters;

                    delFrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please upload a car, nothing to delete", "Empty Lot");
                }
            }
        }

        /// <summary>
        /// Shows all of the listings, used after a user has selected 
        /// a filter to see all the cars again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            FillListings();
        }

        /// <summary>
        /// Calls the FillFilteredListing function to find the cars that matach the filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = cboFilterBy.SelectedItem.ToString();
            FillFilteredListings(filter.Trim());
        }


        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Logs the user in or out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// Sets the starting index to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            startIndex = 0;
            PaginateListings();
        }

        /// <summary>
        /// Sets the starting index for the last pages to show the reaming cars
        /// ex. 11 cars the last page will show 1 car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            startIndex = paginationlistings.Count - paginationlistings.Count % 5;
            PaginateListings();
        }

        /// <summary>
        /// Sets the index back a page stopping at the begining. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            startIndex = startIndex - 5 < 0 ? 0 : startIndex - 5;
            PaginateListings();
        }

        /// <summary>
        /// Sets the index for the next page stopping at the last page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            startIndex = startIndex + 5 >= paginationlistings.Count ? paginationlistings.Count - paginationlistings.Count % 5 : startIndex + 5;
            PaginateListings();
        }

        private void PaginateListings()
        {
            //set the end index for each page. 
            endIndex = startIndex + 5 < paginationlistings.Count ? startIndex + 5 : paginationlistings.Count;

            //clear the listings
            rchListings.Clear();

            //display the listings
            for (int i = startIndex; i < endIndex; i++)
            {
                rchListings.Text += paginationlistings[i];
            }
        }
    }
}