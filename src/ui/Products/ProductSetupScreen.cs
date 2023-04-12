using H1_ERP_System.products;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductSetupScreen : Screen
{
	public Product product = new(88, "CoolProduct", "It is cool", 25, 30, "Bag dig", 3, Unit.Meters);
	public Product product2 = new(44, "unCoolProduct", "It is  not cool", 35, 30, "foran dig", -3, Unit.Meters);
	public override string Title { get; set; } = "product setup";


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
