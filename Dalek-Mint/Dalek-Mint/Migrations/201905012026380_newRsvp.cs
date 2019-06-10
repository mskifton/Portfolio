namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRsvp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventAttendances", "UserId", "dbo.Users");
            DropIndex("dbo.EventAttendances", new[] { "UserId" });
            AddColumn("dbo.Events", "ImageName", c => c.String());
            AddColumn("dbo.EventAttendances", "UserName", c => c.String());
            AddColumn("dbo.EventAttendances", "UserEmail", c => c.String());
            AddColumn("dbo.Clubs", "ImageName", c => c.String());
            DropColumn("dbo.EventAttendances", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventAttendances", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Clubs", "ImageName");
            DropColumn("dbo.EventAttendances", "UserEmail");
            DropColumn("dbo.EventAttendances", "UserName");
            DropColumn("dbo.Events", "ImageName");
            CreateIndex("dbo.EventAttendances", "UserId");
            AddForeignKey("dbo.EventAttendances", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
