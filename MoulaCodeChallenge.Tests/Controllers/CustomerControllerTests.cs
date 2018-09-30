using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoulaCodeChallenge.Tests;
using System.Collections.Generic;
using System.Web.Mvc;
using MoulaCodeChallenge.Controllers;
using MoulaCodeChallenge.Models;

namespace MoulaCodeChallenge.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTests
    {
        [TestMethod()]
        public void CreateCustomerCodeCustomerCodeValidation()
        {
            // setup
            Customer newCustomer = new Customer()
            {
                FirstName = "Han",
                LastName = "Solo",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };
            string expected = "solohan19940120";

            //act
            CustomerController controller = new CustomerController();
            string result = controller.CreateCustomerCode(newCustomer.FirstName, newCustomer.LastName, newCustomer.DateOfBirth);

            //verify
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CreateCustomerCreateCustomerSuccessful()
        {
            //setup
            Mock<DatabaseContext> mockContext = DataCreation.CreateDataContext();
            CustomerController controller = new CustomerController(mockContext.Object);
            //create a new customer
            Customer newCustomer = new Customer()
            {
                FirstName = "Han",
                LastName = "Solo",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };
            newCustomer.CustCode = DataCreation.CreateCustomerCode(
                newCustomer.FirstName, newCustomer.LastName, newCustomer.DateOfBirth);

            //Act
            RedirectToRouteResult result = controller.CreateCustomer(newCustomer) as RedirectToRouteResult;

            //verify
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }

        [TestMethod()]
        public void CreateCustomerCreateCustomerAlreadyExists()
        {
            //setup
            Mock<DatabaseContext> mockContext = DataCreation.CreateDataContext();
            CustomerController controller = new CustomerController(mockContext.Object);
            Customer newCustomer = new Customer()
            {
                FirstName = "George",
                LastName = "Hammond",
                DateOfBirth = new System.DateTime(2000, 04, 20),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };
            newCustomer.CustCode = DataCreation.CreateCustomerCode(
                newCustomer.FirstName, newCustomer.LastName, newCustomer.DateOfBirth);

            //Act
            ViewResult result = controller.CreateCustomer(newCustomer) as ViewResult;

            //verify
            Assert.AreEqual(result.TempData["message"], "Customer Already Exists");
        }

        [TestMethod()]
        public void ViewAllCustomersShowingAllAvailable()
        {
            //setup
            Mock<DatabaseContext> mockContext = DataCreation.CreateDataContext();
            CustomerController controller = new CustomerController(mockContext.Object);

            //Act
            ViewResult result = controller.ListCustomer() as ViewResult;
            List<Customer> modelList = result.Model as List<Customer>;

            //verify
            Assert.AreEqual(modelList.Count, 8);
            Assert.AreEqual(result.TempData.Values.Count, 0);
        }
    }
}