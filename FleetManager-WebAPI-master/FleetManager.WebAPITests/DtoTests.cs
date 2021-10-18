using FleetManager.Entities;
using FleetManager.WebAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FleetManager.WebAPITests
{
    [TestClass]
    public class DtoMapperTests
    {
        [TestMethod]
        public void ExtractIdFromBaseDtoTest()
        {
            LocationDto locationDto = new()
            {
                Href = "api/locations/1",
                Name = "Aalborg"
            };

            Assert.AreEqual(1, locationDto.ExtractId());
        }

        [TestMethod]
        public void ExtractHrefFromEntityBaseTest()
        {
            Location location = new Location
            {
                Id = 1,
                Name = "Aalborg",
            };

            Assert.AreEqual("/api/locations/1", location.ExtractHref());
        }

        [TestMethod]
        public void CarDtoToCarEntityMapperTest()
        {
            CarDto carDto = new()
            {
                Brand = "Ford",
                Mileage = 1234,
                Reserved = null,
                Href = "/api/cars/1",
                LocationHref = "api/locations/1",
            };

            Car testCar = carDto.Map();

            Assert.IsNotNull(testCar);
            Assert.IsNull(testCar.Location);
            Assert.AreEqual(1, testCar.Id);
        }

        [TestMethod]
        public void CarEntityToCarDtoMapperTest()
        {
            Car carEntity = new()
            {
                Id = 1,
                Brand = "Ford",
                Mileage = 1234,
                Reserved = null,
                Location = new() { Id = 1, Name = "Randers" }
            };

            CarDto testCar = carEntity.Map();

            Assert.IsNotNull(testCar);
            Assert.AreEqual("/api/locations/1", testCar.LocationHref);
            Assert.AreEqual("/api/cars/1", testCar.Href);
        }
    }
}
