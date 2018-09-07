namespace Dakal.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dakal.Repositories.DakalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Dakal.Repositories.DakalContext";
        }

        protected override void Seed(Dakal.Repositories.DakalContext context)
        {
            
        }
    }
}
