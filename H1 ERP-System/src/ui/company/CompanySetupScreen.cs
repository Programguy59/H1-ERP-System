using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanySetupScreen : Screen
{
	public static int SelectedOrderId;
	public override string Title { get; set; } = "Company";

	protected override void Draw()
	{

		TechCoolUtils.Clear(this);
		var ListPage = CompanyScreenList.GetPageList();

		ListPage.AddColumn("Company", "CompanyName");
		ListPage.AddColumn("Country", "CompanyCountry");
		ListPage.AddColumn("Currency", "CompanyCurrency");

		SelectedOrderId = ListPage.Select().CompanyId;
		TechCoolUtils.Clear(this);

		Quit();

		Display(new CompanyScreen());
	}
}
