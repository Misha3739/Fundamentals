namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumFieldNotMapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemberTypes", "MemberTypeEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberTypes", "MemberTypeEnum", c => c.Int(nullable: false));
        }
    }
}
