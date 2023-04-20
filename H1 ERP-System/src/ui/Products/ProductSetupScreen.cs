using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductSetupScreen : Screen
{
	public override string Title { get; set; } = "Product";


	protected override void Draw()
	{
		TechCoolUtils.Clear(this);
		var listPage = new ListPage<ProductScreenList>();
		var Products = DatabaseServer.FetchProducts();
		for (var i = 0; i < Products.Count; i++) listPage.Add(new ProductScreenList(Products[i]));


		listPage.AddColumn("Product number", "ProductNumber");
		listPage.AddColumn("Product", "ProductName");
		listPage.AddColumn("Sales Price", "FormattedSalesPrice");
		listPage.AddColumn("Purchase Price", "FormattedPurchasePrice");
		listPage.AddColumn("Profit Margin", "FormattedProfitMargin");


		var selected = listPage.Select();

		TechCoolUtils.Clear(this);

		Quit();

		Display(new ProductScreen(selected));
	}
}
