using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerSetupScreen : Screen
{
	public static int SelectedCustomerId;
	public override string Title { get; set; } = "Customer";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var listPage = CustomerScreenList.GetPageList();


		listPage.AddColumn("ID", "Id");

		listPage.AddColumn("First Name", "FirstName");
		listPage.AddColumn("Last Name", "LastName");

		listPage.AddColumn("Phone Number", "PhoneNumber");
		listPage.AddColumn("Email", "Email");

		var selected = listPage.Select();

		// If the user pressed escape or the list is empty, quit the screen.
		if (selected == null)
		{
			Quit();

			return;
		}

		SelectedCustomerId = selected.Id;

		TechCoolUtils.Clear(this);
		Display(new CustomerScreen());
	}
}
