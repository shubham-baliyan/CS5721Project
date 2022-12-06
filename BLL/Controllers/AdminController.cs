using BLL.Interfaces;
using BLL.ServiceClass;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BLL.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdmin _iAdmin;
        private readonly IStaff _iStaff;
        private readonly ICustomer _iCustomer;
        private IArena _iArena;

        public AdminController(IAdmin iAdmin,IStaff iStaff, ICustomer iCustomer, IArena iArena)
        {
            _iAdmin = iAdmin;
            _iStaff = iStaff;
            _iCustomer = iCustomer;
            _iArena = iArena;
        }


        /// <summary>
        /// Get Admin details
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpGet]
        [ResponseType(typeof(UserModel))]
        [Route("admin/get")]
        public HttpResponseMessage GetDetails()
        {
            var response = _iAdmin.GetAdminDetails();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Update Admin Details
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("admin/update")]
        public HttpResponseMessage UpdateDetails([FromBody]UserModel userModel)
        {
            var response = _iAdmin.UpdateAdminDetails(userModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Register staff
        /// </summary>
        /// <param name="staffModel"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(String))]
        [Route("admin/staff/register")]
        public HttpResponseMessage RegisterStaff([FromBody] StaffModel staffModel)
        {
            var response = _iStaff.RegisterStaff(staffModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Delete Staff
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("admin/staff/{userId}/remove")]

        public HttpResponseMessage DeleteStaff(int userId)
        {
            var response = _iStaff.DeleteStaff(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Get All Staffs
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpGet]
        [ResponseType(typeof(ViewStaffModel))]
        [Route("admin/staff/get-all-staffs")]
        public HttpResponseMessage GetAllStaffs()
        {
            var response = _iStaff.GetAllStaffs();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

       

    }
}
