using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaunchPad.Controllers;
namespace LaunchPad.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            MasterController controller = new MasterController();

            // Act
            var result = controller.GetMaster();

            // Assert
            Assert.IsNotNull(result);
           // Assert.AreEqual(1000, result.Count());

        }
    }
}
