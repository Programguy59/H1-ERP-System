using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.util;

namespace H1_ERP_System.sales;

public class Order
{
	public Order(int id, DateTime? createdAt, DateTime? completedAt, Customer customer, OrderStatus orderStatus)
	{
		Id = id;

		CreatedAt = createdAt;
		CompletedAt = completedAt;

		Customer = customer;

		OrderStatus = orderStatus;

		OrderLines = GetRelevantOrderLines();

		TotalPrice = CalculateTotalPrice();
	}

	public Order(DateTime? createdAt, DateTime? completedAt, Customer customer, OrderStatus orderStatus)
		: this(Constants.DefaultId, createdAt, completedAt, customer, orderStatus)
	{
	}

	public int Id { get; set; }

	public DateTime? CreatedAt { get; set; }
	public DateTime? CompletedAt { get; set; }

	public Customer Customer { get; set; }

	public OrderStatus OrderStatus { get; set; }

	public double TotalPrice { get; set; }

	public List<OrderLine> OrderLines { get; set; }

	private List<OrderLine> GetRelevantOrderLines()
	{
		return Database.GetAllOrderLines().FindAll(orderLine => orderLine.OrderId == Id);
	}

	private double CalculateTotalPrice()
	{
		var totalPrice = 0.0;

		foreach (var orderLine in OrderLines)
		{
			var product = Database.GetProductById(orderLine.Product.Id);

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
