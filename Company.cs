namespace H1_ERP_System;

public class Company
{
	private int Id { get; }
	private string CompanyName { get; }
	
	private Address Address { get; }
	
	private string Currency { get; }

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
	
	public override string ToString()
	{
		return $"Id={Id}, CompanyName={CompanyName}, Address={Address}, Currency={Currency}";
	}
}
