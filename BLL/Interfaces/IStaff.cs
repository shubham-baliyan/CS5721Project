using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStaff
    {
        string RegisterStaff(StaffModel staffModel);
        string UpdateStaffDetails(ViewStaffModel staffModel);
        bool DeleteStaff(int userId);
        ViewStaffModel GetStaffDetails(int userId);
        List<ViewStaffModel> GetAllStaffs();

    }
}
