namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNINumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NationalInsuranceNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NationalInsuranceNumber");
        }
    }
}
