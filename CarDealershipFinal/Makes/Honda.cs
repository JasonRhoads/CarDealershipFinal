using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarDealershipFinal
{
    public class Honda : Car, ICar
    {
        public string Trim { get; set; }
        public Honda() : base() { }

        public Honda(string model, string color, int age, decimal price, string trim) : base(nameof(Honda), model, color, age, price)
        {
            this.Trim = trim;
        }

        public override string GetDisplayText() =>
            $"Make: {Make}\n" +
            $"Model: {Model}\n" +
            $"Color: {Color}\n" +
            $"Age: {Age}\n" +
            $"Price: {Price.ToString("c")}\n" + 
            $"Trim: {Trim}\n";

        public override string GetFilteredString(FilterName filterName = FilterName.Null, string filter = null)
        {
            string result = Filters.GetFiltered(this, filterName, filter);

            if (filterName == FilterName.Make || filterName == FilterName.Color)
            {
                if (result != null && result != "")
                    return result + $"Trim: {Trim}\n";
            }

            return result;
        }
    }
}
