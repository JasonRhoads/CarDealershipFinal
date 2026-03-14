using System;
using System.Collections.Generic;
using CarData;

namespace CarBusiness
{
    public class CarListingService
    {
        private readonly CarRepository repo = new CarRepository();

        public List<Listing> GetListings()
        {
            List<Listing> result = new List<Listing>();
            List<CarRecord> records = repo.GetAllCars();

            foreach (var record in records)
            {
                Car c = null;

                if (record.Make == nameof(BMW))
                    c = new BMW(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Toyota))
                    c = new Toyota(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Ford))
                    c = new Ford(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Honda))
                    c = new Honda(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);

                if (c != null)
                {
                    c.CarID = record.CarID;
                    result.Add(new Listing(c, record.DateListed));
                }
            }

            return result;
        }

        public List<Listing> GetListingsBySeller(int sellerId)
        {
            List<Listing> result = new List<Listing>();
            List<CarRecord> records = repo.GetCarsBySeller(sellerId);

            foreach (var record in records)
            {
                Car c = null;

                if (record.Make == nameof(BMW))
                    c = new BMW(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Toyota))
                    c = new Toyota(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Ford))
                    c = new Ford(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);
                else if (record.Make == nameof(Honda))
                    c = new Honda(record.Model, record.Color, record.AgeYears, record.Price, record.ExtraInfo);

                if (c != null)
                {
                    c.CarID = record.CarID;
                    result.Add(new Listing(c, record.DateListed));
                }
            }

            return result;
        }
    }
}