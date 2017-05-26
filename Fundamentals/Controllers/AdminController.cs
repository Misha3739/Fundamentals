using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fundamentals.Models.Admin;
using Fundamentals.Models.DBContext;
using Fundamentals.Models.DTO;
using Fundamentals.Utility;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
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

            var users = selected.DistinctBy(x => x.UserId).Select(Mapper.Map<UserInRolesDto, UserInRolesViewModel>).ToList();
            users.ForEach(u =>
            {
                u.Roles = selected.Where(r => r.UserId == u.UserId).Select(x =>

                    new AspNetRoleViewModel()
                    {
                        Id = x.RoleId,
                        Name = x.RoleName
                    }
                ).ToList();
            });


            return View("Tree",users);
        }
    }
}