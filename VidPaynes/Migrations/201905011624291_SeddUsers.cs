namespace VidPaynes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeddUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33325a25-9c11-42a0-89ee-7395d224275e', N'michael_payne123@hotmail.co.uk', 0, N'ACEFonRW2bfcGagRFP7cJfMyIiStcDoQGm0ixiukj/so0SKMlSO1CKj3/18oBORXlQ==', N'93bf2523-d0b4-473b-8b08-3db3dd3031af', NULL, 0, 0, NULL, 1, 0, N'michael_payne123@hotmail.co.uk')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b58966e3-077f-4dbc-aaa7-6d44c0bf472f', N'lrdpayne27@gmail.com', 0, N'AIDTJGo8N5zpeMs8e+bYHeceffZJJPrRgrfaSdz1s6qq0wVPYsGlqjP2Zsb3JsycoA==', N'804e5246-1cbf-4afd-861e-f0e713afd17a', NULL, 0, 0, NULL, 1, 0, N'lrdpayne27@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd4ed4704-96d1-49fd-9978-0de20bde4ebb', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b58966e3-077f-4dbc-aaa7-6d44c0bf472f', N'd4ed4704-96d1-49fd-9978-0de20bde4ebb')
");
        }
        
        public override void Down()
        {
        }
    }
}
