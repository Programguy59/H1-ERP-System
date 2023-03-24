using H1_ERP_System.util;

namespace H1_ERP_System.customer;

public abstract class Person
{
	public Person(int id, string personFirstName, string personLastName, Address address, string email, string phoneNumber)
	{
		Id = id;
		PersonFirstName = personFirstName;
		PersonLastName = personLastName;
		PersonFullName = PersonFirstName + " " + PersonLastName;


		Address = address;
		Email = email;
		PhoneNumber = phoneNumber;
	}

	public Person(int id, string personFirstName, string personLastName, string email, string phoneNumber, string streetName, string streetNumber,
		string zipCode, string city, string country)
	{
		Id = id;
		PersonFirstName = personFirstName;
		PersonLastName = personLastName;
		PersonFullName = PersonFirstName + " " + personLastName;

		Email = email;
		PhoneNumber = phoneNumber;


		Address = new Address(streetName, streetNumber, zipCode, city, country);

	}

	public int Id { get; set; }
    public string PersonFirstName { get; set; }
    public string PersonLastName { get; set; }
    public string PersonFullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

	public Address Address { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, PersonFirstName={PersonFirstName}, PersonLastName={PersonLastName}, Address={Address}";
	}
}
