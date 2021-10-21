using FleetManager.Desktop.Data.Daos.REST.Model;
using FleetManager.Desktop.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Desktop.Data.Daos.REST
{
    // TODO: (Step 4) implement data access object for the Cars resource in the FleetManager WebAPI

    // 1. make the class inherit from the BaseDao class and use the relevant data context interface as type parameter
    // 2. implement the IDao interface in the class with the Car model class as type parameter

    class CarDao : BaseDao<IDataContext<IRestClient>>, IDao<Car>
    {
        public CarDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {

        }

        public Car Create(Car model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Car model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> Read()
        {
            IRestClient client = DataContext.Open(); //Åbner forbindelse til datacontext

            IRestRequest request = new RestRequest("/api/cars", Method.GET); //Kalder ressourcen - I dette tilfælde laves der en GET method på /api/cars

            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request); //Kalder en GET metode på request og typeparametriserer det til "Car" så den selv opretter objektet

            IList<Car> result = new List<Car>();
            foreach (CarDto item in response.Data)
            {
                result.Add(item.Map());
            }

            return result; //Returnerer response.Data da response indeholder en IEnumerable<Car> som kan hentes med .Data
        }

        public IEnumerable<Car> Read(Func<Car, bool> predicate)
        {
            IRestClient client = DataContext.Open(); //Åbner forbindelse til datacontext

            IRestRequest request = new RestRequest("/api/cars", Method.GET); //Kalder ressourcen - I dette tilfælde laves der en GET method på /api/cars

            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request); //Kalder en GET metode på request og typeparametriserer det til "Car" så den selv opretter objektet

            IList<Car> result = new List<Car>();
            foreach (CarDto item in response.Data)
            {
                result.Add(item.Map());
            }

            return result.Where(predicate); //Returnerer response.Data.Where(predicate) - Where(predicate) søger efter predicate i IEnumerable og returnerer den enkelte bil
        }

        public bool Update(Car model)
        {
            throw new NotImplementedException();
        }
    }
}
