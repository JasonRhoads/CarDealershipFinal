using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
     /// <summary>
     /// Create a list of Listings, Car + creation DateTime
     /// </summary>
     /// <typeparam name="T"></typeparam>
    public class CarList<T> where T : Listing
    {
        private List<Listing> cars;

        //Delegates and events
        public delegate void ChangeHandler(Listing car, bool add);
        public event ChangeHandler Changed;

        public delegate void ClearHandler();
        public event ClearHandler Cleared;

        public CarList() { cars = new List<Listing>(); }

        public int Count => cars.Count;

        /// <summary>
        /// Add listing car at index. 
        /// </summary>
        /// <param name="car"></param>
        /// <param name="index"></param>
        public void Add(Listing car, int index)
        {
            //try to insert it at the index provided. Otherwise add it to the end of the list
            try
            {
                cars.Insert(index, car);
            }
            catch
            {
                cars.Insert(cars.Count, car);
            }
            Changed?.Invoke(car, true);
        }

        /// <summary>
        /// Add car and creation DateTime to front of the list
        /// </summary>
        /// <param name="car"></param>
        /// <param name="dateTime"></param>
        public void Add(Car car, DateTime dateTime)
        {
            Listing newCar = new Listing(car, dateTime);
            cars.Insert(0, newCar);
        }

        /// <summary>
        /// Enumerator for CarList
        /// </summary>
        public IEnumerable<T> GetEnumerator()
        {
            foreach (T car in cars)
            {
                yield return car;
            }
        }

        /// <summary>
        /// Clears out the list of cars
        /// </summary>
        public void Clear()
        {
            cars.Clear();
            Cleared?.Invoke();
        }

        /// <summary>
        /// Remove a selected car
        /// </summary>
        /// <param name="car"></param>
        public void Remove(Listing car)
        {
            cars.Remove(car);
            Changed?.Invoke(car, false);
        }

        /// <summary>
        /// remove a car at a specific index
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            Listing deletedCourse = cars[index];
            cars.RemoveAt(index);

            Changed?.Invoke(deletedCourse, false);
        }

        /// <summary>
        /// returns a listing at index i, otherwise returns an empty listing 
        /// </summary>
        /// <param name="i"></param>
        /// <returns>listing at index i</returns>
        public Listing this[int i]
        {
            get
            {
                if (i < 0 || i >= cars.Count)
                {
                    Listing temp = new Listing();
                    return temp;
                }
                return cars[i];
            }

            set { cars[i] = value; }
        }


        /// <summary>
        /// Add a listing to CarList
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="car"></param>
        /// <returns>CarList with the added listing</returns>
        public static CarList<T> operator +(CarList<T> cl, Listing car)
        {          
            cl.Add(car, cl.Count);
            return cl;
        }

        /// <summary>
        /// Remove a listing from CarList
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="car"></param>
        /// <returns>CarList with the removed listing</returns>
        public static CarList<T> operator -(CarList<T> cl, Listing car)
        {
            cl.Remove(car);
            return cl;
        }
    }
}
