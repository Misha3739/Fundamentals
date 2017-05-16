using Fundamentals.Utility;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimRoleOnRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ClaimedRoleId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "RoleApproved", c => c.Boolean(nullable: false));

            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.DefaultRole}')");

            Sql($"UPDATE AspNetUsers SET RoleApproved = 1,ClaimedRoleId = (SELECT TOP 1  Id FROM AspNetRoles WHERE Name = '{Roles.SuperAdminRole}') WHERE Email = 'mihail.udot@yandex.ru'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RoleApproved");
            DropColumn("dbo.AspNetUsers", "ClaimedRoleId");
        }
    }
}
