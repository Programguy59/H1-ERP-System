using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SaleSetupScreen : Screen
{
    public override string Title { get; set; } = "Sale";
    protected override void Draw()
    {
        var listPage = SalesList.GetPageList();

        listPage.AddColumn("Order ID", "Id");
        listPage.AddColumn("Date", "Date");
        listPage.AddColumn("Customer ID", "CustomerId");
        listPage.AddColumn("Name", "CustomerFullName");
        listPage.AddColumn("Total Price", "TotalPrice");
        
        var selected = listPage.Select();
        // If the user pressed escape or the list is empty, quit the screen.
        if (selected == null)
        {
            Quit();
			
            return;
        }
        
        TechCoolUtils.Clear(this);
        
        Display(new SalesScreen(selected.Id));
    }
}