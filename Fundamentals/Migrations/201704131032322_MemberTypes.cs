namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        MemberTypeEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserViewModels", "MemberTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserViewModels", "MemberTypeId");
            AddForeignKey("dbo.UserViewModels", "MemberTypeId", "dbo.MemberTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.UserViewModels", "MemberType");

        
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserViewModels", "MemberType", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserViewModels", "MemberTypeId", "dbo.MemberTypes");
            DropIndex("dbo.UserViewModels", new[] { "MemberTypeId" });
            DropColumn("dbo.UserViewModels", "MemberTypeId");
            DropTable("dbo.MemberTypes");
        }
    }
}
