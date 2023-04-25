using H1_ERP_System.db;

namespace ErpTests.UnitTests;

public class Tests
{
	[Fact]
	public void TestOrder()
	{
		var random = new Random();
		
		// Get all orders from the database.
		var allOrders = Database.GetAllOrders();
		// Get a random order from the list, it is null if the list is empty.
		var order = allOrders[random.Next(allOrders.Count)];
		
		Assert.NotNull(order);
	}
}
