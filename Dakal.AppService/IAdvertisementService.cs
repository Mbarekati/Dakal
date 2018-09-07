using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.AppService
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdvertisement(uint age, Gender gender);
        IEnumerable<Advertisement> GetAdvertisement();
    }
}
