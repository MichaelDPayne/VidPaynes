namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDOBToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
