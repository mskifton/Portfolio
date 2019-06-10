namespace Dalek_Mint.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Defines the <see cref="ssecond" />
    /// </summary>
    public partial class ssecond : DbMigration
    {
        /// <summary>
        /// The Up
        /// </summary>
        public override void Up()
        {
            DropForeignKey("dbo.Clubs", "Contact_UserId", "dbo.Users");
            DropIndex("dbo.Clubs", new[] { "Contact_UserId" });
            AddColumn("dbo.Clubs", "Contact", c => c.String());
            DropColumn("dbo.Clubs", "Contact_UserId");
        }

        /// <summary>
        /// The Down
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.Clubs", "Contact_UserId", c => c.Int());
            DropColumn("dbo.Clubs", "Contact");
            CreateIndex("dbo.Clubs", "Contact_UserId");
            AddForeignKey("dbo.Clubs", "Contact_UserId", "dbo.Users", "UserId");
        }
    }
}
