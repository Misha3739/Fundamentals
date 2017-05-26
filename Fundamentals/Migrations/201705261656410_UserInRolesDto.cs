using Fundamentals.Models.DBContext;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInRolesDto : DbMigration
    {
        public override void Up()
        {
            string script =
      @"
        CREATE VIEW dbo.UserInRolesDto 
        AS SELECT u.Id AS UserId, u.UserName, u.LastName, u.FirstName,u.RoleApproved,u.ClaimedRoleId,r.Id as RoleId,r.Name as RoleName FROM dbo.AspNetUsers u
        INNER JOIN dbo.AspNetUserRoles ur ON ur.UserId = u.Id
        INNER JOIN dbo.AspNetRoles r ON r.Id = ur.RoleId";
            FundamentalsDBContext ctx = new FundamentalsDBContext();
            ctx.Database.ExecuteSqlCommand(script);
        }
        
        public override void Down()
        {
            FundamentalsDBContext ctx = new FundamentalsDBContext();
            ctx.Database.ExecuteSqlCommand("DROP VIEW dbo.UserInRolesDto");
        
    }
    }
}
