using BusinessLogicLayer.Repository;
using BusinessObjects.Entities;
using MerchantDistributorService_API.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MerchantDistributorService_API.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository _userRepository;
        public UserController()
        {
            this._userRepository = new UserRepository(); ;
        }
        [HttpPost]
        public HttpResponseMessage AuthenticateUser([FromBody]User request)
        {
            try
            {
                if (_userRepository.IsUserValid(request))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Verified");
                    //AuthenticationRepository authRepo = new AuthenticationRepository();
                    //authRepo.GenerateTokenForUser(request.MobileNumber, 12);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "NotVerified");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                HttpError httpError = new HttpError(ex, true) { { "IsSuccess", false } };
                return Request.CreateErrorResponse(HttpStatusCode.OK, httpError);
            }
        }

        [HttpPost]
        public HttpResponseMessage RegisterUser([FromBody]Registration request) {
            try
            {
                //request.Password = CryptographyHelper.Encrypt(request.Password);
                var response = _userRepository.RegisterUser(request);
                if (response == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Mobile exists");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Registerd id {response}");
                }
                
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                HttpError httpError = new HttpError(ex, true) { { "IsSuccess", false } };
                return Request.CreateResponse(HttpStatusCode.OK, httpError);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateAddressDetails([FromBody]AddressDetails request)
        {
            try
            {
                var response = _userRepository.UpdateAddressDetails(request);
                if (response == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Updated {request.UserId}");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Ambiguous, $"Updated {request.UserId}");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                HttpError httpError = new HttpError(ex, true) { { "IsSuccess", false } };
                return Request.CreateResponse(HttpStatusCode.OK, httpError);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateCompanyDetails([FromBody]CompanyDetails request)
        {
            try
            {
                var response = _userRepository.UpdateCompanyDetails(request);
                if (response == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Updated {request.UserId}");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Ambiguous, $"Failed {request.UserId}");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                HttpError httpError = new HttpError(ex, true) { { "IsSuccess", false } };
                return Request.CreateResponse(HttpStatusCode.OK, httpError);
            }
        }
    }
}
