using FleetManager.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.Desktop.Data.Daos.Memory
{
    internal class LocationDao : BaseDao<ITypedDataContext>, IDao<Location>
    {
        public LocationDao(ITypedDataContext dataContext) : base(dataContext)
        {
        }

        public Location Create(Location model)
        {
            DataContext.Add(model);
            return model;
        }

        public bool Delete(Location model)
        {
            Location deletedLocation = DataContext.Locations.SingleOrDefault(l => l.Id == model.Id);
            return DataContext.Remove(deletedLocation);
        }

        public IEnumerable<Location> Read()
        {
            return DataContext.Locations;
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate)
        {
            return DataContext.Locations.Where(predicate);
        }

        public bool Update(Location model)
        {
            if (Delete(model))
            {
                DataContext.Add(model);
                return true;
            }
            return false;
        }
    }
}
