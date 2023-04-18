using H1_ERP_System.util;

namespace H1_ERP_System.customer;

public class Person
{
	public Person(string firstName, string lastName, string email, string phoneNumber, Address address)
	{
		FirstName = firstName;
		LastName = lastName;
		FullName = FirstName + " " + LastName;

		Email = email;
		PhoneNumber = phoneNumber;

		Address = address;
	}

	public int Id { get; set; } = -1;

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string FullName { get; set; }

	public string Email { get; set; }
	public string PhoneNumber { get; set; }

	public Address Address { get; set; }

	public override string ToString()
	{
		return $"Id={Id}, FirstName={FirstName}, LastName={LastName}, Email={Email}, PhoneNumber={PhoneNumber}, Address={Address}";
	}
}
