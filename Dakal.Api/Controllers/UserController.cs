using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Dakal.Api.ClientReqDto;
using Dakal.Api.ClientResDto;
using Dakal.Api.DTO;
using Dakal.AppService;
using Dakal.Models;
using Dakal.Repositories;

namespace Dakal.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService userService;
        private IAdvertisementService advertisementService;
        private ILoggerService loggerService;
        private IUnitOfWork unitOfWork;
        private ISeenAdsService seenAdsService;
        private IFirmRepository firmRepository;

        public UserController(IUserService _userService,
            IAdvertisementService _advertisementService,
            IUnitOfWork _unitOfWork,
            ILoggerService _logger,
            ISeenAdsService _seenAdsService,
            IFirmRepository _firmRepository
            )
        {
            userService = _userService;
            advertisementService = _advertisementService;
            unitOfWork = _unitOfWork;
            loggerService = _logger;
            seenAdsService = _seenAdsService;
            firmRepository = _firmRepository;
        }

        [HttpPost]
        [Route("GetAdvertisement")]
        public async Task<HttpResponseMessage> GetAdvertisement(GetAdDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user;
                    if (!await userService.IsUserExist(model.username, model.appPackageName))
                    {
                        var firm = await firmRepository.Queryable().FirstOrDefaultAsync(x => x.PackageName == model.appPackageName.ToLower());
                        if (firm == null)
                            return Request.CreateResponse(HttpStatusCode.BadRequest, new ServiceResult()
                            {
                                IsSuccess = false,
                                Message = "The App is not registerd in the system"
                            });
                        user = await userService.CreateUserAndGet(model.username, model.appPackageName, model.age, model.gender, firm.Id);
                        unitOfWork.SaveChanges();
                        if (user == null)
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, "User not created");
                    }
                    else
                        user = await userService.GetUser(model.username, model.appPackageName);
                    var ad = await advertisementService.GetAdvertisement(model.age, model.gender);
                    if (ad != null)
                    {
                        await seenAdsService.AdSentToUser(user.Id, ad.Id);
                        unitOfWork.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, new ServiceResult()
                        {
                            IsSuccess = true,
                            Result = ad
                        });
                    }

                }
                catch (Exception e)
                {
                    loggerService.WriteLogToText(e);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "The Sent Parameter Is Not Correct");
        }


        [HttpPost]
        [Route("UserCompletedSeeingAd")]
        public async Task<HttpResponseMessage> UserCompletedSeeingAd(UserCompletedSeeingAd model)
        {
            if (ModelState.IsValid)
            {
                if (!await userService.IsUserExist(model.username, model.appPackageName))
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The User Not Found");
                var seenAdId = await seenAdsService.getSeenAdId(model.username, model.adId);
                if (seenAdId < 1)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The SeenAd Not Found");
                var res = await seenAdsService.AdSeenCompleted(seenAdId);
                if (res)
                    return Request.CreateResponse(HttpStatusCode.OK, new ServiceResult() { IsSuccess = true });
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new ServiceResult() { IsSuccess = false });
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "The Sent Parameter Is Not Correct");
        }
    }
}
