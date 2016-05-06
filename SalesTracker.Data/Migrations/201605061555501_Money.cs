namespace SalesTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Money : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "CommPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "CommPercentage");
        }
    }
}
