using H1_ERP_System.db;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesScreen : Screen
{
	public override string Title { get; set; } = "Salg";

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

			var salesList = new SalesList(order.Id, order.CreatedAt, customer.Id.ToString(), customer.FullName, order.TotalPrice);
			listPage.Add(salesList);
		}

		listPage.AddColumn("Ordre ID", "Id");
		listPage.AddColumn("Dato", "Date");
		listPage.AddColumn("Kunde ID", "CustomerId");
		listPage.AddColumn("Fulde navn", "CustomerName");
		listPage.AddColumn("Total pris", "TotalPrice");

		var selected = listPage.Select();

		Console.Clear();

		// Display customer details.
		listPage = new ListPage<SalesList>();

		listPage.Add(selected);

        listPage.AddColumn("Ordre ID", "Id");
        listPage.AddColumn("Dato", "Date");
        listPage.AddColumn("Kunde ID", "CustomerId");
        listPage.AddColumn("Fulde navn", "CustomerName");

        listPage.Select();

		Quit();
	}
}
