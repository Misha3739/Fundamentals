using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Fundamentals.Models.DBContext;
using Fundamentals.Models.Error;
using Fundamentals.Utility;
using Microsoft.AspNet.Identity;

namespace Fundamentals
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static BasicAuthHttpModule Module = new BasicAuthHttpModule();

        protected void Application_Start()
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public override void Init()
        {
            base.Init();
            Module.Init(this);
            Error += ErrorHandler;
        }

        private void ErrorHandler(object sender, EventArgs args)
        {
            var ex = Server.GetLastError();
            if(ex == null) return;
            using (var _context = new FundamentalsDBContext())
            {
                _context.Errors.Add(
                    new AppError()
                    {
                        Message =ex.Message,
                        StackTrace = ex.StackTrace,
                        OccuredTime = DateTime.Now,
                        UserId = Context.User.Identity.GetUserId()
                    }
                    );
                _context.SaveChanges();
            }
        }
    }
}
