namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editEvents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Category", c => c.String());
        }
    }
}
