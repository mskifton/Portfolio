namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "ImageName");
            DropColumn("dbo.Clubs", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clubs", "ImageName", c => c.String());
            AddColumn("dbo.Events", "ImageName", c => c.String());
        }
    }
}
