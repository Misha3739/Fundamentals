﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Fundamentals.DomainModel;
using Fundamentals.Utility;

namespace Fundamentals.Controllers
{
    [AllowAnonymous]
    public class CustomersController : BaseController
    {
        
       protected override string[] AvailableRoles => new [] {Roles.SuperAdminRole, Roles.AdminRole, Roles.CanEditCustomersRole};

       
        // GET: Customers
       
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && this.IsInRole(AvailableRoles))
                return View();
            return View("IndexReadOnly");
        }

        [FuntamentalsAuthorize(new []{Roles.SuperAdminRole,Roles.AdminRole,Roles.CanEditCustomersRole})]
        public ActionResult Create()
        {
         
            return View("Customer", new CustomerViewModel());
        }
        [FuntamentalsAuthorize(new[] { Roles.SuperAdminRole, Roles.AdminRole, Roles.CanEditCustomersRole })]
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
        [FuntamentalsAuthorize(new[] { Roles.SuperAdminRole, Roles.AdminRole, Roles.CanEditCustomersRole })]
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

    

    
    }
}