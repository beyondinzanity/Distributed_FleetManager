using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FleetManager.Desktop.Data
{
    public interface IDao<TModel>
    {
        TModel Create(TModel model);
        IEnumerable<TModel> Read();
        IEnumerable<TModel> Read(Func<TModel, bool> predicate);
        bool Update(TModel model);
        bool Delete(TModel model);
    }
}
