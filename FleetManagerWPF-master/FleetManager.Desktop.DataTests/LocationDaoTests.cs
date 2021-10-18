using FleetManager.Desktop.Data;
using FleetManager.Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FleetManager.Desktop.DataTests
{
    [TestClass]
    public class LocationDaoTests
    {
        private IDataContext _dataContext;

        [TestInitialize]
        public void Initialize()
        {
            // TODO: (Step 5) You should change this to instantiate another datacontext
            // to test integration with other datasources, but DO NOT change the
            // tests!
            _dataContext = new TestDataContext();
        }

        [TestMethod]
        public void CreateLocationTest()
        {
            // Arrange
            Location newLocation = new()
            {
                Name = "Viborg"
            };
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            Location testLocation = dao.Create(newLocation);

            // Assert
            Assert.IsNotNull(testLocation);
            Assert.AreEqual(3, testLocation.Id);
        }

        [TestMethod]
        public void DeleteLocationTest()
        {
            // Arrange
            Location deleteLocation = new()
            {
                Id = 1
            };
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            bool test = dao.Delete(deleteLocation);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void DeleteNonExistingLocationTest()
        {
            // Arrange
            Location deleteLocation = new()
            {
                Id = 3
            };
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            bool test = dao.Delete(deleteLocation);

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void ReadAllLocationsTest()
        {
            // Arrange
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            IEnumerable<Location> test = dao.Read();

            // Assert            
            Assert.IsNotNull(test);
            Assert.AreEqual(2, test.Count());
        }

        [TestMethod]
        public void ReadLocationByNonExistingIdTest()
        {
            // Arrange
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            IEnumerable<Location> test = dao.Read(l => l.Id == 3);

            // Assert
            Assert.IsNotNull(test);
            Assert.AreEqual(0, test.Count());
        }

        [TestMethod]
        public void ReadLocationByIdTest()
        {
            // Arrange
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            IEnumerable<Location> test = dao.Read(l => l.Id == 1);

            // Assert            
            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Count());
        }

        [TestMethod]
        public void UpdateLocationTest()
        {
            // Arrange
            Location updatedLocation = new()
            {
                Id = 1,
                Name = "Skive"
            };
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            bool test = dao.Update(updatedLocation);
            // Assert

            Assert.IsTrue(test);
        }

        [TestMethod]
        public void UpdateNonExistingLocationTest()
        {
            // Arrange
            Location updatedLocation = new()
            {
                Id = 3,
                Name = "Skive"
            };
            IDao<Location> dao = DaoFactory.Create<Location>(_dataContext);

            // Act
            bool test = dao.Update(updatedLocation);
            // Assert

            Assert.IsFalse(test);
        }
    }
}
