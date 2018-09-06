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
        internal DakalContext() : base("DakalDB")
        {
        }

        internal DbSet<User> Users { get; set; }
        internal DbSet<Advertisement> Advertisements { get; set; }
        internal DbSet<Firm> Firms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
