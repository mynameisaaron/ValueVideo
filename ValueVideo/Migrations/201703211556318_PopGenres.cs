namespace ValueVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopGenres : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (1,'Animated')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (2,'SciFi')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (3,'Fantasy')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (4,'Action')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (5,'Historical Drama')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (6,'Comedy')");
            Sql(@"INSERT INTO Genres (Id,Name) VALUES (7,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
