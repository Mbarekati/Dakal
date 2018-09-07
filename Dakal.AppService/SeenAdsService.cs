using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dakal.AppService.DTO;
using Dakal.Models;
using Dakal.Repositories;
using Newtonsoft.Json;

namespace Dakal.AppService
{
    public class SeenAdsService : ISeenAdsService
    {
        private ISeenAdsRepository seenAdsRepository;
        public SeenAdsService(ISeenAdsRepository _seenAdsRepository)
        {
            seenAdsRepository = _seenAdsRepository;
        }

        public async Task<bool> AdSeenCompleted(long seenAdId)
        {
            var seenAd = await seenAdsRepository.GetById(seenAdId);
            if (seenAd != null)
            {
                seenAd.UserCompletedAction = true;
                return true;
            }
            return false;
        }

        public async Task<SeenAds> AdSentToUser(long userId, long adId)
        {
            if (userId < 1 || adId < 1)
                throw new ArgumentException("arguments must be posetive");
            var ad = await seenAdsRepository.Insert(new SeenAds()
            {
                AdId = adId,
                UserId = userId,
                UserCompletedAction = false
            });
            return ad;
        }

        public async Task<long> getSeenAdId(string username, long adId)
        {
            var res = await seenAdsRepository.Queryable().
                FirstOrDefaultAsync(x => x.User.Username == username.ToLower() && x.AdId == adId);
            if (res != null)
                return res.Id;
            return -1;
        }
    }
}
