using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Fundamentals.Models.Admin;
using Fundamentals.Models.DBContext;
using Fundamentals.Models.DTO;
using Fundamentals.Utility;
using Microsoft.Ajax.Utilities;

namespace Fundamentals.Controllers
{
    [Authorize(Roles = Roles.SuperAdminRole)]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            var selected = _dbContext.UserInRolesDtos().ToList();
            var roles = _dbContext.Roles.ToList();

            var users = selected.DistinctBy(x => x.UserId).Select(Mapper.Map<UserInRolesDto, UserInRolesViewModel>).ToList();
            users.ForEach(u =>
            {
                u.Roles = roles.Select(r =>

                    new AspNetRoleViewModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        IsChecked = selected.Any(ur => ur.UserId == u.UserId && ur.RoleId == r.Id)
                    }
                ).ToList();
            });


            return View("Tree",users);
        }
    }
}