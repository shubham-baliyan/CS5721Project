using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class Common
    {
        private MembershipDAL _membershipDAL = new MembershipDAL();

        public Common()
        {
           
        }

        public List<MembershipTypeModel> GetMembershipTypes()
        {
            return _membershipDAL.GetMembershipTypes();
        }



    }
}