using H1_ERP_System.customer;
using H1_ERP_System.sales;

namespace ErpTests.UnitTests;

public class Tests
{
    
    [Fact]
    public void TestOrder()
    {
        var order = new Order(1, "2021-01-0", "2", null, OrderStatus.Completed);
        Assert.NotNull(order);
    }
}