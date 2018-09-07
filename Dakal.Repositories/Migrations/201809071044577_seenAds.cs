namespace Dakal.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seenAds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeenAds",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AdId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        UserCompletedAction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.AdId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AdId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeenAds", "UserId", "dbo.Users");
            DropForeignKey("dbo.SeenAds", "AdId", "dbo.Advertisements");
            DropIndex("dbo.SeenAds", new[] { "UserId" });
            DropIndex("dbo.SeenAds", new[] { "AdId" });
            DropTable("dbo.SeenAds");
        }
    }
}
