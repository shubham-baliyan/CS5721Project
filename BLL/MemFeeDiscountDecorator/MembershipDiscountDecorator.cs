using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.MemFeeDiscountDecorator
{
    public abstract class MembershipDiscountDecorator: IMembership
    {
        private IMembership _iMembershipType;
        public MembershipDiscountDecorator(IMembership iMembershipType)
        {
            this._iMembershipType = iMembershipType;
        }
        public virtual int GetMembershipFees()
        {
            return this._iMembershipType.GetMembershipFees();
        }
        
    }
}