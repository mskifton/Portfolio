namespace Dalek_Mint.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Defines the <see cref="adminrights" />
    /// </summary>
    public partial class adminrights : DbMigration
    {
        /// <summary>
        /// The Up
        /// </summary>
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Clubs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clubs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Article", c => c.String(nullable: false));
        }

        /// <summary>
        /// The Down
        /// </summary>
        public override void Down()
        {
            AlterColumn("dbo.News", "Article", c => c.String());
            AlterColumn("dbo.News", "Description", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
            AlterColumn("dbo.Clubs", "Description", c => c.String());
            AlterColumn("dbo.Clubs", "Name", c => c.String());
            AlterColumn("dbo.Events", "State", c => c.String());
            AlterColumn("dbo.Events", "City", c => c.String());
            AlterColumn("dbo.Events", "Address", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
        }
    }
}
