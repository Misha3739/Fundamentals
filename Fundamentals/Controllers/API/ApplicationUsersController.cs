using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Fundamentals.Models.Authorization;
using Fundamentals.Models.DTO;
using Fundamentals.Utility;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundamentals.Controllers.API
{
    [Authorize]
    public class ApplicationUsersController : BaseController
    {
        // POST ---- /api/ApplicationUsers
        [HttpPost]
        [ResponseType(typeof(AspNerUserDTO))]
        public IHttpActionResult GetApplicationUsers([FromBody] bool pendingAuthorization)
        {
            var superAdminRole = _dbContext.Roles.Single(x => x.Name == Roles.SuperAdminRole);
            var allUsers = _dbContext.Users.Where(x=>!(x.RoleApproved && x.ClaimedRoleId == superAdminRole.Id)).Select(Mapper.Map<ApplicationUser, AspNerUserDTO>);
            return Ok(pendingAuthorization ? allUsers.Where(x => x.RoleApproved == false) : allUsers);
        }
    }
}
