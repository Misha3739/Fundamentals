using System.Web.Optimization;

namespace Fundamentals
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/bundles/jqueryui",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-datepicker.js",
                         "~/Scripts/respond.js",
                         "~/Scripts/Datatables/jquery.datatables.js",
                         "~/Scripts/Datatables/datatables.bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-datepicker.js",
                         "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                         "~/Content/bootstrap-datepicker.css",
                        "~/Content/bootstrap.solar.css",
                      "~/Content/Site.css",
                      "~/Content/datatables/css/datatables.bootstrap.css"));

  
        }
    }
}
