using BLL.BookingObserver;
using BLL.Interfaces;
using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class BookSlot : Subject, IBooking
    {
        private BookingDAL _bookingDAL = new BookingDAL();
        public BookSlot()
        {
          
        }


        public string CreateBooking(BookingModel bookingModel)
        {
            string response = _bookingDAL.CreateBooking(bookingModel);
            if(response == null)
            {
                Notify(bookingModel);
            }
            return response;
        }

        public string UpdateBooking(BookingModel bookingModel)
        {
            var response = _bookingDAL.UpdateBooking(bookingModel);
            if (response == null)
            {
                Notify(bookingModel);
            }
            return response;
        }
        public string CancelBooking(int bookingId)
        {
            return _bookingDAL.CancelBooking(bookingId);
        }
        public List<BookingModel> GetUpcomingBookings(int userId, int arenaId)
        {
            return _bookingDAL.GetUpcomingBookings(userId, arenaId);
        }
        public BookingModel GetBooking(int bookingId)
        {
            return _bookingDAL.GetBooking(bookingId);
        }
    }
}