using H1_ERP_System.customer;

namespace H1_ERP_System.db;

public partial class Database
{
	public static readonly List<Customer> Customers = new();
	
	public static Customer? GetCustomerById(int id)
	{
		return Customers.FirstOrDefault(customer => customer.CustomerId == id);
	}

	public static List<Customer> GetAllCustomers()
	{
		return Customers;
	}

	public static void InsertCustomer(Customer customer)
	{
		Customers.Add(customer);
	}

	public static bool UpdateCustomer(Customer customer, int id)
	{
		var existingCustomer = GetCustomerById(id);
		if (existingCustomer == null)
		{
			return false;
		}
		
		existingCustomer.CustomerId = customer.CustomerId;
		
		existingCustomer.FirstName = customer.FirstName;
		existingCustomer.LastName = customer.LastName;
		existingCustomer.FullName = customer.FirstName + " " + customer.LastName;

		existingCustomer.Email = customer.Email;
		existingCustomer.PhoneNumber = customer.PhoneNumber;

		existingCustomer.Address = customer.Address;

		return true;
	}

	public static bool DeleteCustomerById(int id)
	{
		var customerToDelete = GetCustomerById(id);
		if (customerToDelete == null)
		{
			return false;
		}

		Customers.Remove(customerToDelete);

		return true;
	}

	public static void ClearCustomers()
	{
		Customers.Clear();
	}
}
