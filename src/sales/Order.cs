using H1_ERP_System.products;

namespace H1_ERP_System.sales;

public class Order
{
	public Order(int id, string createdAt, string completedAt, string customerId, Status status, List<Product> orderLine, double totalPrice)
	{
		Id = id;

		CreatedAt = createdAt;
		CompletedAt = completedAt;

		CustomerId = customerId;

		Status = status;

		OrderLine = orderLine;
		TotalPrice = totalPrice;
	}

	public int Id { get; set; }

	public string CreatedAt { get; set; }
	public string CompletedAt { get; set; }

	public string CustomerId { get; set; }

	public Status Status { get; set; }

	public List<Product> OrderLine { get; set; }
	public double TotalPrice { get; set; }

	public override string ToString()
	{
		return
			$"Id={Id}, CreatedAt={CreatedAt}, CompletedAt={CompletedAt}, CustomerId={CustomerId}, Status={Status}, OrderLine={OrderLine}, TotalPrice={TotalPrice}";
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
