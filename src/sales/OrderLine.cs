namespace H1_ERP_System.sales;

public class OrderLine
{
	public string OrderNumber { get; }
	public string Date { get; }
	
	public string CustomerId { get; }
	
	public OrderLine(string orderNumber, string date, string customerId)
	{
		OrderNumber = orderNumber;
		Date = date;
		
		CustomerId = customerId;
	}
}
