using System.Data.SqlClient;
using H1_ERP_System.company;
using H1_ERP_System.products;

namespace H1_ERP_System.util;

public class DatabaseServer
{
	private static SqlConnection _connection;

	public static SqlConnection GetConnection()
	{
		if (_connection != null)
		{
			return _connection;
		}

		SqlConnectionStringBuilder sb = new()
		{
			DataSource = "docker.data.techcollege.dk",
			InitialCatalog = "H1PD021123_Gruppe3",
			UserID = "H1PD021123_Gruppe3",
			Password = "H1PD021123_Gruppe3"
		};

		var connectionString = sb.ToString();
		_connection = new SqlConnection(connectionString);

		return _connection;
	}

	public static List<Company> FetchCompanies()
	{
		var companies = new List<Company>();

		const string query = "SELECT * FROM Companies";

		using var connection = GetConnection();

		connection.Open();

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

		connection.Open();

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
}
