using H1_ERP_System.util;
using System;
using System.Collections.Generic;
using H1_ERP_System.company;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpTests.UnitTests
{

    public class CompanyUnitTest
    {
        
        [Fact]
        public void ToStringTest()
        {
            Address SuperAddress = new Address(0, "", "", "", "", "");
            Company company = new(0, "BestCompany", SuperAddress, "USD");
            Assert.IsType<string>(company.ToString());
        }  
    }
}
