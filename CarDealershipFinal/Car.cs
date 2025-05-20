using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// Base class of Car to be inherited by a Make Car Class
    /// </summary>
    public abstract class Car : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }

        public Car() { }

        /// <summary>
        /// Base Car object
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        /// <param name="price"></param>
        public Car(string make, string model, string color, int age, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Color = color;
            this.Age = age;
            this.Price = price;
        }

        /// <summary>
        /// Requires each Car Make to implement a GetDisplayText method
        /// </summary>
        public abstract string GetDisplayText();
        
        /// <summary>
        /// Get the appropriate data based off of the filter selected
        /// ex. If Make is the filter then the listings shown does not include the make in the listing
        /// this works the same when color is selected then color is not shown in the listing
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        /// <returns>a Car object without having the seleted filter to reduce redundency</returns>
        public virtual string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            if (filterName == FilterName.Make)
            {
                if (Make == filter)
                    return $"Model: {Model}\nColor: {Color}\nAge: {Age}\nPrice: {Price.ToString("c")}\n";
            }
            else if (filterName == FilterName.Color)
            {
                if (Color == filter)
                    return $"Make: {Make}\nModel: {Model}\nAge: {Age}\nPrice: {Price.ToString("c")}\n";
            }

            return null;
        }
    }
}
