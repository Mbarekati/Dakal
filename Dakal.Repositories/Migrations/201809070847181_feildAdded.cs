namespace Dakal.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feildAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Tags", x => x.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Tags");
        }
    }
}
