using H1_ERP_System.db;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreen : Screen
{
	public override string Title { get; set; } = "Kunder";

	protected override void Draw()
	{
		Clear(this);

		// Display list of customers.
		var listPage = new ListPage<CustomerList>();

		foreach (var customer in Database.GetAllCustomers())
		{
			var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);
			
			var customerList = new CustomerList(
				customer.CustomerId,
				customer.FirstName,
				customer.LastName,
				customer.PhoneNumber,
				customer.Email,
				lastOrder,
				customer.Address
			);

			listPage.Add(customerList);
		}

		listPage.AddColumn("ID", "Id");

		listPage.AddColumn("Fulde Navn", "FormattedName");
		listPage.AddColumn("Telefon", "Phone");
		listPage.AddColumn("Email", "Email");

		var selected = listPage.Select();

		Console.Clear();

		// Display customer details.
		listPage = new ListPage<CustomerList>();

		listPage.Add(selected);

		listPage.AddColumn("ID", "Id");

		listPage.AddColumn("Fulde Navn", "FormattedName");
		listPage.AddColumn("Adresse", "FormattedAddress");
		listPage.AddColumn("Seneste Ordre", "FormattedLastOrderDate");

		listPage.Select();

		Console.Clear();

		// Return to main menu.
		Quit();
	}
}
