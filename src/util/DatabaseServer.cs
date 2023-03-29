using System.Data.SqlClient;
using H1_ERP_System.company;
using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.products;
using H1_ERP_System.sales;
using H1_ERP_System.src.ui.Company;

namespace H1_ERP_System.util;

public static class DatabaseServer
{
	private static SqlConnection? _connection;

	public static void Initialize()
	{
		var addresses = FetchAddresses();
		addresses.ForEach(Database.InsertAddress);
		
		var persons = FetchPersons();
		persons.ForEach(Database.InsertPerson);
		
		var customers = FetchCustomers();
		customers.ForEach(Database.InsertCustomer);
		
		var companies = FetchCompanies();
		companies.ForEach(Database.InsertCompany);
		
		var products = FetchProducts();
		products.ForEach(Database.InsertProduct);
		
		var orderLines = FetchOrderLines();
		orderLines.ForEach(Database.InsertOrderLine);
		
		var orders = FetchOrders();
		orders.ForEach(Database.InsertOrder);
	}

	public static SqlConnection GetConnection()
	{
		SqlConnectionStringBuilder sb = new()
		{
			DataSource = "docker.data.techcollege.dk",
			InitialCatalog = "H1PD021123_Gruppe3",
			UserID = "H1PD021123_Gruppe3",
			Password = "H1PD021123_Gruppe3"
		};

		var connectionString = sb.ToString();

		_connection = new SqlConnection(connectionString);
		_connection.Open();

		return _connection;
	}

	public static List<Address> FetchAddresses()
	{
		var addresses = new List<Address>();
		
		const string query = "SELECT * FROM Addresses";
		
		using var connection = GetConnection();
		
		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();
		
		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			
			var streetName = reader.GetString(1);
			var streetNumber = reader.GetString(2);
			
			var zipCode = reader.GetString(3);
			var city = reader.GetString(4);
			
			var country = reader.GetString(5);
			
			var address = new Address(id, streetName, streetNumber, zipCode, city, country);
			
			addresses.Add(address);
		}
		
		return addresses;
	}

	public static List<Person> FetchPersons()
	{
		var persons = new List<Person>();
		
		const string query = "SELECT * FROM Persons";
		
		using var connection = GetConnection();
		
		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();
		
		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			
			var firstName = reader.GetString(1);
			var lastName = reader.GetString(2);
			
			var email = reader.GetString(3);
			var phoneNumber = reader.GetString(4);
			
			var addressId = reader.GetInt32(5);
			
			var address = Database.GetAddressById(addressId);
			if (address == null)
			{
				continue;
			}
			
			var person = new Person(id, firstName, lastName, email, phoneNumber, address);
			
			persons.Add(person);
		}
		
		return persons;
	}
	
	public static List<Customer> FetchCustomers()
	{
		var customers = new List<Customer>();

		const string query =
			"SELECT p.Id, " +
			"       c.Id, " +

			"       c.DateSinceLastPurchase " +
			"FROM Persons p " +
			"         JOIN Customers c ON p.Id = c.PersonId";
		
		using var connection = GetConnection();

		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();
		
		while (reader.Read())
		{
			var personId = reader.GetInt32(0);
			var customerId = reader.GetInt32(1);
			
			var dateSinceLastPurchase = reader.GetDateTime(2).ToShortDateString();

			var person = Database.GetPersonById(personId);
			if (person == null)
			{
				continue;
			}
			
			var customer = new Customer(customerId, person, dateSinceLastPurchase);

			customers.Add(customer);
		}
		
		return customers;
	}
	
	public static List<Company> FetchCompanies()
	{
		var companies = new List<Company>();
		
		const string query = "SELECT * FROM Companies";
		
		using var connection = GetConnection();
		
		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();

		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			
			var companyName = reader.GetString(1);
			var currency = reader.GetString(2);

			var addressId = reader.GetInt32(3);
			
			var address = Database.GetAddressById(addressId);
			if (address == null)
			{
				continue;
			}
			
			var company = new Company(id, companyName, address, currency);
			
			companies.Add(company);
		}

		return companies;
	}
	
	public static List<Product> FetchProducts()
	{
		var products = new List<Product>();

		const string query = "SELECT * FROM Products";

		using var connection = GetConnection();

		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();

		while (reader.Read())
		{
			var id = reader.GetInt32(0);

			var name = reader.GetString(1);
			var description = reader.GetString(2);

			var salesPrice = reader.GetSqlDecimal(3).ToDouble();
			var purchasePrice = reader.GetSqlDecimal(4).ToDouble();

			var location = reader.GetString(5);
			var stock = reader.GetSqlDecimal(6).ToDouble();

			var unit = UnitExtensions.Of(reader.GetString(7));

			var product = new Product(id, name, description, salesPrice, purchasePrice, location, stock, unit);

			products.Add(product);
		}

		return products;
	}
	
	public static List<OrderLine> FetchOrderLines()
	{
		var orderLines = new List<OrderLine>();
		
		const string query = "SELECT * FROM OrderLines";
		
		using var connection = GetConnection();
		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();
		
		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			
			var productId = reader.GetInt32(1);
			var quantity = reader.GetInt32(2);
			
			var orderLine = new OrderLine(id, productId, quantity);
			
			orderLines.Add(orderLine);
		}
		
		return orderLines;
	}
	
	public static List<Order> FetchOrders() 
	{
		var orders = new List<Order>();
		
		const string query = "SELECT * FROM Orders o " + 
		                     "JOIN OrderLines ol ON o.OrderLineId = ol.Id " + 
		                     "JOIN Products p ON ol.ProductId = p.Id";
		
		using var connection = GetConnection();
		using var command = new SqlCommand(query, connection);
		using var reader = command.ExecuteReader();

		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			
			var createdAt = reader.GetDateTime(1).ToShortDateString();
			var completedAt = reader.IsDBNull(2) ? "N/A" : reader.GetDateTime(2).ToShortDateString();
			
			var customerId = reader.GetInt32(3).ToString();
			
			var orderStatus = OrderStatusExtensions.Of(reader.GetString(4));
			
			var orderLineId = reader.GetInt32(5);
			
			var orderLine = Database.GetOrderLineById(orderLineId);
			if (orderLine == null)
			{
				continue;
			}
			
			var product = Database.GetProductById(orderLine.ProductId);
			if (product == null)
			{
				continue;
			}
			
			var order = new Order(id, createdAt, completedAt, customerId, orderStatus);
			
			orders.Add(order);
		}
		
		return orders;
	}
	
	public static void InsertCompany(CompanyScreenList companyData)
	{
		var query = 
			"INSERT INTO Companies (CompanyName, Currency, AddressId) " + 
			$"VALUES ('{companyData.CompanyName}', '{companyData.CompanyCurrency}', {companyData.AddressId})";
		
		using var connection = GetConnection();
		using var command = new SqlCommand(query, connection);
		
		command.ExecuteNonQuery();
	}
}
