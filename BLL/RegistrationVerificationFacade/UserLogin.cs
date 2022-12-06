using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL.ServiceClass;
using BLL.Interfaces;

namespace BLL.RegistrationVerificationFacade
{
    public class UserLogin : ILogin
    {
        private bool isLoginSuccess = true;
        private bool isUserVerified;
        private string loginToken;
        private ICustomer _customer = new Customer();
        private IVerification _verification = new Verification();
        


//user function to verify user login
        public (string,int) userLogin(LoginModel login)
        {
            var res = _customer.UserLogin(login);
            loginToken = res.Item1;
            if (!loginToken.Contains("invalid Login"))
            {
                var user = _customer.GetUserDetails(login) ;
                isUserVerified = isVerified(user);
            }
            return res;         
        }

// verification function to check whether the user is verified or not and if not send a verification mail 

        public bool isVerified(UserModel user)
        {
            isUserVerified = _verification.isVerified(user);
            if(isUserVerified == false)
            {
                _verification.verify(user);
                isUserVerified = true;
            }
            
           return isUserVerified;
        }


    }
}