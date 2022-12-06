using BLL.ArenaFactory;
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
    public class StaffController : ApiController
    {

        private IArena _iArena;
        private readonly IStaff _iStaff;
        private readonly ICustomer _iCustomer;
        private readonly IArenaTypeFactory _iArenaTypeFactory;

        public StaffController(IArena iArena, IStaff iStaff, ICustomer iCustomer, IArenaTypeFactory iArenaFactory)
        {
           // _iUserContext = iUserContext;
            _iArena = iArena;
            _iStaff = iStaff;
            _iCustomer = iCustomer;
            _iArenaTypeFactory = iArenaFactory;
        }

        /// <summary>
        /// Update Staff Details
        /// </summary>
        /// <param name="staffModel"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ResponseType(typeof(String))]
        [Route("staff/update")]
        public HttpResponseMessage UpdateDetails([FromBody] ViewStaffModel staffModel)
        {
            var response = _iStaff.UpdateStaffDetails(staffModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Get Staff Details
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Admin")]
        [HttpGet]
        [ResponseType(typeof(ViewStaffModel))]
        [Route("staff/{userId}")]
        public HttpResponseMessage GetDetails(int userId)
        {
            var response = _iStaff.GetStaffDetails(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("staff/customer/{userId}/remove")]
        public HttpResponseMessage DeleteCustomer(int userId)
        {
            var response = _iCustomer.DeleteCustomer(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Get all active customers
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("staff/customer/get-all-customers")]
        public HttpResponseMessage GetAllCustomer()
        {
            var response = _iCustomer.GetAllCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Create slots
        /// </summary>
        /// <param name= "createSlotModel"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        
        [HttpPost]
        [ResponseType(typeof(List<SlotModel>))]
        [Route("staff/create-slots")]
        public HttpResponseMessage CreateSlots([FromBody]CreateSlotModel createSlotModel)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(createSlotModel.ArenaId);
            var response = iarena.CreateSlots(createSlotModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Add slots
        /// </summary>
        /// <param name="slotList"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        //[MyAuthorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(List<SlotModel>))]
        [Route("staff/add-slots")]

        public HttpResponseMessage AddSlots([FromBody] List<SlotModel> slotList)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(slotList[0].ArenaId);
            var res = iarena.CheckCapacity(slotList);
            if (res != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            else
            {
                var response = iarena.AddSlots(slotList);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
           
        }

        /// <summary>
        /// Update slots
        /// </summary>
        /// <param name="slotList"></param>
        /// <returns></returns>

        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("staff/update-slots")]
        public HttpResponseMessage UpdateSlots([FromBody] List<SlotModel> slotList)
        {
            _iArena = _iArenaTypeFactory.GetArena(slotList[0].ArenaId);
            var res = _iArena.CheckCapacity(slotList);
            if (res != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            else
            {
                var response = _iArena.UpdateSlots(slotList);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
        }

        /// <summary>
        /// Delete slots
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// 
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("staff/delete-slots")]
        public HttpResponseMessage DeleteSlots(int arenaId, DateTime date)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(arenaId);
            var response = iarena.DeleteSlots(date);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// get upcoming slots
        /// </summary>
        /// <param name="arenaId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("staff/{arenaId}/get-upcoming-slots")]
        public HttpResponseMessage GetAllUpcomingSlots(int arenaId)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(arenaId);
            var response = iarena.GetUpcomingSlots();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// get slots
        /// </summary>
        /// <param name="date"></param>
        /// <param name="arenaId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [MyAuthorize(Roles = "Staff,Admin")]
        [HttpGet]
        [ResponseType(typeof(List<SlotModel>))]
        [Route("staff/{arenaId}/get-slots")]
        public HttpResponseMessage GetSlots(DateTime date, int arenaId)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(arenaId);
            var response = iarena.GetSlotsForDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }






    }
}
