using BLL.Interfaces;
using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    // Strategy Design Pattern
    public class UserContext: IUserContext
    {
        //private IUser iUser;

        // Constructor
        //public UserContext(IUser iUser)
        //{
        //    this.iUser = iUser;
        //}
        //public string ContextCreateCustomer(CustomerModel customerModel)
        //{
        //    return iUser.CreateCustomer(customerModel);
        //}


        //public CustomerModel ContextViewCustomer(int userId)
        //{
        //    return iUser.GetCustomer(userId);
        //}
    }
}