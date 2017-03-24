using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaunchPad.Controllers;
using LaunchPad.Repository;
using LaunchPad.Entities.Domain;

namespace LaunchPad.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            UnityConfig.RegisterComponents();
        }
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
        //[TestMethod]
        //public void Getcode()
        //{
            
        //    // Arrange
        //    var controller = new AppointmentController();

        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    // Assert.AreEqual(1000, result.Count());

        //}
        [TestMethod]
        public void Getcode()
        {
            var ClientData = new ClientUnitOfWork();
            var result = ClientData.Repository<Appointment>().GetAll();
            foreach(var i in result)
            {

                var x = i.Native_ID;
            }

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
