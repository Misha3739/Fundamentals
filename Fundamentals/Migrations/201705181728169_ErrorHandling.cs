namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorHandling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppErrors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OccuredTime = c.DateTime(nullable: false),
                        Message = c.String(),
                        StackTrace = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppErrors");
        }
    }
}
