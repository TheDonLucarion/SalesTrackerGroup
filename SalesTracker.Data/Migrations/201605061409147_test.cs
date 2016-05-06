namespace SalesTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        SalesTrackerUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.SalesTrackerUser", t => t.SalesTrackerUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.SalesTrackerUser_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCommission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdPartyReferral = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoyaltyFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AgentSplit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReloSplit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Base = c.Decimal(nullable: false, precision: 18, scale: 2),
                        APCF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnrollPCC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CharitbaleContribution = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Source = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId);
            
            CreateTable(
                "dbo.SalesTrackerUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        SalesTrackerUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalesTrackerUser", t => t.SalesTrackerUser_Id)
                .Index(t => t.SalesTrackerUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        SalesTrackerUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.SalesTrackerUser", t => t.SalesTrackerUser_Id)
                .Index(t => t.SalesTrackerUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "SalesTrackerUser_Id", "dbo.SalesTrackerUser");
            DropForeignKey("dbo.IdentityUserLogin", "SalesTrackerUser_Id", "dbo.SalesTrackerUser");
            DropForeignKey("dbo.IdentityUserClaim", "SalesTrackerUser_Id", "dbo.SalesTrackerUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "SalesTrackerUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "SalesTrackerUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "SalesTrackerUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.SalesTrackerUser");
            DropTable("dbo.Sales");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
        }
    }
}
