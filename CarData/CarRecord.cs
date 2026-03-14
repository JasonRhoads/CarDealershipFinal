using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarData
{
    public class CarRecord
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int AgeYears { get; set; }
        public decimal Price { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime DateListed { get; set; }
        public int SellerID { get; set; }
    }
}