namespace H1_ERP_System.util;

public class Address
{
	public Address(int id, string streetName, string streetNumber, string zipCode, string city, string country)
	{
		Id = id;
		
		StreetName = streetName;
		StreetNumber = streetNumber;

		ZipCode = zipCode;
		City = city;

		Country = country;
	}
	
	public Address(string streetName, string streetNumber, string zipCode, string city, string country) 
		: this(Constants.DefaultId, streetName, streetNumber, zipCode, city, country) { }
	
	public int Id { get; set; }

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
