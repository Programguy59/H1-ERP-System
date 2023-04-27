using H1_ERP_System.db;
using H1_ERP_System.product;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.products;

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
		
		FormattedProfitMargin = $"{Math.Round(ProfitMargin, 2)}%";
		FormattedEarnings = $"{Math.Round(Earnings, 2)}";
		
		FormattedSalesPrice = $"{Math.Round(SalesPrice, 2)}";
		FormattedPurchasePrice = $"{Math.Round(PurchasePrice, 2)}";
		
		FormattedStock = $"{Math.Round(Stock, 2)}";
		FormattedUnit = Unit.ToString();
	}
	
	public int ProductNumber { get; set; }
	
	public string ProductName { get; set; }
	public string ProductDescription { get; set; }
	
	public double SalesPrice { get; set; }
	public double PurchasePrice { get; set; }
	
	public double Earnings { get; set; }
	public double ProfitMargin { get; set; }
	
	public string Location { get; set; }
	public double Stock { get; set; }
	public Unit Unit { get; set; }
	
	public int Priority { get; set; }
	
	public ProductScreen State { get; set; }
	
	public string FormattedProfitMargin { get; set; }
	
	public string FormattedEarnings { get; set; }
	public string FormattedSalesPrice { get; set; }
	public string FormattedPurchasePrice { get; set; }
	
	public string FormattedStock { get; set; }
	public string FormattedUnit { get; set; }
	
	public static ProductScreenList? GetProductScreenListFromId(int id)
	{
		var product = Database.GetProductById(id);
		
		return product == null ? 
				null : 
				new ProductScreenList(product);
	}
	
	public static ListPage<ProductScreenList> GetPageList()
	{
		var listPage = new ListPage<ProductScreenList>();

		listPage.AddKey(ConsoleKey.F1, MakeProductButton);
		listPage.AddKey(ConsoleKey.F2, EditProductButton);
		listPage.AddKey(ConsoleKey.F5, DeleteProductButton);
		
		var products = Database.GetAllProducts();
		
		// If the products list is empty, force the user to make a product.
		if (products.Count < 1)
		{
			MakeProductButton();
			
			return listPage;
		}
		
		foreach (var product in products)
		{
			listPage.Add(new ProductScreenList(product));
		}
		
		return listPage;
	}
	
	public static void MakeProductButton(ProductScreenList product = null)
	{
		Screen.Display(new ProductMakeScreen());
	}
	
	public static void EditProductButton(ProductScreenList product)
	{
		Screen.Display(new ProductEditScreen(product.ProductNumber));
	}
	
	public static void DeleteProductButton(ProductScreenList productScreenList)
	{
		var product = Database.GetProductById(productScreenList.ProductNumber);
		if (product == null)
		{
			return;
		}
		
		if (!DatabaseServer.DeleteProduct(product))
		{
			new ErrorScreen("Failed to delete product!");
			
			return;
		}
		
		// Refresh the screen.
		Screen.Display(new ProductSetupScreen());
	}
}
