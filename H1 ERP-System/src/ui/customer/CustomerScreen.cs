using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreen : Screen
{
	public override string Title { get; set; } = "Customer";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var listPage = CustomerScreenList.GetPageListFromId(CustomerSetupScreen.SelectedCustomerId);

		listPage.AddColumn("Name", "FormattedName");

		listPage.AddColumn("Address", "FormattedAddress");

		listPage.AddColumn("Last Order", "FormattedLastOrderDate");

		listPage.Select();

		TechCoolUtils.Clear(this);

		Display(new Menu.MenuScreen());
	}
}
