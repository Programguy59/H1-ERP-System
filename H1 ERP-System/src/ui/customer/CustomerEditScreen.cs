using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerEditScreen : Screen
{
	private static int _selectedCustomerId;
	
	public override string Title { get; set; } = "Rediger Kunde";
	
	public CustomerEditScreen(int id)
	{
		_selectedCustomerId = id;
	}

	protected override void Draw()
	{
		Clear(this);
		
		var customerScreenList = CustomerScreenList.GetCustomerScreenListFromId(_selectedCustomerId);
		if (customerScreenList == null)
		{
			return;
		}
		
		var editor = new Form<CustomerScreenList>();
		
		// Add a text-box.
		editor.TextBox("ID", "Id");
		
		editor.TextBox("Fornavn", "FirstName");
		editor.TextBox("Efternavn", "LastName");
		
		editor.TextBox("Email", "Email");
		editor.TextBox("Telefon", "PhoneNumber");
		
		editor.TextBox("Adresse", "StreetName");
		editor.TextBox("Husnummer", "StreetNumber");
		editor.TextBox("Postnummer", "ZipCode");
		editor.TextBox("By", "City");
		editor.TextBox("Land", "Country");
		
		editor.TextBox("Seneste Ordre", "FormattedLastOrderDate");
		
		Clear(this);
		
		// Draw the editor.
		editor.Edit(customerScreenList);
		
		// Update the customer.
		var customer = Database.GetCustomerById(customerScreenList.Id);
		if (customer == null)
		{
			return;
		}

		var person = customer.Person;
		var address = customer.Address;
		
		person.FirstName = customerScreenList.FirstName;
		person.LastName = customerScreenList.LastName;
		
		customer.Email = customerScreenList.Email;
		customer.PhoneNumber = customerScreenList.PhoneNumber;
		
		address.StreetName = customerScreenList.StreetName;
		address.StreetNumber = customerScreenList.StreetNumber;
		address.ZipCode = customerScreenList.ZipCode;
		address.City = customerScreenList.City;
		address.Country = customerScreenList.Country;
		
		var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);
		var dateSinceLastPurchase = lastOrder == null ? "N/A" : lastOrder.CreatedAt;
		
		var updatedCustomer = new Customer(customer.CustomerId, person, dateSinceLastPurchase);
		
		if (!DatabaseServer.UpdateCustomer(updatedCustomer))
		{
			return;
		}
		
		Clear(this);
		
		Display(new Menu.MenuScreen());
	}
}
