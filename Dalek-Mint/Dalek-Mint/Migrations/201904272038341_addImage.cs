namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ImageName", c => c.String());
            AddColumn("dbo.Clubs", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clubs", "ImageName");
            DropColumn("dbo.Events", "ImageName");
        }
    }
}
