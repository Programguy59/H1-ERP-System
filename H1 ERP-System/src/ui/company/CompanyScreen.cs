using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.src.ui.Company;

public class CompanyScreen : Screen
{
    private readonly int selectedCompanyId = CompanySetupScreen.SelectedOrderId;
    public override string Title { get; set; } = "Company info";

    protected override void Draw()
    {
        TechCoolUtils.Clear(this);

        var ListPage = CompanyScreenList.GetPageListFromId(selectedCompanyId);

        ListPage.AddColumn("Company", "CompanyName");
        ListPage.AddColumn("Country", "CompanyCountry");
        ListPage.AddColumn("Street Name", "CompanyStreetName");
        ListPage.AddColumn("Street Number", "CompanyStreetNumber");
        ListPage.AddColumn("Zip Code", "CompanyZipCode");
        ListPage.AddColumn("City", "CompanyCity");
        ListPage.AddColumn("Currency", "CompanyCurrency");
        var selected = ListPage.Select();


        Quit();
        TechCoolUtils.Clear(this);
    }
}