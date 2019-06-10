namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagetobytes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Image", c => c.Binary());
            DropColumn("dbo.Events", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ImageName", c => c.String());
            DropColumn("dbo.Events", "Image");
        }
    }
}
