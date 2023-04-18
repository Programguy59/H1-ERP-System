using H1_ERP_System.db;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesScreen : Screen
{
	public override string Title { get; set; } = "Sale";

	protected override void Draw()
	{
		Clear(this);

		// Display list of customers.
		var listPage = new ListPage<SalesList>();

		foreach (var order in Database.GetAllOrders())
		{
			var customer = Database.GetCustomerById(order.Customer.Id);
			if (customer == null)
			{
				continue;
			}

			var salesList = new SalesList(order.Id, order.CreatedAt, customer, order.TotalPrice);
			listPage.Add(salesList);
		}

		listPage.AddColumn("Order ID", "Id");
		listPage.AddColumn("Date", "Date");
		listPage.AddColumn("Customer ID", "CustomerId");
		listPage.AddColumn("Name", "CustomerFullName");
		listPage.AddColumn("Total Price", "TotalPrice");

		var selected = listPage.Select();

		Console.Clear();

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
