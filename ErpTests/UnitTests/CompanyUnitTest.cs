using H1_ERP_System.company;
using H1_ERP_System.util;

namespace ErpTests.UnitTests;

public class CompanyUnitTest
{
    [Fact]
    public void ToStringTest()
    {
        var SuperAddress = new Address("", "", "", "", "");
        Company company = new("BestCompany", SuperAddress, "USD");
        Assert.IsType<string>(company.ToString());
    }
}