using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// Listing object that combines a Car object and DateTime 
    /// to create a unique listing for each car
    /// </summary>
    public class Listing
    {
        public Listing() { }

        public Car Car { get; set; }

        public DateTime CreationTime { get; set; }

        public Listing(Car car, DateTime dateTime)
        {
            this.Car = car;
            this.CreationTime = dateTime;
        }

        public override string ToString()
        {
            return Car.GetDisplayText() + CreationTime.ToString() + "\n\n";
        }

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
                return carFilteredString + CreationTime.ToString() + "\n\n";

            return null;
        }
    }
}
