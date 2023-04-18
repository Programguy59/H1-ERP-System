namespace H1_ERP_System.util;

public class Address
{
	public Address(string streetName, string streetNumber, string zipCode, string city, string country)
	{
		StreetName = streetName;
		StreetNumber = streetNumber;

		ZipCode = zipCode;
		City = city;

		Country = country;
	}

	public int Id { get; set; } = -1;

    public string StreetName { get; set; }
	public string StreetNumber { get; set; }
	public string ZipCode { get; set; }
	public string City { get; set; }
	public string Country { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, StreetName={StreetName}, StreetNumber={StreetNumber}, ZipCode={ZipCode}, City={City}, Country={Country}";
	}
}
