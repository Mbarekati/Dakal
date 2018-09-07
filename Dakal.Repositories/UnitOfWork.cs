using System;
using System.Data.Entity;
using Dakal.Models;
using Dakal.Repositories.Migrations;

namespace Dakal.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DakalContext context = null;
        public UnitOfWork()
        {
            context = new DakalContext();
        }
     
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DbSet<User> UserRepository()
        {      
            return context.Users;
        }

        public DbSet<Advertisement> AdvertisementRepository()
        {
            return context.Advertisements;
        }

        public DbSet<Firm> FirmRepository()
        {
            return context.Firms;
        }

        public DbSet<SeenAds> SeenAdsRepository()
        {
            return context.SeenAds;
        }
    }
}