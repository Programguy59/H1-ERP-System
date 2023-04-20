using H1_ERP_System.db;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesScreen : Screen
{
	public override string Title { get; set; } = "Sale";

	protected override void Draw()
	{
        TechCoolUtils.Clear(this);

        // Display list of customers.
        var listPage = SalesList.GetPageList();

		listPage.AddColumn("Order ID", "Id");
		listPage.AddColumn("Date", "Date");
		listPage.AddColumn("Customer ID", "CustomerId");
		listPage.AddColumn("Name", "CustomerFullName");
		listPage.AddColumn("Total Price", "TotalPrice");

		var selected = listPage.Select();

        TechCoolUtils.Clear(this);

        // Display customer details.
        listPage = new ListPage<SalesList>();

		listPage.Add(selected);

        listPage.AddColumn("Order ID", "Id");
        listPage.AddColumn("Date", "Date");
        listPage.AddColumn("Customer ID", "CustomerId");
        listPage.AddColumn("Name", "CustomerFullName");

        listPage.Select();

		Quit();
	}
}
