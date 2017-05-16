using Fundamentals.Controllers;
using Fundamentals.Utility;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedAdminRoles : DbMigration
    {
        public override void Up()
        {
            var superAdminRoleId = Guid.NewGuid();

            var userName = "mihail.udot@yandex.ru";

            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{Guid.NewGuid()}','{Roles.AdminRole}')");

            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES('{superAdminRoleId}','{Roles.SuperAdminRole}')");

            var userId = Guid.NewGuid();
            Sql($@"INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
        ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
    ,[PhoneNumberConfirmed]
,[TwoFactorEnabled]
,[LockoutEnabled]
,[AccessFailedCount]
           ,[UserName]
           ,[FirstName]
           ,[LastName]
           ,[BirthDate])
VALUES
('{userId}',
'{userName}',
1,
'{new FundamentalsPasswordHasher().HashPassword("Fergana12@")}',
'{Guid.NewGuid()}',
'89213050242',
1,
0,
0,
5,
'{userName}',
'Mihail',
'Udot',
 '1991-01-02')");

            Sql($@"INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           ('{userId}','{superAdminRoleId}')
GO");
        }

        public override void Down()
        {
        }
    }
}
