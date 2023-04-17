using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreenList
{
	public CustomerScreenList(int id, string firstName, string lastName, string email, string phoneNumber, Address address, Order? lastOrder)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		
		Email = email;
		PhoneNumber = phoneNumber;
		
		Address = address;
		LastOrder = lastOrder;
	}
	
	public int Id { get; set; }
	
	public string FirstName { get; set; }
	public string LastName { get; set; }
	
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	
	public Address Address { get; set; }
	public Order? LastOrder { get; set; }
	
	public string FormattedName => $"{FirstName} {LastName}";
	public string FormattedAddress => $"{Address.StreetName} {Address.StreetNumber}, {Address.ZipCode} {Address.City}, {Address.Country}";
	public string FormattedLastOrderDate => LastOrder == null ? "N/A" : LastOrder.CreatedAt;
	
	public string StreetName => Address.StreetName;
	public string StreetNumber => Address.StreetNumber;
	public string ZipCode => Address.ZipCode;
	public string City => Address.City;
	public string Country => Address.Country;

	public static ListPage<CustomerScreenList> GetPageListFromId(int id)
	{
		var listPage = new ListPage<CustomerScreenList>();
		
		listPage.AddKey(ConsoleKey.F1, MakeCustomerButton);
		listPage.AddKey(ConsoleKey.F2, EditCustomerButton);
		
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
	    /*
        var Addresses = Database.GetAllAddresses();
        var Companies = Database.GetAllCompanies();

        int highestAddressId = 0;
        for (var i = 0; i < Addresses.Count; i++)
            if (Addresses[i].Id > highestAddressId){highestAddressId = Addresses[i].Id;}
        int highestCompanyId = 0;
        for (var i = 0; i < Companies.Count; i++)
            if (Companies[i].Id > highestCompanyId) { highestCompanyId = Companies[i].Id; }

        int newCompanyId = highestCompanyId + 1;
        int newAddressId = highestAddressId + 1;
        Address tempAddress = new Address(newAddressId, "", "", "", "", "");
        company.Company TempCompany = new(newCompanyId, "newCompany", tempAddress, "USD");
        DatabaseServer.InsertAddress(tempAddress);
        DatabaseServer.InsertCompany(TempCompany);
        CompanySetupScreen.SelectedCompanyName = TempCompany.CompanyName;
        Screen.Display(new CompanyEditDataScreen("newCompany"));
        */
    }
    public static void EditCustomerButton(CustomerScreenList customer)
    {
        Screen.Display(new CustomerEditScreen(customer.Id));
    }
    
    public static ListPage<CustomerScreenList> GetPageList()
    {
	    var listPage = new ListPage<CustomerScreenList>();
	    
	    var customers = Database.GetAllCustomers();
	    foreach (var customer in customers)
	    {
		    var person = customer.Person;
		    var address = person.Address;
		    
		    var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);
		    
		    listPage.Add(new CustomerScreenList(
			    customer.Id,
			    
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
