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
        private DakalContext context;
        public UserRepository(DakalContext _context)
        {
            context = _context;
        }

        public async Task<bool> Delete(uint id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return false;
                context.Users.Remove(user);
            return true;
        }

        public IQueryable<User> Queryable()
        {
            return context.Users;
        }

        public async Task<User> GetById(uint id)
        {
            var res = await context.Users.FindAsync(id);
            return res;
        }

        public async Task<bool> Insert(User obj)
        {
            if (obj.Id < 1)
                return false;
            var repUser = await context.Users.FindAsync(obj.Id);
            if (repUser != null)
                return false;
            context.Users.Add(obj);
            return true;
        }

        public async Task<bool> Update(User obj)
        {
            if (obj.Id < 1)
                return false;
            var repUser = await context.Users.FindAsync(obj.Id);
            if (repUser == null)
                return false;
            context.Users.AddOrUpdate(obj);
            return true;
        }
    }
}