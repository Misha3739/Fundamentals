using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Fundamentals.Models;
using Fundamentals.Models.FundamentalsDBContext;

namespace Fundamentals.Controllers
{
    public class CustomersController : Controller
    {
        private readonly FundamentalsDBContext _dbContext;

        public CustomersController()
        {
            _dbContext= new FundamentalsDBContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.ToList();
            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
         
            return View("Customer", new CustomerViewModel());
        }


        public ActionResult GetCustomer(int id)
        {
            var customers = _dbContext.Customers.ToList();
            var selected = customers.SingleOrDefault(x => x.Id == id);
            if (selected == null)
                return View("CustomerNotFound", id);
            return View("Customer", selected);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer(CustomerViewModel customer)
        {
            try
            {
                _dbContext.Customers.AddOrUpdate(customer);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return Json($"Exception on DB occured: {e.Message}");
            }
           
            return RedirectToAction("Index");
        }

        private List<CustomerViewModel> GetCustomersList()
        {
            return new List<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Id = 1,
                    FirstName = "Udot",
                    LastName = "Mihail",
                    BirthDate = new DateTime(1991,01,02)
                },
                new CustomerViewModel()
                {
                    Id=2,
                     FirstName = "Kotskaya",
                    LastName = "Anastasya",
                    BirthDate = new DateTime(1993, 01, 21)
                }
            };
        }

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}