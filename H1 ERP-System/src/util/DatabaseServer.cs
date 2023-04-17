using System.Data;
using System.Data.SqlClient;
using H1_ERP_System.company;
using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.products;
using H1_ERP_System.sales;

namespace H1_ERP_System.util;

/// <summary>
///     The database server manager, used to connect to the database and execute queries.
///     <seealso cref="DatabaseServer.Initialize()" />
///     <seealso cref="DatabaseServer.GetConnection()" />
///     <seealso cref="DatabaseServer.ExecuteQuery(string)" />
///     <seealso cref="DatabaseServer.ExecuteNonQuery(string)" />
///     <seealso cref="DatabaseServer.InsertAddress(Address)" />
///     <seealso cref="DatabaseServer.InsertPerson(Person)" />
///     <seealso cref="DatabaseServer.InsertCustomer(Customer)" />
///     <seealso cref="DatabaseServer.InsertCompany(Company)" />
///     <seealso cref="DatabaseServer.InsertProduct(Product)" />
///     <seealso cref="DatabaseServer.InsertOrderLine(OrderLine)" />
///     <seealso cref="DatabaseServer.InsertOrder(Order)" />
///     <seealso cref="DatabaseServer.FetchAddresses()" />
///     <seealso cref="DatabaseServer.FetchPersons()" />
///     <seealso cref="DatabaseServer.FetchCustomers()" />
///     <seealso cref="DatabaseServer.FetchCompanies()" />
///     <seealso cref="DatabaseServer.FetchProducts()" />
///     <seealso cref="DatabaseServer.FetchOrderLines()" />
///     <seealso cref="DatabaseServer.FetchOrders()" />
///     <seealso cref="DatabaseServer.UpdateAddress(Address)" />
///     <seealso cref="DatabaseServer.UpdatePerson(Person)" />
///     <seealso cref="DatabaseServer.UpdateCustomer(Customer)" />
///     <seealso cref="DatabaseServer.UpdateCompany(Company)" />
///     <seealso cref="DatabaseServer.UpdateProduct(Product)" />
///     <seealso cref="DatabaseServer.UpdateOrderLine(OrderLine)" />
///     <seealso cref="DatabaseServer.UpdateOrder(Order)" />
///     <seealso cref="DatabaseServer.DeleteAddress(Address)" />
///     <seealso cref="DatabaseServer.DeletePerson(Person)" />
///     <seealso cref="DatabaseServer.DeleteCustomer(Customer)" />
///     <seealso cref="DatabaseServer.DeleteCompany(Company)" />
///     <seealso cref="DatabaseServer.DeleteProduct(Product)" />
///     <seealso cref="DatabaseServer.DeleteOrderLine(OrderLine)" />
///     <seealso cref="DatabaseServer.DeleteOrder(Order)" />
/// </summary>
public static class DatabaseServer
{
	/// <summary>
	///     The connection to the database.
	/// </summary>
	private static SqlConnection? _connection;

	/// <summary>
	///     Load all data from the database and insert it into local lists.
	/// </summary>
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

	/// <summary>
	///     Get the connection to the database, or create a new one if it doesn't exist.
	/// </summary>
	/// <returns>The connection to the database.</returns>
	private static SqlConnection GetConnection()
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

