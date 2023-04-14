using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.products;

namespace H1_ERP_System.sales;

public class Order
{
	public Order(int id, string createdAt, string completedAt, Customer customer, OrderStatus orderStatus)
	{
		Id = id;

		CreatedAt = createdAt;
		CompletedAt = completedAt;

		Customer = customer;
		
		OrderStatus = orderStatus;

		//TotalPrice = CalculateTotalPrice();
	}

	public int Id { get; set; }

	public string CreatedAt { get; set; }
	public string CompletedAt { get; set; }

	public Customer Customer { get; set; }
	
	public OrderStatus OrderStatus { get; set; }

	public double TotalPrice { get; set; }

	//public double CalculateTotalPrice()
	//{
	//	var totalPrice = 0.0;

	//	var orderLines = Database.GetAllOrderLines().FindAll(orderLine => orderLine.Id == Id);
	//	foreach (var orderLine in orderLines)
	//	{
	//		var product = Database.GetProductById(orderLine.Product.Id);
	//		if (product == null)
	//		{
	//			continue;
	//		}

	//		totalPrice += product.PurchasePrice * orderLine.Quantity;
	//	}

	//	return totalPrice;
	//}

	public override string ToString()
	{
		return $"Order #{Id} - {CreatedAt} - {CompletedAt} - {Customer} - {OrderStatus} - {TotalPrice}";
	}
}

public enum OrderStatus
{
	None,
	Created,
	Confirmed,
	Packaged,
	Completed
}

public static class OrderStatusExtensions
{
	public static OrderStatus Of(string input)
	{
		return input.ToLower() switch
		{
			"none" => OrderStatus.None,
			"created" => OrderStatus.Created,
			"confirmed" => OrderStatus.Confirmed,
			"packaged" => OrderStatus.Packaged,
			"completed" => OrderStatus.Completed,
			_ => OrderStatus.None
		};
	}
}

public class OrderLine
{
	public OrderLine(int id, int orderId, Product product, double quantity)
	{
		Id = id;
		OrderId = orderId;
		Product = product;
		Quantity = quantity;
	}
	
	public int Id { get; set; }
	public int OrderId { get; set; }
	public Product Product { get; set; }
	public double Quantity { get; set; }

	public override string ToString()
	{
		return $"OrderLine #{Id} - {OrderId} - {Product} - {Quantity}";
	}
}
