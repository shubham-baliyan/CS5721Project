using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DAL.DALClasses;
using DAL;
using BLL.BookingObserver;
using System.Text;

namespace BLL.ServiceClass
{
    public class Customer: ICustomer
    {
        private CustomerDAL _customerDAL = new CustomerDAL();
        public Customer()
        {
        }
        public (string,int) UserLogin(LoginModel login)
        {
            (bool,int) res = _customerDAL.LoginCheck(login.UserName, login.Password);
            bool isUserPresent = res.Item1;
            string token = login.UserName + ":" + login.Password;
            string loginToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            return isUserPresent == true ? (loginToken,res.Item2) : ("invalid Login",0);
        }
        public string RegisterCustomer(CustomerModel customerModel)
        {
            customerModel.UserType = "Customer";
            customerModel.CreatedOn = DateTime.Now;
            customerModel.IsApproved = customerModel.CustomerType == "Student" ? false: true;
            var res = _customerDAL.CreateCustomer(customerModel);
            if(res == null)
            {
                res = "Customer has been registered successfully!";
            }
            return res;
        }

        public ViewCustomerModel GetCustomerDetails(int userId)
        {
            return _customerDAL.GetCustomer(userId);
        }

        public string UpdateCustomer(ViewCustomerModel customerModel)
        {
            string res;
            var response = _customerDAL.UpdateCustomer(customerModel);
            if (response)
            {
                res = "Customer has been updated successfully";
            }
            else
            {
                res = "Unable to update customer";
            }
            return res;
        }
        public bool DeleteCustomer(int userId)
        {
            return _customerDAL.DeleteCustomer(userId);
        }
       
        public bool CheckMembershipValid(int userId, int slotId)
        {
            return _customerDAL.IsMembershipValid(userId, slotId);
        }

        public List<ViewCustomerModel> GetAllCustomers()
        {
            return _customerDAL.GetAllCustomerList();
        }

        public bool BuyMembership(int userId)
        {
            return _customerDAL.BuyMembership(userId);
        }

        public string ChangePassword(int userId, ChangePasswordModel changePasswordModel)
        {
            var response = _customerDAL.ChangePassword(userId, changePasswordModel);
            if(response == null)
            {
                response = "Password has been changed successfully";
            }
            return response;
        }
        public (bool,int) isUserValid(string userName, string password)
        {
            return _customerDAL.LoginCheck(userName, password);
        }

        public UserModel GetUserDetails(LoginModel login)
        {
            return _customerDAL.GetUserDetails(login.UserName, login.Password);
        }
    }
}