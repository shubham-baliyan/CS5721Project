using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICustomer
    {
        string RegisterCustomer(CustomerModel customerModel);
        ViewCustomerModel GetCustomerDetails(int userId);
        string UpdateCustomer(ViewCustomerModel customerModel);
        bool DeleteCustomer(int userId);
        (string,int) UserLogin(LoginModel login);
        bool CheckMembershipValid(int userId, int slotId);
        List<ViewCustomerModel> GetAllCustomers();
        string ChangePassword(int userId, ChangePasswordModel changePasswordModel);
        UserModel GetUserDetails(LoginModel login);
        bool BuyMembership(int userId);
    }
}
