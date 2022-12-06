using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces


namespace BLL.ServiceClass
{
    public class ArenaTypeFactory:IArenaTypeFactory
    {
        private readonly ArenaDal _arena = new ArenaDal();
        public IArenaTypeFactory GetArenaTypeFactory(string type)

        {
            IArenaTypeFactory instance = null;
            if (type === "pool")
            {
                instance = new Pool()
            }else if (type === "gym")
            {
                instance = new Gym()
            }

            return instance;
        }

    }
}