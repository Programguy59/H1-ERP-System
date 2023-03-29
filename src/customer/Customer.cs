namespace H1_ERP_System.customer;

public class Customer : Person
{
    private int CustomerId { get; }
    private Person Person { get; }
        
    private string DateSinceLastPurchase { get; }

    public Customer(int customerId, Person person, string dateSinceLastPurchase) 
           : base(person.Id, person.FirstName, person.LastName, person.Email, person.PhoneNumber, person.Address)
    {
        CustomerId = customerId;
        Person = person;
        
        DateSinceLastPurchase = dateSinceLastPurchase;
    }
}
