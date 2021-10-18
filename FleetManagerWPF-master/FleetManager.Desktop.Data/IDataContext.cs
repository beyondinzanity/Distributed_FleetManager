using FleetManager.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Data
{
    public interface IDataContext
    {

    }
    
    public interface IDataContext<TConnection> : IDataContext
    {
        TConnection Open();
    }

    public interface ITypedDataContext : IDataContext
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Location> Locations { get; }

        Car Add(Car car);
        Location Add(Location location);

        bool Remove(Car car);
        bool Remove(Location location);
    }
}
