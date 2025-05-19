using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    public class Toyota : Car, ICar
    {
        public string Mileage { get; set; }

        public Toyota() : base() { }


        public Toyota(string model, string color, int age, decimal price, string mileage) : base(nameof(Toyota), model, color, age, price)
        {
            this.Mileage = mileage;
        }

        public override string GetDisplayText() =>
             $"Make: {Make}\n" +
             $"Model: {Model}\n" +
             $"Color: {Color}\n" +
             $"Age: {Age}\n" +
             $"Price: {Price.ToString("c")}\n" + 
             $"Mileage: {Mileage}\n";

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
    }
}
