namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DAL134 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Contact", c => c.String(nullable: false));
            AddColumn("dbo.News", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Contact");
            DropColumn("dbo.Events", "Contact");
        }
    }
}
