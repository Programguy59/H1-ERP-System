using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreenList
{
	public CustomerScreenList(int id, string firstName, string lastName, string email, string phoneNumber,
		Address address, Order? lastOrder)
	{
		Id = id;

		FirstName = firstName;
		LastName = lastName;

		Email = email;
		PhoneNumber = phoneNumber;

		Address = address;
		LastOrder = lastOrder;

		// Define the properties that are not in the constructor.
		StreetName = Address.StreetName;
		StreetNumber = Address.StreetNumber;
		ZipCode = Address.ZipCode;
		City = Address.City;
		Country = Address.Country;
	}

	public int Id { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public string Email { get; set; }
	public string PhoneNumber { get; set; }

	public Address Address { get; set; }
	public Order? LastOrder { get; set; }

	public string StreetName { get; set; }
	public string StreetNumber { get; set; }
	public string ZipCode { get; set; }
	public string City { get; set; }
	public string Country { get; set; }

	public string FormattedName => $"{FirstName} {LastName}";

	public string FormattedAddress =>
		$"{Address.StreetName} {Address.StreetNumber}, {Address.ZipCode} {Address.City}, {Address.Country}";

	public string FormattedLastOrderDate => LastOrder?.CreatedAt?.ToShortDateString() ?? "No orders";
	
	public static ListPage<CustomerScreenList> GetPageListFromId(int id)
	{
		var listPage = new ListPage<CustomerScreenList>();

		var customer = Database.GetCustomerById(id);

		if (customer == null)
		{
			return listPage;
		}

		var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);

		listPage.Add(new CustomerScreenList(
			customer.CustomerId,
			customer.FirstName,
			customer.LastName,
			customer.Email,
			customer.PhoneNumber,
			customer.Address,
			lastOrder));

		return listPage;
	}

	public static CustomerScreenList? GetCustomerScreenListFromId(int id)
	{
		var customer = Database.GetCustomerById(id);

		if (customer == null)
		{
			return null;
		}

		var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);

		return new CustomerScreenList(
			customer.CustomerId,
			customer.FirstName,
			customer.LastName,
			customer.Email,
			customer.PhoneNumber,
			customer.Address,
			lastOrder);
	}

	public static void MakeCustomerButton(CustomerScreenList customer)
	{
		Address tempAddress = new("", "", "", "", "");
		DatabaseServer.InsertAddress(tempAddress);

		Person tempPerson = new("", "", "", "", tempAddress);
		DatabaseServer.InsertPerson(tempPerson);

		Customer tempCustomer = new(tempPerson, null);
		DatabaseServer.InsertCustomer(tempCustomer);


		Screen.Display(new CustomerEditScreen(tempCustomer.CustomerId));
	}

	public static void EditCustomerButton(CustomerScreenList customer)
	{
		Screen.Display(new CustomerEditScreen(customer.Id));
	}

	public static ListPage<CustomerScreenList> GetPageList()
	{
		var listPage = new ListPage<CustomerScreenList>();

        listPage.AddKey(ConsoleKey.F1, MakeCustomerButton);
        listPage.AddKey(ConsoleKey.F2, EditCustomerButton);

        var customers = Database.GetAllCustomers();

		foreach (var customer in customers)
		{
			var person = customer.Person;
			var address = person.Address;

			var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);

			listPage.Add(new CustomerScreenList(
				customer.CustomerId,
				person.FirstName,
				person.LastName,
				person.Email,
				person.PhoneNumber,
				address,
				lastOrder
			));
		}

		return listPage;
	}
}
