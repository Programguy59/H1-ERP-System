using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class CompanyScreen : Screen
{
    public override string Title { get; set; } = "company stuff";

    protected override void Draw()
    {
        Clear(this);
        ListPage<CompanyScreenList> listPage = new ListPage<CompanyScreenList>();
        listPage.Add(new CompanyScreenList("company test1", "country test", "street test", "zipcode test", "city test",
            "currency test", 1));
        
        listPage.Add(new CompanyScreenList("company test2", "country test", "street test", "zipcode test", "city test",
            "currency test", 1));
        
        listPage.AddColumn("Company", "CompanyName");
        listPage.AddColumn("Country", "CompanyCountry");
        listPage.AddColumn("Street", "CompanyStreet");
        listPage.AddColumn("Zipcode", "CompanyZipCode");
        listPage.AddColumn("City", "CompanyCity");
        listPage.AddColumn("Currency", "CompanyCurrency");

        CompanyScreenList selected = listPage.Select();

        Console.WriteLine("You selected: " + selected.CompanyName);



    }
}