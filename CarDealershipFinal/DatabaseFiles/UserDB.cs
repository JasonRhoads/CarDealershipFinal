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

                var users = textIn.ReadToEnd().Trim().Split('|');
                string username = "";
                string password = "";

                foreach (var up in users)
                {
                    var lines = up.Split('\n');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var line = lines[i];

                        if (i == 0)
                            username = line.Trim();
                        else if (i == 1)
                            password = line.Trim();
                        else if (i == 2)
                        {
                            output.Add(username, password);
                        }

                    }
                }


                for (int i = 0; i < textIn.)
                {

                    //textIn.ReadToEnd().Trim().Split('|').ToList()
                    string username = str.Split('|')[0];
                    string password = str.Split('|')[1];

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
}
