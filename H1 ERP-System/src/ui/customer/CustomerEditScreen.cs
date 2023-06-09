﻿using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerEditScreen : Screen
{
	private static int _selectedCustomerId;

	public CustomerEditScreen(int id)
	{
		_selectedCustomerId = id;
	}

	public override string Title { get; set; } = "Edit Customer";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);

		var customerScreenList = CustomerScreenList.GetCustomerScreenListFromId(_selectedCustomerId);

		if (customerScreenList == null)
		{
			return;
		}

		var editor = new Form<CustomerScreenList>();

		editor.TextBox("First Name", "FirstName");
		editor.TextBox("Last Name", "LastName");

		editor.TextBox("Email", "Email");
		editor.TextBox("Phone Number", "PhoneNumber");

		editor.TextBox("Street Name", "StreetName");
		editor.TextBox("Street Number", "StreetNumber");
		editor.TextBox("Zip Code", "ZipCode");
		editor.TextBox("City", "City");
		editor.TextBox("Country", "Country");


		TechCoolUtils.Clear(this);

		// Draw the editor.
		editor.Edit(customerScreenList);

		// Update the customer.
		var customer = Database.GetCustomerById(customerScreenList.Id);

		if (customer == null)
		{
			return;
		}

		var person = customer.Person;
		var address = customer.Address;

		person.FirstName = customerScreenList.FirstName;
		person.LastName = customerScreenList.LastName;

		person.Email = customerScreenList.Email;
		person.PhoneNumber = customerScreenList.PhoneNumber;

		address.StreetName = customerScreenList.StreetName;
		address.StreetNumber = customerScreenList.StreetNumber;
		address.ZipCode = customerScreenList.ZipCode;
		address.City = customerScreenList.City;
		address.Country = customerScreenList.Country;

		var lastOrder = Database.GetAllOrders().Find(o => o.Customer.CustomerId == customer.CustomerId);
		var dateSinceLastPurchase = lastOrder?.CreatedAt;

		var updatedCustomer = new Customer(customer.CustomerId, person, dateSinceLastPurchase);

		if (!DatabaseServer.UpdateCustomer(updatedCustomer))
		{
			return;
		}

		TechCoolUtils.Clear(this);

		Display(new Menu.MenuScreen());
	}
}
