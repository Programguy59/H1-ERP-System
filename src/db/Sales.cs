using H1_ERP_System.sales;

namespace H1_ERP_System.db;

public partial class Database
{
	private static readonly List<Order> Orders = new();
	private static int _nextOrderId = 1;
	
	public static Order GetOrderById(int id)
	{
		return Orders.FirstOrDefault(order => order.Id == id)!;
	}
	
	public static List<Order> GetAllOrders()
	{
		return Orders;
	}
	
	public static void InsertOrder(Order order)
	{
		order.Id = _nextOrderId++;
		
		Orders.Add(order);
	}
	
	public static bool UpdateOrder(Order order, int id)
	{
		var existingOrder = GetOrderById(id);
		
		if (existingOrder == null)
		{
			return false;
		}
		
		existingOrder.CreatedAt = order.CreatedAt;
		existingOrder.CompletedAt = order.CompletedAt;
		
		existingOrder.CustomerId = order.CustomerId;
		
		existingOrder.Status = order.Status;
		
		existingOrder.OrderLine = order.OrderLine;
		existingOrder.TotalPrice = order.TotalPrice;
		
		return true;
	}
	
	public static bool DeleteOrderById(int id)
	{
		var orderToDelete = GetOrderById(id);
		
		if (orderToDelete == null)
		{
			return false;
		}
		
		Orders.Remove(orderToDelete);
		
		return true;
	}
	
	public static void ClearOrders()
	{
		Orders.Clear();
	}
}
