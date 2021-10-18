using FleetManager.Desktop.Model;
using System;

namespace FleetManager.Desktop.Data
{
    public class DaoFactory
    {
        public static IDao<TModel> Create<TModel>(DaoType daoType)
        {
            switch (daoType)
            {
                case DaoType.Memory:
                    return CreateMemoryDao<TModel>();
                case DaoType.REST:
                default:
                    throw new Exception($"Dao [{daoType}] is not supported");
            }
        }

        private static IDao<TModel> CreateMemoryDao<TModel>()
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(Car) => new Memory.CarDao() as IDao<TModel>,
                var dao when dao == typeof(Location) => new Memory.LocationDao() as IDao<TModel>,
                _ => null,
            };
        }

        public enum DaoType
        {
            SQL,
            Memory,
            REST,
        }
    }
}
