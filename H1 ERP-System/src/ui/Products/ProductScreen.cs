using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductScreen : Screen
{
	public ProductScreen(ProductScreenList product)
	{
		CurrentProduct = product;
	}

	public override string Title { get; set; } = "product info";
	public ProductScreenList CurrentProduct { get; set; }

	protected override void Draw()
	{
		Clear(this);
		var listPage = new ListPage<ProductScreenList>();
		listPage.Add(CurrentProduct);

		listPage.AddColumn("Product", "ProductName");
		listPage.AddColumn("Description", "ProductDescription");
		listPage.AddColumn("Sales Price", "SalesPrice");
		listPage.AddColumn("Purchase Price", "PurchasePrice");
		listPage.AddColumn("Earnings", "Earnings");
		listPage.AddColumn("Profit Margin", "ProfitMargin");

		var selected = listPage.Select();

		Console.Clear();


		Quit();


	}
}
