using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal.DatabaseFiles
{
    public class CarMakesDB
    {
        private const string Path = @"..\..\DataFiles\CarMakes.txt";

        public static List<string> Get()
        {
            return System.IO.File.ReadAllText(Path).Trim().Split('|').ToList();
        }
    }
}
