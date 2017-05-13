using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using Fundamentals.Models.DBContext;
using Microsoft.AspNet.Identity;

namespace Fundamentals.Utility
{
    public sealed class BasicAuthHttpModule :IDisposable
    {
        private const string REALM_NAME = "Fundamentals Realm";

        private readonly FundamentalsDBContext _context;

        public BasicAuthHttpModule()
        {
            _context = new FundamentalsDBContext();
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Context_AuthenticateRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", $"Basic realm=\"{REALM_NAME}\"");
            }
        }

        private void Context_AuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (IsApiRequest(request) && authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                if (authHeaderVal.Parameter != null &&
                    authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        private void AuthenticateUser(string credentials)
        {
            try
            {
                credentials = Encoding.UTF8.GetString(Convert.FromBase64String(credentials));
                int separator = credentials.IndexOf(':');
                var name = credentials.Substring(0, separator);
                var password = credentials.Substring(separator + 1);
                if (CheckPassword(name, password))
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 401;
                    throw new UnauthorizedAccessException();
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        private bool CheckPassword(string name, string password)
        {
        
            var user = _context.Users.SingleOrDefault(x => x.UserName == name);
            if (user == null) return false;
            var hasher = new FundamentalsPasswordHasher();
            return hasher.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Success;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool IsApiRequest(HttpRequest request)
        {
            string apiPath = VirtualPathUtility.ToAbsolute("~/api/");
            return request.Url.AbsolutePath.StartsWith(apiPath);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}