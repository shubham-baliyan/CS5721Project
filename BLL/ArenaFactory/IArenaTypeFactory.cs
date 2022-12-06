using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ArenaFactory
{
    public interface IArenaTypeFactory
    {
        IArena GetArena(int arenaId);
    }
}
