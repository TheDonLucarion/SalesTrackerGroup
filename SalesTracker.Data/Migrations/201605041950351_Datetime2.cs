namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
        }
    }
}
