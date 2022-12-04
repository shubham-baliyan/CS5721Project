using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.ServiceClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceClass.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        Customer getCustomer = new Customer();
        [TestMethod()]
        public void GetCustomerDetailsTest()
        {
            getCustomer.GetCustomerDetails(1);
        }
    }
}