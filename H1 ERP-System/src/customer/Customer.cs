namespace H1_ERP_System.customer;

public class Customer : Person
{
	public Customer( Person person, string dateSinceLastPurchase)
		: base(person.FirstName, person.LastName, person.Email, person.PhoneNumber, person.Address)
	{
		
		Person = person;

		DateSinceLastPurchase = dateSinceLastPurchase;
	}

	public int CustomerId { get; set; } = -1;
	public Person Person { get; }

	public string DateSinceLastPurchase { get; }
}
