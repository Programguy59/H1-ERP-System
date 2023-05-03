using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.company;

public class CompanySetupScreen : Screen
{
	public static int SelectedOrderId;
	public override string Title { get; set; } = "Company";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);
		var listPage = CompanyScreenList.GetPageList();

		listPage.AddColumn("Company", "CompanyName");
		listPage.AddColumn("Country", "CompanyCountry");
		listPage.AddColumn("Currency", "CompanyCurrency");

		var selected = listPage.Select();

		// If the user pressed escape or the list is empty, quit the screen.
		if (selected == null)
		{
			Quit();

			return;
		}

		SelectedOrderId = selected.CompanyId;

		TechCoolUtils.Clear(this);

		Quit();

		Display(new CompanyScreen());
	}
}
