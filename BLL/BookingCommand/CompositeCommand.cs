using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace BLL.BookingCommand
{
    public class CompositeCommand : ICommand
    {
        ICommand checkMembership = new CheckMembership();
        ICommand checkSlotAvailablity = new CheckSlotAvailaibility();
        ICommand assignSlot = new AssignSlot();

        (bool,string) ICommand.Execute(BookingModel bookingModel)
        {
          (bool,string) membershipStatus = checkMembership.Execute(bookingModel);
          if(membershipStatus.Item1)
            {
                (bool,string) isSlotAvailable = checkSlotAvailablity.Execute(bookingModel);
                if(isSlotAvailable.Item1)
                {
                    (bool,string) slotBooked = assignSlot.Execute(bookingModel);
                    return (slotBooked.Item1, slotBooked.Item2);
                }
            }
            return (false, "Not able to execute. Please try again!");
        }
    }
}