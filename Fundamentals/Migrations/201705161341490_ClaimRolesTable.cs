namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimRolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClaimRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        RoleId = c.String(nullable: false),
                        RoleApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
           
            DropTable("dbo.ClaimRoles");
        }
    }
}
