using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Fundamentals.Utility;

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
        }
    }
}
