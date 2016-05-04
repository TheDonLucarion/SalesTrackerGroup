namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTitle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sales", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Title", c => c.String(nullable: false));
        }
    }
}
