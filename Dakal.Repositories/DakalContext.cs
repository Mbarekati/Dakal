using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.Repositories
{
    public class DakalContext : DbContext
    {
        public DakalContext() : base("Data Source=DESKTOP-NEI9004;Integrated Security=True;Trusted_Connection=True;Database=DakalDatabase;")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<SeenAds> SeenAds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
