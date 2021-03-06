﻿using System.Web.Http;
using Fundamentals.Models.DBContext;

namespace Fundamentals.Controllers.API
{
    public class BaseController : ApiController
    {
        protected readonly FundamentalsDBContext _dbContext;

        public BaseController()
        {
            _dbContext = new FundamentalsDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
