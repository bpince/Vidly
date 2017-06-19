namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set MembershipTypeName = 'Monthly' Where Id = 2");
            Sql("Update MembershipTypes Set MembershipTypeName = 'Quarterly' Where Id = 3");
            Sql("Update MembershipTypes Set MembershipTypeName = 'No Membership' Where Id = 1");
            Sql("Update MembershipTypes Set MembershipTypeName = 'Yearly' Where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
