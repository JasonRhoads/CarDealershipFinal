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
        public static Dictionary<string, string[]> Get()
        {
            StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.Read));

            try
            {
                Dictionary<string, string[]> output = new Dictionary<string, string[]>();

                var users = textIn.ReadToEnd().Trim().Split('\n');
                string username = "";
                string password = "";
                string role = "";

                foreach (var up in users)
                {
                    username = up.Split('|')[0].Trim();
                    password = up.Split('|')[1].Trim();
                    role = up.Split('|')[2].Trim();

                    string[] val = new string[2];
                    val[0] = password;
                    val[1] = role;

                    output.Add(username, val);
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

        /// <summary>
        /// Add function takes three strings for username, password, role
        /// and writes a user with those characteristics
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public static void Add(string username, string password, string role)
        {
            StreamReader input = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.ReadWrite));
            StreamWriter output;
            try
            {
                string userResult = input.ReadToEnd();
                userResult += $"\n{username}|{password}|{role}";
                input.Close();
                userResult = userResult.Trim();

                output = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.ReadWrite));
                output.Write(userResult);

                output.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(Path + " not found.\n"
                    , "File Not Found");
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
        /// Remove function takes one string for username
        /// and deletes the user with that name
        /// </summary>
        /// <param name="username"></param>
        public static void Remove(string username)//, string password, string role)
        {
            StreamReader input = new StreamReader(new FileStream(Path, FileMode.Open, FileAccess.ReadWrite));
            StreamWriter output;
            try
            {
                string[] lines = input.ReadToEnd().Split('\n');
                input.Close();

                string userResult = "";

                foreach (string line in lines)
                {
                    string name = line.Split('|')[0];

                    if (name != username)
                    {
                        userResult += "\n" + line;
                        userResult = userResult.Trim();
                    }
                }

                output = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.ReadWrite));
                output.Write(userResult);

                output.Close();



            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(Path + " not found.\n"
                    , "File Not Found");
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
