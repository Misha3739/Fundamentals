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
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RoleApproved");
            DropColumn("dbo.AspNetUsers", "ClaimedRoleId");
        }
    }
}
