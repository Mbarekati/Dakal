using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.AppService
{
    public interface ISeenAdsService
    {
        Task<bool> AdSeenCompleted(long seenAdId);
        Task<SeenAds> AdSentToUser(long userId, long adId);
        Task<long> getSeenAdId(string username, long adId);
    }
}
