namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'20cf4d35-aad4-4ce8-84c4-587d34c312d4', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'480274a5-0087-45bb-b54f-bbf6034e8994', N'admin@vidly.com', 0, N'AFhLZpaKPapN06jwLdQ7MYeHxMfUV2rPd3RGjjsLK8ds93zvdGrQrpAMLvdFGisiVg==', N'99dd393f-f559-4dc2-a4c5-68c4023c4693', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'78c66acb-a869-4e49-80e0-77b0f1318ed1', N'guestUser1@vidly.com', 0, N'AJgn2d4TD9G5qSq58zLHknweqrbtlbWL+Ora3F/iCiPJq8BNBaQrLX2n/C/Ok1hs9g==', N'7cd96b47-4f76-4444-8d48-0cdf3ad87c49', NULL, 0, 0, NULL, 1, 0, N'guestUser1@vidly.com')
            
             INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'480274a5-0087-45bb-b54f-bbf6034e8994', N'20cf4d35-aad4-4ce8-84c4-587d34c312d4')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
