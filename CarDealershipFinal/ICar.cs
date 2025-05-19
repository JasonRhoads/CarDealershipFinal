using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// ICar interface for the basic attributes for a car
    /// Inherits IDisplayable
    /// </summary>
    public interface ICar : IDisplayable
    {   
        string Make { get; set; }
        string Model { get; set; }
        string Color { get; set; }
        int Age { get; set; }
        decimal Price { get; set; }
    }
}
