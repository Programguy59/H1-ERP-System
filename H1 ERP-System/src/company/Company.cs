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

	public Company(string companyName, Address address, string currency) : 
		this(-1, companyName, address, currency) { }

    public int Id { get; set; }

	public string CompanyName { get; set; }
	public Address Address { get; set; }

	public string Currency { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, CompanyName={CompanyName}, Address={Address}, Currency={Currency}";
	}
}
