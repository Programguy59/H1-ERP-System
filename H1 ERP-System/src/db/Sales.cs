using H1_ERP_System.sales;

namespace H1_ERP_System.db;

public static partial class Database
{
	public static readonly List<Order> Orders = new();
	public static readonly List<OrderLine> OrderLines = new();

	public static Order? GetOrderById(int id)
	{
		return Orders.FirstOrDefault(order => order.Id == id);
	}

	public static List<Order> GetAllOrders()
	{
		return Orders;
	}

	public static OrderLine? GetOrderLineById(int id)
	{
		return OrderLines.FirstOrDefault(orderLine => orderLine.Id == id);
	}

	public static List<OrderLine> GetAllOrderLines()
	{
		return OrderLines;
	}
}
