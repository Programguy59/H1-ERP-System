using TECHCOOL.UI;
using H1_ERP_System.db;
using H1_ERP_System.sales;

namespace H1_ERP_System.ui.customer;

public class CustomerScreen : Screen
{
	public override string Title { get; set; }
	
	protected override void Draw()
	{
		Clear(this);
		
		// Display list of customers.
		var listPage = new ListPage<CustomerList>();
		
		foreach (var customer in Database.GetAllCustomers())
		{
			var lastOrder = Database.GetAllOrders().Find(order => order.CustomerId == customer.Id.ToString());
			
			listPage.Add(new CustomerList(customer.Id, customer.PersonFirstName, customer.PersonLastName, customer.PhoneNumber, customer.Email, lastOrder!));
		}
		
		listPage.AddColumn("Id", "Id");
		
		listPage.AddColumn("Fulde navn", "FullName");
		listPage.AddColumn("Telefon", "Phone");
		listPage.AddColumn("Email", "Email");
		
		var selected = listPage.Select();

		Console.Clear();
		
		// Display customer details.
		listPage = new ListPage<CustomerList>();
		
		listPage.Add(selected);
		
		listPage.AddColumn("Fulde navn", "FullName");
		listPage.AddColumn("Adresse", "Address");
		listPage.AddColumn("Dato for sidste ordre", "LastOrderDate");
		
		listPage.Select();
		
		Quit();
	}
}
