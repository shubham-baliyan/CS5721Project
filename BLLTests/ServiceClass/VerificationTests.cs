using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.ServiceClass.Tests
{
    [TestClass()]
    public class VerificationTests
    {
        
        [TestMethod()]
        public void isVerifiedTest()
        {
            UserModel testUser = new UserModel();
            testUser.UserId = 1;
            testUser.FirstName = "Test";
            testUser.LastName = "User";
            testUser.Email = "piyushnagpal1998@gmail.com";
            testUser.IsApproved = true;

            Verification testVerification = new Verification();
             testVerification.verify(testUser);
        }
    }
}