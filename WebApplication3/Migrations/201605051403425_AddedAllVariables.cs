namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAllVariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "TotalCommission", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "ThirdPartyReferral", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "RoyaltyFee", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "AgentSplit", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "ReloSplit", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "Base", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "APCF", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "EnrollPCC", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "CharitbaleContribution", c => c.Single(nullable: false));
            AlterColumn("dbo.Sales", "SalesPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Sales", "Commission", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Commission", c => c.Double(nullable: false));
            AlterColumn("dbo.Sales", "SalesPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Sales", "CharitbaleContribution");
            DropColumn("dbo.Sales", "EnrollPCC");
            DropColumn("dbo.Sales", "APCF");
            DropColumn("dbo.Sales", "Base");
            DropColumn("dbo.Sales", "ReloSplit");
            DropColumn("dbo.Sales", "AgentSplit");
            DropColumn("dbo.Sales", "RoyaltyFee");
            DropColumn("dbo.Sales", "ThirdPartyReferral");
            DropColumn("dbo.Sales", "TotalCommission");
        }
    }
}
