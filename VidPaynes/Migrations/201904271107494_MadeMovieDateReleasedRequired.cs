namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeMovieDateReleasedRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateReleased", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateReleased", c => c.DateTime());
        }
    }
}
