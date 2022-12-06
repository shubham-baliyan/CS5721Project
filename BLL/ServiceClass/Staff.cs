using BLL.Interfaces;
using DAL.DALClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ServiceClass
{
    public class Staff: IStaff
    {
        private CustomerDAL _customerDAL = new CustomerDAL();
        private StaffDAL _staffDAL = new StaffDAL();
        public Staff()
        {
            
        }

        public string RegisterStaff(StaffModel staffModel)
        {
            staffModel.UserType = "Staff";
            staffModel.CreatedBy = "Admin";
            staffModel.CreatedOn = DateTime.Now;
            var res = _staffDAL.CreateStaff(staffModel);
            if (res == null)
            {
                res = "Staff has been registered successfully!";
            }
            return res;
        }

        public string UpdateStaffDetails(ViewStaffModel staffModel)
        {
            string res;
            var response = _staffDAL.UpdateStaff(staffModel);
            if (response)
            {
                res = "Staff has been updated successfully!";
            }
            else
            {
                res = "Unable to update staff!";
            }
            return res;
        }
        public ViewStaffModel GetStaffDetails(int userId)
        {
            return _staffDAL.GetStaff(userId);
        }
        public bool DeleteStaff(int userId)
        {
            return _staffDAL.DeleteStaff(userId);
        }
       public List<ViewStaffModel> GetAllStaffs()
        {
            return _staffDAL.GetAllStaff();
        }
    }
}