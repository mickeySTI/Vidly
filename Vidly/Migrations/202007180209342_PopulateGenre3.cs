namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre3 : DbMigration
    {
        public override void Up()
        {
            // Needed to add lone below because of error when trying to update data base
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres(Id,Name) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(2,'Action')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(3,'Family')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(4,'Romance')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
