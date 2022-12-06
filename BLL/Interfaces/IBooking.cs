using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBooking
    {
        string CreateBooking(BookingModel bookingModel);
        string UpdateBooking(BookingModel bookingModel);
        string CancelBooking(int bookingId);
        List<BookingModel> GetUpcomingBookings(int userId, int arenaId);
        BookingModel GetBooking(int bookingId);

    }
}
