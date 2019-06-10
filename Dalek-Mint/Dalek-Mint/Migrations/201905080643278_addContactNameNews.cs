namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactNameNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ContactName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ContactName");
        }
    }
}
