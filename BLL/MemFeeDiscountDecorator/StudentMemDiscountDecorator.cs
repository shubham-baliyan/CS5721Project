using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.MemFeeDiscountDecorator
{
    public class StudentMemDiscountDecorator: MembershipDiscountDecorator
    {
        public StudentMemDiscountDecorator(IMembership iMembershipType)
   : base(iMembershipType)
        {

        }
        public override int GetMembershipFees()
        {
            double a = MembershipDiscount();
            int b = base.GetMembershipFees();
            return Convert.ToInt32(base.GetMembershipFees() * MembershipDiscount());
        }
        private double MembershipDiscount()
        {
            return 40 / 100.0;
        }
    }
}