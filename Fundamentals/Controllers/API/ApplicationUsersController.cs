using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Fundamentals.Models.Authorization;
using Fundamentals.Models.DBContext;
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
        [ResponseType(typeof(AspNetUserDto))]
        public IHttpActionResult GetApplicationUsers([FromUri] bool pendingAuthorization)
        {
            var superAdminRole = _dbContext.Roles.Single(x => x.Name == Roles.SuperAdminRole);
            var allUsers = _dbContext.Users
                //.Where(x=>!(x.RoleApproved && x.ClaimedRoleId == superAdminRole.Id)).
                .Select(Mapper.Map<ApplicationUser, AspNetUserDto>);
            return Ok(pendingAuthorization ? allUsers.Where(x => x.RoleApproved == false) : allUsers);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationUsers([FromBody] ApplicationUserRequest requestParams)
        {
            if (requestParams?.Id != null && requestParams.AppliedRoleId != null)
            {
                var manager =
                    new ApplicationUserManager(new UserStore<ApplicationUser>(_dbContext))
                    {
                        PasswordHasher = new FundamentalsPasswordHasher()
                    };

                var user = _dbContext.Users.Find(requestParams.Id);
                var newRole = _dbContext.Roles.Single(x => x.Id == requestParams.AppliedRoleId);
                var oldRole = _dbContext.Roles.Single(x => x.Id == user.ClaimedRoleId);
                user.ClaimedRoleId = requestParams.AppliedRoleId;
                user.RoleApproved = true;

                await _dbContext.SaveChangesAsync();
                await manager.RemoveFromRoleAsync(requestParams.Id, oldRole.Name);
                await manager.AddToRoleAsync(requestParams.Id, newRole.Name);
                

                return Ok();
            }
            return BadRequest("Invalid parameters");
        }
    }

    public class ApplicationUserRequest
    {
        public string Id { get; set; }

        public string AppliedRoleId { get; set; }
    }
}
