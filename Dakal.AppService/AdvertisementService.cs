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
    public class AdvertisementService : IAdvertisementService
    {
        private IAdvertisementRepository advertisementRepository;
        public AdvertisementService(IAdvertisementRepository _advertisementRepository)
        {
            advertisementRepository = _advertisementRepository;
        }

        public async Task<Advertisement> GetAdvertisement(uint age, Gender gender)
        {
            using (var httpCli = new HttpClient())
            {
                HttpResponseMessage response = await httpCli.GetAsync("http://192.168.1.111:5000/predict/" + (int)gender + "/" + age);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var predictRes = JsonConvert.DeserializeObject<PredictAdvertisementResponse>(responseBody);
                var selectedTag = GetSelectedTag(predictRes);
                return await advertisementRepository.Queryable().
                    Where(x => x.Tags.ToLower().Contains(selectedTag.ToLower())).
                    OrderBy(x => x.Id).
                    Skip(new Random().
                        Next(0, advertisementRepository.
                            Queryable().Where(x => x.Tags.ToLower().
                            Contains(selectedTag.ToLower())).Count())).
                    Take(1).FirstOrDefaultAsync();
            }
        }

        private string GetSelectedTag(PredictAdvertisementResponse predictRes)
        {
            var selectedTag = "";
            Random r = new Random();
            double diceRoll = r.NextDouble();
            double cumulative = 0.0;
            foreach (var prop in (typeof(PredictAdvertisementResponse)).GetProperties())
            {
                cumulative += (int)predictRes.GetType().GetProperty(prop.Name).GetValue(predictRes);
                if (diceRoll < cumulative)
                {
                    selectedTag = prop.Name;
                    break;
                }
            }
            return selectedTag;
        }
    }
}
