namespace Dalek_Mint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsurehwhyitsbroken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Events", "Contact", c => c.String(nullable: false));
            AddColumn("dbo.News", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Contact");
            DropColumn("dbo.Events", "Contact");
            DropTable("dbo.Categories");
        }
    }
}
