namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreId", c => c.Long(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
