using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.ServiceClass.Tests
{
    [TestClass()]
    public class BookSlotTests
    {
        BookSlot testSlot = new BookSlot();
        BookingModel testBooking = new BookingModel();

        [TestMethod()]
        public void CreateBookingTest()
        {
            testBooking.BookingId = 1;
            testBooking.UserId = 1;
            testBooking.ArenaId = 1;
            testBooking.ArenaName = "Gym";
            testBooking.SlotId = 1;
            testBooking.SlotDate = new DateTime();
            testBooking.CreatedOn = new DateTime();
            testBooking.SlotStartTime = new TimeSpan();
            testBooking.SlotEndTime = new TimeSpan();

            testSlot.CreateBooking(testBooking);
        }
    }
}