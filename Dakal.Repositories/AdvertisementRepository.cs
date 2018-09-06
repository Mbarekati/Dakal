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
        private DakalContext context;
        public AdvertisementRepository(DakalContext _context)
        {
            context = _context;
        }

        public async Task<bool> Delete(uint id)
        {
            var ad = await context.Advertisements.FirstOrDefaultAsync(x => x.Id == id);
            if (ad == null)
                return false;
            context.Advertisements.Remove(ad);
            return true;
        }

        public IQueryable<Advertisement> Queryable()
        {
            return context.Advertisements;
        }

        public async Task<Advertisement> GetById(uint id)
        {
            var res = await context.Advertisements.FindAsync(id);
            return res;
        }

        public async Task<bool> Insert(Advertisement obj)
        {
            if (obj.Id < 1)
                return false;
            var repad = await context.Advertisements.FindAsync(obj.Id);
            if (repad != null)
                return false;
            context.Advertisements.Add(obj);
            return true;
        }

        public async Task<bool> Update(Advertisement obj)
        {
            if (obj.Id < 1)
                return false;
            var repad = await context.Advertisements.FindAsync(obj.Id);
            if (repad == null)
                return false;
            context.Advertisements.AddOrUpdate(obj);
            return true;
        }
    }
}

