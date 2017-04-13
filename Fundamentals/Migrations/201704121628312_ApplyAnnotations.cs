namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerViewModels", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CustomerViewModels", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserViewModels", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserViewModels", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserViewModels", "Patronimic", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserViewModels", "Patronimic", c => c.String());
            AlterColumn("dbo.UserViewModels", "LastName", c => c.String());
            AlterColumn("dbo.UserViewModels", "FirstName", c => c.String());
            AlterColumn("dbo.CustomerViewModels", "LastName", c => c.String());
            AlterColumn("dbo.CustomerViewModels", "FirstName", c => c.String());
        }
    }
}
