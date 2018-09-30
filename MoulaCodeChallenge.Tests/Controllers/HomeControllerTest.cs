using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoulaCodeChallenge.Controllers;
using MoulaCodeChallenge.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MoulaCodeChallenge.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void VerifyOldestFiveArePresentAndCorrect()
        {
            //setup
            Mock<DatabaseContext> mockContext = DataCreation.CreateDataContext();
            HomeController controller = new HomeController(mockContext.Object);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            List<Customer> modelList = result.Model as List<Customer>;

            //Verify model contains the correct number of customers and no error messages
            Assert.AreEqual(modelList.Count, 5);
            Assert.AreEqual(result.TempData.Values.Count, 0);

            //Verify model is in correct order
            Assert.IsTrue(modelList.FindIndex(x => x.PersonId == 4).Equals(0));
            Assert.IsTrue(modelList.FindIndex(x => x.PersonId == 3).Equals(1));
            Assert.IsTrue(modelList.FindIndex(x => x.PersonId == 8).Equals(2));
            Assert.IsTrue(modelList.FindIndex(x => x.PersonId == 5).Equals(3));
            Assert.IsTrue(modelList.FindIndex(x => x.PersonId == 6).Equals(4));
        }
    }
}
