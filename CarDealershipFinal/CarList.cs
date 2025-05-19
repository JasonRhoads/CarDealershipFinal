using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipFinal
{
    public class CarList<T> where T : Listing
    {
        private List<Listing> cars;

        public delegate void ChangeHandler(Listing car, bool add);
        public event ChangeHandler Changed;

        public delegate void ClearHandler();
        public event ClearHandler Cleared;

        public CarList() { cars = new List<Listing>(); }

        public int Count => cars.Count;

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

        public void Add(Car car, DateTime dateTime)
        {
            Listing newCar = new Listing(car, dateTime);
            cars.Insert(0, newCar);
        }

        public IEnumerable<T> GetEnumerator()
        {
            foreach (T car in cars)
            {
                yield return car;
            }
        }

        public void Clear()
        {
            cars.Clear();
            Cleared?.Invoke();
        }

        public void Remove(Listing car)
        {
            cars.Remove(car);
            Changed?.Invoke(car, false);
        }

        public void Remove(int index)
        {
            Listing deletedCourse = cars[index];
            cars.RemoveAt(index);

            Changed?.Invoke(deletedCourse, false);
        }

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

        public static CarList<T> operator +(CarList<T> cl, Listing car)
        {          
            cl.Add(car, cl.Count);
            return cl;
        }

    public static CarList<T> operator -(CarList<T> cl, Listing car)
        {
            cl.Remove(car);
            return cl;
        }
    }
}
