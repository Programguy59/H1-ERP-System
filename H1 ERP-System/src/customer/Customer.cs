﻿namespace H1_ERP_System.customer;

public class Customer : Person
{
	public Customer(int customerId, Person person, string dateSinceLastPurchase)
		: base(person.Id, person.FirstName, person.LastName, person.Email, person.PhoneNumber, person.Address)
	{
		CustomerId = customerId;
		Person = person;

		DateSinceLastPurchase = dateSinceLastPurchase;
	}

	public int CustomerId { get; set; }
	public Person Person { get; }

	public string DateSinceLastPurchase { get; }
}