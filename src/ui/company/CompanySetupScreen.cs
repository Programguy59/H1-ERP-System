using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanySetupScreen : Screen
{
	public static string SelectedCompanyName;
	public override string Title { get; set; } = "company";

	protected override void Draw()
	{

		Clear();
		var listPage = CompanySetupList.GetPageList();

		listPage.AddColumn("Company", "CompanyName");
		listPage.AddColumn("Country", "Country");
		listPage.AddColumn("Currency", "Currency");


		var selected = listPage.Select();

		SelectedCompanyName = selected.CompanyName;
		Console.WriteLine("You selected: " + selected.CompanyName);
		Clear();

		Quit();

		Display(new CompanyScreen());
	}
}
