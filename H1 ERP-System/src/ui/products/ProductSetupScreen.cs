using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.products;

public class ProductSetupScreen : Screen
{
	public override string Title { get; set; } = "Product";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var listPage = ProductScreenList.GetPageList();

		listPage.AddColumn("Product Number", "ProductNumber");

		listPage.AddColumn("Product", "ProductName");

		listPage.AddColumn("Sales Price", "FormattedSalesPrice");
		listPage.AddColumn("Purchase Price", "FormattedPurchasePrice");

		listPage.AddColumn("Profit Margin", "FormattedProfitMargin");

		// Make sure the user selects a product, if the list is empty, quit the screen.
		ProductScreenList selected;

		try
		{

			selected = listPage.Select();

			// If the user didn't select a product, throw an exception.
			if (selected == null)
			{

				throw new ArgumentOutOfRangeException();
			}

		}
		catch (ArgumentOutOfRangeException)
		{

			Quit();

			return;
		}

		TechCoolUtils.Clear(this);

		Quit();

		Display(new ProductScreen(selected));
	}
}
