using CarDealershipFinal.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace CarDealershipFinal
{
    public static class CarListingsDB
    {
        private const string CarsPath = @"..\..\DataFiles\InventoryItems.txt";
        private const string TimesPath = @"..\..\DataFiles\ListingTimes.txt";

        public static List<Listing> GetListings()
        {
            List<Listing> result = new List<Listing>();

            string[] cars = System.IO.File.ReadAllText(CarsPath).Split('|');
            string[] times = System.IO.File.ReadAllText(TimesPath).Split('|');

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

                    result.Add(new Listing(c, DateTime.Parse(times[index])));
                    index++;
                }
            }

            return result;
        }

        public static CarList<Listing> Get()
        {
            CarList<Listing> result = new CarList<Listing>();
            var listings = GetListings();
            foreach (var listing in listings)
            {
                var car = listing.Car;
                result.Add(car, listing.CreationTime);
            }
            return result;
        }

        public static void Save(BMW car)
        {
            CarColorsDB.Save(car.Color);

            string carsResult = System.IO.File.ReadAllText(CarsPath);
            carsResult += $"{car.Make}\n{car.Model}\n{car.Color}\n{car.Age}\n{car.Price}\n{car.Engine}|";
            System.IO.File.WriteAllText(CarsPath, carsResult);

            string timesResult = System.IO.File.ReadAllText(TimesPath);
            timesResult += $"{DateTime.Now}|";
            System.IO.File.WriteAllText(TimesPath, timesResult);
        }

        public static void Save(Toyota car)
        {
            CarColorsDB.Save(car.Color);

            string carsResult = System.IO.File.ReadAllText(CarsPath);
            carsResult += $"{car.Make}\n{car.Model}\n{car.Color}\n{car.Age}\n{car.Price}\n{car.Mileage}|";
            System.IO.File.WriteAllText(CarsPath, carsResult);

            string timesResult = System.IO.File.ReadAllText(TimesPath);
            timesResult += $"{DateTime.Now}|";
            System.IO.File.WriteAllText(TimesPath, timesResult);
        }
        public static void Save(Honda car)
        {
            CarColorsDB.Save(car.Color);

            string carsResult = System.IO.File.ReadAllText(CarsPath);
            carsResult += $"{car.Make}\n{car.Model}\n{car.Color}\n{car.Age}\n{car.Price}\n{car.Trim}|";
            System.IO.File.WriteAllText(CarsPath, carsResult);

            string timesResult = System.IO.File.ReadAllText(TimesPath);
            timesResult += $"{DateTime.Now}|";
            System.IO.File.WriteAllText(TimesPath, timesResult);
        }

        public static void Save(Ford car)
        {
            CarColorsDB.Save(car.Color);

            string carsResult = System.IO.File.ReadAllText(CarsPath);
            carsResult += $"{car.Make}\n{car.Model}\n{car.Color}\n{car.Age}\n{car.Price}\n{car.Height}|";
            System.IO.File.WriteAllText(CarsPath, carsResult);

            string timesResult = System.IO.File.ReadAllText(TimesPath);
            timesResult += $"{DateTime.Now}|";
            System.IO.File.WriteAllText(TimesPath, timesResult);
        }

        //Get the new list of cars and save them to the datafile
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

            System.IO.File.WriteAllText(CarsPath, carsResult);
            System.IO.File.WriteAllText(TimesPath, timesResult);

        }
    }
}
