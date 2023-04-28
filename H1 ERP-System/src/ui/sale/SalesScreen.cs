using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesScreen : Screen
{
	public override string Title { get; set; } = "Sale";
    private readonly int _selectedSalesId;

    public SalesScreen(int saleId) 
	{
		_selectedSalesId = saleId;
	}
    
	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var listPage = SalesList.GetPageListFromId(_selectedSalesId);
		
		// If the list page is null, return.
		if (listPage == null)
		{
			return;
		}
		
        // Display customer details.
		listPage.AddColumn("Order ID", "Id");
		listPage.AddColumn("Date", "Date");
		listPage.AddColumn("Customer ID", "CustomerId");
		listPage.AddColumn("Name", "CustomerFullName");

		listPage.Select();

        TechCoolUtils.Clear(this);

        Display(new Menu.MenuScreen());
    }
}
