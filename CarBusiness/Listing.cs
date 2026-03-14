using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBusiness
{
    /// <summary>
    /// Listing object that combines a Car object and DateTime 
    /// to create a unique listing for each car
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Listing() { }

        /// <summary>
        /// Get and Set Car object
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// Get and Set CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Listing Object contains a Car object and DateTime of creation
        /// </summary>
        /// <param name="car"></param>
        /// <param name="dateTime"></param>
        public Listing(Car car, DateTime dateTime)
        {
            this.Car = car;
            this.CreationTime = dateTime;
        }

        /// <summary>
        /// Display a car listing in a readable format
        /// </summary>
        /// <returns>Car.GetDisplayText and the DateTime it is created</returns>
        public override string ToString() =>
             $"{CreationTime.ToString()} | {Car.Make} {Car.Model} | {Car.Color} | {Car.Age} | {Car.Price:C}";
        

        /// <summary>
        /// Get the Listings that match the filter
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        /// <returns>A Car objects that match the filter and 
        /// return the Car and then the CreationTime</returns>
        public string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            string carFilteredString = Car.GetFilteredString(filterName, filter);
            if (carFilteredString != null && carFilteredString != "")
                return CreationTime.ToString() + " | " + carFilteredString;

            return null;
        }
    }
}
