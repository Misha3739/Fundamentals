using System;
using System.Web.Mvc;

namespace Fundamentals.Utility
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method ,Inherited = true, AllowMultiple = true)]
    public class FuntamentalsAuthorizeAttribute : AuthorizeAttribute
    {
        public FuntamentalsAuthorizeAttribute(string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}