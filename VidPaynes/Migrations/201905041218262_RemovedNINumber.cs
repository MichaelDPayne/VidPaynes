namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNINumber : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NationalInsuranceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NationalInsuranceNumber", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
