using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBusiness
{
    /// <summary>
    /// Creates a new Car object
    /// </summary>
    public interface ICloneable
    {
        object Clone();
    }
}
