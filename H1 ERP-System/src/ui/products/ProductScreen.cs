﻿using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.products;

public class ProductScreen : Screen
{
	public ProductScreen(ProductScreenList product)
	{
		CurrentProduct = product;
	}

	public override string Title { get; set; } = "Product";
	private ProductScreenList CurrentProduct { get; }

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var listPage = new ListPage<ProductScreenList>();

		listPage.Add(CurrentProduct);

		listPage.AddColumn("Product", "ProductName");
		listPage.AddColumn("Description", "ProductDescription");

		listPage.AddColumn("Sales Price", "FormattedSalesPrice");
		listPage.AddColumn("Purchase Price", "FormattedPurchasePrice");

		listPage.AddColumn("Earnings", "FormattedEarnings");
		listPage.AddColumn("Profit Margin", "FormattedProfitMargin");

		// Wait for the user to press a key, then quit the screen.
		listPage.Select();

		TechCoolUtils.Clear(this);

		Quit();
	}
}
