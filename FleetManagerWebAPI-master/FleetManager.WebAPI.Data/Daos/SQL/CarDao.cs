using FleetManager.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FleetManager.WebAPI.Data.Daos.SQL
{
    // TODO: (Step 4) implement data access object for the Cars table in the SQL Server database

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Car model class as type parameter

    class CarDao : BaseDao<IDataContext<IDbConnection>>, IDao<Car>
    {
        public CarDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
        {

        }

        public Car Create(Car model)
        {
            using IDbConnection conn = DataContext.Open();
            model.Id = conn.ExecuteScalar<int>("INSERT INTO Cars (Brand, Mileage, Reserved) VALUES (@brand, @mileage, @reserved); Select Scope_Identity();", model);
            return model;
        }

        public bool Delete(Car model)
        {
            using IDbConnection conn = DataContext.Open();

            return conn.Execute("DELETE FROM Cars WHERE Id = @id", model) >= 1;
        }

        public IEnumerable<Car> Read()
        {
            string query = "SELECT * FROM Cars INNER JOIN Locations ON Cars.LocationId=Locations.Id";
            using IDbConnection conn = DataContext.Open();

            return conn.Query<Car, Location, Car>(query, (c, l ) => {
                c.Location = l;
                return c;
                });
        }

        public IEnumerable<Car> Read(Func<Car, bool> predicate)
        {
            string query = "SELECT * FROM Cars INNER JOIN Locations ON Cars.LocationId=Locations.Id";
            using IDbConnection conn = DataContext.Open();

            return conn.Query<Car, Location, Car>(query, (c, l) => {
                c.Location = l;
                return c;
            }).Where(predicate);
        }

        public bool Update(Car model)
        {
            using IDbConnection conn = DataContext.Open();

            return conn.Execute("UPDATE Cars SET Brand = @brand, Mileage = @mileage, Reserved = @reserved WHERE Id = @id", model) == 1;
        }
    }
}
