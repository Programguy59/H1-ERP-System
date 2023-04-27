using H1_ERP_System.product;

namespace H1_ERP_System.ui.products;

public class ProductSetupList
{
	public enum ProductSetupState
	{
		Todo,
		Started,
		Done
	}

	public ProductSetupList(Product product, int priority = 1)
	{
		ProductNumber = product.Id;
		
		ProductName = product.Name;

		SalesPrice = product.SalesPrice;
		PurchasePrice = product.PurchasePrice;
		
		ProfitMargin = product.ProfitMargin;
		Stock = product.Stock;

		Priority = priority;
	}
	
	public int ProductNumber { get; set; }
	
	public string ProductName { get; set; } = "";
	
	public double SalesPrice { get; set; }
	public double PurchasePrice { get; set; }
	
	public double ProfitMargin { get; set; }
	public double Stock { get; set; }
	
	public int Priority { get; set; }
	public ProductSetupState State { get; set; }
}
