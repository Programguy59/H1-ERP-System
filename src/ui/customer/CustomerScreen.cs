using H1_ERP_System.db;
using H1_ERP_System.src.ui.customer;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreen : Screen
{
	public override string Title { get; set; } = "Kunde";

	protected override void Draw()
	{
		var listPage = CustomerScreenList.GetPageListFromId(CustomerSetupScreen.SelectedCustomerId);

		listPage.AddColumn("ID", "Id");
		
		listPage.AddColumn("Fornavn", "FirstName");
		listPage.AddColumn("Efternavn", "LastName");
		
		listPage.AddColumn("Email", "Email");
		listPage.AddColumn("Telefon", "PhoneNumber");
		
		listPage.AddColumn("Adresse", "StreetName");
		listPage.AddColumn("Husnummer", "StreetNumber");
		listPage.AddColumn("Postnummer", "ZipCode");
		listPage.AddColumn("By", "City");
		listPage.AddColumn("Land", "Country");
		
		listPage.AddColumn("Seneste Ordre", "FormattedLastOrderDate");

		var selected = listPage.Select();
		
		Quit();
		Clear();
	}
}
