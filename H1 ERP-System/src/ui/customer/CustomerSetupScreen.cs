using H1_ERP_System.db;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerSetupScreen : Screen
{
	public static int SelectedCustomerId;
	public override string Title { get; set; } = "Kunder";

	protected override void Draw()
	{
		Clear();
		
		var listPage = CustomerScreenList.GetPageList();
		
		listPage.AddColumn("ID", "Id");
		
		listPage.AddColumn("Navn", "FormattedName");
		
		listPage.AddColumn("Email", "Email");
		listPage.AddColumn("Telefon", "PhoneNumber");
		
		listPage.AddColumn("Seneste Ordre", "FormattedLastOrderDate");
		
		SelectedCustomerId = listPage.Select().Id;
		
		Clear();
		
		var customer = Database.GetCustomerById(SelectedCustomerId);
		if (customer == null)
		{
			return;
		}
		
		var newCustomer = CustomerScreenList.GetCustomerScreenListFromId(SelectedCustomerId);
		if (newCustomer == null)
		{
			return;
		}
		
		customer.Id = newCustomer.Id;

		customer.FirstName = newCustomer.FirstName;
		customer.LastName = newCustomer.LastName;
		
		customer.Email = newCustomer.Email;
		customer.PhoneNumber = newCustomer.PhoneNumber;
		
		customer.Address.StreetName = newCustomer.StreetName;
		customer.Address.StreetNumber = newCustomer.StreetNumber;
		customer.Address.ZipCode = newCustomer.ZipCode;
		customer.Address.City = newCustomer.City;
		customer.Address.Country = newCustomer.Country;
		
		if (!DatabaseServer.UpdateCustomer(customer))
		{
			return;
		}
		
		Clear(this);
		Display(new Menu.MenuScreen());
	}
}
