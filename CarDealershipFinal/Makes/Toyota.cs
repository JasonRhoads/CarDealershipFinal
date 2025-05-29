using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// Toyota is a child class of Car
    /// </summary>
    public class Toyota : Car, ICar
    {
        public string Mileage { get; set; }

        public Toyota() : base() { }


        public Toyota(string model, string color, int age, decimal price, string mileage) : base(nameof(Toyota), model, color, age, price)
        {
            this.Mileage = mileage;
        }


        /// <summary>
        /// Get the display properties of the Toyota object
        /// </summary>
        /// <returns>properties of the Toyota object as a string</returns>
        public override string GetDisplayText() =>
             $"Make: {Make}\n" +
             $"Model: {Model}\n" +
             $"Color: {Color}\n" +
             $"Age: {Age}\n" +
             $"Price: {Price.ToString("c")}\n" + 
             $"Mileage: {Mileage}\n";


        /// <summary>
        /// Gets the Toyota object when a filter is selected
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        /// <returns>the unique attribute for Toyota</returns>
        public override string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            string result = Filters.GetFiltered(this, filterName, filter);

            if (filterName == FilterName.Make || filterName == FilterName.Color)
            {
                if (result != null && result != "")
                    return result + $"Mileage: {Mileage}\n";
            }

            return result;
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
