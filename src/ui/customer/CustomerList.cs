using H1_ERP_System.sales;
using H1_ERP_System.util;

namespace H1_ERP_System.ui.customer;

public class CustomerList
{
	public int Id { get; init; }
	
	public string FirstName { get; init; }
	public string LastName { get; init; }
	
	public string Phone { get; init; }
	public string Email { get; init; }
	
	public Order? LastOrder { get; init; }
	
	public Address Address { get; init; }
	
	public string FormattedName => $"{FirstName} {LastName}";
	public string FormattedLastOrderDate => LastOrder == null ? "Ingen ordre!" : LastOrder.CreatedAt;
	public string FormattedAddress => $"{Address.StreetName} {Address.StreetNumber}, {Address.ZipCode} {Address.City} {Address.Country}";
	
	public CustomerList(int id, string firstName, string lastName, string phone, string email, Order? lastOrder, Address address)
	{
		Id = id;
		
		FirstName = firstName;
		LastName = lastName;
		
		Phone = phone;
		Email = email;
		
		LastOrder = lastOrder;
		Address = address;
	}
}
