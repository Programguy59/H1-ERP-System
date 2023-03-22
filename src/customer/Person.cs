using H1_ERP_System.util;

namespace H1_ERP_System.customer;

public class Person
{
    private int Id { get; }
    private string PersonFirstName { get; }
    private string PersonLastName { get; }
    private string PersonFullName { get; }
    private string Email { get; }
    private string PhoneNumber { get; }
    
    private Address Address { get; }

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

    public Person(int id, string personFirstName, string personLastName, string email, string phoneNumber, string streetName, string streetNumber, string zipCode, string city, string country)
    {
        Id = id;
        PersonFirstName = personFirstName;
        PersonLastName = personLastName;
        PersonFullName = PersonFirstName + " " + personLastName;
        
        Email = email;
        PhoneNumber = phoneNumber;


        Address = new Address(streetName, streetNumber, zipCode, city, country);

    }

    public override string ToString()
    {
        return $"Id={Id}, PersonFirstName={PersonFirstName}, PersonLastName={PersonLastName}, Address={Address}";
    }
}
