using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CarDealershipFinal
{
    /// <summary>
    /// Functions to access datafiles
    /// </summary>
    public static class CarListingsDB<T> where T : Listing
    {
        private const string Directory = @"..\..\DataFiles\";
        private const string CarsPath = Directory + "InventoryItems.txt";
        private const string TimesPath = Directory + "ListingTimes.txt";

        /// <summary>
        /// Gets the Car and ListingTime data from file
        /// </summary>
        /// <returns>List of Listing for each Car and ListingTime</returns>
        public static List<T> GetListings()
        {
            List<T> result = new List<T>();

            try
            {
                //read in current data from file
                StreamReader carsIn = new StreamReader(new FileStream(CarsPath, FileMode.Open, FileAccess.Read));
                StreamReader timesIn = new StreamReader(new FileStream(TimesPath, FileMode.Open, FileAccess.Read));

                string[] cars = carsIn.ReadToEnd().Split('|');
                string[] times = timesIn.ReadToEnd().Split('|');

                carsIn?.Close();
                timesIn?.Close();

                //iterate through cars to create each object and time
                int index = 0;
                Car c = null;
                foreach (var car in cars)
                {
                    if (car != null && car != "")
                    {
                        var lines = car.Split('\n');
                    
                        if (lines[0].Trim() == nameof(BMW))
                            c = new BMW(lines[1].Trim(), lines[2].Trim(), Convert.ToInt32(lines[3].Trim()), Convert.ToDecimal(lines[4].Trim()), lines[5].Trim());
                        else if (lines[0].Trim() == nameof(Toyota))
                            c = new Toyota(lines[1].Trim(), lines[2].Trim(), Convert.ToInt32(lines[3].Trim()), Convert.ToDecimal(lines[4].Trim()), lines[5].Trim());
                        else if (lines[0].Trim() == nameof(Ford))
                            c = new Ford(lines[1].Trim(), lines[2].Trim(), Convert.ToInt32(lines[3].Trim()), Convert.ToDecimal(lines[4].Trim()), lines[5].Trim());
                        else if (lines[0].Trim() == nameof(Honda))
                            c = new Honda(lines[1].Trim(), lines[2].Trim(), Convert.ToInt32(lines[3].Trim()), Convert.ToDecimal(lines[4].Trim()), lines[5].Trim());

                        //create a new listing for each iteration
                        result.Add((T)new Listing(c, DateTime.Parse(times[index])));
                        index++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(CarsPath + " not found.\n"
                    + TimesPath + " not found."
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

            return result;
        }

        /// <summary>
        /// Gets Cars and ListingTimes creates a CarList from the GetListing function.
        /// </summary>
        /// <returns>CarList listing object</returns>
        public static CarList<T> Get()
        {
            CarList<T> result = new CarList<T>();
            var listings = GetListings();
            foreach (var listing in listings)
            {
                var car = listing.Car;
                result.Add(car, listing.CreationTime);
            }
            return result;
        }

        /// <summary>
        /// Main Save function takes car object 
        /// and the uniqueAttribute related to each make
        /// </summary>
        /// <param name="car"></param>
        /// <param name="uniqueAttribute"></param>
        public static void Save(Car car, string uniqueAttribute)
        {
            StreamReader carsIn = new StreamReader(new FileStream(CarsPath, FileMode.Open, FileAccess.ReadWrite));
            StreamReader timesIn = new StreamReader(new FileStream(TimesPath, FileMode.Open, FileAccess.ReadWrite));
            StreamWriter carsOut;
            StreamWriter timesOut;
            try
            {
                CarColorsDB.Save(car.Color);

                //Get list of current cars
                string carsResult = carsIn.ReadToEnd();
                carsResult += $"{car.Make}\n{car.Model}\n{car.Color}\n{car.Age}\n{car.Price}\n{uniqueAttribute}|";
                carsIn.Close();

                //Get list of current listing times
                string timesResult = timesIn.ReadToEnd();
                timesResult += $"{DateTime.Now}|";
                timesIn.Close();

                //Write new car and time to files.
                carsOut = new StreamWriter(new FileStream(CarsPath, FileMode.Create, FileAccess.ReadWrite));
                timesOut = new StreamWriter(new FileStream(TimesPath, FileMode.Create, FileAccess.ReadWrite));
                carsOut.Write(carsResult);
                timesOut.Write(timesResult);

                carsOut.Close();
                timesOut.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(CarsPath + " not found.\n"
                    + TimesPath + " not found."
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
        /// Save BMW with unique attribute 
        /// </summary>
        /// <param name="car"></param>
        public static void Save(BMW car)
        {
            Save(car, car.Engine);
        }

        /// <summary>
        /// Save Toyota with unique attribute 
        /// </summary>
        /// <param name="car"></param>
        public static void Save(Toyota car)
        {
           Save(car, car.Mileage);
        }

        /// <summary>
        /// Save Honda with unique attribute 
        /// </summary>
        /// <param name="car"></param>
        public static void Save(Honda car)
        {
            Save(car, car.Trim);
        }

        /// <summary>
        /// Save Ford with unique attribute 
        /// </summary>
        /// <param name="car"></param>
        public static void Save(Ford car)
        {
            Save(car, car.Height);
        }

        /// <summary>
        /// Get the new list of cars and save them to the datafile
        /// </summary>
        /// <param name="listings"></param>
        public static void UpdateAfterDeleted(List<Listing> listings)
        {
            string carsResult = "";
            string timesResult = "";
            List<string> colors = new List<string>();

            //Get all of the cars and creation times for each listing
            foreach (var listing in listings)
            {
                //split the car tostring file into format for saving
                string[] carValues = listing.Car.GetDisplayText().Split('\n');
                //had to further split each member to get the value to match the storage for the datafile
                carsResult += $"{carValues[0].Split(':')[1].Trim()}\n" +
                              $"{carValues[1].Split(':')[1].Trim()}\n" +
                              $"{carValues[2].Split(':')[1].Trim()}\n" +
                              $"{carValues[3].Split(':')[1].Trim()}\n" +
                              $"{carValues[4].Split(':')[1].Trim().Substring(1)}\n" +
                              $"{carValues[5].Split(':')[1].Trim()}|";
                timesResult += $"{listing.CreationTime}|";

                colors.Add(carValues[2].Split(':')[1].Trim());
            }

            CarColorsDB.Update(colors);

            //write new listing of cars to files
            try
            {
                StreamWriter carsOut = new StreamWriter(new FileStream(CarsPath, FileMode.Create, FileAccess.Write));
                StreamWriter timesOut = new StreamWriter(new FileStream(TimesPath, FileMode.Create, FileAccess.Write));
                carsOut.Write(carsResult);
                timesOut.Write(timesResult);

                carsOut.Close();
                timesOut.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(CarsPath + " not found.\n"
                    + TimesPath + " not found."
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
