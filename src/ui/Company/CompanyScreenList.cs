using H1_ERP_System.src.Company;
using H1_ERP_System.util;
using Org.BouncyCastle.Crypto.Prng;
using System.ComponentModel.DataAnnotations;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreenList
{
    public enum CompanyScreen { Todo, Started, Done }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
    public string CompanyCountry { get; set; } = "";

    public string CompanyStreetName { get; set; } = "";

    public int CompanyStreetNumber { get; set; }

    public int CompanyZipCode { get; set; }

    public string CompanyCity { get; set; } = "";
    public string CompanyCurrency { get; set; } = "";
    public int Priority { get; set; }



    public CompanyScreen State { get; set; }

    public CompanyScreenList(int id, string companyName, string companyCountry, string companyStreetName, int companyStreetNumber, int companyZipCode, string companyCity, string companyCurrency, int priority)
    {
        CompanyId = id;
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyStreetName = companyStreetName;
        CompanyStreetNumber = companyStreetNumber;
        CompanyZipCode = companyZipCode;
        CompanyCity = companyCity;
        CompanyCurrency = companyCurrency;
        Priority = priority;

    }
    static void something(CompanyScreenList i)
    {
        Screen.Display(new CompanyEditDataScreen());
    }

    public static ListPage<CompanyScreenList> GetPageListFromName(string CompanyName)
    {

        ListPage<CompanyScreenList> listPage = new ListPage<CompanyScreenList>();
        listPage.AddKey(ConsoleKey.F1, something);
        var Companies = DatabaseServer.FetchCompanies();
        for (int i = 0; i < Companies.Count; i++)
        {
            if (Companies[i].CompanyName == CompanyName) {
                listPage.Add(new CompanyScreenList(Companies[i].Id,Companies[i].CompanyName, Companies[i].Address.Country, Companies[i].Address.StreetName, Convert.ToInt32(Companies[i].Address.StreetNumber), Convert.ToInt32(Companies[i].Address.ZipCode), Companies[i].Address.City,
              Companies[i].Currency, 1));
            }
        }
        return listPage;
    }
    public static CompanyScreenList GetCompanyScreenListFromName(string CompanyName)
    {
        CompanyScreenList companyScreenList = new(0,"","","",0,0,"","",1);
        var Companies = DatabaseServer.FetchCompanies();
        for (int i = 0; i < Companies.Count; i++)
        {
            if (Companies[i].CompanyName == CompanyName)
            {
                companyScreenList = new CompanyScreenList(Companies[i].Id,Companies[i].CompanyName, Companies[i].Address.Country, Companies[i].Address.StreetName, Convert.ToInt32(Companies[i].Address.StreetNumber), Convert.ToInt32(Companies[i].Address.ZipCode), Companies[i].Address.City,
              Companies[i].Currency, 1);
            }
        }
        return companyScreenList;
    }
}