	/// <summary>
	///     Execute a query and return the results.
	/// </summary>
	/// <param name="query">The query to execute.</param>
	/// <returns>The results of the query.</returns>
	private static SqlDataReader ExecuteQuery(string query)
	{
		var connection = GetConnection();
		var command = new SqlCommand(query, connection);

		try
		{
			// Get the results of the query.
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch
		{
			// Dispose of the connection and command objects before re-throwing the exception.
			connection.Dispose();
			command.Dispose();

			throw;
		}
	}

	/// <summary>
	///     Execute a query that doesn't return any results.
	/// </summary>
	/// <param name="query">The query to execute.</param>
	/// <returns>True if the query effected any rows, false otherwise.</returns>
	private static bool ExecuteNonQuery(string query)
	{
		using var connection = GetConnection();
		using var command = new SqlCommand(query, connection);

		// Return true if the query effected any rows.
		return command.ExecuteNonQuery() > 0;
	}

	/// <summary>
	///     Fetch all addresses from the database.
	/// </summary>
	/// <returns>A list of all addresses.</returns>
	private static List<Address> FetchAddresses()
	{
		var addresses = new List<Address>();

		const string query = "SELECT * FROM Addresses";

		using var reader = ExecuteQuery(query);

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

	/// <summary>
	///     Fetch all persons from the database.
	/// </summary>
	/// <returns>A list of all persons.</returns>
	private static List<Person> FetchPersons()
	{
		var persons = new List<Person>();

		const string query = "SELECT * FROM Persons";

		using var reader = ExecuteQuery(query);

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

	/// <summary>
	///     Fetch all customers from the database.
	/// </summary>
	/// <returns>A list of all customers.</returns>
	private static List<Customer> FetchCustomers()
	{
		var customers = new List<Customer>();

		const string query =
			"SELECT p.Id, " +
			"       c.Id, " +
			"       c.DateSinceLastPurchase " +
			"FROM Persons p " +
			"         JOIN Customers c ON p.Id = c.PersonId";

		using var reader = ExecuteQuery(query);

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

	/// <summary>
	///     Fetch all companies from the database.
	/// </summary>
	/// <returns>A list of all companies.</returns>
	private static List<Company> FetchCompanies()
	{
		var companies = new List<Company>();

		const string query = "SELECT * FROM Companies";

		using var reader = ExecuteQuery(query);

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

	/// <summary>
	///     Fetch all products from the database.
	/// </summary>
	/// <returns>A list of all products.</returns>
	public static List<Product> FetchProducts()
	{
		var products = new List<Product>();

		const string query = "SELECT * FROM Products";

		using var reader = ExecuteQuery(query);

		while (reader.Read())
		{
			var id = reader.GetInt32(0);

			var name = reader.GetString(1);
			var description = reader.GetString(2);

			var salesPrice = reader.GetSqlDecimal(3).ToDouble();
			var purchasePrice = reader.GetSqlDecimal(4).ToDouble();

			var location = reader.GetString(5);
			var stock = reader.GetSqlDecimal(6).ToDouble();

			var unit = reader.GetString(7).Of();

			var product = new Product(id, name, description, salesPrice, purchasePrice, location, stock, unit);

			products.Add(product);
		}

		return products;
	}

	/// <summary>
	///     Fetches all order lines from the database.
	/// </summary>
	/// <returns>A list of all order lines.</returns>
	private static List<OrderLine> FetchOrderLines()
	{
		var orderLines = new List<OrderLine>();

		const string query = "SELECT * FROM OrderLines";

		using var reader = ExecuteQuery(query);

		while (reader.Read())
		{
			var id = reader.GetInt32(0);

			var orderId = reader.GetInt32(1);
			var productId = reader.GetInt32(2);

			var product = Database.GetProductById(productId);

			if (product == null)
			{
				continue;
			}

			var quantity = Convert.ToDouble(reader.GetInt32(3));
			var orderLine = new OrderLine(id, orderId, product, quantity);

			orderLines.Add(orderLine);
		}

		return orderLines;
	}

	/// <summary>
	///     Fetches all orders from the database.
	/// </summary>
	/// <returns>A list of all orders.</returns>
	private static List<Order> FetchOrders()
	{
		var orders = new List<Order>();

		const string query =
			"SELECT * FROM Orders o";

		using var reader = ExecuteQuery(query);

		while (reader.Read())
		{
			var id = reader.GetInt32(0);

			var createdAt = reader.GetDateTime(1).ToShortDateString();
			var completedAt = reader.IsDBNull(2) ? "N/A" : reader.GetDateTime(2).ToShortDateString();

			var customerId = reader.GetInt32(3);

			var customer = Database.GetCustomerById(customerId);

			if (customer == null)
			{
				continue;

			}

			var orderStatus = OrderStatusExtensions.Of(reader.GetString(4));
			var order = new Order(id, createdAt, completedAt, customer, orderStatus);

			orders.Add(order);
		}

		return orders;
	}

	/// <summary>
	///     Inserts an address into the database.
	/// </summary>
	/// <param name="address">The address to insert.</param>
	/// <returns>True if the address was inserted successfully, false otherwise.</returns>
	public static bool InsertAddress(Address address)
	{
		var query =
			"INSERT INTO Addresses (StreetName, StreetNumber, City, ZipCode, Country) " +
			$"VALUES ('{address.StreetName}', '{address.StreetNumber}', '{address.City}', '{address.ZipCode}', '{address.Country}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Addresses.Add(address);

		return true;
	}

	/// <summary>
	///     Inserts a person into the database.
	/// </summary>
	/// <param name="person">The person to insert.</param>
	/// <returns>True if the person was inserted successfully, false otherwise.</returns>
	public static bool InsertPerson(Person person)
	{
		var query =
			"INSERT INTO Persons (FirstName, LastName, Email, PhoneNumber, AddressId) " +
			$"VALUES ('{person.FirstName}', '{person.LastName}', '{person.Email}', '{person.PhoneNumber}', '{person.Address.Id}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Persons.Add(person);

		return true;
	}

	/// <summary>
	///     Inserts a customer into the database.
	/// </summary>
	/// <param name="customer">The customer to insert.</param>
	/// <returns>True if the customer was inserted successfully, false otherwise.</returns>
	public static bool InsertCustomer(Customer customer)
	{
		var query =
			"INSERT INTO Customers (PersonId, DateSinceLastPurchase) " +
			$"VALUES ('{customer.Person.Id}', '{customer.DateSinceLastPurchase}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Customers.Add(customer);

		return true;
	}

	/// <summary>
	///     Inserts a company into the database.
	/// </summary>
	/// <param name="company">The company to insert.</param>
	/// <returns>True if the company was inserted successfully, false otherwise.</returns>
	public static bool InsertCompany(Company company)
	{
		var query =
			"INSERT INTO Companies (CompanyName, Currency, AddressId) " +
			$"VALUES ('{company.CompanyName}', '{company.Currency}', '{company.Address.Id}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Companies.Add(company);

		return true;
	}

	/// <summary>
	///     Inserts a product into the database.
	/// </summary>
	/// <param name="product">The product to insert.</param>
	/// <returns>True if the product was inserted successfully, false otherwise.</returns>
	public static bool InsertProduct(Product product)
	{
		var query =
			"INSERT INTO Products (Name, Description, SalesPrice, PurchasePrice, Location, Stock, Unit) " +
			$"VALUES ('{product.Name}', '{product.Description}', '{product.SalesPrice}', '{product.PurchasePrice}', '{product.Location}', '{product.Stock}', '{product.Unit}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Products.Add(product);

		return true;
	}

	/// <summary>
	///     Inserts an order line into the database.
	/// </summary>
	/// <param name="orderLine">The order line to insert.</param>
	/// <returns>True if the order line was inserted successfully, false otherwise.</returns>
	public static bool InsertOrderLine(OrderLine orderLine)
	{
		var query =
			"INSERT INTO OrderLines (OrderId, ProductId, Quantity) " +
			$"VALUES ('{orderLine.OrderId}', '{orderLine.Product.Id}', '{orderLine.Quantity}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.OrderLines.Add(orderLine);

		return true;
	}

	/// <summary>
	///     Inserts an order into the database.
	/// </summary>
	/// <param name="order">The order to insert.</param>
	/// <returns>True if the order was inserted successfully, false otherwise.</returns>
	public static bool InsertOrder(Order order)
	{
		var query =
			"INSERT INTO Orders (CreatedAt, CompletedAt, CustomerId, OrderStatus) " +
			$"VALUES ('{order.CreatedAt}', '{order.CompletedAt}', '{order.Customer.Id}', '{order.OrderStatus}')";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Orders.Add(order);

		return true;
	}

	/// <summary>
	///     Updates an address in the database.
	/// </summary>
	/// <param name="address">The address to update.</param>
	/// <returns>True if the address was updated successfully, false otherwise.</returns>
	public static bool UpdateAddress(Address address)
	{
		var query =
			"UPDATE Addresses " +
			$"SET StreetName = '{address.StreetName}', StreetNumber = '{address.StreetNumber}', City = '{address.City}', ZipCode = '{address.ZipCode}', Country = '{address.Country}' " +
			$"WHERE Id = '{address.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Addresses.FindIndex(a => a.Id == address.Id);
		Database.Addresses[index] = address;

		return true;
	}

	/// <summary>
	///     Updates a person in the database.
	/// </summary>
	/// <param name="person">The person to update.</param>
	/// <returns>True if the person was updated successfully, false otherwise.</returns>
	/// <seealso cref="UpdateAddress" />
	public static bool UpdatePerson(Person person)
	{
		if (!UpdateAddress(person.Address))
		{
			return false;
		}

		var query =
			"UPDATE Persons " +
			$"SET FirstName = '{person.FirstName}', LastName = '{person.LastName}', Email = '{person.Email}', PhoneNumber = '{person.PhoneNumber}', AddressId = '{person.Address.Id}' " +
			$"WHERE Id = '{person.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Persons.FindIndex(p => p.Id == person.Id);
		Database.Persons[index] = person;

		return true;
	}

	/// <summary>
	///     Updates a customer in the database.
	/// </summary>
	/// <param name="customer">The customer to update.</param>
	/// <returns>True if the customer was updated successfully, false otherwise.</returns>
	/// <seealso cref="UpdatePerson" />
	public static bool UpdateCustomer(Customer customer)
	{
		if (!UpdatePerson(customer.Person))
		{
			return false;
		}

		// DateSinceLastPurchase is a string, so we need to convert it to a DateTime, it's possible it's null.
		var dateSinceLastPurchase =
			customer.DateSinceLastPurchase.Trim() == "N/A"
				? DateTime.MinValue
				: DateTime.Parse(customer.DateSinceLastPurchase);

		// Query to update the customer.
		var query =
			"UPDATE Customers " +
			$"SET PersonId = '{customer.Person.Id}', DateSinceLastPurchase = '{dateSinceLastPurchase}' " +
			$"WHERE Id = '{customer.CustomerId}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Customers.FindIndex(c => c.Id == customer.Id);
		Database.Customers[index] = customer;

		return true;
	}

	/// <summary>
	///     Updates a company in the database.
	/// </summary>
	/// <param name="company">The company to update.</param>
	/// <returns>True if the company was updated successfully, false otherwise.</returns>
	/// <seealso cref="UpdateAddress" />
	public static bool UpdateCompany(Company company)
	{
		if (!UpdateAddress(company.Address))
		{
			return false;
		}

		var query =
			"UPDATE Companies " +
			$"SET CompanyName = '{company.CompanyName}', Currency = '{company.Currency}', AddressId = '{company.Address.Id}' " +
			$"WHERE Id = '{company.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Companies.FindIndex(c => c.Id == company.Id);
		Database.Companies[index] = company;

		return true;
	}

	/// <summary>
	///     Updates a product in the database.
	/// </summary>
	/// <param name="product">The product to update.</param>
	/// <returns>True if the product was updated successfully, false otherwise.</returns>
	public static bool UpdateProduct(Product product)
	{
		var query =
			"UPDATE Products " +
			$"SET Name = '{product.Name}', Description = '{product.Description}', SalesPrice = '{product.SalesPrice}', PurchasePrice = '{product.PurchasePrice}', Location = '{product.Location}', Stock = '{product.Stock}', Unit = '{product.Unit}' " +
			$"WHERE Id = '{product.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Products.FindIndex(p => p.Id == product.Id);
		Database.Products[index] = product;

		return true;
	}

	/// <summary>
	///     Updates an order line in the database.
	/// </summary>
	/// <param name="orderLine">The order line to update.</param>
	/// <returns>True if the order line was updated successfully, false otherwise.</returns>
	public static bool UpdateOrderLine(OrderLine orderLine)
	{
		var query =
			"UPDATE OrderLines " +
			$"SET ProductId = '{orderLine.Product.Id}', Quantity = '{orderLine.Quantity}' " +
			$"WHERE Id = '{orderLine.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.OrderLines.FindIndex(o => o.Id == orderLine.Id);
		Database.OrderLines[index] = orderLine;

		return true;
	}

	/// <summary>
	///     Updates an order in the database.
	/// </summary>
	/// <param name="order">The order to update.</param>
	/// <returns>True if the order was updated successfully, false otherwise.</returns>
	public static bool UpdateOrder(Order order)
	{
		var query =
			"UPDATE Orders " +
			$"SET CreatedAt = '{order.CreatedAt}', CompletedAt = '{order.CompletedAt}', CustomerId = '{order.Customer.Id}', OrderStatus = '{order.OrderStatus}' " +
			$"WHERE Id = '{order.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		var index = Database.Orders.FindIndex(o => o.Id == order.Id);
		Database.Orders[index] = order;

		return true;
	}

	/// <summary>
	///     Delete an address from the database.
	/// </summary>
	/// <param name="address">The address to delete.</param>
	/// <returns>True if the address was deleted successfully, false otherwise.</returns>
	public static bool DeleteAddress(Address address)
	{
		var query =
			"DELETE FROM Addresses " +
			$"WHERE Id = '{address.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Addresses.Remove(address);

		return true;
	}

	/// <summary>
	///     Delete a person from the database.
	/// </summary>
	/// <param name="person">The person to delete.</param>
	/// <returns>True if the person was deleted successfully, false otherwise.</returns>
	public static bool DeletePerson(Person person)
	{
		var query =
			"DELETE FROM Persons " +
			$"WHERE Id = '{person.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Persons.Remove(person);

		return true;
	}

	/// <summary>
	///     Delete a customer from the database.
	/// </summary>
	/// <param name="customer">The customer to delete.</param>
	/// <returns>True if the customer was deleted successfully, false otherwise.</returns>
	public static bool DeleteCustomer(Customer customer)
	{
		var query =
			"DELETE FROM Customers " +
			$"WHERE Id = '{customer.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Customers.Remove(customer);

		return true;
	}

	/// <summary>
	///     Delete a company from the database.
	/// </summary>
	/// <param name="company">The company to delete.</param>
	/// <returns>True if the company was deleted successfully, false otherwise.</returns>
	public static bool DeleteCompany(Company company)
	{
		var query =
			"DELETE FROM Companies " +
			$"WHERE Id = '{company.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Companies.Remove(company);

		return true;
	}

	/// <summary>
	///     Delete a product from the database.
	/// </summary>
	/// <param name="product">The product to delete.</param>
	/// <returns>True if the product was deleted successfully, false otherwise.</returns>
	public static bool DeleteProduct(Product product)
	{
		var query =
			"DELETE FROM Products " +
			$"WHERE Id = '{product.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Products.Remove(product);

		return true;
	}

	/// <summary>
	///     Delete an order line from the database.
	/// </summary>
	/// <param name="orderLine">The order line to delete.</param>
	/// <returns>True if the order line was deleted successfully, false otherwise.</returns>
	public static bool DeleteOrderLine(OrderLine orderLine)
	{
		var query =
			"DELETE FROM OrderLines " +
			$"WHERE Id = '{orderLine.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.OrderLines.Remove(orderLine);

		return true;
	}

	/// <summary>
	///     Delete an order from the database.
	/// </summary>
	/// <param name="order">The order to delete.</param>
	/// <returns>True if the order was deleted successfully, false otherwise.</returns>
	public static bool DeleteOrder(Order order)
	{
		var query =
			"DELETE FROM Orders " +
			$"WHERE Id = '{order.Id}'";

		// If the query fails, return false.
		if (!ExecuteNonQuery(query))
		{
			return false;
		}

		// Update the local cache.
		Database.Orders.Remove(order);

		return true;
	}
}
