namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSystemUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberType = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Patronimic = c.String(),
                        BirthDate = c.DateTime(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserViewModels");
        }
    }
}
