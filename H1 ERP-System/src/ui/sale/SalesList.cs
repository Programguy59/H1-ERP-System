﻿using H1_ERP_System.util;
using TECHCOOL.UI;
using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.customer;
using H1_ERP_System.ui.customer;

namespace H1_ERP_System.ui.sale;

public class SalesList
{
	public SalesList(int id, string date, Customer customer, double totalPrice)
	{
		Id = id;
		Date = date;

		CustomerId = customer.CustomerId;
		
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
        DatabaseServer.InsertAddress(tempAddress);

        Person tempPerson = new("", "", "", "", tempAddress);
        DatabaseServer.InsertPerson(tempPerson);

        Customer tempCustomer = new(tempPerson, "");
        DatabaseServer.InsertCustomer(tempCustomer);

        Order newOrder = new("", "", tempCustomer, OrderStatus.Created);
        DatabaseServer.InsertOrder(newOrder);

        Screen.Display(new CustomerEditScreen(tempCustomer.CustomerId));
    }
    public static void EditSalesButton(SalesList sale)
    {
        Screen.Display(new CustomerEditScreen(sale.CustomerId));
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
