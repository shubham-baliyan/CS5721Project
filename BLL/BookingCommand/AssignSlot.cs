using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL.BookingObserver;
using BLL.Interfaces;
using BLL.ArenaFactory;
using BLL.MembershipFactory;
using BLL.ServiceClass;
using DAL;

namespace BLL.BookingCommand
{
    public class AssignSlot : ICommand
    {
        private readonly IArenaTypeFactory _iArenaTypeFactory = new ArenaTypeFactory();
        private readonly ISubject _iSubject = new Subject();
        private readonly IBooking _iBooking = new BookSlot();
        (bool,string) ICommand.Execute(BookingModel bookingModel)
        {
            string message = null;
            IArena iarena = _iArenaTypeFactory.GetArena(bookingModel.ArenaId);
            IObserver arenaObserver;
            
            if (iarena is Gym)
            {
                arenaObserver = new Gym();
            }
            else
            {
                arenaObserver = new Pool();
            }
            _iSubject.Attach(arenaObserver);
            if (bookingModel.BookingId != 0)
            {
                message = _iBooking.UpdateBooking(bookingModel);
            }
            else
            {
                message = _iBooking.CreateBooking(bookingModel);
            }
            _iSubject.Detach(arenaObserver);
            return (true, message);
        }
    }
}