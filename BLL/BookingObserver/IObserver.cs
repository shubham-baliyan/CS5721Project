using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BookingObserver
{
    public interface IObserver
    {
        void BookingChanged(BookingModel booking);
    }
}
