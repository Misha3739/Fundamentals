using Fundamentals.Utility;

namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDummyUsers : DbMigration
    {
        public override void Up()
        {
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
('{Guid.NewGuid()}',
'User1@mail.ru',
1,
'{new FundamentalsPasswordHasher().HashPassword("Fergana12@")}',
'{Guid.NewGuid()}',
'89213050242',
1,
0,
0,
5,
'User1@mail.ru',
'Fedorov',
'Vasiliy',
 '1993-01-02')");

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
('{Guid.NewGuid()}',
'User2@mail.ru',
1,
'{new FundamentalsPasswordHasher().HashPassword("Fergana12@")}',
'{Guid.NewGuid()}',
'89222222222',
1,
0,
0,
5,
'User2@,ail.ru',
'Ivanova',
'Svetlana',
 '1991-06-02')");

        }

        public override void Down()
        {
        }
    }
}
