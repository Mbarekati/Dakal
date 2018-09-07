using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.Repositories
{
    public interface IUnitOfWork
    {
        DakalContext GetDakalContext();
        void SaveChanges();
    }
}
