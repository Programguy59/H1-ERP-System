using H1_ERP_System.product;
using H1_ERP_System.util;

namespace H1_ERP_System.sales;

public class OrderLine
{
	public OrderLine(int id, int orderId, Product product, double quantity)
	{
		Id = id;
		OrderId = orderId;

		Product = product;
		Quantity = quantity;
	}

	public OrderLine(int orderId, Product product, double quantity)
		: this(Constants.DefaultId, orderId, product, quantity)
	{
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
