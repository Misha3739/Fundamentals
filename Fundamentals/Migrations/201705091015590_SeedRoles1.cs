using Fundamentals.Controllers;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles1 : DbMigration
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
