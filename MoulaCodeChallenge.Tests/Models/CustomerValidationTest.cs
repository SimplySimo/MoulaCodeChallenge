using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoulaCodeChallenge.Models;
using System.ComponentModel.DataAnnotations;

namespace MoulaCodeChallenge.Tests.Models
{
    /// <summary>
    /// Summary description for CustomerValidationTest
    /// </summary>
    [TestClass]
    public class CustomerValidationTest
    {
        [TestMethod]
        public void ValidateRequiredFirstName()
        {
            //setup
            Customer newCustomer = new Customer()
            {
                FirstName = "",
                LastName = "Solo",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };

            //act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(newCustomer, null, null);
            var isvalid = Validator.TryValidateObject(newCustomer, context, results, true);

            //verify
            Assert.IsFalse(isvalid);
        }

        [TestMethod]
        public void ValidateRequiredLastName()
        {
            //setup
            Customer newCustomer = new Customer()
            {
                FirstName = "Han",
                LastName = "",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };

            //act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(newCustomer, null, null);
            var isvalid = Validator.TryValidateObject(newCustomer, context, results, true);

            //verify
            Assert.IsFalse(isvalid);
        }

        [TestMethod]
        public void ValidateRequiredEmailBlank()
        {
            //setup
            Customer newCustomer = new Customer()
            {
                FirstName = "Han",
                LastName = "",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "",
                PersonId = 10
            };

            //act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(newCustomer, null, null);
            var isvalid = Validator.TryValidateObject(newCustomer, context, results, true);

            //verify
            Assert.IsFalse(isvalid);
        }

        [TestMethod]
        public void ValidateRequiredEmailIncorrect()
        {
            //setup
            Customer newCustomer = new Customer()
            {
                FirstName = "Han",
                LastName = "",
                DateOfBirth = new System.DateTime(1994, 1, 20),
                Email = "RuntheDeathStar.com",
                PersonId = 10
            };

            //act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(newCustomer, null, null);
            var isvalid = Validator.TryValidateObject(newCustomer, context, results, true);

            //verify
            Assert.IsFalse(isvalid);
        }
    }
}
