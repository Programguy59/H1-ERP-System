using H1_ERP_System.company;
using H1_ERP_System.util;

namespace H1_ERP_System.src.ui.Company;

using System.CodeDom.Compiler;
using TECHCOOL.UI;
public class CompanySetupScreen : Screen
{
    public override string Title { get; set; } = "company setup";

    public static string selectedCompanyName;
    
    protected override void Draw()
    {
       
        Clear(this);
        ListPage<CompanySetupList> listPage = CompanySetupList.GetPageList();

        listPage.AddColumn("Company", "CompanyName");
        listPage.AddColumn("Country", "Country");
        listPage.AddColumn("Currency", "Currency");


        CompanySetupList selected = listPage.Select();

        selectedCompanyName = selected.CompanyName;
        Console.WriteLine("You selected: " + selected.CompanyName);
        Console.Clear();

        Quit();

        Display(new CompanyScreen());
    }
}