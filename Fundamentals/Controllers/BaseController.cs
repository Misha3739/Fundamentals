using System;
using System.Web.Mvc;
using Fundamentals.Models.DBContext;

namespace Fundamentals.Controllers
{
    public class BaseController : Controller
    {
        protected readonly FundamentalsDBContext _dbContext;

        protected virtual string[] AvailableRoles { get; }

        public BaseController()
        {
            _dbContext = new FundamentalsDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}