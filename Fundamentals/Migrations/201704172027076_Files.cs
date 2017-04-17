namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("Delete from dbo.MovieViewModels");
            AddColumn("dbo.MovieViewModels", "FileId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieViewModels", "FileId");
            AddForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files", "Id", cascadeDelete: true);
            DropColumn("dbo.MovieViewModels", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieViewModels", "Content", c => c.Binary());
            DropForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files");
            DropIndex("dbo.MovieViewModels", new[] { "FileId" });
            DropColumn("dbo.MovieViewModels", "FileId");
            DropTable("dbo.Files");
        }
    }
}
