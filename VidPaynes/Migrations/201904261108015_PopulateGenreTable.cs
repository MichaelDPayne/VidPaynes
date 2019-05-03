namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id, Name) Values (1, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values (2, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values (3, 'Sci-Fi')");
            Sql("Insert Into Genres (Id, Name) Values (4, 'Fantasy')");
            Sql("Insert Into Genres (Id, Name) Values (5, 'Horror')");
            Sql("Insert Into Genres (Id, Name) Values (6, 'Thriller')");

        }

        public override void Down()
        {
        }
    }
}
