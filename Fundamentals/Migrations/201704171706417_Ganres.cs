namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ganres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ganres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieViewModels", "GanreId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieViewModels", "GanreId");
            AddForeignKey("dbo.MovieViewModels", "GanreId", "dbo.Ganres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieViewModels", "GanreId", "dbo.Ganres");
            DropIndex("dbo.MovieViewModels", new[] { "GanreId" });
            DropColumn("dbo.MovieViewModels", "GanreId");
            DropTable("dbo.Ganres");
        }
    }
}
