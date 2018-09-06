using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Dakal.Api.ClientReqDto;
using Dakal.Api.ClientResDto;
using Dakal.AppService;
using Dakal.Models;

namespace Dakal.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserService userService;
        private IAdvertisementService advertisementService;
        //private ILoggerService loggerService;

        public UserController(IUserService _userService, IAdvertisementService _advertisementService, ILoggerService _logger)
        {
            userService = _userService;
            advertisementService = _advertisementService;
            //loggerService = _logger;
        }
        public async Task<HttpResponseMessage> GetAdvertisement(cli_GetAdDTO model)
        {
            try
            {
                ServiceResult result;
                if (string.IsNullOrEmpty(model.username) || model.age < 10 || model.age > 130 ||
                    String.IsNullOrEmpty(model.appPackageName))
                {
                    result = new ServiceResult()
                    {
                        IsSuccess = false,
                        Message = "Bad Argument",
                        Result = null
                    };
                    Request.CreateResponse(HttpStatusCode.OK, result);
                }
                if (!await userService.IsUserExist(model.username, model.appPackageName))
                {
                    //model state of user must be corrected------------------------------
                    var userAddRes = await userService.CreateUser(model);
                    if (!userAddRes)
                        Request.CreateResponse(HttpStatusCode.InternalServerError, "User not created");
                }
                var res = await advertisementService.GetAdvertisement(model.age, model.gender);
                result = new ServiceResult()
                {
                    IsSuccess = true,
                    Result = Json(res)
                };
                Request.CreateResponse(HttpStatusCode.OK, result); 
            }
            catch (Exception e)
            {
                //ExceptionLogger.Log(e);
                Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }
    }
}
