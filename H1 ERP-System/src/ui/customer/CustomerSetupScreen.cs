using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerSetupScreen : Screen
{
    public static int SelectedCustomerId;
    public override string Title { get; set; } = "Customer";

    protected override void Draw()
    {
        TechCoolUtils.Clear(this);

        var listPage = CustomerScreenList.GetPageList();


        listPage.AddColumn("ID", "Id");

        listPage.AddColumn("First Name", "FirstName");
        listPage.AddColumn("Last Name", "LastName");

        listPage.AddColumn("Phone Number", "PhoneNumber");
        listPage.AddColumn("Email", "Email");
        SelectedCustomerId = listPage.Select().Id;

        TechCoolUtils.Clear(this);
        Display(new CustomerScreen());
    }
}