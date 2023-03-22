namespace H1_ERP_System.sales;

public class Order
{
	public int Id { get; set; }
	
	public string CreatedAt { get; set; }
	public string CompletedAt { get; set; }
	
	public string CustomerId { get; set; }
	
	public Status Status { get; set; }
	
	public List<Order> OrderLine { get; set; } // TODO: Change to Product list.
	public double TotalPrice { get; set; }
	
	public Order(int id, string createdAt, string completedAt, string customerId, Status status, List<Order> orderLine, double totalPrice)
	{
		Id = id;
		
		CreatedAt = createdAt;
		CompletedAt = completedAt;
		
		CustomerId = customerId;
		
		Status = status;
		
		OrderLine = orderLine;
		TotalPrice = totalPrice;
	}
	
	public override string ToString()
	{
		return $"Id={Id}, CreatedAt={CreatedAt}, CompletedAt={CompletedAt}, CustomerId={CustomerId}, Status={Status}, OrderLine={OrderLine}, TotalPrice={TotalPrice}";
	}
}

public enum Status
{
	None,
	Created,
	Confirmed,
	Packaged,
	Completed
}
