using H1_ERP_System.util;
using System.Text.Encodings.Web;
using H1_ERP_System.ui;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreen : Screen
{
    public override string Title { get; set; } = "company info";
    string selectedCompanyName = CompanySetupScreen.selectedCompanyName;

    protected override void Draw()
    {
        Clear(this);
        ListPage<CompanyScreenList> ListPage = CompanyScreenList.GetPageListFromName(selectedCompanyName);

        ListPage.AddColumn("Company", "CompanyName");
        ListPage.AddColumn("Country", "CompanyCountry");
        ListPage.AddColumn("Street", "CompanyStreet");
        ListPage.AddColumn("Zipcode", "CompanyZipCode");
        ListPage.AddColumn("City", "CompanyCity");
        ListPage.AddColumn("Currency", "CompanyCurrency");
        CompanyScreenList selected = ListPage.Select();
        Console.Clear();



        Quit();
    }
}