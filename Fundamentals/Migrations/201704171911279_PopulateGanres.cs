namespace Fundamentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGanres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ganres (Name) VALUES ('Classic')");
            Sql("INSERT INTO Ganres (Name) VALUES ('Rock')");
            Sql("INSERT INTO Ganres (Name) VALUES ('Hip-Hop')");
            Sql("INSERT INTO Ganres (Name) VALUES ('Jazz')");
        }
        
        public override void Down()
        {
        }
    }
}
