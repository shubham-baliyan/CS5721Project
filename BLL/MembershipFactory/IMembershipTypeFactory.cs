﻿using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MembershipFactory
{
    public interface IMembershipTypeFactory
    {
        IMembership GetMembershipType(int membershipTypeId);
    }
}
