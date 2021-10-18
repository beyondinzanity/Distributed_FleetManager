using FleetManager.DataAccessLayer;
using FleetManager.Entities;
using FleetManager.WebAPI.Controllers;
using FleetManager.WebAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.WebAPITests
{
    [TestClass]
    public class CarsControllerTests
    {
        private IDao<Car> _carDao;
        private IDao<Location> _locationDao;

        [TestInitialize]
        public void Init()
        {
            Location testLocation = new Location { Id = 1, Name = "Randers" };
            List<Car> testCars = new()
            {
                new Car
                {
                    Id = 1,
                    Brand = "Ford",
                    Mileage = 45358,
                    Location = testLocation
                },
                new Car
                {
                    Id = 2,
                    Brand = "KIA", 
                    Mileage = 4235, 
                    Location = testLocation
                }
            };

            Mock<IDao<Car>> carDaoMock = new();
            carDaoMock.Setup(d => d.ReadAll()).Returns(testCars);
            carDaoMock.Setup(d => d.ReadById(1)).Returns(testCars.Single(c => c.Id == 1));

            _carDao = carDaoMock.Object;

            Mock<IDao<Location>> locationDaoMock = new();
            locationDaoMock.Setup(l => l.ReadById(1)).Returns(testLocation);
            _locationDao = locationDaoMock.Object;
        }

        [TestMethod]
        public void GetAllCarsTest()
        {
            // Arrange
            CarsController carsController = new(_carDao, _locationDao);

            // Act
            IEnumerable<CarDto> cars = carsController.Get();

            // Assert
            Assert.IsNotNull(cars);
            Assert.AreEqual(cars.Count(), 2);
        }

        [TestMethod]
        public void GetCarByIdTest()
        {
            // Arrange
            CarsController carsController = new(_carDao, _locationDao);

            // Act
            CarDto cars = carsController.Get(1);

            // Assert
            Assert.IsNotNull(cars);
            Assert.AreEqual("/api/locations/1", cars.LocationHref);
        }
    }
}
