using H1_ERP_System.src.customer;

namespace H1_ERP_System.db;

public partial class Database
{
    private static readonly List<Customer> Customers = new();
    private static int _nextCustomerId = 1;

    public static Customer? GetCustomerById(int id)
    {
        return Customers.FirstOrDefault(customer => customer.Id == id);
    }

    public static List<Customer> GetAllCustomers()
    {   
        return Customers;
    }

    public static void InsertCustomer(Customer customer)
    {
        customer.Id = _nextCustomerId++;

        Customers.Add(customer);
    }

    public static bool UpdateCustomer(Customer customer, int id)
    {
        var existingCustomer = GetCustomerById(id);

        if (existingCustomer == null)
        {
            return false;
        }

        existingCustomer.PersonFullName = customer.PersonFullName;
        existingCustomer.Address = customer.Address;
        existingCustomer.Email = customer.Email;

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
