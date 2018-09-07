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
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public DbSet<T> context;
        private IUnitOfWork unitOfWork;

        public Repository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            context = unitOfWork.GetDakalContext().Set<T>();
        }

        public async Task<bool> Delete(long id)
        {
            var firm = await context.FirstOrDefaultAsync(x => x.Id == id);
            if (firm == null)
                return false;
            context.Remove(firm);
            return true;
        }

        public IQueryable<T> Queryable()
        {
            return context;
        }

        public async Task<T> GetById(long id)
        {
            var res = await context.FindAsync(id);
            return res;
        }

        public async Task<T> Insert(T obj)
        {
            return context.Add(obj);
        }

        public async Task<bool> Update(T obj)
        {
            if (obj.Id < 1)
                return false;
            var repFirm = await context.FindAsync(obj.Id);
            if (repFirm == null)
                return false;
            context.AddOrUpdate<T>(obj);
            return true;
        }
    }
}
