namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredDateForCustomesrAndMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieViewModels", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieViewModels", "ReleaseDate");
        }
    }
}
