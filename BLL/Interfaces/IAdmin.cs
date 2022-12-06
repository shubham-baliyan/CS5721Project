using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdmin
    {
        UserModel GetAdminDetails();
        bool UpdateAdminDetails(UserModel userModel);
    }
}
