using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.BookingCommand
{
    public interface ICommand
    {
         (bool,string) Execute(BookingModel bookingModel);
    }
}
