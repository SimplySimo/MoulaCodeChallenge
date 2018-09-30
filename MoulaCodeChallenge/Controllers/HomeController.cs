using MoulaCodeChallenge.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace MoulaCodeChallenge.Controllers
{

    public class HomeController : Controller
    {
        public Models.IDbContext dbContext;

        //Dependancy Injection
        public HomeController()
        {
            dbContext = new Models.DatabaseContext();
        }
        public HomeController(Models.IDbContext repo)
        {
            dbContext = repo;
        }
        /// <summary>
        /// Default page load method
        /// </summary>
        /// <returns>Index page</returns>
        public ActionResult Index()
        {
            List<Models.Customer> customers = new List<Models.Customer>();

            try
            {
                //retrieval of oldest (by age) 5 customers
                using (Models.IDbContext context = dbContext)
                {
                    var CustomerRepository = new CustomerRepository(context);
                    customers = CustomerRepository.GetOldestFive();

                }
                //ordering of custermers by lastname
                customers = customers.OrderByDescending(o => o.LastName).Reverse().ToList();
            }
            catch (SqlException)
            {
                TempData["Message"] = "Unable to connect to database";

            }
            //catch all
            catch (Exception e)
            {
                //tempory logging till a logger can be implemented
                Console.Out.WriteLine(e.Message);
                TempData["Message"] = "Unable to connect to database";
            }
            return View(customers);
        }
    }
}

