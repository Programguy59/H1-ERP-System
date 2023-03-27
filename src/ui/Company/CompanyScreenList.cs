using H1_ERP_System.util;
using Org.BouncyCastle.Crypto.Prng;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreenList
{
    public enum CompanyScreen { Todo, Started, Done }
    public string CompanyName { get; set; } = "";
    public string CompanyCountry { get; set; } = "";

    public string CompanyStreet { get; set; } = "";


    public string CompanyZipCode { get; set; } = "";

    public string CompanyCity { get; set; } = "";
    public string CompanyCurrency { get; set; } = "";
    public int Priority { get; set; }



    public CompanyScreen State { get; set; }

    public CompanyScreenList(string companyName, string companyCountry, string companyStreet, string companyZipCode, string companyCity, string companyCurrency, int priority)
    {
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyStreet = companyStreet;
        CompanyZipCode = companyZipCode;
        CompanyCity = companyCity;
        CompanyCurrency = companyCurrency;
        Priority = priority;

    }

    public static ListPage<CompanyScreenList> GetPageListFromName(string CompanyName)
    {
        ListPage<CompanyScreenList> listPage = new ListPage<CompanyScreenList>();
        var Companies = DatabaseServer.FetchCompanies();
        for (int i = 0; i < Companies.Count; i++)
        {
            if (Companies[i].CompanyName == CompanyName) {
                listPage.Add(new CompanyScreenList(Companies[i].CompanyName, Companies[i].Address.Country, Companies[i].Address.StreetName, Companies[i].Address.ZipCode, Companies[i].Address.City,
              Companies[i].Currency, 1));
            }
        }
        return listPage;
    }
}

