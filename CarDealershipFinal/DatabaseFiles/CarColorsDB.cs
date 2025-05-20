using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal.DatabaseFiles
{
    public class CarColorsDB
    {
        private const string Path = @"..\..\DataFiles\CarColors.txt";

        /// <summary>
        /// Gets the age range data from the data file and returns it as a dictionary
        /// ex. 
        /// </summary>
        /// <param></param>
        /// <returns>If successful, returns a Dictionary with keys equal to the names of the ranges
        /// and values equal to the minimum and maximum values of the keys
        /// </returns>
        public static List<string> Get()
        {
            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));

            var s = textIn.ReadToEnd().Split('|').ToList();
            return s;
        }

        public static void Save(string color)
        {
            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));

            string result = textIn.ReadToEnd();
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
