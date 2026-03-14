using CarData;
using System;
using System.Collections.Generic;

namespace CarBusiness
{
    /// <summary>
    /// Manages the filters by interacting with the data layer.
    /// </summary>
    public class Filters
    {
        private static List<string> Colors;
        private static List<string> Makes;
        private static List<string> Prices;
        private static List<string> Ages;

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

            foreach (var color in Colors)
                result.Add(color);

            foreach (var make in Makes)
                result.Add(make);

            foreach (var price in Prices)
                result.Add(price);

            foreach (var age in Ages)
                result.Add(age);

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
                    if (car.Make == filter)
                        return $"{car.Model} | {car.Color} | {car.Age} | {car.Price:c}";
                }
                else if (filterName == FilterName.Color)
                {
                    if (car.Color == filter)
                        return $"{car.Make} | {car.Model} | {car.Age} | {car.Price:c}";
                }
                else if (filterName == FilterName.Age)
                {
                    var ages = CarAgeRangesDB.Get();
                    int lowerLimit = ages[filter][0];
                    int upperLimit = ages[filter][1];

                    if (!car.CompareTo(lowerLimit) && car.CompareTo(upperLimit))
                    {
                        result += car.GetListText();
                    }
                }
                else if (filterName == FilterName.Price)
                {
                    var prices = CarPriceRangesDB.Get();
                    decimal lowerLimit = prices[filter][0];
                    decimal upperLimit = prices[filter][1];

                    if (!car.CompareTo(lowerLimit) && car.CompareTo(upperLimit))
                    {
                        result += car.GetListText();
                    }
                }
            }

            return result;
        }
    }

    public enum FilterName
    {
        Color,
        Make,
        Age,
        Price,
        Null
    }
}