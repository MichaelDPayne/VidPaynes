namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedNamePropertyOfMembersipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET MembershipName = 'Pay As You Go' WHERE Id = 1");
            Sql("Update MembershipTypes SET MembershipName = 'Monthly' WHERE Id = 2");
            Sql("Update MembershipTypes SET MembershipName = 'Quarterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET MembershipName = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
