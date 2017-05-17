using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Fundamentals.Models.DTO;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundamentals.Controllers.API
{
    [Authorize]
    public class RolesController : BaseController
    {
        // GET ---- /api/Roles
        [HttpGet]
        [ResponseType(typeof(AspNetRoleDto))]
        public IHttpActionResult GetRoles()
        {
            return Ok(_dbContext.Roles.Select(Mapper.Map<IdentityRole, AspNetRoleDto>));
        }
    }
}