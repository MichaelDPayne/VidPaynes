namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMoviesRentedTypetoRental : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "Customers_Id" });
            DropColumn("dbo.Rentals", "Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "Customers_Id", newName: "Customer_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Customers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Customers_Id", c => c.Int());
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "Customers_Id");
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Customers_Id");
            AddForeignKey("dbo.Movies", "Customers_Id", "dbo.Customers", "Id");
        }
    }
}
