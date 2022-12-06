using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.BookingObserver
{
    public class Subject: ISubject
    {
        #region ISubject Members  

         static List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify(BookingModel booking)
        {
            _observers.ToList().ForEach(o => o.BookingChanged(booking));
        }

        #endregion
    }
}