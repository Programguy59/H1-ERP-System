using H1_ERP_System.db;

namespace ErpTests.UnitTests;

public class Tests
{
	[Fact]
	public void TestOrder()
	{
		var random = new Random();
		
		var allOrders = Database.GetAllOrders();
		
		// Get a random order from the database (shouldn't be null unless the database is empty).
		var order = Database.GetOrderById(random.Next(0, allOrders.Count));
		
		// This is a test to see if the order is null. If it is null, our system is broken.
		Assert.NotNull(order);
	}
}
