using H1_ERP_System.db;
using H1_ERP_System.product;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.products;

public class ProductEditScreen : Screen
{
	private static int _selectedProductId;

	public ProductEditScreen(int id)
	{
		_selectedProductId = id;
	}

	public override string Title { get; set; } = "Edit Product";

	protected override void Draw()
	{
		var productScreenList = ProductScreenList.GetProductScreenListFromId(_selectedProductId);
		if (productScreenList == null)
		{
			return;
		}
		
		var editor = new Form<ProductScreenList>();

		editor.TextBox("Name", "ProductName");
		editor.TextBox("Description", "ProductDescription");

		editor.TextBox("Sales Price", "FormattedSalesPrice");
		editor.TextBox("Purchase Price", "FormattedPurchasePrice");

		editor.TextBox("Location", "Location");
		editor.TextBox("Stock", "FormattedStock");

		editor.SelectBox(
			title: "Unit",
			property: "FormattedUnit",
			options: new Dictionary<string, object>
			{
				{"Piece", Unit.Piece.ToString()},
				{"Hours", Unit.Hours.ToString()},
				{"Meters", Unit.Meters.ToString()}
			}
		);
		
		TechCoolUtils.Clear(this);

		// Draw the editor.
		editor.Edit(productScreenList);
		
		var product = Database.GetProductById(_selectedProductId);
		if (product == null)
		{
			return;
		}
		
		product.Name = productScreenList.ProductName;
		product.Description = productScreenList.ProductDescription;

		try
		{
			product.SalesPrice = Convert.ToDouble(productScreenList.FormattedSalesPrice); 
			product.PurchasePrice = Convert.ToDouble(productScreenList.FormattedPurchasePrice);
			
			product.UpdateData();
		}
		catch (FormatException)
		{
			new ErrorScreen("Invalid price format!");
			
			Quit();
			
			return;
		}
		
		product.Location = productScreenList.Location;
		product.Stock = productScreenList.Stock;
		product.Unit = UnitExtensions.Of(productScreenList.FormattedUnit);
		
		if (!DatabaseServer.UpdateProduct(product))
		{
			new ErrorScreen("Failed to update product!");
		}
		
		TechCoolUtils.Clear(this);

		Display(new Menu.MenuScreen());
	}
}
