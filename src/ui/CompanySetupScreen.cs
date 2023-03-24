using H1_ERP_System.company;
using H1_ERP_System.util;

namespace H1_ERP_System.ui;

using TECHCOOL.UI;
public class CompanySetup : Screen
{
    public override string Title { get; set; } = "company stuff";
    protected override void Draw()
    {
        Clear(this);
        ListPage<CompanySetupList> listPage = new ListPage<CompanySetupList>();
        listPage.Add(new CompanySetupList("techcollege","Denmark","DKK", 1));
        listPage.Add(new CompanySetupList("techcollege ok","Denmark","DKK", 1));
    
        listPage.AddColumn("Company", "CompanyName" );
        listPage.AddColumn("Country", "Country" );
        listPage.AddColumn("Currency", "Currency");
        
        
        CompanySetupList selected = listPage.Select(); 
        
        Console.WriteLine("You selected: "+selected.CompanyName);
        
        
        

    }
}