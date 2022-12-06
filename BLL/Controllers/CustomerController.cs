using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.ServiceClass;
using BLL.Interfaces;
using Model;
using BLL.RegistrationVerificationFacade;
using BLL.MemFeeDiscountDecorator;
using BLL.MembershipFactory;
using BLL.ArenaFactory;
using BLL.BookingObserver;
using BLL.BookingCommand;

namespace BLL.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IArenaTypeFactory _iArenaTypeFactory;
        private readonly ICustomer _iCustomer;
        private readonly IBooking _iBooking;
        private readonly ISubject _iSubject;
        private readonly IMembershipTypeFactory _iMembershipTypeFactory;
        public CustomerController(IArenaTypeFactory iArenaTypeFactory,ICustomer iCustomer,IBooking iBooking,
            IMembershipTypeFactory iMembershipTypeFactory)
        { 
            _iArenaTypeFactory = iArenaTypeFactory;
            _iCustomer = iCustomer;
            _iBooking = iBooking;
            _iMembershipTypeFactory = iMembershipTypeFactory;
        }



        /// <summary>
        /// Register Customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("customer/register")]
        public HttpResponseMessage RegisterCustomer([FromBody]CustomerModel customerModel)
        {
            customerModel.UserType = "Customer";
            var response = _iCustomer.RegisterCustomer(customerModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("customer/update")]
        public HttpResponseMessage UpdateCustomer([FromBody] ViewCustomerModel customerModel)
        {
            var response = _iCustomer.UpdateCustomer(customerModel);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        /// <summary>
        /// Get customer details
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(CustomerModel))]
        [Route("customer/{customerId}")]
        public HttpResponseMessage GetCustomer(int userId)
        {
           // var response = _iUserContext.ContextViewCustomer(userId);
            var response = _iCustomer.GetCustomerDetails(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        /// <summary>
        /// Get Booking dates
        /// </summary>
        /// <param name="arenaId"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(List<DateTime>))]
        [Route("customer/get-booking-dates/{arenaId}")]
        public HttpResponseMessage GetBookingDates(int arenaId)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(arenaId);
            var dates = iarena.GetDatesWithSlots();
            return Request.CreateResponse(HttpStatusCode.OK, dates);
        }

        /// <summary>
        /// Get Booking slots
        /// </summary>
        /// <param name="date"></param>
        /// <param name="arenaId"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpPost]
        [ResponseType(typeof(List<SlotModel>))]
        [Route("customer/get-booking-slots")]
        public HttpResponseMessage GetBookingSlotsforDates([FromBody]DateTime date,int arenaId)
        {
            IArena iarena = _iArenaTypeFactory.GetArena(arenaId);
            var slots = iarena.GetSlots(date);
            return Request.CreateResponse(HttpStatusCode.OK, slots);
        }

        /// <summary>
        /// Book slots
        /// </summary>
        /// <param name="bookingModel"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpPost]
        [ResponseType(typeof((bool,string)))]
        [Route("customer/book-slots")]

        public HttpResponseMessage BookSlots([FromBody] BookingModel bookingModel)
        {
            ICommand command = new CompositeCommand();
            (bool,string) bookingConfirmed = command.Execute(bookingModel);
            return Request.CreateResponse(HttpStatusCode.OK, bookingConfirmed);
        }


        /// <summary>
        /// Update Booking
        /// </summary>
        /// <param name="bookingModel"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("customer/update-booking")]
        public HttpResponseMessage UpdateBooking(BookingModel bookingModel)
        {
            ICommand command = new CompositeCommand();
            (bool,string) bookingUpdated = command.Execute(bookingModel);
            return Request.CreateResponse(HttpStatusCode.OK, bookingUpdated);
        }
        /// <summary>
        /// Get all upcoming bookings
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="arenaId"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(List<BookingModel>))]
        [Route("customer/get-upcoming-bookings")]
        public HttpResponseMessage GetUpcomingBookings(int userId, int arenaId)
        {
            var response = _iBooking.GetUpcomingBookings(userId, arenaId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Get Booking 
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        
        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(BookingModel))]
        [Route("customer/get-booking")]
        public HttpResponseMessage GetBooking(int bookingId)
        {
            var response = _iBooking.GetBooking(bookingId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Get Membership Fees
        /// </summary>
        /// <param name="customerTypeId"></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(int))]
        [Route("customers/{customerTypeId}/membershipFees")]
        public HttpResponseMessage GetMembershipFees(int customerTypeId)
        {
            int membershipFees;
            IMembership iMembershiptype = _iMembershipTypeFactory.GetMembershipType(customerTypeId);
            if (iMembershiptype is Student)
            {
                MembershipDiscountDecorator membershipDecorator = new StudentMemDiscountDecorator(iMembershiptype);
                membershipFees = membershipDecorator.GetMembershipFees();
            }
            else
            {
                membershipFees = iMembershiptype.GetMembershipFees();
            }
            return Request.CreateResponse(HttpStatusCode.OK, membershipFees);

        }

        /// <summary>
        /// Get Membership types
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(List<MembershipTypeModel>))]
        [Route("customers/get-membership-types")]
        public HttpResponseMessage getMembershipTypes()
        {
            Common _common = new Common();
            var response = _common.GetMembershipTypes();
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        /// <summary>
        /// Buy Membership
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        [Authenticate]
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("customers/buy-membership")]
        public HttpResponseMessage BuyMembership(int userId)
        {
            var response = _iCustomer.BuyMembership(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }


    }
}

