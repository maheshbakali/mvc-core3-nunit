using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Project.RandomGenerator;
using Project.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    [TestFixture]    
    public class RandomGeneratorTests
    {        
        private HomeController _homeController;
        
        [Test]
        public void HomeController_RandomGenerator_Test1()
        {
            // Arrange
            int min = 1, max = 100;
            var mock = new Mock<IRandomGenerator>();
            _homeController = new HomeController(mock.Object);

            mock.Setup(m => m.Generate(min, max)).Returns(34);

            // Act
            var result = _homeController.DependencyInjection(min, max);
            var actualRandomNumber = (result as ViewResult).ViewData["RandomNumber"];

            // Assert
            Assert.AreEqual(34, Convert.ToInt32(actualRandomNumber));
        }

        [SetUp]
        public void HomeController_RandomGenerator_Test2()
        {
            // Arrange
            int min = 100, max = 1000;
            var mock = new Mock<IRandomGenerator>();
            _homeController = new HomeController(mock.Object);

            mock.Setup(m => m.Generate(min, max)).Returns(2);

            // Act
            var result = _homeController.DependencyInjection(min, max);
            var actualRandomNumber = (result as ViewResult).ViewData["RandomNumber"];

            // Assert
            Assert.AreNotEqual(-2, Convert.ToInt32(actualRandomNumber));
        }

        [SetUp]
        public void HomeController_RandomGenerator_Test3()
        {
            // Arrange
            int min = -100, max = 100;
            var mock = new Mock<IRandomGenerator>();
            _homeController = new HomeController(mock.Object);

            mock.Setup(m => m.Generate(min, max)).Returns(-10);

            // Act
            var result = _homeController.DependencyInjection(min, max);
            var actualRandomNumber = (result as ViewResult).ViewData["RandomNumber"];

            // Assert
            Assert.AreEqual(-10, Convert.ToInt32(actualRandomNumber));
        }
        
    }
}
