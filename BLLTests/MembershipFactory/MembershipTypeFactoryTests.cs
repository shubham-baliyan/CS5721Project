using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.MembershipFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MembershipFactory.Tests
{
    [TestClass()]
    public class MembershipTypeFactoryTests
    {
        [TestMethod()]
        public void GetMembershipTypeTest()
        {
            MembershipTypeFactory getMembership = new MembershipTypeFactory();
            getMembership.GetMembershipType(1);
        }
    }
}