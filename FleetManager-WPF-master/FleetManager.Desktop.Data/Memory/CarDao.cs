using FleetManager.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.Desktop.Data.Memory
{
    public class CarDao : IDao<Car>
    {
        private static readonly List<Car> _cars = new();

        public Car Create(Car car)
        {
            car.Id = GenerateId();
            _cars.Add(car);
            return car;
        }

        public bool Delete(Car car)
        {
            return _cars.Remove(car);
        }


        public IEnumerable<Car> Read(Func<Car, bool> predicate)
        {
            return _cars.Where(predicate);
        }

        public IEnumerable<Car> Read()
        {
            return _cars;
        }

        public bool Update(Car car)
        {
            Car oldCar = _cars.Single(c => c.Id == car.Id);
            if (_cars.Remove(oldCar))
            {
                _cars.Add(car);
                return true;
            }
            return false;
        }

        private static int GenerateId()
        {
            int id = 1;
            foreach (Car car in _cars)
            {
                if (car.Id > id)
                {
                    id = car.Id.Value;
                }
            }
            return id + 1;
        }
    }
}
