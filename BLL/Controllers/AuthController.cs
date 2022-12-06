using BLL.RegistrationVerificationFacade;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BLL.Controllers
{
    public class AuthController : ApiController
    {
        private ILogin _login;  // facaded interface object  

        public AuthController(ILogin iLogin)
        {
            _login = iLogin;
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("Auth/Login")]
        public HttpResponseMessage UserLogin([FromBody] LoginModel login)
        {
            try
            {
                (string,int) res = _login.userLogin(login);
                var message = Request.CreateResponse(HttpStatusCode.Created, res);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}