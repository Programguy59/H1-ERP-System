using H1_ERP_System.util;

namespace H1_ERP_System.customer;

public class Person
{
	public Person(int personId, string firstName, string lastName, string email, string phoneNumber, Address address)
	{
		PersonId = personId;
		
		FirstName = firstName;
		LastName = lastName;
		FullName = FirstName + " " + LastName;

		Email = email;
		PhoneNumber = phoneNumber;

		Address = address;
	}
	
	public Person(string firstName, string lastName, string email, string phoneNumber, Address address) 
		: this(Constants.DefaultId, firstName, lastName, email, phoneNumber, address) { }
	
	public int PersonId { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string FullName { get; set; }

	public string Email { get; set; }
	public string PhoneNumber { get; set; }

	public Address Address { get; set; }

	public override string ToString()
	{
		return $"PersonId={PersonId}, FirstName={FirstName}, LastName={LastName}, Email={Email}, PhoneNumber={PhoneNumber}, Address={Address}";
	}
}
