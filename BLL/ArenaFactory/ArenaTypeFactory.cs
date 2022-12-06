using BLL.Interfaces;
using BLL.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ArenaFactory
{
    public class ArenaTypeFactory: IArenaTypeFactory
    {
        public ArenaTypeFactory()
        {

        }
        public IArena GetArena(int arenaId)
        {
            IArena returnValue = null;
            if (arenaId == 1)
            {
                returnValue = new Gym();
            }
            else if (arenaId == 2)
            {
                returnValue = new Pool();
            }
            return returnValue;

        }
    }
}