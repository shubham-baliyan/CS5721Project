using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.RegistrationVerificationFacade
{
    public interface ILogin
    {
         (string,int) userLogin(LoginModel login);
         bool isVerified(UserModel user);
    }
}
