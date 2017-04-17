namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieAttributes : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from dbo.MovieViewModels");
            AlterColumn("dbo.MovieViewModels", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieViewModels", "Name", c => c.String());
        }
    }
}
