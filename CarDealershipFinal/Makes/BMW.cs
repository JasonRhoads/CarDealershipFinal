using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    public class BMW : Car, ICar
    {
        public string Engine { get; set; }

        public BMW() : base() { }

        public BMW(string model, string color, int age, decimal price, string engine) : base(nameof(BMW), model, color, age, price)
        {
            this.Engine = engine;
        }

        public override string GetDisplayText() =>
            $"Make: {Make}\n" +
            $"Model: {Model}\n" +
            $"Color: {Color}\n" +
            $"Age: {Age}\n" +
            $"Price: {Price.ToString("c")}\n" + 
            $"Engine: {Engine}\n";
        
        public override string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            string result = Filters.GetFiltered(this, filterName, filter);

            if (filterName == FilterName.Make || filterName == FilterName.Color)
            {
                if (result != null && result != "")
                    return result + $"Engine: {Engine}\n";
            }

            return result;
        }
    }
}
