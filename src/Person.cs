using H1_ERP_System.util;

namespace H1_ERP_System;

public class Person
{
	private int Id { get; }
	private string PersonFirstName { get; }
    private string PersonLastName { get; }
	private string PersonFullName { get; }



    private Address Address { get; }

	public Person(int id, string personFirstName, string personLastName, Address address, string currency)
	{
		Id = id;
		PersonFirstName = personFirstName;
        PersonLastName = personLastName;
		PersonFullName = PersonFirstName + " " + PersonLastName;


        Address = address;
		
	}
	
	public Person(int id, string personFirstName, string personLastName, string streetName, string streetNumber, string zipCode, string city, string country, string currency)
	{
		Id = id;
        PersonFirstName = personFirstName;
        PersonLastName = personLastName;
        PersonFullName = PersonFirstName + " " + personLastName;


        Address = new Address(streetName, streetNumber, zipCode, city, country);
		
	}
	
	public override string ToString()
	{
		return $"Id={Id}, PersonFirstName={PersonFirstName}, PersonLastName={PersonLastName}, Address={Address}";
	}
}
