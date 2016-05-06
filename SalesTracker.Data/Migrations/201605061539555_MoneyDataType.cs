namespace SalesTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoneyDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "SalesPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Sales", "TotalCommission", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Sales", "Commission", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Commission", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sales", "TotalCommission", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sales", "SalesPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
