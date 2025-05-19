using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    public abstract class Car : ICar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }

        public Car() { }

        public Car(string make, string model, string color, int age, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Color = color;
            this.Age = age;
            this.Price = price;
        }

        public abstract string GetDisplayText();
        

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
