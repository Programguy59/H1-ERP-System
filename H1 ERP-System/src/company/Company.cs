using H1_ERP_System.util;

namespace H1_ERP_System.company;

public class Company
{
	public Company(string companyName, Address address, string currency)
	{
		CompanyName = companyName;
		Address = address;

		Currency = currency;
	}

	public int Id { get; set; } = -1;

	public string CompanyName { get; set; }
	public Address Address { get; set; }

	public string Currency { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, CompanyName={CompanyName}, Address={Address}, Currency={Currency}";
	}
}
