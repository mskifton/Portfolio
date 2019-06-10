namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsArchived", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.Clubs", "IsArchived", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.News", "IsArchived", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "IsArchived");
            DropColumn("dbo.Clubs", "IsArchived");
            DropColumn("dbo.Events", "IsArchived");
        }
    }
}
