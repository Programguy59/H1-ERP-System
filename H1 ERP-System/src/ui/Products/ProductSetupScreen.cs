using H1_ERP_System.products;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductSetupScreen : Screen
{
	public override string Title { get; set; } = "Product";


	protected override void Draw()
	{


		Clear(this);
		var listPage = new ListPage<ProductScreenList>();
		var Products = DatabaseServer.FetchProducts();
		for (var i = 0; i < Products.Count; i++) listPage.Add(new ProductScreenList(Products[i]));


		listPage.AddColumn("Product number", "ProductNumber");
		listPage.AddColumn("Product", "ProductName");
		listPage.AddColumn("Sales Price", "SalesPrice");
		listPage.AddColumn("Purchase Price", "PurchasePrice");
		listPage.AddColumn("Profit Margin", "ProfitMargin");


		var selected = listPage.Select();

		Console.WriteLine("You selected: " + selected.ProductName);
		Console.Clear();

		Quit();

		Display(new ProductScreen(selected));
	}
}
