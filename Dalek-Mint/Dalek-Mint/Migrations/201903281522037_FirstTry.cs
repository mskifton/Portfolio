namespace Dalek_Mint.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Defines the <see cref="FirstTry" />
    /// </summary>
    public partial class FirstTry : DbMigration
    {
        /// <summary>
        /// The Up
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.ClubEvents",
                c => new
                {
                    Club_ClubId = c.Int(nullable: false),
                    Event_EventId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Club_ClubId, t.Event_EventId })
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventId, cascadeDelete: true)
                .Index(t => t.Club_ClubId)
                .Index(t => t.Event_EventId);

            AddColumn("dbo.Users", "Title", c => c.String());
            AddColumn("dbo.Users", "Club_ClubId", c => c.Int());
            AddColumn("dbo.News", "PostedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Users", "Club_ClubId");
            AddForeignKey("dbo.Users", "Club_ClubId", "dbo.Clubs", "ClubId");
        }

        /// <summary>
        /// The Down
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.ClubEvents", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.ClubEvents", "Club_ClubId", "dbo.Clubs");
            DropIndex("dbo.ClubEvents", new[] { "Event_EventId" });
            DropIndex("dbo.ClubEvents", new[] { "Club_ClubId" });
            DropIndex("dbo.Users", new[] { "Club_ClubId" });
            DropColumn("dbo.News", "PostedDate");
            DropColumn("dbo.Users", "Club_ClubId");
            DropColumn("dbo.Users", "Title");
            DropTable("dbo.ClubEvents");
        }
    }
}
