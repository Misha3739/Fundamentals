using System.Linq;
using System.Web.Mvc;

namespace Fundamentals.Utility
{
    public static class ControllerHelper
    {
        public static bool IsInRole(this Controller controller, string[] roles)
        {
            return roles.Any(x => controller.User.IsInRole(x));
        }
    }
}