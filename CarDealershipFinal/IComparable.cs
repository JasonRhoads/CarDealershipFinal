using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    /// <summary>
    /// Interface to compare the price and/or ages of Car
    /// </summary>
    public interface IComparable
    {
        bool CompareTo(decimal price);
        bool CompareTo(int age);
    }
}
