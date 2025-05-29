using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarDealershipFinal
{
 
    /// <summary>
    /// Manages the filters by interacting with the DataBaseFiles
    /// </summary>
    public class Filters
    {
        //Get a list of all of the filters
        private static List<string> Colors = CarColorsDB.Get();
        private static List<string> Makes = CarMakesDB.Get();
        private static List<string> Prices = CarPriceRangesDB.GetRanges();
        private static List<string> Ages = CarAgeRangesDB.GetRanges();

        /// <summary>
        /// Assign the filter variables
        /// </summary>
        private static void LoadFilters()
        {
            Colors = CarColorsDB.Get();
            Makes = CarMakesDB.Get();
            Prices = CarPriceRangesDB.GetRanges();
            Ages = CarAgeRangesDB.GetRanges();
        }

        /// <summary>
        /// Get the filters into a result list
        /// </summary>
        /// <returns>array of filters</returns>
        public static string[] Get()
        {
            LoadFilters();

            List<string> result = new List<string>();
            result.Add("Select a filter....");

            //Add colors
            foreach (var color in Colors)
            {
                result.Add(color);
            }

            //Add Makes
            foreach (var make in Makes)
            {
                result.Add(make);
            }

            //Add Prices
            foreach (var price in Prices)
            {
                result.Add(price.ToString());
            }

            //Add Ages
            foreach (var age in Ages)
            {
                result.Add(age.ToString());
            }

            return result.ToArray();
        }
        

        /// <summary>
        /// Gets listings based off of the selected filter
        /// </summary>
        /// <param name="car"></param>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        /// <returns>Listing objects that match the selected filter</returns>
        public static string GetFiltered(Car car, FilterName filterName = FilterName.Null, string filter = null)
        {
            string result = "";

            if (filterName != FilterName.Null && filter != null)
            {
                if (filterName == FilterName.Make)
                {
                    //Returns cars that match the Make, does not show Make in the display
                    if (car.Make == filter)
                        return $"Model: {car.Model}\nColor: {car.Color}\nAge: {car.Age}\nPrice: {car.Price.ToString("c")}\n";
                }
                else if (filterName == FilterName.Color)
                {
                    //Returns cars that match the Color, does not show Color in the display
                    if (car.Color == filter)
                        return $"Make: {car.Make}\nModel: {car.Model}\nAge: {car.Age}\nPrice: {car.Price.ToString("c")}\n";
                }
                else if (filterName == FilterName.Age)
                {
                    //Get the age range desired, and set the lower and upper limits
                    var ages = CarAgeRangesDB.Get();
                    int lowerLimit = ages[filter][0];
                    int upperLimit = ages[filter][1];

                    //Compare the age of the car to the limits of the filter
                    if (!car.CompareTo(lowerLimit) && car.CompareTo(upperLimit))  //Only include if within range
                    {
                        result += car.GetDisplayText();
                    }
                }
                else if (filterName == FilterName.Price)
                {
                    //Get the price range desired and set the lower and upper limits
                    var prices = CarPriceRangesDB.Get();
                    decimal lowerLimit = prices[filter][0];
                    decimal upperLimit = prices[filter][1];

                    //Compare the price of the car to the limits of the filter
                    if (!car.CompareTo(lowerLimit) && car.CompareTo(upperLimit)) //Only include if within range
                    {
                        result += car.GetDisplayText();
                    }
                }
            }

            return result;
        }
    }

    /// <summary>
    /// Enum for filter names
    /// </summary>
    public enum FilterName
    {
        Color,
        Make,
        Age,
        Price,
        Null
    }
}
