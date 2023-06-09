﻿using H1_ERP_System.util;

namespace H1_ERP_System.customer;

public class Customer : Person
{
	public Customer(int customerId, Person person, DateTime? dateSinceLastPurchase)
		: base(person.PersonId, person.FirstName, person.LastName, person.Email, person.PhoneNumber, person.Address)
	{
		CustomerId = customerId;
		Person = person;

		DateSinceLastPurchase = dateSinceLastPurchase;
	}

	public Customer(Person person, DateTime? dateSinceLastPurchase) :
		this(Constants.DefaultId, person, dateSinceLastPurchase)
	{
	}

	public int CustomerId { get; set; }
	public Person Person { get; }

	public DateTime? DateSinceLastPurchase { get; }
}
