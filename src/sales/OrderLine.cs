using H1_ERP_System.products;

namespace H1_ERP_System.sales;

public class OrderLine
{
	public string OrderNumber { get; }
	public string Date { get; }
	
	public string CustomerId { get; }
	
	public List<Product> Products { get; }
	
	public OrderLine(string orderNumber, string date, string customerId, List<Product> products)
	{
		OrderNumber = orderNumber;
		Date = date;
		
		CustomerId = customerId;
		
		Products = products;
	}
	
	public override string ToString()
	{
		return $"OrderNumber={OrderNumber}, Date={Date}, CustomerId={CustomerId}, Products={Products}";
	}
}
