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
		
		Clear(this);
		Display(new Menu.MenuScreen());
	}
}
