using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipFinal.DatabaseFiles
{
    public class UserDB
    {

        private const string Directory = @"..\..\DataFiles\";
        private const string Path = Directory + "Users.txt";

        /// <summary>
        /// Gets list of users splitting up usernames and passwords
        /// </summary>
        /// <returns>List of string, strings that contain the Users available</returns>
        public static Dictionary<string, string> Get()
        {
            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));

            try
            {
                Dictionary<string, string> output = new Dictionary<string, string>();

                var users = textIn.ReadToEnd().Trim().Split('\n');
                string username = "";
                string password = "";

                foreach (var up in users)
                {
                    username = up.Split('|')[0].Trim();
                    password = up.Split('|')[1].Trim();
                    
                    output.Add(username, password);
                }

                return output;
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
