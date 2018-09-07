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
    public class SeenAdsRepository : ISeenAdsRepository
    {

        private DbSet<SeenAds> context;
        private IUnitOfWork unitOfWork;
        public SeenAdsRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            context = unitOfWork.SeenAdsRepository();
        }

        public async Task<bool> Delete(long id)
        {
            var ad = await context.FirstOrDefaultAsync(x => x.Id == id);
            if (ad == null)
                return false;
            context.Remove(ad);
            return true;
        }

        public IQueryable<SeenAds> Queryable()
        {
            return context;
        }

        public async Task<SeenAds> GetById(long id)
        {
            var res = await context.FindAsync(id);
            return res;
        }

        public async Task<SeenAds> Insert(SeenAds obj)
        {
            return context.Add(obj);
        }

        public async Task<bool> Update(SeenAds obj)
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
