using H1_ERP_System.src.ui.Company;
using H1_ERP_System.util;
using TECHCOOL.UI;
using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.src.ui.sale;
using H1_ERP_System.customer;
using H1_ERP_System.products;
using System.Data;

namespace H1_ERP_System.ui.sale;

public class SalesList
{
	public SalesList(int id, string date, Person customer, double totalPrice)
	{
		Id = id;
		Date = date;

		CustomerId = customer.Id;

		CustomerFullName = customer.FullName;
        CustomerfirstName = customer.FirstName;
        CustomerlastName = customer.LastName;

        CustomerStreetName = customer.Address.StreetName;
        CustomerHouseNumber = customer.Address.StreetNumber;
        CustomerZipCode = customer.Address.ZipCode;
        CustomerCity = customer.Address.City;

        CustomerPhoneNumber = customer.PhoneNumber;
        CustomerEmail = customer.Email;

        

		TotalPrice = totalPrice;
	}

	public int Id { get; }

	public string Date { get; }
	public int CustomerId { get; }
	public string CustomerFullName { get; }
    public string CustomerfirstName { get; }
    public string CustomerlastName { get; }
    public string CustomerStreetName { get; }
    public string CustomerHouseNumber { get; }
    public string CustomerZipCode { get; }
    public string CustomerCity { get; }
    public string CustomerPhoneNumber { get; }
    public string CustomerEmail { get; }
    public double TotalPrice { get; }


    public static SalesList GetSalesScreenListFromId(int SalesId)
    {
        var Order = Database.GetOrderById(SalesId);
        var Customers = Database.GetOrderById(SalesId);

        SalesList salesList = new(
                    Order.Id,
                    Order.CreatedAt,
                    Order.Customer,
                    Order.TotalPrice
                    );

        return salesList;
    }

    public static void MakeSalesButton(SalesList sales)
    {
        Address tempAddress = new("", "", "", "", "");
        Person tempPerson = new("", "", "", "", tempAddress);
        Customer tempCustomer = new(tempPerson, "");

        Order newOrder = new("", "", tempCustomer, OrderStatus.Created);

        DatabaseServer.InsertOrder(newOrder);
        DatabaseServer.InsertCustomer(tempCustomer);

        var AllOrders = Database.GetAllOrders();
        //for (int i; i > AllOrders.Count; i++) 
        //{ if (AllOrders[i].Customer.FirstName == ""); }

        //CompanySetupScreen.SelectedOrderId = newOrder.Id;
        //Screen.Display(new SalesEditDataScreen(newCompanyId));
    }
    public static void EditSalesButton(SalesList sale)
    {
        Screen.Display(new SalesEditDataScreen(sale.Id));
    }

    public static ListPage<SalesList> GetPageList()
    {
        var listPage = new ListPage<SalesList>();
        listPage.AddKey(ConsoleKey.F1, MakeSalesButton);
        listPage.AddKey(ConsoleKey.F2, EditSalesButton);

        var SalesOrder = Database.GetAllOrders();
        for (var i = 0; i < SalesOrder.Count; i++)
            listPage.Add(new SalesList(
                    SalesOrder[i].Id,
                    SalesOrder[i].CreatedAt,
                    SalesOrder[i].Customer,
                    SalesOrder[i].TotalPrice
                    ));

        return listPage;
    }

}


