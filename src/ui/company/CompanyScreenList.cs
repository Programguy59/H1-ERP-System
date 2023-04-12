using H1_ERP_System.src.Company;
using H1_ERP_System.util;
using TECHCOOL.UI;
using System.Net.NetworkInformation;
using H1_ERP_System.src.util;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreenList
{
	public enum CompanyScreen
	{
		Todo,
		Started,
		Done
	}

	public CompanyScreenList(int id, string companyName, Address? address, string companyCurrency, int addressId, int priority)
	{
		CompanyId = id;
		CompanyName = companyName;
		CompanyCurrency = companyCurrency;

		AddressId = id;
        CompanyAddress = address;
        CompanyCountry = address.Country;
        CompanyStreetName = address.StreetName;
        CompanyStreetNumber = address.StreetNumber;
        CompanyZipCode = address.ZipCode;
        CompanyCity = address.City;
        CompanyCurrency = companyCurrency;
        Priority = priority;

	}

	public int CompanyId { get; set; }

	public string CompanyName { get; set; }
	public string CompanyCurrency { get; set; }

	public int AddressId { get; set; }
    public Address CompanyAddress { get; set; }
    public string CompanyCountry { get; set; } = "";

    public string CompanyStreetName { get; set; } = "";

    public string CompanyStreetNumber { get; set; }

    public string CompanyZipCode { get; set; }

    public string CompanyCity { get; set; } = "";
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
				listPage.Add(new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Address, companies[i].Currency, companies[i].Address.Id, 1));
			}

		return listPage;
	}

	public static CompanyScreenList GetCompanyScreenListFromName(string CompanyName)
	{
		Address tempaddress = new Address(0,"","","","","");
		CompanyScreenList companyScreenList = new(0, "", tempaddress, "", 0, 0);

		var companies = DatabaseServer.FetchCompanies();

		for (var i = 0; i < companies.Count; i++)
			if (companies[i].CompanyName == CompanyName)
			{
				companyScreenList = new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Address, companies[i].Currency, companies[i].Address.Id,
					1);
			}

		return companyScreenList;
	}
}
