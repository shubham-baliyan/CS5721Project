using BLL.ServiceClass;
using BLL.Interfaces;
using DAL.DALClasses;

namespace BLL.MembershipFactory
{
    // Factory Design Pattern
    public class MembershipTypeFactory: IMembershipTypeFactory
    {
        private readonly MembershipDAL _membershipDAL = new MembershipDAL();
        public MembershipTypeFactory()
        {
           
        }
        public IMembership GetMembershipType(int membershipTypeId)
        {
            IMembership returnValue = null;
            if (membershipTypeId == 1)
            {
                returnValue = new Student(_membershipDAL);
            }
            else if (membershipTypeId == 2)
            {
                returnValue = new General(_membershipDAL);
            }
            return returnValue;

        }
    }
}