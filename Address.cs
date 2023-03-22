namespace H1_ERP_System;

public class Address
{
	private string StreetName { get; }
	private string StreetNumber { get; }
	private string ZipCode { get; }
	private string City { get; }
	private string Country { get; }
	
	public Address(string streetName, string streetNumber, string zipCode, string city, string country)
	{
		StreetName = streetName;
		StreetNumber = streetNumber;
		ZipCode = zipCode;
		City = city;
		Country = country;
	}
	
	public override string ToString()
	{
		return $"StreetName={StreetName}, StreetNumber={StreetNumber}, ZipCode={ZipCode}, City={City}, Country={Country}";
	}
}
