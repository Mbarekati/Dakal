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
    public class FirmRepository : IFirmRepository
    {
        private DakalContext context;
        public FirmRepository(DakalContext _context)
        {
            context = _context;
        }

        public async Task<bool> Delete(uint id)
        {
            var firm = await context.Firms.FirstOrDefaultAsync(x => x.Id == id);
            if (firm == null)
                return false;
            context.Firms.Remove(firm);
            return true;
        }

        public IQueryable<Firm> Queryable()
        {
            return context.Firms;
        }

        public async Task<Firm> GetById(uint id)
        {
            var res = await context.Firms.FindAsync(id);
            return res;
        }

        public async Task<bool> Insert(Firm obj)
        {
            if (obj.Id < 1)
                return false;
            var repFirm = await context.Firms.FindAsync(obj.Id);
            if (repFirm != null)
                return false;
            context.Firms.Add(repFirm);
            return true;
        }

        public async Task<bool> Update(Firm obj)
        {
            if (obj.Id < 1)
                return false;
            var repFirm = await context.Firms.FindAsync(obj.Id);
            if (repFirm == null)
                return false;
            context.Firms.AddOrUpdate(obj);
            return true;
        }
    }
}   
