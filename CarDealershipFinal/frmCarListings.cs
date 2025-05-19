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

namespace CarDealershipFinal
{
    public partial class frmCarListings : Form
    {
        public frmCarListings()
        {
            InitializeComponent();
        }

        private void frmCarListings_Load(object sender, EventArgs e)
        {
            FillListings();
            FillFilters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check to see if there is at least one listing to delete
            if (CarListingsDB.Get().Count != 0)
            {
                var delFrm = new frmDeleteCar();
                delFrm.ShowDialog();
                FillListings();
                FillFilters();
            }
            else
            {
                MessageBox.Show("Please upload a car, nothing to delete", "Empty Lot");
            }
        }

        private void FillFilters()
        {
            cboFilterBy.Items.Clear();
            cboFilterBy.Items.AddRange(Filters.Get());
            cboFilterBy.SelectedIndex = 0;
        }

        private void FillListings()
        {
            rchListings.Clear();

            CarList<Listing> listings = CarListingsDB.Get();
            //have the newist listing at the top
            for (int i = 0; i < listings.Count; i++)
                rchListings.Text += $"\t{listings[i].CreationTime.ToString()}\n" 
                    + $"{listings[i].Car.GetDisplayText()}\n";
        }

        private void FillFilteredListings(string filter)
        {
            if (cboFilterBy.SelectedIndex != 0)
            {
                rchListings.Clear();

                var listings = CarListingsDB.GetListings();

                FilterName filterName = FilterName.Null;
                if (CarMakesDB.Get().Contains(filter))
                    filterName = FilterName.Make;
                else if (CarColorsDB.Get().Contains(filter))
                    filterName = FilterName.Color;
                else if (CarAgeRangesDB.GetRanges().Contains(filter))
                    filterName = FilterName.Age;
                else if (CarPriceRangesDB.GetRanges().Contains(filter))
                    filterName = FilterName.Price;

                foreach (var listing in listings)
                {
                    //have the newist listing at the top
                    rchListings.Text = listing.GetFilteredString(filterName, filter) + rchListings.Text;
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var addFrm = new frmUpload();
            addFrm.ShowDialog();
            FillListings();
            FillFilters();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            FillListings();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = cboFilterBy.SelectedItem.ToString();
            FillFilteredListings(filter.Trim());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}