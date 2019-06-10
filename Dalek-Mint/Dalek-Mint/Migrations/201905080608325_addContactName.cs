namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ContactName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ContactName");
        }
    }
}
