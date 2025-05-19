using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal.DatabaseFiles
{
    public class CarColorsDB
    {
        private const string Path = @"..\..\DataFiles\CarColors.txt";

        public static List<string> Get()
        {
            var s = System.IO.File.ReadAllText(Path).Trim().Split('|').ToList();
            return s;
        }

        public static void Save(string color)
        {
            string result = System.IO.File.ReadAllText(Path);
            if (!result.Contains(color))
                result += $"|{color}";
            System.IO.File.WriteAllText(Path, result);
        }

        public static void Update(List<string> colors)
        {
            string result = "";
            foreach (string color in colors)
            {
                if (!result.Contains(color))
                    result += $"|{color}";
            }
            System.IO.File.WriteAllText(Path, result.Substring(1));
        }
    }
}
