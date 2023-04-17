using TECHCOOL.UI;


namespace H1_ERP_System.src.ui.Company;

public class CompanySetupScreen : Screen
{
	public static string SelectedCompanyId;
	public override string Title { get; set; } = "Company";

	protected override void Draw()
	{

		Clear();
		var ListPage = CompanyScreenList.GetPageList();

        ListPage.AddColumn("Company", "CompanyName");
        ListPage.AddColumn("Country", "CompanyCountry");
        ListPage.AddColumn("Currency", "CompanyCurrency");

        SelectedCompanyId = ListPage.Select().CompanyName;
        Clear();

		Quit();

		Display(new CompanyScreen());
	}
}
