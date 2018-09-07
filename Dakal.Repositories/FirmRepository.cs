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
        private DbSet<Firm> context;
        private IUnitOfWork unitOfWork;

        public FirmRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            context = unitOfWork.FirmRepository();
        }

        public async Task<bool> Delete(long id)
        {
            var firm = await context.FirstOrDefaultAsync(x => x.Id == id);
            if (firm == null)
                return false;
            context.Remove(firm);
            return true;
        }

        public IQueryable<Firm> Queryable()
        {
            return context;
        }

        public async Task<Firm> GetById(long id)
        {
            var res = await context.FindAsync(id);
            return res;
        }

        public async Task<Firm> Insert(Firm obj)
        {
            return context.Add(obj);
        }

        public async Task<bool> Update(Firm obj)
        {
            if (obj.Id < 1)
                return false;
            var repFirm = await context.FindAsync(obj.Id);
            if (repFirm == null)
                return false;
            context.AddOrUpdate(obj);
            return true;
        }
    }
}
