using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductScreen : Screen
{
	public ProductScreen(ProductScreenList product)
	{
		CurrentProduct = product;
	}

	public override string Title { get; set; } = "Product";
	public ProductScreenList CurrentProduct { get; set; }

	protected override void Draw()
	{
		Clear(this);
		var listPage = new ListPage<ProductScreenList>();
		listPage.Add(CurrentProduct);
		
		listPage.AddColumn("Product", "ProductName");
		listPage.AddColumn("Description", "ProductDescription");
		listPage.AddColumn("Sales Price", "FormattedSalesPrice");
		listPage.AddColumn("Purchase Price", "FormattedPurchasePrice");
		listPage.AddColumn("Earnings", "FormattedEarnings");
		listPage.AddColumn("Profit Margin", "FormattedProfitMargin");

		var selected = listPage.Select();

		Console.Clear();


		Quit();


	}
}
