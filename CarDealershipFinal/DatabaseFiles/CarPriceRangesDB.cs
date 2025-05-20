using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CarDealershipFinal.DatabaseFiles
{
    /// <summary>
    /// Gets price ranges from file
    /// </summary>
    public class CarPriceRangesDB
    {
        private const string Directory = @"..\..\DataFiles\";
        private const string Path = Directory + "CarPriceRanges.txt";
        
        /// <summary>
        /// Creates Dictionary for price ranges
        /// </summary>
        /// <returns>Deicionary where key is the price ranges and 
        /// the values are the lower and upper ranges</returns>
        public static Dictionary<string, List<decimal>> Get()
        {
            var result = new Dictionary<string, List<decimal>>();

            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));
            
            try
            {
                var cars = textIn.ReadToEnd().Split('|');
                string key = "";
                decimal lowerLimit = 0;
                decimal upperLimit = 0;
                foreach (var car in cars)
                {
                    var lines = car.Split('\n');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var line = lines[i];

                        if (i == 0)
                            key = line.Trim();
                        else if (i == 1)
                            lowerLimit = Convert.ToDecimal(line);
                        else if (i == 2)
                        {
                            upperLimit = Convert.ToDecimal(line);
                            result.Add(key, new List<decimal> { lowerLimit, upperLimit });
                        }

                    }
                }
            } 
            catch (FileNotFoundException)
            {
                MessageBox.Show(Path + " not found.", "File Not Found");
            }
            catch (DirectoryNotFoundException) 
            {
                MessageBox.Show(Directory + " not found.", "Directory Not Found");
            }
            catch (IOException ex) 
            {
                MessageBox.Show(ex.Message, "IOException");
            }
            finally
            {
                textIn?.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets the price ranges
        /// </summary>
        /// <returns>The key values from Get() as a list</returns>
        public static List<string> GetRanges()
        {
            var result = Get();
            return result.Keys.ToList();
        }
    }
}
