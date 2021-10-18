using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Data.Daos
{
    internal class BaseDao<TDataContext>
    {
        protected TDataContext DataContext { get; }

        public BaseDao(TDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
