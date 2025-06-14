﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// Ford is a child class of Car
    /// </summary>
    public class Ford : Car, ICar
    {
        public string Height {  get; set; }
        public Ford() : base() { }

        public Ford(string model, string color, int age, decimal price, string height) : base(nameof(Ford), model, color, age, price)
        {
            this.Height = height;
        }

        /// <summary>
        /// Get the display properties of the Ford object
        /// </summary>
        /// <returns>properties of the Ford object as a string</returns>
        public override string GetDisplayText() =>
            $"Make: {Make}\n" +
            $"Model: {Model}\n" +
            $"Color: {Color}\n" +
            $"Age: {Age}\n" +
            $"Price: {Price.ToString("c")}\n" +
            $"Height: {Height}\n";

        /// <summary>
        /// Gets the Ford object when a filter is selected
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="filter"></param>
        /// <returns>the unique attribute for Ford</returns>
        public override string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            string result = Filters.GetFiltered(this, filterName, filter);

            if (filterName == FilterName.Make || filterName == FilterName.Color)
            {
                if (result != null && result != "")
                    return result + $"Height: {Height}\n";
            }

            return result;
        }

        /// <summary>
        /// Clones a deep copy of a Ford car
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new Ford(Model, Color, Age, Price, Height);
        }
    }
}
