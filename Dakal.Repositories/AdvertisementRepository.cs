using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private DbSet<Advertisement> context;
        private IUnitOfWork unitOfWork;
        public AdvertisementRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            context = unitOfWork.AdvertisementRepository();
        }

        public async Task<bool> Delete(long id)
        {
            var ad = await context.FirstOrDefaultAsync(x => x.Id == id);
            if (ad == null)
                return false;
            context.Remove(ad);
            return true;
        }

        public IQueryable<Advertisement> Queryable()
        {
            return context;
        }

        public async Task<Advertisement> GetById(long id)
        {
            var res = await context.FindAsync(id);
            return res;
        }

        public async Task<Advertisement> Insert(Advertisement obj)
        {
            return context.Add(obj);
        }

        public async Task<bool> Update(Advertisement obj)
        {
            if (obj.Id < 1)
                return false;
            var repad = await context.FindAsync(obj.Id);
            if (repad == null)
                return false;
            context.AddOrUpdate(obj);
            return true;
        }
    }
}

