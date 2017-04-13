namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberTypes (RoleName) VALUES ('Admin')");
            Sql("INSERT INTO MemberTypes (RoleName) VALUES ('User')");
            Sql("INSERT INTO MemberTypes (RoleName) VALUES ('Customer')");
        }
        
        public override void Down()
        {
        }
    }
}
