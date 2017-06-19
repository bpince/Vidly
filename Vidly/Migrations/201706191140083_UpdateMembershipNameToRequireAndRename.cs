namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipNameToRequireAndRename : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "MemberShipTypeName", c => c.String(nullable: false));

            Sql("Update MembershipTypes SET MembershipTypeName = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "MemberShipTypeName", c => c.String());
        }
    }
}
