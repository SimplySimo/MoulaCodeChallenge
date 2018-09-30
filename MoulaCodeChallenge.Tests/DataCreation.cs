using Moq;
using MoulaCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace MoulaCodeChallenge.Tests
{
    class DataCreation
    {
        /// <summary>
        /// Mock databasecontext for testing so no internet connection is needed
        /// </summary>
        /// <returns>mocked database</returns>
        public static Mock<DatabaseContext> CreateDataContext()
        {
            var data = new List<Customer>
            {
                new Customer {PersonId = 1, FirstName = "Jack", LastName = "O'niell", Email = "test@hotmail.com",DateOfBirth = DateTime.ParseExact("07/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 2, FirstName = "Samantha", LastName = "Carter",Email = "test@hotmail.com",DateOfBirth = DateTime.ParseExact("06/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 3, FirstName = "Daniel", LastName = "Jackson",Email = "test@hotmail.com", DateOfBirth = DateTime.ParseExact("05/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 4, FirstName = "George", LastName = "Hammond",Email = "test@hotmail.com",DateOfBirth = DateTime.ParseExact("04/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 5, FirstName = "Luke", LastName = "Picard", Email = "test@hotmail.com",DateOfBirth = DateTime.ParseExact("03/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 6, FirstName = "Hikaru", LastName = "Sulu", Email = "test@hotmail.com",DateOfBirth = DateTime.ParseExact("02/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 8, FirstName = "Rodney",LastName= "Mckay",Email = "test@hotmail.com", DateOfBirth = DateTime.ParseExact("01/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) },
                new Customer {PersonId = 9, FirstName = "Radek", LastName= "Zelenka",Email = "test@hotmail.com", DateOfBirth = DateTime.ParseExact("09/20/2000","MM/dd/yyyy", CultureInfo.InvariantCulture) }
            }.AsQueryable();

            foreach (var customer in data)
            {
                customer.CustCode = CreateCustomerCode(customer.FirstName, customer.LastName, customer.DateOfBirth);
            }

            Mock<DbSet<Customer>> mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<Customer>()).Returns(mockSet.Object);

            return mockContext;
        }

        ///copied method that creates customer code 
        public static string CreateCustomerCode(string firstName, string lastName, DateTime dateOfBirth)
        {
            return string.Join(firstName.ToLower(), lastName.ToLower(), dateOfBirth.ToString("yyyyMMdd"));
        }
    }
}
