using H1_ERP_System.src.Company;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreenList
{
	public enum CompanyScreen
	{
		Todo,
		Started,
		Done
	}

	public CompanyScreenList(int id, string companyName, string companyCurrency, int addressId, int priority)
	{
		CompanyId = id;
		CompanyName = companyName;
		CompanyCurrency = companyCurrency;

		AddressId = id;

		Priority = priority;

	}

	public int CompanyId { get; set; }

	public string CompanyName { get; set; }
	public string CompanyCurrency { get; set; }

	public int AddressId { get; set; }

	public int Priority { get; set; }

	public CompanyScreen State { get; set; }

	private static void something(CompanyScreenList i)
	{
		Screen.Display(new CompanyEditDataScreen());
	}

	public static ListPage<CompanyScreenList> GetPageListFromName(string CompanyName)
	{
		var listPage = new ListPage<CompanyScreenList>();

		listPage.AddKey(ConsoleKey.F1, something);

		var companies = DatabaseServer.FetchCompanies();

		for (var i = 0; i < companies.Count; i++)
			if (companies[i].CompanyName == CompanyName)
			{
				listPage.Add(new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Currency, companies[i].Address.Id, 1));
			}

		return listPage;
	}

	public static CompanyScreenList GetCompanyScreenListFromName(string CompanyName)
	{
		CompanyScreenList companyScreenList = new(0, "", "", 0, 0);

		var companies = DatabaseServer.FetchCompanies();

		for (var i = 0; i < companies.Count; i++)
			if (companies[i].CompanyName == CompanyName)
			{
				companyScreenList = new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Currency, companies[i].Address.Id,
					1);
			}

		return companyScreenList;
	}
}
