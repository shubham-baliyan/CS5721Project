using BLL.Interfaces;
using DAL.DALClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class Student: IMembership
    {
        private readonly MembershipDAL _membershipDAL;
        public Student(MembershipDAL membershipDAL)
        {
            _membershipDAL = membershipDAL;
        }
        public int GetMembershipFees()
        {
            int membershipTypeId = 1;
            var membershipDetails = _membershipDAL.GetMembershipDetails(membershipTypeId);
            return membershipDetails.MembershipFees;

        }
    }
}