namespace Dakal.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FilePath = c.String(),
                        AdType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Firms",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PackageName = c.String(maxLength: 450),
                        ApiAddress = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PackageName, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        FrimId = c.Long(nullable: false),
                        FirmPackageName = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firms", t => t.FrimId, cascadeDelete: true)
                .Index(t => t.FrimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "FrimId", "dbo.Firms");
            DropIndex("dbo.Users", new[] { "FrimId" });
            DropIndex("dbo.Firms", new[] { "PackageName" });
            DropTable("dbo.Users");
            DropTable("dbo.Firms");
            DropTable("dbo.Advertisements");
        }
    }
}
