using H1_ERP_System.util;
using System.Text.Encodings.Web;
using H1_ERP_System.ui;
using TECHCOOL.UI;
using H1_ERP_System.src.Company;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreen : Screen
{
    public override string Title { get; set; } = "company info";
    string selectedCompanyName = CompanySetupScreen.selectedCompanyName;

    protected override void Draw()
    {
        Clear();
        ListPage<CompanyScreenList> ListPage = CompanyScreenList.GetPageListFromName(selectedCompanyName);

        ListPage.AddColumn("Company", "CompanyName");
        ListPage.AddColumn("Country", "CompanyCountry");
        ListPage.AddColumn("Street Name", "CompanyStreetName");
        ListPage.AddColumn("Street Number", "CompanyStreetNumber");
        ListPage.AddColumn("Zipcode", "CompanyZipCode");
        ListPage.AddColumn("City", "CompanyCity");
        ListPage.AddColumn("Currency", "CompanyCurrency");
        CompanyScreenList selected = ListPage.Select();


        Quit();
        Clear();
        
    }
}