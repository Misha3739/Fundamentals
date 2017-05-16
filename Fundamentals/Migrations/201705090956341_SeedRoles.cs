using Fundamentals.Controllers;
using Fundamentals.Utility;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.CanEditMoviesRole}')");

            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.CanEditCustomersRole}')");
        }
        
        public override void Down()
        {
        }
    }
}
