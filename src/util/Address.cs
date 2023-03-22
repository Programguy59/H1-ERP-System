namespace H1_ERP_System.util;

public class Address
{
	public string StreetName { get; set; }
	public string StreetNumber { get; set; }
	public string ZipCode { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
	
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
