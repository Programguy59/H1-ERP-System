namespace H1_ERP_System.sales;

public class Order
{
	public int Id { get; set; }

	public string CreatedAt { get; set; }
	public string CompletedAt { get; set; }

	public string CustomerId { get; set; }

	public OrderStatus OrderStatus { get; set; }
	
	public OrderLine OrderLine { get; set; }
	public double TotalPrice { get; set; }
	
	public Order(int id, string createdAt, string completedAt, string customerId, OrderStatus orderStatus, OrderLine orderLine, double totalPrice)
	{
		Id = id;

		CreatedAt = createdAt;
		CompletedAt = completedAt;

		CustomerId = customerId;

		OrderStatus = orderStatus;

		OrderLine = orderLine;
		TotalPrice = totalPrice;
	}
	
	public override string ToString()
	{
		return
			$"Id={Id}, CreatedAt={CreatedAt}, CompletedAt={CompletedAt}, CustomerId={CustomerId}, OrderStatus={OrderStatus}, OrderLine={OrderLine}, TotalPrice={TotalPrice}";
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
