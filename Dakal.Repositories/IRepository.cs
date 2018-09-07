using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Queryable();
        Task<T> GetById(long id);
        Task<T> Insert(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(long id);
    }
}
