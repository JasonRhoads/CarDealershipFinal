using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipFinal.DatabaseFiles
{
    /// <summary>
    /// Get Car colors from file
    /// </summary>
    public class CarColorsDB
    {
        private const string Directory = @"..\..\DataFiles\";
        private const string Path = Directory + "CarColors.txt";

        /// <summary>
        /// Gets the age range data from the data file and returns it as a dictionary
        /// ex. 
        /// </summary>
        /// <returns>If successful, returns a Dictionary with keys equal to the names of the ranges
        /// and values equal to the minimum and maximum values of the keys
        /// </returns>
        public static List<string> Get()
        {
            List<string> colors = new List<string>();
            try
            {
                StreamReader carsIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));

                colors = carsIn.ReadToEnd().Split('|').ToList();
                carsIn?.Close();
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
            return colors;
        }

        /// <summary>
        /// Saves color to file only if it is a new color
        /// </summary>
        /// <param name="color"></param>
        public static void Save(string color)
        {
            try
            {
                //read the current list of colors
                StreamReader colorIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));
                string result = colorIn.ReadToEnd();
                colorIn?.Close();

                if (!result.Contains(color))
                    result += $"|{color}";

                //write the new list of colors
                StreamWriter colorOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write));
                colorOut.Write(result);
                colorOut?.Close();
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
        }

        /// <summary>
        /// Updates Car colors after a car has been deleted
        /// </summary>
        /// <param name="colors"></param>
        public static void Update(List<string> colors)
        {
            string result = "";
            foreach (string color in colors)
            {
                if (!result.Contains(color))
                    result += $"|{color}";
            }
            try
            {
                //write the new list of colors
                StreamWriter colorOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write));
                colorOut.Write(result.Substring(1));
                colorOut?.Close();
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
        }
    }
}
