using FleetManager.Desktop.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop
{
    class RestDataContext : IDataContext<IRestClient>
    {
        private readonly string _baseUri = "https://localhost:44305";

        #region Singleton
        public static IDataContext<IRestClient> Instance { get; set;}

        static RestDataContext()
        {
            Instance = new RestDataContext();
        }

        private RestDataContext()
        {

        }
        #endregion

        public IRestClient Open()
        {
            return new RestClient(_baseUri);
        }
    }
}
