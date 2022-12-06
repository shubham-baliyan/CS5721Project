using BLL.Interfaces;
using DAL.DALClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class General: IMembership
    {
        private MembershipDAL _membershipDAL;
        public General(MembershipDAL membershipDAL)
        {
            _membershipDAL = membershipDAL;
        }
        public int GetMembershipFees()
        {
            int membershipTypeId = 2;
            var membershipDetails = _membershipDAL.GetMembershipDetails(membershipTypeId); 
            return membershipDetails.MembershipFees;

        }
    }
}