using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Fundamentals.DomainModel;
using Fundamentals.Models.DBContext;

namespace Fundamentals.Controllers
{
   [AllowAnonymous]
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
            if (User.Identity.IsAuthenticated && User.IsInRole(Roles.CanEditCustomersRole))
                return View();
            return View("IndexReadOnly");
        }
        [Authorize]
        public ActionResult Create()
        {
         
            return View("Customer", new CustomerViewModel());
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var customers = _dbContext.Customers.ToList();
            var selected = customers.SingleOrDefault(x => x.Id == id);
            if (selected == null)
                return View("CustomerNotFound", id);
            return View("Customer", selected);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(CustomerViewModel customer)
        {
            if(!ModelState.IsValid)
                return View("Customer", customer);
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

    

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}