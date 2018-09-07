namespace Dakal.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "FrimId", newName: "FirmId");
            RenameIndex(table: "dbo.Users", name: "IX_FrimId", newName: "IX_FirmId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_FirmId", newName: "IX_FrimId");
            RenameColumn(table: "dbo.Users", name: "FirmId", newName: "FrimId");
        }
    }
}
