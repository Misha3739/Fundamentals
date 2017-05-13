using Fundamentals.Controllers;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminRoles : DbMigration
    {
        public override void Up()
        {
            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.AdminRole}')");

            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.SuperAdminRole}')");

        }

        public override void Down()
        {
        }
    }
}
