namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubcribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isSubscribed");
        }
    }
}
