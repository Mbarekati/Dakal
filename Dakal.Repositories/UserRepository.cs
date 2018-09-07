using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> context;
        private IUnitOfWork unitOfWork;
        public UserRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            context = unitOfWork.UserRepository();
        }

        public async Task<bool> Delete(long id)
        {
            var user = await context.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return false;
            context.Remove(user);
            return true;
        }

        public IQueryable<User> Queryable()
        {
            return context;
        }

        public async Task<User> GetById(long id)
        {
            var res = await context.FindAsync(id);
            return res;
        }

        public async Task<User> Insert(User obj)
        {
            var repUser = await context.FindAsync(obj.Id);
            if (repUser != null)
                return null;
            obj.Id = 1;
            var u = context.Add(obj);
            return u;
        }

        public async Task<bool> Update(User obj)
        {
            if (obj.Id < 1)
                return false;
            var repUser = await context.FindAsync(obj.Id);
            if (repUser == null)
                return false;
            context.AddOrUpdate(obj);
            return true;
        }
    }
}