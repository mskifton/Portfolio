namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DAL123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsApproved", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.News", "IsApproved", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "IsApproved");
            DropColumn("dbo.Events", "IsApproved");
        }
    }
}
