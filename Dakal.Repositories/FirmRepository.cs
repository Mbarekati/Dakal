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
    public class FirmRepository : Repository<Firm>, IFirmRepository
    {
        public FirmRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
