﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interfaces
{
    public interface IVerification
    {
        bool isVerified(UserModel user);

        void verify(UserModel user);

    }
}
