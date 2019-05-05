namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogicToRentalsAPIforMoviesRented : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Customers_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Customers_Id");
            AddForeignKey("dbo.Movies", "Customers_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "Customers_Id" });
            DropColumn("dbo.Movies", "Customers_Id");
        }
    }
}
