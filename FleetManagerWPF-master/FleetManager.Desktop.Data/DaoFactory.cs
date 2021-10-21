using FleetManager.Desktop.Model;
using RestSharp;
using System;

namespace FleetManager.Desktop.Data
{
    public static class DaoFactory
    {
        public static IDao<TModel> Create<TModel>(IDataContext dataContext)
        {
            Type dataContextType = dataContext.GetType();

            // TODO: (Step 3) add check for the sql server datacontext interface type and return the correct dao

            if (typeof(ITypedDataContext).IsAssignableFrom(dataContextType))
            {
                return typeof(TModel) switch
                {
                    var dao when dao == typeof(Car) => new Daos.Memory.CarDao(dataContext as ITypedDataContext) as IDao<TModel>,
                    var dao when dao == typeof(Location) => new Daos.Memory.LocationDao(dataContext as ITypedDataContext) as IDao<TModel>,
                    _ => throw new DaoFactoryException($"Model [{typeof(TModel).Name}] not supported"),
                };
            } else if(typeof(IDataContext<IRestClient>).IsAssignableFrom(dataContextType))
            {
                return typeof(TModel) switch
                {
                    var dao when dao == typeof(Car) => new Daos.REST.CarDao(dataContext as IDataContext<IRestClient>) as IDao<TModel>,
                    var dao when dao == typeof(Location) => new Daos.REST.LocationDao(dataContext as IDataContext<IRestClient>) as IDao<TModel>,
                    _ => throw new DaoFactoryException($"Model [{typeof(TModel).Name}] not supported"),
                };
            }
            throw new DaoFactoryException($"DataContext [{dataContext}] not supported");
        }
    }
}
