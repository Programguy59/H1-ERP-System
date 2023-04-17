using H1_ERP_System.src.Company;
using H1_ERP_System.util;
using TECHCOOL.UI;
using System.Net.NetworkInformation;
using H1_ERP_System.db;

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



	public static ListPage<CompanyScreenList> GetPageListFromId(int CompanyId)
	{
		var listPage = new ListPage<CompanyScreenList>();


		var companies = Database.GetAllCompanies();

		for (var i = 0; i < companies.Count; i++)
			if (companies[i].Id == CompanyId)
			{
				listPage.Add(new CompanyScreenList(companies[i].Id, companies[i].CompanyName, companies[i].Address, companies[i].Currency, companies[i].Address.Id, 1));
			}

		return listPage;
	}

	public static CompanyScreenList GetCompanyScreenListFromId(int CompanyId)
	{
		Address tempAddress = new Address(0,"","","","","");
		CompanyScreenList companyScreenList = new(0, "", tempAddress, "", 0, 0);

		var companies = Database.GetAllCompanies();

		for (var i = 0; i < companies.Count; i++)
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

		return companyScreenList;
	}

    public static void MakeCompanyButton(CompanyScreenList company)
    {
        var Addresses = Database.GetAllAddresses();
        var Companies = Database.GetAllCompanies();

        int highestAddressId = 0;
        for (var i = 0; i < Addresses.Count; i++)
            if (Addresses[i].Id > highestAddressId){highestAddressId = Addresses[i].Id;}
        int highestCompanyId = 0;
        for (var i = 0; i < Companies.Count; i++)
            if (Companies[i].Id > highestCompanyId) { highestCompanyId = Companies[i].Id; }

        int newCompanyId = highestCompanyId + 1;
        int newAddressId = highestAddressId + 1;
        Address tempAddress = new Address(newAddressId, "", "", "", "", "");
        company.Company TempCompany = new(newCompanyId, "newCompany", tempAddress, "USD");
        DatabaseServer.InsertAddress(tempAddress);
        DatabaseServer.InsertCompany(TempCompany);
        CompanySetupScreen.SelectedCompanyId = TempCompany.CompanyName;
        Screen.Display(new CompanyEditDataScreen(newCompanyId));
    }
    public static void EditCompanyButton(CompanyScreenList company)
    {
        Screen.Display(new CompanyEditDataScreen(company.CompanyId));
    }
    
    public static ListPage<CompanyScreenList> GetPageList()
    {
        var listPage = new ListPage<CompanyScreenList>();
        listPage.AddKey(ConsoleKey.F1, MakeCompanyButton);
        listPage.AddKey(ConsoleKey.F2, EditCompanyButton);

        var Companies = Database.GetAllCompanies();
        for (var i = 0; i < Companies.Count; i++)
            listPage.Add(new CompanyScreenList(
                   Companies[i].Id,
                   Companies[i].CompanyName,
                   Companies[i].Address,
                   Companies[i].Currency,
                   Companies[i].Address.Id,
                    1));

        return listPage;
    }
}
