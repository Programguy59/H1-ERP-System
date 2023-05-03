using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.ui.customer;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.sale;

public class SalesList
{
	public SalesList(int id, DateTime? date, Customer customer, double totalPrice)
	{
		Id = id;

		Date = date;

		CustomerId = customer.CustomerId;

		CustomerFullName = customer.FullName;
		CustomerFirstName = customer.FirstName;
		CustomerLastName = customer.LastName;

		CustomerStreetName = customer.Address.StreetName;
		CustomerStreetNumber = customer.Address.StreetNumber;
		CustomerZipCode = customer.Address.ZipCode;
		CustomerCity = customer.Address.City;

		CustomerPhoneNumber = customer.PhoneNumber;
		CustomerEmail = customer.Email;

		TotalPrice = totalPrice;
	}

	public int Id { get; set; }

	public DateTime? Date { get; set; }
	public int CustomerId { get; set; }

	public string CustomerFullName { get; set; }
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }

	public string CustomerStreetName { get; set; }
	public string CustomerStreetNumber { get; set; }
	public string CustomerZipCode { get; set; }
	public string CustomerCity { get; set; }

	public string CustomerPhoneNumber { get; set; }
	public string CustomerEmail { get; set; }

	public double TotalPrice { get; set; }

	public static ListPage<SalesList>? GetPageListFromId(int orderId)
	{
		var listPage = new ListPage<SalesList>();

		var order = Database.GetOrderById(orderId);

		// If the order is null, just return.
		if (order == null)
		{
			return null;
		}

		listPage.Add(new SalesList(
			order.Id,
			order.CreatedAt,
			order.Customer,
			order.TotalPrice
		));

		return listPage;
	}

	public static SalesList? GetSalesScreenListFromId(int salesId)
	{
		var order = Database.GetOrderById(salesId);

		// If the order returns null, it's an invalid ID.
		if (order == null)
		{
			return null;
		}

		SalesList salesList = new(
			order.Id,
			order.CreatedAt,
			order.Customer,
			order.TotalPrice
		);

		return salesList;
	}

	public static void MakeSalesButton(SalesList sales)
	{
		Address tempAddress = new("", "", "", "", "");
		DatabaseServer.InsertAddress(tempAddress);

		Person tempPerson = new("", "", "", "", tempAddress);
		DatabaseServer.InsertPerson(tempPerson);

		Customer tempCustomer = new(tempPerson, null);
		DatabaseServer.InsertCustomer(tempCustomer);

		Order newOrder = new(null, null, tempCustomer, OrderStatus.Created);
		DatabaseServer.InsertOrder(newOrder);

		Screen.Display(new CustomerEditScreen(tempCustomer.CustomerId));
	}

	public static void EditSalesButton(SalesList sale)
	{
		Screen.Display(new CustomerEditScreen(sale.CustomerId));
	}

	public static void DeleteSales(SalesList sale)
	{
		var order = Database.GetOrderById(sale.Id);

		// If the order is null, just return.
		if (order == null)
		{
			return;
		}

		DatabaseServer.DeleteOrder(order);

		Screen.Display(new SaleSetupScreen());
		Screen.Display(new Menu.MenuScreen());
	}

	public static ListPage<SalesList> GetPageList()
	{
		var listPage = new ListPage<SalesList>();

		listPage.AddKey(ConsoleKey.F1, MakeSalesButton);
		listPage.AddKey(ConsoleKey.F2, EditSalesButton);
		listPage.AddKey(ConsoleKey.F5, DeleteSales);

		var orders = Database.GetAllOrders();

		foreach (var order in orders)
		{
			listPage.Add(new SalesList(
				order.Id,
				order.CreatedAt,
				order.Customer,
				order.TotalPrice
			));
		}

		return listPage;
	}
}
