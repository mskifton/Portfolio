namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DALEditEventBug : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Pending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Pending", c => c.Boolean(nullable: false));
        }
    }
}
