using H1_ERP_System.company;
using H1_ERP_System.db;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.company;

public class CompanyScreenList
{
	public enum CompanyScreen
	{
		Todo,
		Started,
		Done
	}

	public CompanyScreenList(int id, string companyName, Address? address, string companyCurrency, int addressId,
		int priority)
	{
		CompanyId = id;
		CompanyName = companyName;
		CompanyCurrency = companyCurrency;

		AddressId = addressId;

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

	public string CompanyCountry { get; set; }
	public string CompanyStreetName { get; set; }
	public string CompanyStreetNumber { get; set; }
	public string CompanyZipCode { get; set; }
	public string CompanyCity { get; set; }

	public int Priority { get; set; }

	public CompanyScreen State { get; set; }


	public static ListPage<CompanyScreenList> GetPageListFromId(int CompanyId)
	{
		var listPage = new ListPage<CompanyScreenList>();


		var companies = Database.GetAllCompanies();

		for (var i = 0; i < companies.Count; i++)
		{
			if (companies[i].Id == CompanyId)
			{
				listPage.Add(new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Address,
					companies[i].Currency,
					companies[i].Address.Id, 1));
			}
		}

		return listPage;
	}

	public static CompanyScreenList GetCompanyScreenListFromId(int CompanyId)
	{
		var tempAddress = new Address("", "", "", "", "");
		CompanyScreenList companyScreenList = new(0, "", tempAddress, "", 0, 0);

		var companies = Database.GetAllCompanies();

		for (var i = 0; i < companies.Count; i++)
		{
			if (companies[i].Id == CompanyId)
			{
				companyScreenList = new CompanyScreenList(
					companies[i].Id,
					companies[i].CompanyName,
					companies[i].Address,
					companies[i].Currency,
					companies[i].Address.Id,
					1);
			}
		}

		return companyScreenList;
	}

	public static void MakeCompanyButton(CompanyScreenList company)
	{
		var tempAddress = new Address("", "", "", "", "");
		DatabaseServer.InsertAddress(tempAddress);

		var tempCompany = new Company("newCompany", tempAddress, "USD");
		DatabaseServer.InsertCompany(tempCompany);

		Screen.Display(new CompanyEditDataScreen(tempCompany.Id));
	}

	public static void EditCompanyButton(CompanyScreenList company)
	{
		Screen.Display(new CompanyEditDataScreen(company.CompanyId));
	}

	public static void DeleteCompany(CompanyScreenList companyList)
	{
		var company = Database.GetCompanyById(companyList.CompanyId);

		// If the company is null, return.
		if (company == null)
		{
			return;
		}

		// If the delete operation fails, show an error message.
		if (!DatabaseServer.DeleteCompany(company))
		{
			new ErrorScreen("Failed to delete company!");

			return;
		}

		Screen.Display(new CompanySetupScreen());
	}

	public static ListPage<CompanyScreenList> GetPageList()
	{
		var listPage = new ListPage<CompanyScreenList>();

		listPage.AddKey(ConsoleKey.F1, MakeCompanyButton);
		listPage.AddKey(ConsoleKey.F2, EditCompanyButton);
		listPage.AddKey(ConsoleKey.F5, DeleteCompany);

		var companies = Database.GetAllCompanies();

		foreach (var company in companies)
		{
			listPage.Add(new CompanyScreenList(
				company.Id,
				company.CompanyName,
				company.Address,
				company.Currency,
				company.Address.Id,
				1));
		}

		return listPage;
	}
}
