using TECHCOOL.UI;


namespace H1_ERP_System.src.ui.Company;

public class CompanySetupScreen : Screen
{
	public static string SelectedCompanyName;
	public override string Title { get; set; } = "company";

	protected override void Draw()
	{

		Clear();
		var ListPage = CompanyScreenList.GetPageList();

        ListPage.AddColumn("Company", "CompanyName");
        ListPage.AddColumn("Country", "CompanyCountry");
        ListPage.AddColumn("Currency", "CompanyCurrency");

        SelectedCompanyName = ListPage.Select().CompanyName;
        Clear();

		Quit();

		Display(new CompanyScreen());
	}
}
