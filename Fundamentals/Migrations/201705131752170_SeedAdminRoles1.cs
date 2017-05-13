using Fundamentals.Controllers;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminRoles1 : DbMigration
    {
        public override void Up()
        {
            var superAdminRoleId = Guid.NewGuid();

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
'mihail.udot@tandex.ru',
1,
'Ji~kmbm=>L',
'{Guid.NewGuid()}',
'89213050242',
1,
0,
0,
5,
'mihail.udot@tandex.ru',
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
