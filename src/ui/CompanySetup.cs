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
        ListPage<Company> listPage = new ListPage<Company>();
        listPage.Add(new Company(1, "e", new Address("fds","testStr", "testZip", "okCi","okCo"), "dkk"));
        listPage.AddColumn("", "");


        listPage.Draw();
    }
}