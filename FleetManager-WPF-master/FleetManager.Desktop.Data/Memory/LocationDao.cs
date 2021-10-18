using FleetManager.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.Desktop.Data.Memory
{
    public class LocationDao : IDao<Location>
    {
        private static readonly List<Location> _locations = new()
        {
            new Location { Id = 1, Name = "Aalborg" },
            new Location { Id = 2, Name = "Randers" },
        };

        public Location Create(Location location)
        {
            location.Id = GenerateId();
            _locations.Add(location);
            return location;
        }

        public bool Delete(Location car)
        {
            return _locations.Remove(car);
        }

        public IEnumerable<Location> Read()
        {
            return _locations;
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate)
        {
            return _locations.Where(predicate);
        }

        public bool Update(Location car)
        {
            Location oldLocation = _locations.Single(c => c.Id == car.Id);
            if (_locations.Remove(oldLocation))
            {
                _locations.Add(car);
                return true;
            }
            return false;
        }

        private int GenerateId()
        {
            int id = 1;
            foreach (Location location in _locations)
            {
                if (location.Id > id)
                {
                    id = location.Id.Value;
                }
            }
            return id + 1;
        }
    }
}
