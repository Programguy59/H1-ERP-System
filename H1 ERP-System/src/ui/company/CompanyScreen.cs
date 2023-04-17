using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreen : Screen
{
	private readonly string selectedCompanyName = CompanySetupScreen.SelectedCompanyName;
	public override string Title { get; set; } = "Company info";

	protected override void Draw()
	{
		Clear();
		var ListPage = CompanyScreenList.GetPageListFromName(selectedCompanyName);

		ListPage.AddColumn("Company", "CompanyName");
		ListPage.AddColumn("Country", "CompanyCountry");
		ListPage.AddColumn("Street Name", "CompanyStreetName");
		ListPage.AddColumn("Street Number", "CompanyStreetNumber");
		ListPage.AddColumn("Zip Code", "CompanyZipCode");
		ListPage.AddColumn("City", "CompanyCity");
		ListPage.AddColumn("Currency", "CompanyCurrency");
		var selected = ListPage.Select();


		Quit();
		Clear();

	}
}
