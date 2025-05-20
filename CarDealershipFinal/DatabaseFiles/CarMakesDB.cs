using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipFinal.DatabaseFiles
{
    /// <summary>
    /// Get Makes from file
    /// </summary>
    public class CarMakesDB
    {
        private const string Directory = @"..\..\DataFiles\";
        private const string Path = Directory + "CarMakes.txt";

        /// <summary>
        /// Gets Makes that are available for application
        /// </summary>
        /// <returns>List of strings that contain the Makes available</returns>
        public static List<string> Get()
        {
            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));
            
            try
            {
                return textIn.ReadToEnd().Trim().Split('|').ToList();
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

            return null;
        }
    }
}
