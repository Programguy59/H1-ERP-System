using System.Data.SqlClient;
using H1_ERP_System.company;
using H1_ERP_System.db;
using H1_ERP_System.products;
using H1_ERP_System.src.customer;
using H1_ERP_System.src.ui.Company;

namespace H1_ERP_System.util;

public class DatabaseServer
{
	private static SqlConnection? _connection;

	public static void Initialize()
	{
		// Fetch data from database.
		var companies = FetchCompanies();
		var products = FetchProducts();
		var customers = FetchCustomers();

		// Insert data into local database.
		companies.ForEach(Database.InsertCompany);
		products.ForEach(Database.InsertProduct);
		customers.ForEach(Database.InsertCustomer);
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
			var streetName = reader.GetString(2);
			var streetNumber = reader.GetString(3);
			var zipCode = reader.GetString(4);
			var city = reader.GetString(5);
			var country = reader.GetString(6);

			var currency = reader.GetString(7);

			var company = new Company(id, companyName, streetName, streetNumber, zipCode, city, country, currency);

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

	public static List<Customer> FetchCustomers()
	{
		var customers = new List<Customer>();

		const string query = "SELECT * FROM Persons " +
							 "JOIN Customers ON Persons.Id = Customers.PersonID";

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

			var address = new Address(reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
			var customer = new Customer(reader.GetInt32(10).ToString(), reader.GetDateTime(12).ToShortDateString(), id, firstName, lastName, address, email, phoneNumber);

			customers.Add(customer);
		}

		return customers;
	}

	public static void InsertCompany(CompanyScreenList CompanyData)
	{


		string query = $"UPDATE Companies " +
					   $"SET CompanyName = \'{CompanyData.CompanyName}\'," +
					   $"StreetName = \'{CompanyData.CompanyStreetName}\'," +
					   $"StreetNumber = \'{CompanyData.CompanyStreetNumber}\'," +
					   $"ZipCode = \'{CompanyData.CompanyZipCode}\'," +
					   $"City = \'{CompanyData.CompanyCity}\'," +
					   $"Country = \'{CompanyData.CompanyCountry}\'," +
					   $"Currency = \'{CompanyData.CompanyCurrency}\' " +
					   $"WHERE Id = \'{CompanyData.CompanyId}\'";

		using var connection = GetConnection();

		using var command = new SqlCommand(query, connection);
		command.ExecuteNonQuery();
	}
}

