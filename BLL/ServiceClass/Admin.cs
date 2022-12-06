using BLL.Interfaces;
using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class Admin: IAdmin
    {
        private AdminDAL _adminDAL = new AdminDAL();
        public Admin()
        {
            
        }
        public UserModel GetAdminDetails()
        {
            return _adminDAL.GetAdminDetails();
        }   
        
        public bool UpdateAdminDetails(UserModel userModel)
        {
            return _adminDAL.UpdateAdminDetails(userModel);
        }

        }
    
}