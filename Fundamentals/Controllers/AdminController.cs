using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fundamentals.Models.Admin;
using Fundamentals.Models.DBContext;
using Fundamentals.Models.DTO;
using Fundamentals.Utility;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebGrease.Css.Extensions;

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
                    {
                        var isAssigned = selected.Any(ur => ur.UserId == u.UserId && ur.RoleId == r.Id);
                        return new AspNetRoleViewModel()
                        {
                            Id = r.Id,
                            UserId = u.UserId,
                            Name = r.Name,
                            IsAssigned = isAssigned,
                            IsChecked = isAssigned,
                            IsDirty = false
                        };
                    }
                ).ToList();
            });


            return View("Tree",users);
        }

        [HttpPost]
        public async Task<ActionResult> Save(List<UserInRolesViewModel> model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            await Task.Run(()=>model.ForEach(x => 
                {
                    if (x.IsDirty)
                    {
                        var rolesToDelete = x.Roles.Where(r => r.IsDirty && !r.IsChecked).Select(r => r.Name).ToArray();
                        userManager.RemoveFromRoles(x.UserId, rolesToDelete.ToArray());

                        var rolesToAdd = x.Roles.Where(r => r.IsDirty && r.IsChecked).Select(r => r.Name).ToArray();
                        userManager.AddToRoles(x.UserId, rolesToAdd);
                    }
                }
            )); 

            return RedirectToAction("Index");
        }
    }
}