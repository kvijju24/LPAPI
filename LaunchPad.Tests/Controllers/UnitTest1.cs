using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaunchPad.Controllers;
namespace LaunchPad.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Get()
        //{
        //    // Arrange
        //    var controller = new AppointmentController();

        //    // Act
        //    var result = controller.GetAppointment();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
        [TestMethod]
        public void Getcode()
        {
            // Arrange
            var controller = new AppointmentController();

            // Act
            var result = controller.GetAppointmentCode();

            // Assert
            Assert.IsNotNull(result);
            // Assert.AreEqual(1000, result.Count());

        }
        //[TestMethod]
        //public void GetMaster()
        //{
        //    // Arrange
        //    var controller = new MasterController();

        //    // Act
        //    var result = controller.GetMaster();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
    }
}
