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
			Display(new Menu.MenuScreen());
			
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
		Clear(this);
		
		Display(new Menu.MenuScreen());
	}
}
