using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CarDealershipFinal.DatabaseFiles
{
    public class CarAgeRangesDB
    {

        private const string Path = @"..\..\DataFiles\CarAgeRanges.txt";

        /// <summary>
        /// Gets the age range data from the data file and returns it as a dictionary
        /// ex. If the data is "Under 5 years\n0\n5|Between 5 years to 15 years\n5\n15|" it will return
        /// { "Under 5 years" : [0, 5], "Between 5 years to 15 years": [5, 15] }
        /// </summary>
        /// <param></param>
        /// <returns>If successful, returns a Dictionary with keys equal to the names of the ranges
        /// and values equal to the minimum and maximum values of the keys
        /// </returns>
        public static Dictionary<string, List<int>> Get()
        {
            try
            {
                StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));
                var cars = textIn.ReadToEnd().Split('|');

                var result = new Dictionary<string, List<int>>();


                //var cars = System.IO.File.ReadAllText(Path).Split('|');
                string key = "";
                int lowerLimit = 0;
                int upperLimit = 0;
                foreach (var car in cars)
                {
                    var lines = car.Split('\n');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var line = lines[i];

                        if (i == 0)
                            key = line.Trim();
                        else if (i == 1)
                            lowerLimit = Convert.ToInt32(line);
                        else if (i == 2)
                        {
                            upperLimit = Convert.ToInt32(line);
                            result.Add(key, new List<int> { lowerLimit, upperLimit });
                        }

                    }
                }

                return result;

            }
            catch (Exception)
            {
                MessageBox.Show("Error, file not found");
                return null;
            }
        }

        /// <summary>
        /// Get the range names as a list from the existing dictionary
        /// ex. if the age range is { "Under 5 years" : [0, 5], "Between 5 years to 15 years": [5, 15] }
        /// it will return { "Under 5 years", "Between 5 years to 15 years" }
        /// </summary>
        /// <param></param>
        /// <returns>If successful, returns a List of the human readable keys</returns>
        public static List<string> GetRanges()
        {
            var result = Get();
            return result.Keys.ToList();
        }
    }
}
