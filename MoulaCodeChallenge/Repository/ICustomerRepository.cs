using MoulaCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoulaCodeChallenge.Repository
{
    public interface ICustomerRepository : IDisposable, IRepository<Customer>
    {
        IQueryable<Customer> FindCustomerByEmail(string email);
        List<Customer> GetOldestFive();
        bool DoesCustomerExist(string customerCode);
        List<Customer> GetAllCustomers();

    }
}