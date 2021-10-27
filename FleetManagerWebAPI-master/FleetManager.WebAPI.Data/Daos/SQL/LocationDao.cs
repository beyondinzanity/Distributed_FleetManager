using Dapper;
using FleetManager.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.WebAPI.Data.Daos.SQL
{
    // TODO: (Step 4) implement data access object for the Locations table in the SQL Server database

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Location model class as type parameter

    class LocationDao : BaseDao<IDataContext<IDbConnection>>, IDao<Location>
    {
        public LocationDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
        {

        }

        public Location Create(Location model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Location model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> Read()
        {
            string query = "SELECT * FROM Locations";
            using IDbConnection conn = DataContext.Open();
            return conn.Query<Location>(query);
        }

        public IEnumerable<Location> Read(Func<Location, bool> predicate)
        {
            string query = "SELECT * FROM Locations";
            using IDbConnection conn = DataContext.Open();
            return conn.Query<Location>(query).Where(predicate);
        }

        public bool Update(Location model)
        {
            throw new NotImplementedException();
        }
    }
}
