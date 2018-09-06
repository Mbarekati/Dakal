using System;
using Dakal.Models;

namespace Dakal.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private DakalContext context = null;
        public UnitOfWork()
        {
            context = new DakalContext();
        }

        IRepository<User> userRepository = null;
        IRepository<Advertisement> advertisementRepository = null;
        IRepository<Firm> firmRepository = null;
        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IRepository<Advertisement> AdvertisementRepository
        {
            get
            {
                if (advertisementRepository == null)
                {
                    advertisementRepository = new AdvertisementRepository(context);
                }
                return advertisementRepository;
            }
        }

        public IRepository<Firm> FirmRepository
        {
            get
            {
                if (firmRepository == null)
                {
                    firmRepository = new FirmRepository(context);
                }
                return firmRepository;
            }
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

    }
}