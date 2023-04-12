using H1_ERP_System.products;

namespace H1_ERP_System.ui;

public class ProductScreenList
{
	public enum ProductScreen
	{
		Todo,
		Started,
		Done
	}

	public ProductScreenList(Product product, int priority = 1)
	{
		ProductNumber = product.Id;
		ProductName = product.Name;
		ProductDescription = product.Description;
		SalesPrice = product.SalesPrice;
		PurchasePrice = product.PurchasePrice;
		Earnings = product.Earnings;
		ProfitMargin = product.ProfitMargin;
		Location = product.Location;
		Stock = product.Stock;
		Unit = product.Unit;
		Priority = priority;

	}

	public int ProductNumber { get; set; }
	public string ProductName { get; set; } = "";
	public string ProductDescription { get; set; } = "";
	public double SalesPrice { get; set; }
	public double PurchasePrice { get; set; }
	public double Earnings { get; set; }
	public double ProfitMargin { get; set; }
	public string Location { get; set; }
	public double Stock { get; set; }
	public Unit Unit { get; set; }
	public int Priority { get; set; }


	public ProductScreen State { get; set; }
}
