using H1_ERP_System.util;

namespace H1_ERP_System.company;

public class Company
{
	public Company(int id, string companyName, Address address, string currency)
	{
		Id = id;
		CompanyName = companyName;

		Address = address;

		Currency = currency;
	}

	public Company(int id, string companyName, string streetName, string streetNumber, string zipCode, string city, string country, string currency)
	{
		Id = id;
		CompanyName = companyName;

		Address = new Address(streetName, streetNumber, zipCode, city, country);

		Currency = currency;
	}

	public int Id { get; set; }
	public string CompanyName { get; set; }
	public Address Address { get; set; }

	public string Currency { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, CompanyName={CompanyName}, Address={Address}, Currency={Currency}";
	}
}
