namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagetobytesclub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clubs", "Image", c => c.Binary());
            DropColumn("dbo.Clubs", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clubs", "ImageName", c => c.String());
            DropColumn("dbo.Clubs", "Image");
        }
    }
}
