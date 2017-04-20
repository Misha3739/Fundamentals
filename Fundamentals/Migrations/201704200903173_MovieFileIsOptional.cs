namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieFileIsOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files");
            DropIndex("dbo.MovieViewModels", new[] { "FileId" });
            AlterColumn("dbo.MovieViewModels", "FileId", c => c.Int());
            CreateIndex("dbo.MovieViewModels", "FileId");
            AddForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files");
            DropIndex("dbo.MovieViewModels", new[] { "FileId" });
            AlterColumn("dbo.MovieViewModels", "FileId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieViewModels", "FileId");
            AddForeignKey("dbo.MovieViewModels", "FileId", "dbo.Files", "Id", cascadeDelete: true);
        }
    }
}
