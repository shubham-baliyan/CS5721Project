using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ArenaFactory;
using BLL.Interfaces;
using Model;

namespace BLL.BookingCommand
{
    public class CheckSlotAvailaibility : ICommand
    {
        private readonly IArenaTypeFactory _iArenaTypeFactory = new ArenaTypeFactory();

        (bool,string) ICommand.Execute(BookingModel bookingModel)
        {
            bool availableCapacity = false;
            IArena iarena = _iArenaTypeFactory.GetArena(bookingModel.ArenaId);
            int capacity = iarena.GetSlotCapacity(bookingModel.SlotId);
            if(capacity>0)
            {
                availableCapacity = true;
            }

            return (availableCapacity, null);
        }

    }
}