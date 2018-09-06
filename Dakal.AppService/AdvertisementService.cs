using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.AppService
{
    public class AdvertisementService : IAdvertisementService
    {
        public Task<Advertisement> GetAdvertisement(uint age, Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
