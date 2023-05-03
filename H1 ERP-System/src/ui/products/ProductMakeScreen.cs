using H1_ERP_System.product;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.products;

public class ProductMakeScreen : Screen
{
	public ProductMakeScreen()
	{
		NewProduct = new Product(
			"",
			"",
			0,
			0,
			"",
			0,
			Unit.Piece
		);

		NewProduct.UpdateData();

		// Draw the screen.
		Display(this);
	}

	public override string Title { get; set; } = "Make Product";

	private Product NewProduct { get; }

	protected override void Draw()
	{
		var productScreenList = new ProductScreenList(NewProduct);

		var editor = new Form<ProductScreenList>();

		editor.TextBox("Name", "ProductName");
		editor.TextBox("Description", "ProductDescription");

		editor.TextBox("Sales Price", "SalesPrice");
		editor.TextBox("Purchase Price", "PurchasePrice");

		editor.TextBox("Location", "Location");
		editor.TextBox("Stock", "Stock");

		editor.SelectBox(
			"Unit",
			"FormattedUnit",
			new Dictionary<string, object> {{"Piece", Unit.Piece.ToString()}, {"Hours", Unit.Hours.ToString()}, {"Meters", Unit.Meters.ToString()}}
		);

		TechCoolUtils.Clear(this);

		// Draw the editor.
		editor.Edit(productScreenList);

		// Validate the attributes.
		if (!IsValidProduct(productScreenList))
		{
			new ErrorScreen("Invalid product details, please try again!");

			TechCoolUtils.Clear(this);

			// Refresh the screen.
			Display(new Menu.MenuScreen());
		}

		// Update the product.
		NewProduct.Name = productScreenList.ProductName;
		NewProduct.Description = productScreenList.ProductDescription;

		NewProduct.SalesPrice = productScreenList.SalesPrice;
		NewProduct.PurchasePrice = productScreenList.PurchasePrice;

		NewProduct.Location = productScreenList.Location;
		NewProduct.Stock = productScreenList.Stock;
		NewProduct.Unit = productScreenList.FormattedUnit.Of();

		NewProduct.UpdateData();

		if (!DatabaseServer.InsertProduct(NewProduct))
		{
			new ErrorScreen("Failed to insert product into database!");
		}

		TechCoolUtils.Clear(this);

		// Refresh the screen.
		Display(new Menu.MenuScreen());
	}

	private static bool IsValidProduct(ProductScreenList product)
	{
		// Make sure all numbers are above 0.
		if (product.SalesPrice < 0 || product.PurchasePrice < 0 || product.Stock < 0)
		{
			return false;
		}

		// Make sure the unit is valid.
		if (!Enum.IsDefined(typeof(Unit), product.Unit))
		{
			return false;
		}

		// Make sure the name, description and location are not empty or the location is too long.
		return !string.IsNullOrWhiteSpace(product.ProductName) &&
		       !string.IsNullOrWhiteSpace(product.ProductDescription) &&
		       !string.IsNullOrWhiteSpace(product.Location) &&
		       product.Location.Length <= 4;

	}
}
