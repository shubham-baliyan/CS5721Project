using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL.Interfaces;
using BLL.ServiceClass;

namespace BLL.BookingCommand
{
    public class CheckMembership : ICommand
    {
        private readonly ICustomer _iCustomer = new Customer();
        (bool, string) ICommand.Execute(BookingModel bookingModel)
        {
            
            bool isValidMembership = _iCustomer.CheckMembershipValid(bookingModel.UserId, bookingModel.SlotId);
            if(isValidMembership)
            {
               return (true, null);
            }
            else
            {
                return (false, null);
            }
        }
    }
}