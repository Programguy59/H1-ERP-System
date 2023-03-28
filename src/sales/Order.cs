using H1_ERP_System.db;

namespace H1_ERP_System.sales;

public class Order
{
	public int Id { get; set; }

	public string CreatedAt { get; set; }
	public string CompletedAt { get; set; }

	public string CustomerId { get; set; }

	public OrderStatus OrderStatus { get; set; }
	
	public double TotalPrice { get; set; }
	
	public Order(int id, string createdAt, string completedAt, string customerId, OrderStatus orderStatus)
	{
		Id = id;

		CreatedAt = createdAt;
		CompletedAt = completedAt;

		CustomerId = customerId;

		OrderStatus = orderStatus;
		
		TotalPrice = CalculateTotalPrice();
	}
	
	public double CalculateTotalPrice()
	{
		var totalPrice = 0.0;
		
		var orderLines = Database.GetAllOrderLines().FindAll(orderLine => orderLine.Id == Id);
		
		foreach (var orderLine in orderLines)
		{
			var product = Database.GetProductById(orderLine.ProductId);
			if (product == null)
			{
				continue;
			}
			
			totalPrice += product.PurchasePrice * orderLine.Quantity;
		}
		
		return totalPrice;
	}
	
	public override string ToString()
	{
		return
			$"Id={Id}, CreatedAt={CreatedAt}, CompletedAt={CompletedAt}, CustomerId={CustomerId}, OrderStatus={OrderStatus}, TotalPrice={TotalPrice}";
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
	public int Id { get; set; }
	
	public int ProductId { get; set; }
	public double Quantity { get; set; }
	
	public OrderLine(int id, int productId, double quantity)
	{
		Id = id;
		
		ProductId = productId;
		Quantity = quantity;
	}
	
	public override string ToString()
	{
		return $"Id={Id}, ProductId={ProductId}, Quantity={Quantity}";
	}
}
