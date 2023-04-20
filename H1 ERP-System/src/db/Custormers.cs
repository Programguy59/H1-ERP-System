using H1_ERP_System.customer;

namespace H1_ERP_System.db;

public static partial class Database
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
}
