using H1_ERP_System.sales;

namespace ErpTests.UnitTests;

public class Tests
{
	[Fact]
	public void TestOrder()
	{
        DateTime createdAt = DateTime.Parse("2021-01-0");
        DateTime completedAt = DateTime.Parse("2");
        var order = new Order(createdAt, completedAt, null, OrderStatus.Completed);
		Assert.NotNull(order);
	}
}
