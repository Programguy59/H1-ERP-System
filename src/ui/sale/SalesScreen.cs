using H1_ERP_System.db;
using H1_ERP_System.products;
using H1_ERP_System.sales;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesScreen : Screen
{
    public override string Title { get; set; } = "Salg";
	
    protected override void Draw()
    {
        Clear(this);
		
        // Display list of customers.
        var listPage = new ListPage<SalesList>();
		
        foreach (var order in Database.GetAllOrders())
        {
            var customer = Database.GetCustomerById(int.Parse(order.CustomerId));
            var salesList = new SalesList(order.Id, order.CreatedAt, customer.Id.ToString(), customer.PersonFullName, order.TotalPrice);
            listPage.Add(salesList);
        }
        
		listPage.AddColumn("Ordre ID", "Id");
		listPage.AddColumn("Dato", "CreatedAt");
		listPage.AddColumn("Kunde ID", "CustomerId");
		listPage.AddColumn("Fulde navn", "FullName");
		listPage.AddColumn("Total pris", "TotalPrice");
		
        var selected = listPage.Select();

        Console.Clear();
		
        // Display customer details.
        listPage = new ListPage<SalesList>();
		
        listPage.Add(selected);
		
        listPage.AddColumn("Ordre ID", "Id");
        listPage.AddColumn("Dato", "CreatedAt");
        listPage.AddColumn("Kunde ID", "CustomerId");
        listPage.AddColumn("Fulde navn", "FullName");

        listPage.Select();
		
        Quit();
    }
}
